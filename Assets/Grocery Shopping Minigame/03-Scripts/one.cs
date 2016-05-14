using UnityEngine;
using System.Collections;

public class one : MonoBehaviour {
    public static int value = 1;

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
    }
}
