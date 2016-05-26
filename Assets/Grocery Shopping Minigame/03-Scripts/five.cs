using UnityEngine;
using System.Collections;

//part of Cashier game
public class five : MonoBehaviour {
    public static int value = 5;   //this is the value of the $5 bill

    // Use this for initialization
    void Start()
    {
        transform.Rotate(Vector3.forward * 90);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Link the onClick method to the onClick() list in the twentybutton
    public void onClick()
    {
		//increment moneyP by the 
        RemainingMoney.moneyP = RemainingMoney.moneyP + value;
    }
}
