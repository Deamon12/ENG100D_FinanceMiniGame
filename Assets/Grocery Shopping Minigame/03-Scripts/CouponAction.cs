using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CouponAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /**
     *
     *
     */
    void OnMouseDown()
    {
        GameController.getCouponList().printCouponList();

        Debug.Log("Coupon Clicked : " + this);

        if(this.name == "product_coupon_1")
        {
            GameController.couponList.selectCoupon(0);
        }
        else if (this.name == "product_coupon_2")
        {
            GameController.couponList.selectCoupon(1);
        }
        else if (this.name == "product_coupon_3")
        {
            GameController.couponList.selectCoupon(2);
        }
        else if (this.name == "product_coupon_4")
        {
            GameController.couponList.selectCoupon(3);
        }


        GameController.couponList.destroyCouponList();


        //Close Coupon List UI
        Button exitButton = GameObject.Find("GUI").transform.FindChild("ExitButton").GetComponent<Button>();
        exitButton.gameObject.SetActive(false);
        RectTransform CouponList = GameObject.Find("GUI").transform.FindChild("CouponList").GetComponent<RectTransform>();
        CouponList.gameObject.SetActive(false);


        //Generate new coupon list
        GameController.couponList.makeCouponList();

    }


}
