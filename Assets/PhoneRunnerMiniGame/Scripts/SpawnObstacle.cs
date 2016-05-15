using UnityEngine;
using System.Collections;

public class SpawnObstacle : MonoBehaviour {

    public static float BOX_SPAWN_POSX = 11.49f;
    public static float BOX_SPAWN_POSY = -2.56f;
    private float last_spawn_time;
    public Obstacle obstacle;
	// Use this for initialization
	void Start () {
        last_spawn_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float current_time = Time.time;
        if(current_time - last_spawn_time > 1)
        {
            //height and width of camera - used to determine where to spawn food
            float camHeight = Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;

            //gets a random location relative to camera boundaries
            Vector3 spawn_loc_vector = new Vector3(BOX_SPAWN_POSX, BOX_SPAWN_POSY);
            Obstacle newObstacle = (Obstacle)GameObject.Instantiate(obstacle, spawn_loc_vector, new Quaternion());
            newObstacle.initialize(this);
            last_spawn_time = Time.time;
        }
    }

    public void removeObstacle(Obstacle removeMe)
    {
        GameObject.Destroy(removeMe.gameObject);
    }
}
