using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CouponListController : MonoBehaviour {
    public GameObject[] products;

    public class CouponList
    {
        //Coupon List               productid   FreeAmount(quantity)
        //First coupon      [0]     [0][0]      [0][1]         
        //Second coupon     [1]
        //Third coupon      [2]
        //Forth coupon      [3]
        //Selected coupon   [4]
        private int[][] couponList = null;


        //number of product categories
        const int numOfProdCategory = 10;
        const int maxCouponProd = 3;

        //Accessor function for coupon list
        public int getCouponListVal(int couponId, int optionId)
        {
            return couponList[couponId][optionId];
        }
        //Mutator function for coupon list
        public void setCouponListVal(int couponId, int optionId, int val)
        {
            couponList[couponId][optionId] = val;
        }
        //constructor
        public CouponList()
        {
            //1~4 is Current Coupon on the screen, 5th is coupon that user selected
            couponList = new int[5][];
            for(int i = 0; i < 5; i++)
            {
                //first element : prod id
                //second element : number of product for coupon
                couponList[i] = new int[2];
            }
        }

        /**
         * @name : makeCouponList
         * Description : This function generate random coupon list.
         */
        public void makeCouponList()
        {
            for(int i = 0; i < 4; i++)
            {
                //Setting What product will be used for coupon.
                couponList[i][0] = Random.Range(0, numOfProdCategory+1);
                couponList[i][1] = Random.Range(2, maxCouponProd+1);
            }
        }

        //Debug purpose
        public void printCouponList()
        {
            for(int i = 0; i < 4; i++)
            {
                Debug.Log(i+"th Coupon : " + couponList[i][0] + ", " + couponList[i][1] + ", " + couponList[i][2]);
            }
            Debug.Log("Selected Coupon : " + couponList[4][0] + ", " + couponList[4][1] + ", " + couponList[4][2]);
        }


        /**
         * @name : selectCoupon
         * @param : The coupon which is selected by the user.
         * Description : This function update selected coupon field to the coupon which
         * the user selected.
         */
        public void selectCoupon(int couponId)
        {
            couponList[4][0] = couponList[couponId][0];
            couponList[4][1] = couponList[couponId][1];
            couponList[4][2] = couponList[couponId][2];

        }


        /**
         * @name : destroyCouponList
         * Description : This function destroy all the child object(product) of coupon.
         */
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
    
    //Exit button for Coupon List
    Button exitButton;

    /**
     * @name : activate
     * Description : This functio draw Coupon list.
     */
    public void activate()
    {
        //Before draw, reset coupon list
        GameController.couponList.destroyCouponList();

        //Draw Exit button
        exitButton = GameObject.Find("GUI").transform.FindChild("ExitButton").GetComponent<Button>();
        exitButton.gameObject.SetActive(true);

        this.gameObject.SetActive(true);

        //Draw Coupon based on Coupon list
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
        //Left product
        GameObject instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
        RectTransform item;
        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_" + (couponId + 1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition = new Vector3(-1, 0, 0); ;
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

        //right product
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
        //left product
        GameObject instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
        RectTransform item;
        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_"+(couponId+1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition = new Vector3(-1, 0, 0); ;
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

        //middle product
        instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_"+(couponId + 1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition =  new Vector3(0, 0, 0);
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

        //right product
        instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_"+(couponId + 1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition =  new Vector3(1, 0, 0);
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

    }

    //This function remove coupon list
    public void deactivate()
    {
        exitButton = GameObject.Find("GUI").transform.FindChild("ExitButton").GetComponent<Button>();
        exitButton.gameObject.SetActive(false);
        
        this.gameObject.SetActive(false);
    }






    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () { 
	
	}


}
