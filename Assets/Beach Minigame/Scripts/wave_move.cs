using UnityEngine;
using System.Collections;

public class wave_move : MonoBehaviour
{

    //speed that the tile is scrolling
    private float waveSpeed;

    //start position, for calculating scroll position
    private Vector3 startPosition;

    //next position track should move to, for scrolling
    private bool moveDown;
    private Vector2 nextPosition;
    private Vector2 lastPosition;

    Timer waveTimer;
    System.Diagnostics.Stopwatch waveStopwatch;

    // Use this for initialization
    void Start()
    {

        //sets the start position
        startPosition = transform.position;

        //sets other variables
        waveSpeed = 1.0f;
        moveDown = true;
        waveTimer = new Timer();
        waveStopwatch = new System.Diagnostics.Stopwatch();
        waveStopwatch.Start();
        lastPosition = new Vector2(startPosition.x, startPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        moveWave();
    }

    void OnMouseDown()
    {
        Debug.Log("Animal Mouse Down!");
        Destroy(this.gameObject);
    }

    public void moveWave()
    {
        float waveHorizontalProgress = waveTimer.getElapsedTime();
        nextPosition.x = Mathf.Repeat(waveHorizontalProgress, getWaveWidth() * 2);
        if (moveDown)
        {
            float waveVerticalProgress = (float)waveStopwatch.Elapsed.TotalSeconds / 4;
            nextPosition.y = Mathf.Repeat(waveVerticalProgress, getWaveHeight());
        }
        else
        {
            nextPosition.y = lastPosition.y;
        }
        transform.position = startPosition + (Vector3.right * nextPosition.x) + (Vector3.down * nextPosition.y);
        lastPosition = nextPosition;
    }

    public void stopWave()
    {
        moveDown = false;
        waveStopwatch.Stop();
    }

    public void startWave()
    {
        moveDown = true;
        waveStopwatch.Start();
    }

    public void updateWaveSpeed(float waveSpeed)
    {
        this.waveSpeed = waveSpeed;
    }

    public float getWaveWidth()
    {
        //gets the wave size according to the sprite renderer bounds
        return this.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public float getWaveHeight()
    {
        //gets the wave size according to the sprite renderer bounds
        return this.GetComponent<SpriteRenderer>().bounds.size.y;
    }
}
