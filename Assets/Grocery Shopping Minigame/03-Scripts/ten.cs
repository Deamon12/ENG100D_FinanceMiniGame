using UnityEngine;
using System.Collections;


public class ten : MonoBehaviour {
    public static int value = 10;
    // Use this for initialization
    void Start () {
        transform.Rotate(Vector3.forward * -90);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void onClick()
    {
        RemainingMoney.moneyP = RemainingMoney.moneyP + value;
    }
}
