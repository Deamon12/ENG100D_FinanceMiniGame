﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //list used to quickly get the correct price for each item:
    public int[] priceArr = { 2, 4, 5, 1, 5, 5, 1, 1, 2, 5, 3, 3, 2, 3, 4, 3, 2, 5, 3, 2, 4, 4, 1, 5 };

    //Global variable for the cash the user will have to pay
    public static int need_to_pay;

    //Global points variables
    public static int goodPoints;
    public static int badPoints;

    //When user swipe the product, this value will detect that the user buy the product or not.
    static private bool isCart = false;

    //False for no product on the screen
    static private bool currProductExist = false;

    //Grocery List
    private ListController.List list;
    public GameObject[] products;

    //Coupon List
    static public CouponListController.CouponList couponList;


    //This will trace the index of current product
    private int currentProduct;

    //Item from Grocery List
    public GameObject firstItem;
    public GameObject secondItem;
    public GameObject thirdItem;

    //Number of Item from Grocery List
    private Text numOfFirstItem = null;
    private Text numOfSecondItem = null;
    private Text numOfThirdItem = null;

    //Animation
    public GameObject goodSignObj;
    public GameObject badSignObj;

    //Mutator Function
    public int getCurrentProduct()
    {
        return currentProduct;
    }

    static public bool getCurrProductExist()
    {
        return currProductExist;
    }

    static public bool getIsCart()
    {
        return isCart;
    }



    //Accessor Function
    static public void setCurrProductExist(bool currentStatus)
    {
        currProductExist = currentStatus;
    }
    static public void setIsCart(bool state)
    {
        isCart = state;
    }


    // Use this for initialization
    void Start () {
        //Initialize productIndex and grocery list
        currentProduct = -1;
        list = new ListController.List();
        list.makeList();
        list.printList();

        //Initialize coupon list
        couponList = new CouponListController.CouponList();
        couponList.makeCouponList();


        //initialize score-related global variables
        need_to_pay = 0;
        goodPoints = 0;
        badPoints = 0;

        //Assign Text UI
        numOfFirstItem = GameObject.Find("GUI").transform.Find("FirstList").GetComponent<Text>();
        numOfSecondItem = GameObject.Find("GUI").transform.Find("SecondList").GetComponent<Text>();
        numOfThirdItem = GameObject.Find("GUI").transform.Find("ThirdList").GetComponent<Text>();
        
        drawNewList();

    }
	
	// Update is called once per frame
	void Update () {
        spawnProduct();
    }

    /**
     * @name : spawnProduct
     * Description : This function checks that the product is already existed or not.
     *               If there is no product on the screen, this function will generate new product.
     *
     */
    void spawnProduct()
    {
        //Case : Product need to be spawn
        if (currProductExist == false)
        {
            //Case : Before we spaw new product, we need to add the previous product
            //       to the grocery list. If currentProduct is -1, this is for initial state, so we don't
            //       need to update grocery list for this state.
            //Case for isCart : If the user Swipe down the previous product, add to grocery list.
            if(currentProduct != -1 && getIsCart() == true )
            {
                int indexOfGroceryList = list.findProduct(currentProduct);
                //Case : Product exists in the grocery list
                if (indexOfGroceryList != -1)
                {
                    //update the quantity of grocery list.
                    int currentNum = list.getListValue(indexOfGroceryList, 2);
                    list.setListValue(indexOfGroceryList,2, (currentNum+1));
                    list.printList();

                    //Show Good Sign
                    StartCoroutine(prefabAnimation(1));
                }
                else
                {
                    //Show Bad Sign
                    StartCoroutine(prefabAnimation(0));
                }

                //Add price of the bought item to the global price counter
                need_to_pay += priceArr[currentProduct];

                //Case : If the user accomplish all the grocery list, make new grocery list
                if (list.isDone())
                {
                    list.makeList();
                    drawNewList();
                    //Debugging purpose
                    Debug.Log("New Gocery List is generated");
                    list.printList();
                }
            }
            
            //Spaw products
            Vector3 spawnPos = new Vector3(0, 3, 0);
            currentProduct = Random.Range(0, list.getNumOfProdCategory());
            GameObject product = (GameObject)Instantiate(products[currentProduct], spawnPos, new Quaternion());
            currProductExist = true;
        }
    }

    /**
     * @name : prefabAnimation
     * @param option : 1 for good sign, 0 for bad sign
     * Description : This function will play the animation of good or bad sign.
     *               If the given param is 0, this function will play bad-sign animation.
     *               If the given param is 1, this function will play good-sign animation.
     */
    IEnumerator prefabAnimation(int option)
    {
        GameObject sign = null;
        if (option == 1)
        {
            sign = Instantiate(goodSignObj) as GameObject;
            TimerController.timer += 3.00f;
            goodPoints += 100;
        }
        else if (option == 0)
        {
            sign = Instantiate(badSignObj) as GameObject;
            TimerController.timer -= 5.00f;
            badPoints += 200;
        }
        yield return new WaitForSeconds(2);
        Destroy(sign);
    }

    /**
     * @name : drawNewList()
     * Description : This function draw grocery list on the left top based on ListController
     */
    void drawNewList()
    {
        //Case : If items are exist, destroy the items.
        if(firstItem != null && secondItem != null && thirdItem != null)
        {
            Destroy(firstItem);
            Destroy(secondItem);
            Destroy(thirdItem);
        }

        //Draw Grocery List
        firstItem = (GameObject)Instantiate(products[list.getListValue(0, 0)], new Vector3(-6.67f, 4.03f, -2), new Quaternion());
        firstItem.transform.SetParent(GameObject.Find("GUI").transform,false);
        RectTransform item = firstItem.GetComponent<RectTransform>();
        item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 50);
        item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);
        item.localPosition = new Vector3(-274,177,0);
        item.localScale = new Vector3(20,20,0);
        Destroy(item.GetComponent<Rigidbody2D>()); //Need to remove rigidbody 


        secondItem = (GameObject)Instantiate(products[list.getListValue(1, 0)], new Vector3(-6.67f, 4.03f, -2), new Quaternion());
        secondItem.transform.SetParent(GameObject.Find("GUI").transform, false);
        item = secondItem.GetComponent<RectTransform>();
        item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 50);
        item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);
        item.localPosition = new Vector3(-274, 127, 0);
        item.localScale = new Vector3(20, 20, 0);
        Destroy(item.GetComponent<Rigidbody2D>()); //Need to remove rigidbody 

        thirdItem = (GameObject)Instantiate(products[list.getListValue(2, 0)], new Vector3(-6.67f, 4.03f, -2), new Quaternion());
        thirdItem.transform.SetParent(GameObject.Find("GUI").transform, false);
        item = thirdItem.GetComponent<RectTransform>();
        item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 50);
        item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);
        item.localPosition = new Vector3(-274, 77, 0);
        item.localScale = new Vector3(20, 20, 0);
        Destroy(item.GetComponent<Rigidbody2D>()); //Need to remove rigidbody 


        //Draw Quantity of Grocery list
        numOfFirstItem.text = "X" + list.getListValue(0, 1);
        numOfSecondItem.text = "X" + list.getListValue(1, 1);
        numOfThirdItem.text = "X" + list.getListValue(2, 1);
    }

}
