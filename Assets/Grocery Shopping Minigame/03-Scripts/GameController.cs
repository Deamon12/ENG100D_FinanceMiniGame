using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //When user swipe the product, this value will detect that the user buy the product or not.
    static private bool isCart = false;

    //False for no product on the screen
    static private bool currProductExist = false;

    //Grocery List
    private ListController.List list;
    public GameObject[] products;


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

                //Case : If the user accomplish all the grocery list, make new grocery list
                if(list.isDone())
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
        }
        else if(option ==0)
        {
             sign = Instantiate(badSignObj) as GameObject;
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
        firstItem.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        Destroy(firstItem.GetComponent<Rigidbody2D>()); //Need to remove rigidbody 
        secondItem = (GameObject)Instantiate(products[list.getListValue(1, 0)], new Vector3(-6.67f, 3.09f, -2), new Quaternion());
        secondItem.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        Destroy(secondItem.GetComponent<Rigidbody2D>());//Need to remove rigidbody 
        thirdItem = (GameObject)Instantiate(products[list.getListValue(2, 0)], new Vector3(-6.67f, 1.88f, -2), new Quaternion());
        thirdItem.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        Destroy(thirdItem.GetComponent<Rigidbody2D>());//Need to remove rigidbody 

        //Draw Quantity of Grocery list
        numOfFirstItem.text = "X" + list.getListValue(0, 1);
        numOfSecondItem.text = "X" + list.getListValue(1, 1);
        numOfThirdItem.text = "X" + list.getListValue(2, 1);
    }

}
