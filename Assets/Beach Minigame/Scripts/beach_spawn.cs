using UnityEngine;
using System.Collections;

public class beach_spawn : MonoBehaviour {
    public GameObject[] trash;
    public GameObject[] animal;

    public Vector2 xrange;
    public Vector2 yrange;

    static public int numTrash;
    // Use this for initialization
    void Start () {
        numTrash = 0;
        spawnTrash();
    }

    void spawnTrash() {
        //height and width of camera - used to determine where to spawn food
        float camHeight = Camera.main.orthographicSize;
        float camWidth = camHeight * Camera.main.aspect;
        
        // Spawn random trash
        for (int i = 0; i < 5; ++i) {
            float xPos = Random.Range(xrange.x, xrange.y);
            float yPos = Random.Range(yrange.x, yrange.y);

            Debug.Log(yPos);

            //gets a random location relative to camera boundaries
            Vector3 randomLoc = MyRandom.Location2D(Camera.main.transform.position, camWidth, camHeight);
            //changes depth of new location to ensure spawned food will be visible and above track
            randomLoc.z = 0;
            int ranInt = Random.Range(0, trash.Length);
            GameObject randObj = (GameObject) GameObject.Instantiate(trash[ranInt], randomLoc, new Quaternion());
            randObj.transform.parent = this.gameObject.transform;
            numTrash++;
        }

        // Spawn random animals
        for (int i = 0; i < numTrash/4; ++i) {
            //gets a random location relative to camera boundaries
            Vector3 randomLoc = MyRandom.Location2D(Camera.main.transform.position, camWidth, camHeight);
            //changes depth of new location to ensure spawned food will be visible and above track
            randomLoc.z = 0;
            int ranInt = Random.Range(0, animal.Length);
            GameObject randObj = (GameObject)GameObject.Instantiate(animal[ranInt], randomLoc, new Quaternion());
            randObj.transform.parent = this.gameObject.transform;
        }
    }
}
