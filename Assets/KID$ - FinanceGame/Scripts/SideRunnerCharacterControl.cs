using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(SideRunnerCharacter))]
public class SideRunnerCharacterControl : MonoBehaviour
{
    public GameObject gameOverUI;

    private SideRunnerCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

    //public float z_axis = -8;
	//public float turnSpeed = 0.002f;

    //public Rigidbody rigidBody;
    private bool crouch = false;

    private float lastCollisionX = 0f;

    private void Start()
    {
        // get the transform of the main camera
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
            // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
        }

        // get the third person character ( this should never be null due to require component )
        m_Character = GetComponent<SideRunnerCharacter>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }

    protected void LateUpdate()
    {

    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        //This is necessary to lock positions and rotations...otherwise dude goes all nilly willy.

        
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;


        // read horizontal inputs and apply boundary
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        
        if(h < 0) { h = 0; }
            
        h = h + .7f;


        //Old vertical controls, for turning...
        //float v = CrossPlatformInputManager.GetAxis("Vertical");      //Disable depth moving
        //bool crouch = Input.GetKey(KeyCode.C);



#if !MOBILE_INPUT
        // walk speed multiplier
        //No walking.... 
        //if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

        /*
        //Auto adjust player to stay on course
        float currentZ = this.gameObject.transform.position.z;
        print("Current Z: " + currentZ);

        float diff = currentZ - z_axis;
        print("diff: " + diff);

        print("Deltatime: " + Time.deltaTime);

        if (currentZ > z_axis)          //go right to get back
        {
            m_Character.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            //m_Character.transform.Rotate(0, .002f, 0); //.002f
            m_Character.Move(new Vector3(h, 0, 0), crouch, m_Jump);
        }
        else if(currentZ < z_axis)      //go left to get back
        {
            //float diff = currentZ - z_axis;
			m_Character.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            //m_Character.transform.Rotate(0, -.002f, 0); //-.002f
            m_Character.Move(new Vector3(h, 0, 0), crouch, m_Jump);
        }
        else
        {
            m_Character.Move(new Vector3(h, 0, 0), crouch, m_Jump);     // pass all parameters to the character control script
        }
        */

        m_Character.Move(new Vector3(h, 0, 0), crouch, m_Jump);     // pass all parameters to the character control script

        m_Jump = false;
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {

            //print("Game Over? - X is " + GetComponent<Rigidbody>().position.x);
            doGameOver();
        }
    }

    /*
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Coin")
        {
            print("Hit coin with " + this.gameObject.GetComponent<Rigidbody>().tag);
            Destroy(other.gameObject);
            ScoreText.runnerScore += 10;
        }
        
    }*/


    private void doGameOver()
    {
        //Show stumble animation
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("stumble");
        
        //Show game over screen
        Animator gameOverAnim = gameOverUI.GetComponent<Animator>();
        gameOverAnim.SetTrigger("game_over");


        print("Final score: "+ScoreText.runnerScore);

        BankEntry be = new BankEntry(ScoreText.runnerScore, "Earned");

        GameManager.instance.addBankEntry(be);
        GameManager.instance.saveGame();
    }




}
