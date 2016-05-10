using UnityEngine;
using System.Collections;

public class CouponController : MonoBehaviour {
    GameObject exitButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 
	
	}

    public void activate()
    {
        Debug.Log("Clicked");
        this.gameObject.SetActive(true);
    }

    public void deactivate()
    {
        exitButton = GameObject.Find("ExitButton");
        exitButton.SetActive(false);
        Debug.Log("Deactivate Clicked");
        this.gameObject.SetActive(false);

    }
}
