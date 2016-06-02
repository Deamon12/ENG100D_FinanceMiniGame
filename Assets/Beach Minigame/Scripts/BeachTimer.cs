using UnityEngine;
using System.Collections;

public class BeachTimer : MonoBehaviour {

    private Timer t;

    private float fps = 60;
    private float interval = 1; //unnecessary at 1, but can be changed for slower update rate
    private float count = 0;

    private float timer_width = 10f;
    private float timer_height = .5f;

    private Vector3 timer_position = new Vector3(.8f, 4.3f, 0.0f);

    private float round_time;
    private float time_rem;

    private bool toggle = true; //unnecessary additional control with current model
    private bool endLevel = false;

    public BeachTimer() {
        round_time = 10f;
        time_rem = round_time;
        Start();
    }

    public BeachTimer(float time) {
        round_time = time;
        time_rem = round_time;
        Start();
    }

    // Use this for initialization
    // When making a real class, move this into instantiation of BeachTimer ^^
    public void Start() {
        t = new Timer();
        t.reset();

        this.transform.position = timer_position;
        timer_width = 10f;

        this.transform.localScale = new Vector3(timer_width, timer_width, timer_height);
    }

    // Update is called once per frame
    // CreatorClass should call our Update on their update -- checking for endLevel.
    public void Update() {
        //every interval
        if (toggle)
        {
            if (count > interval)
            {
                float elapsed = t.getElapsedTime();

                if (time_rem > 0)
                {
                    //animate based off elapsed time
                    animateTimer(elapsed);

                    //update time_remaining
                    time_rem -= elapsed;
                }
                else
                {
                    //Time is over.  Boom.
                    endLevel = true;
                    resetTimer(20f);
                    this.resume();
                }


                t.reset();
                count = 0;
            }
            count++;
        }
    }


    private void animateTimer(float elapsed) {

        float percentElapsed = elapsed / round_time;
        float decrement = timer_width * percentElapsed * GlobalVariables.speedScale;

        //transform timer by % time elapsed
        this.transform.localScale -= new Vector3(decrement, decrement, 0);

        //update position to account for scale size
        Vector3 v = this.transform.position;
        v.x += decrement * 1;
        this.transform.position = v;

        //Debug.Log(time_rem);
    }

    public void resetTimer(float time) {
        round_time = time;
        time_rem = round_time;

        toggle = false;
        Start();
    }

    //unused optimization since we're creating a new timer everytime/each scene.
    public void pause() {
        toggle = false;
    }

    public void resume()
    {
        toggle = true;
    }

    public bool getEndLevel() {
        return endLevel;
    }
}
