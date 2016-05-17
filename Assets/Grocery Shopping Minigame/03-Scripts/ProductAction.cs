using UnityEngine;
using System.Collections;

public enum Swipe { None, Up, Down, Left, Right };
public class ProductAction : MonoBehaviour {

    private Rigidbody2D rb = null;


    //For Swipe implementation
    public float minSwipeLength = 200f;
	public int brandId = -1;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public static Swipe swipeDirection;


    // Use this for initialization
    void Start () {
        //For product movement
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.velocity = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        DetectSwipe();
    }


    //Move this product to down
    void moveToCart()
    {
        float productSpeed = 20.0f;

        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - productSpeed);
    }

    //Move this product to right
    void moveToRight()
    {
        float productSpeed = 20.0f;

        rb.velocity = new Vector2(rb.velocity.x + productSpeed, rb.velocity.y);
    }

    /**
     *  @name : OnCollisionEnter2D
     *  @return
     *  
     *  Basic Unity function. This will detect the collision between products and other colider(cart or outside of screen)
     * 
     */
    void OnTriggerEnter2D(Collider2D col)
    {
        //Case : Product reaches to Cart or Wall
        if (col.gameObject.name == "Cart" || col.gameObject.name == "EmptyWall")
        {
            //Case : Product reaches to Cart(Swipe down)
            if (col.gameObject.name == "Cart")
            {
				GameController.setSelectedBrand(brandId);
                GameController.setIsCart(true);
            }
            //Case : Product reaches to Wall(Swipe Right)
            else
            {
                GameController.setIsCart(false);
            }
            //Destroy product
            Destroy(this.gameObject);

            //Set current product is not exist
            GameController.setCurrProductExist(false);
        }
    }







    public void DetectSwipe()
    {
		//Check velocity so that you can't use arrows keys until previous product is off-screen
		if (Input.GetKey ("1") && brandId == 0 && rb.velocity.magnitude == 0) {
			moveToCart ();
			swipeDirection = Swipe.Left;
		} else if (Input.GetKey ("2") && brandId == 1 && rb.velocity.magnitude == 0) {
			moveToCart ();
			swipeDirection = Swipe.Left;
		} else if (Input.GetKey ("3") && brandId == 2 && rb.velocity.magnitude == 0) {
			moveToCart ();
			swipeDirection = Swipe.Left;
		} else if (Input.GetKey ("space") && rb.velocity.magnitude == 0) {
			moveToRight ();
			swipeDirection = Swipe.Right;
		} else if (Input.touches.Length > 0) {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }

            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                // Make sure it was a legit swipe, not a tap
                if (currentSwipe.magnitude < minSwipeLength)
                {
                    swipeDirection = Swipe.None;
                    return;
                }

                currentSwipe.Normalize();

                // Swipe up
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                    swipeDirection = Swipe.Up;
                    // Swipe down
                } else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                    swipeDirection = Swipe.Down;
                    moveToCart();
                    // Swipe left
                } else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f&&  currentSwipe.y < 0.5f) {
                    swipeDirection = Swipe.Left;
                    // Swipe right
                } else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                    swipeDirection = Swipe.Right;
                    moveToRight();
                }
            }
        }
        else
        {
            swipeDirection = Swipe.None;
        }
    }

}
