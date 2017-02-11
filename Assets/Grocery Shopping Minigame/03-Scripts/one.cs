using UnityEngine;
using System.Collections;

//part of Cashier game
public class one : MonoBehaviour {
	public static int NumberOfOnesUsed = 0;
    public static int value = 1;     //this is the dollar bill value

    // Use this for initialization
    void Start()
    {
        transform.Rotate(Vector3.forward * 60);

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Link the onClick method to the onClick() list in the twentybutton
    public void onClick()
    {
        RemainingMoney.moneyP = RemainingMoney.moneyP + value;

		NumberOfOnesUsed += 1;
    }
}
