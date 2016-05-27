using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

    public static float ICON_SPAWN_POSX = 20f;
    private float last_spawn_time;
    public Icon icon;
    public static float BOX_SPAWN_POSX = 12f;
    public static float BOX_SPAWN_POSY = -2.56f;
    private float lastObstacleSpawnTime;
    public Obstacle obstacle;
    // Use this for initialization
    void Start()
    {
        last_spawn_time = Time.time;
        lastObstacleSpawnTime = last_spawn_time;

    }

    // Update is called once per frame
    void Update()
    {
        float current_time = Time.time;
        if (current_time - last_spawn_time > 1.5)
        {
            //height and width of camera - used to determine where to spawn food
            float camHeight = Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;

            //gets a random location relative to camera boundaries
            Vector3 spawn_loc_vector = new Vector3(Random.Range(15, 19), Random.Range(-1, 2));
            Icon newIcon = (Icon)GameObject.Instantiate(icon, spawn_loc_vector, new Quaternion());
            newIcon.initialize(this);
            last_spawn_time = Time.time;
        }

        if (current_time - lastObstacleSpawnTime > 2)
        {
            //height and width of camera - used to determine where to spawn food
            float camHeight = Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;

            //gets a random location relative to camera boundaries
            Vector3 spawn_loc_vector = new Vector3(BOX_SPAWN_POSX, Random.Range(-4, -2));
            Obstacle newObstacle = (Obstacle)GameObject.Instantiate(obstacle, spawn_loc_vector, new Quaternion());
            newObstacle.initialize(this);
            lastObstacleSpawnTime = Time.time;
        }
    }

    public void removeIcon(Icon removeMe)
    {
        GameObject.Destroy(removeMe.gameObject);
    }

    public void removeObstacle(Obstacle removeMe)
    {
        GameObject.Destroy(removeMe.gameObject);
    }
}
