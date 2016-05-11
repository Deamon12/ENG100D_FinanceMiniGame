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
     * Description : If Coupon is clicked, This will be called.
     *              This function update the selected coupon, and close the coupon list window.
     *
     */
    void OnMouseDown()
    {
        //Debug purpose
        //GameController.getCouponList().printCouponList();

        //The followin code update selected coupon based on user selection.
        //Case : If user selected first coupon
        if(this.name == "product_coupon_1")
        {
            GameController.couponList.selectCoupon(0);
        }
        //Case : If user selected second coupon
        else if (this.name == "product_coupon_2")
        {
            GameController.couponList.selectCoupon(1);
        }
        //Case : If user selected third coupon
        else if (this.name == "product_coupon_3")
        {
            GameController.couponList.selectCoupon(2);
        }
        //Case : If user selected fourth coupon
        else if (this.name == "product_coupon_4")
        {
            GameController.couponList.selectCoupon(3);
        }


        //Before close, delete all the child of coupon
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
