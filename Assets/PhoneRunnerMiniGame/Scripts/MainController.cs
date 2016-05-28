using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

    public static float ICON_SPAWN_POSX = 20f;
    private float lastPhoneSpawnTime;
    private float lastCoinSpawnTime;
    private float lastObstacleSpawnTime;
    public PhoneIcon phoneIcon;
    public CoinIcon coinIcon;
    public static float BOX_SPAWN_POSX = 12f;
    public static float BOX_SPAWN_POSY = -2.56f;
    public Obstacle obstacle;
    // Use this for initialization
    void Start()
    {
        lastPhoneSpawnTime = Time.time;
        lastObstacleSpawnTime = lastPhoneSpawnTime;
        lastCoinSpawnTime = lastPhoneSpawnTime;

    }

    // Update is called once per frame
    void Update()
    {
        float current_time = Time.time;

        if (current_time - lastCoinSpawnTime > 1.0)
        {
            //height and width of camera - used to determine where to spawn food
            float camHeight = Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;

            //gets a random location relative to camera boundaries
            Vector3 spawn_loc_vector = new Vector3(Random.Range(15, 19), Random.Range(-1, 2));
            CoinIcon newIcon = (CoinIcon)GameObject.Instantiate(coinIcon, spawn_loc_vector, new Quaternion());
            newIcon.initialize(this);
            lastCoinSpawnTime = Time.time;
        }

        if (current_time - lastPhoneSpawnTime > 1.5)
        {
            //height and width of camera - used to determine where to spawn food
            float camHeight = Camera.main.orthographicSize;
            float camWidth = camHeight * Camera.main.aspect;

            //gets a random location relative to camera boundaries
            Vector3 spawn_loc_vector = new Vector3(Random.Range(15, 19), Random.Range(-1, 2));
            PhoneIcon newIcon = (PhoneIcon)GameObject.Instantiate(phoneIcon, spawn_loc_vector, new Quaternion());
            newIcon.initialize(this);
            lastPhoneSpawnTime = Time.time;
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

    public void removePhoneIcon(PhoneIcon removeMe)
    {
        GameObject.Destroy(removeMe.gameObject);
    }

    public void removeCoinIcon(CoinIcon removeMe)
    {
        GameObject.Destroy(removeMe.gameObject);
    }

    public void removeObstacle(Obstacle removeMe)
    {
        GameObject.Destroy(removeMe.gameObject);
    }
}
