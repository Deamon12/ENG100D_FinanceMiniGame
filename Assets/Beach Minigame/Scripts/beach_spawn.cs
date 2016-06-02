using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class beach_spawn : MonoBehaviour {
    public GameObject[] trash;
    public GameObject[] animal;
    
    public Vector2 xrange;
    public Vector2 yrange;

    private List<trash_click> trashList;
    private bool complete_trash;

    BeachTimer t;

    private RectTransform objectRectTransform;

    static public int numTrash;
    static public int heartsLeft;
    // Use this for initialization
    void Start () {
        objectRectTransform = gameObject.GetComponent<RectTransform>();
        t = GameObject.FindGameObjectWithTag("beach_timer").GetComponent<BeachTimer>();
        t.resetTimer(20f); //get level persistant level data?
        t.resume();

        numTrash = 0;
        trashList = new List<trash_click>();
        spawnTrash();
        heartsLeft = 3;
        // Trash is not visible
        complete_trash = false;
    }

    void Update() {
        checkTrash();
        t.Update();
    }

    void checkTrash() {
        if (!complete_trash) {
            foreach (trash_click trash in trashList) {
                if (!trash.locked) {
                    return;
                }
            }
            foreach (trash_click trash in trashList) {
                trash.GetComponent<SpriteRenderer>().enabled = true;
                
            }
        }
    }

    void spawnTrash() {
        // Height and width of camera - used to determine where to spawn
        float canvasHeight = objectRectTransform.rect.height;
        float canvasWidth = objectRectTransform.rect.width;

        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;
        
        // Spawn random trash
        for (int i = 0; i < 5; ++i) {
            float xPos = Random.Range(xrange.x, xrange.y);
            float yPos = Random.Range(yrange.x, yrange.y);
            int ranInt = Random.Range(0, trash.Length);

            //gets a random location relative to camera boundaries
            float newLocY   = Random.Range(Camera.main.transform.position.y - trash[ranInt].GetComponent<SpriteRenderer>().bounds.size.y, Camera.main.transform.position.y - camHeight);
            float newLocX = Random.Range(Camera.main.transform.position.x - camWidth, Camera.main.transform.position.x + camWidth);

            trash[ranInt].GetComponent<SpriteRenderer>().enabled = false;
            Vector3 randomLoc = MyRandom.Location2D(gameObject.GetComponent<Canvas>().transform.position, 5, 2);

            GameObject randObj = (GameObject) GameObject.Instantiate(trash[ranInt], randomLoc, new Quaternion());
            randObj.transform.parent = this.gameObject.transform;
            numTrash++;
            trashList.Add(randObj.GetComponent<trash_click>());
        }

        // Spawn random animals
        for (int i = 0; i < numTrash / 4; ++i) {
            //gets a random location relative to camera boundaries
            Vector3 randomLoc = MyRandom.Location2D(gameObject.GetComponent<Canvas>().transform.position, 5, 2);
            //changes depth of new location to ensure spawned food will be visible and above track
            randomLoc.z = 0;
            int ranInt = Random.Range(0, animal.Length);
            GameObject randObj = (GameObject)GameObject.Instantiate(animal[ranInt], randomLoc, new Quaternion());
            randObj.transform.parent = this.gameObject.transform;
        }
    }
}
