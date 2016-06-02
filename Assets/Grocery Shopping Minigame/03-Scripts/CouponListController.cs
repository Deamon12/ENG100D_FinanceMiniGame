using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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

		public List<Coupon> coupons = new List<Coupon>();

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
		public void makeCouponList(int[] productIDs)
        {
			int numProducts = productIDs.Length;
            for(int i = 0; i < 4; i++) {
				Debug.Log ("Creating new coupon list!");
				//BOGO, Buy One Get Two, Buy A get one B
				int prodA = productIDs[Random.Range(0, numProducts-1)];
				int brandA = Random.Range (0, 3);

				int prodB = productIDs[Random.Range(0, numProducts-1)];
				int brandB = Random.Range (0, 3);

				int couponType = Random.Range(0, 3);
				Debug.Log ("Coupon Type: " + couponType);
				if (couponType == 0) {
					//BOGO
					coupons.Add(new BOGOCoupon(prodA, brandA));
				} else if (couponType == 1) {
					//BOG2
					coupons.Add(new BuyOneGetTwoCoupon(prodA, brandA));
				} else if (couponType == 2) {
					//BAGB
					coupons.Add(new BuyOneAGetOneBCoupon(prodA, prodB, brandA, brandB));
				}
            }
        }

        //Debug purpose
        public void printCouponList()
        {
            
           /*for(int i = 0; i < 4; i++)
            {
                Debug.Log(i+"th Coupon : " + couponList[i][0] + ", " + couponList[i][1]  );
            }
            Debug.Log("Selected Coupon : " + couponList[4][0] + ", " + couponList[4][1] );*/
        }


        /**
         * @name : selectCoupon
         * @param : The coupon which is selected by the user.
         * Description : This function update selected coupon field to the coupon which
         * the user selected.
         */
        public void selectCoupon(int couponId)
        {
//			Debug.Log ("Selected coupon: " + couponId);
//            couponList[4][0] = couponList[couponId][0];
//            couponList[4][1] = couponList[couponId][1];
//            //couponList[4][2] = couponList[couponId][2];

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

	public static int getFinalPrice(List<GameController.ProductSelection> selectedProducts) {
		int[] prices = new int[selectedProducts.Count];
		int[] products = new int[selectedProducts.Count];
		int[] brands = new int[selectedProducts.Count];

		for (int currIndex = 0; currIndex < selectedProducts.Count; currIndex++) {
			GameController.ProductSelection selection = selectedProducts[currIndex];
			prices [currIndex] = selection.productModel.getPriceForIndex (selection.brandID);
			products [currIndex] = selection.productModel.getProductID ();
			brands [currIndex] = selection.brandID;
		}

		for (int currIndex = 0; currIndex < GameController.couponList.coupons.Count; currIndex++) {
			int tempTotal = 0;
			foreach (int currPrice in prices) {
				tempTotal += currPrice;
			}
			Debug.Log ("Price is now: " + tempTotal);

			prices = GameController.couponList.coupons[currIndex].applyCoupon (prices, brands, products);
		}

		int total = 0;
		foreach (int currPrice in prices) {
			total += currPrice;
		}
		return total;
	}
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
        for(int i = 0; i < 4; i++) {
			int prod1 = -1;
			int prod2 = -1;
			int brand1 = -1;
			int brand2 = -1;
			Coupon currCoupon = GameController.couponList.coupons [i];
			switch (currCoupon.getCouponType ()) {
			case Coupon.Type.BAGB:
				prod1 = ((MultiProductCoupon)currCoupon).getProductA();
				prod2 = ((MultiProductCoupon)currCoupon).getProductB();
				brand1 = ((MultiProductCoupon)currCoupon).getBrandA();
				brand2 = ((MultiProductCoupon)currCoupon).getBrandB();
				break;
			case Coupon.Type.BOGO:
				prod1 = ((SingleProductCoupon)currCoupon).getProductID();
				prod2 = ((SingleProductCoupon)currCoupon).getProductID();
				brand1 = ((SingleProductCoupon)currCoupon).getBrandID();
				brand2 = ((SingleProductCoupon)currCoupon).getBrandID();
				break;
			case Coupon.Type.BOGT:
				prod1 = ((SingleProductCoupon)currCoupon).getProductID();
				prod2 = ((SingleProductCoupon)currCoupon).getProductID();
				brand1 = ((SingleProductCoupon)currCoupon).getBrandID();
				brand2 = ((SingleProductCoupon)currCoupon).getBrandID();
				break;
			}
			genTwoCoupon(prod1, prod2, brand1, brand2, i);
        }

    }

    //Draw coupon with two prod
	public void genTwoCoupon(int prod1, int prod2, int brand1, int brand2, int location)
    {
		Debug.Log ("Prod 1: " + prod1 + " Prod 2: " + prod2 + " Brand 1: " + brand1 + " Brand 2: " + brand2); 
        //Left product
        GameObject instaniatedProd = (GameObject)Instantiate(products[prod1], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
		instaniatedProd.GetComponent<Renderer> ().material = generateTintMaterial((ProductOfferingModel.TintColor)brand1);
        RectTransform item;
		instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_" + (location + 1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition = new Vector3(-1, 0, 0); ;
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

        //right product
		instaniatedProd = (GameObject)Instantiate(products[prod2], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
		instaniatedProd.GetComponent<Renderer> ().material = generateTintMaterial((ProductOfferingModel.TintColor)brand1);
		instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_" + (location + 1)).transform, false);
        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
        item = instaniatedProd.GetComponent<RectTransform>();
        item.localPosition = new Vector3(1, 0, 0);
        item.localScale = new Vector3(0.7f, 0.7f, 0);
        Destroy(item.GetComponent<Rigidbody2D>());

    }
		
	private Material generateTintMaterial(ProductOfferingModel.TintColor tintColor) {
		Color tint = new Color (0, 0, 0, 1); //default to white
		switch (tintColor) {
		case ProductOfferingModel.TintColor.Red:
			tint = new Color(1,0,0,1);
			break;

		case ProductOfferingModel.TintColor.Green:
			tint = new Color(0,1,0,1);
			break;

		case ProductOfferingModel.TintColor.Blue:
			tint = new Color(0,0,1,1);
			break;
		}

		Material newMaterial = new Material(Shader.Find("Sprites/Default"));
		newMaterial.color = tint;
		return newMaterial;
	}

//    //Draw coupon with three prod
//    public void genThreeCoupon(int couponId)
//    {
//        //left product
//        GameObject instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
//        RectTransform item;
//        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_"+(couponId+1)).transform, false);
//        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
//        item = instaniatedProd.GetComponent<RectTransform>();
//        item.localPosition = new Vector3(-1, 0, 0); ;
//        item.localScale = new Vector3(0.7f, 0.7f, 0);
//        Destroy(item.GetComponent<Rigidbody2D>());
//
//        //middle product
//        instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
//        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_"+(couponId + 1)).transform, false);
//        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
//        item = instaniatedProd.GetComponent<RectTransform>();
//        item.localPosition =  new Vector3(0, 0, 0);
//        item.localScale = new Vector3(0.7f, 0.7f, 0);
//        Destroy(item.GetComponent<Rigidbody2D>());
//
//        //right product
//        instaniatedProd = (GameObject)Instantiate(products[GameController.couponList.getCouponListVal(couponId, 0)], new Vector3(-2.2f, 0.78f, -2), new Quaternion());
//        instaniatedProd.transform.SetParent(GameObject.Find("GUI").transform.FindChild("CouponList/product_coupon_"+(couponId + 1)).transform, false);
//        instaniatedProd.GetComponent<Renderer>().sortingOrder = 5;
//        item = instaniatedProd.GetComponent<RectTransform>();
//        item.localPosition =  new Vector3(1, 0, 0);
//        item.localScale = new Vector3(0.7f, 0.7f, 0);
//        Destroy(item.GetComponent<Rigidbody2D>());
//
//    }

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
