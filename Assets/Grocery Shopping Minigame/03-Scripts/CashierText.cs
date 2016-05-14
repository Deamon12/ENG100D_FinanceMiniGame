using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CashierText : MonoBehaviour {
    public Text cashierText;
    public static int totalPrice;
	// Use this for initialization
	void Start () {
        cashierText = GetComponent<Text>();
        totalPrice = 10;
    }
	
	// Update is called once per frame
	void Update () {
        cashierText.text = "Total Price: $" + totalPrice;
    }
}
