using UnityEngine;
using System.Collections;

public class GrabIcon : MonoBehaviour {

    public PhoneIconScore phoneScore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Icon myIcon = other.gameObject.GetComponent<Icon>();

        if (myIcon)
        {
            float value = myIcon.value;
            GameObject.Destroy(other.gameObject);
            Debug.Log("Got the coin, value being " + value);
            phoneScore.addScore(value);

        }
    }
}
