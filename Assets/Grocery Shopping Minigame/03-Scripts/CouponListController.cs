using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CouponListController : MonoBehaviour {
    public GameObject[] products;

    public class CouponList
    {

         private int[][] couponList = null;


        //number of product categories
        const int numOfProdCategory = 10;
        const int maxCouponProd = 3;

         public int getCouponListVal(int couponId, int optionId)
        {
            return couponList[couponId][optionId];
        }
         public void setCouponListVal(int couponId, int optionId, int val)
        {
            couponList[couponId][optionId] = val;
        }
        public CouponList()
        {
            //1~4 is Current Coupon on the screen, 5th is coupon that user selected
            couponList = new int[5][];
            for(int i = 0; i < 5; i++)
            {
                //first element : prod id
                //second element : number of product for coupon
                //third element : check the coupon is activated or not
                couponList[i] = new int[3];
            }
        }

        public void makeCouponList()
        {
            for(int i = 0; i < 4; i++)
            {
                //Setting What product will be used for coupon.
                couponList[i][0] = Random.Range(0, numOfProdCategory+1);
                couponList[i][1] = Random.Range(2, maxCouponProd+1);
                couponList[i][2] = 0; //1 for activated coupon and 0 for de-activated coupon
            }
        }

        public void printCouponList()
        {
            for(int i = 0; i < 4; i++)
            {
                Debug.Log(i+"th Coupon : " + couponList[i][0] + ", " + couponList[i][1] + ", " + couponList[i][2]);
            }
            Debug.Log("Selected Coupon : " + couponList[4][0] + ", " + couponList[4][1] + ", " + couponList[4][2]);
        }


        public void selectCoupon(int couponId)
        {
            couponList[4][0] = couponList[couponId][0];
            couponList[4][1] = couponList[couponId][1];
            couponList[4][2] = couponList[couponId][2];

        }

        public void destroyCouponList()
        {
            for (int i = 0; i < 4; i++)
            {
                Transform coupon = GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_" + (i + 1));//.GetComponent<GameObject>();
                int childs = coupon.transform.childCount;
                //Debug.Log("num:" + coupon);
                for (int j = 0; j < childs; j++)
                {
                    GameObject.Destroy(coupon.GetChild(j).gameObject);
                }
            }
        }


    }
    

    Button exitButton;
    public void activate()
    {
        GameController.couponList.destroyCouponList();

        exitButton = GameObject.Find("GUI").transform.FindChild("ExitButton").GetComponent<Button>();
        exitButton.gameObject.SetActive(true);
        Debug.Log("Clicked");

        this.gameObject.SetActive(true);

        //Generate Coupon
        //FirstCoupon - Left top
        for(int i = 0; i < 4; i++)
        {
            if (GameController.couponList.getCouponListVal(i, 1) == 2)
            {
                genTwoCoupon(i);
            }
            else
            {
                genThreeCoupon(i);
            }
        }

    }

    //Draw coupon with two prod
    public void genTwoCoupon(int couponId)
    {
        GameObject instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
        RectTransform item;
        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_" + (couponId + 1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition = new Vector3(-1, 0, 0); ;
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

        instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_" + (couponId + 1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition = new Vector3(1, 0, 0);
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

    }

    //Draw coupon with three prod
    public void genThreeCoupon(int couponId)
    {
        GameObject instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
        RectTransform item;
        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_"+(couponId+1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition = new Vector3(-1, 0, 0); ;
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

        instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_"+(couponId + 1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition =  new Vector3(0, 0, 0);
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

        instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_"+(couponId + 1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition =  new Vector3(1, 0, 0);
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

    }

    public void deactivate()
    {
        exitButton = GameObject.Find("GUI").transform.FindChild("ExitButton").GetComponent<Button>();
        exitButton.gameObject.SetActive(false);
        Debug.Log("Deactivate Clicked");
        this.gameObject.SetActive(false);
    }






    // Use this for initialization
    void Start () {
        Debug.Log("Coupon Controller Entered!");
	}
	
	// Update is called once per frame
	void Update () { 
	
	}


}
