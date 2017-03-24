using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(SideRunnerCharacter))]
public class SideRunnerCharacterControl : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseUI;
    public Button cancelButton;

    private SideRunnerCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
    
    private bool crouch = false;

    private float lastCollisionX = 0f;
    
    private bool gameOver = false;
    private bool showingPauseUI = false;

    //Time Counter
    public Text timeText;
    public static float timeLeft = 25.0f;
    public static float timeStartedWith;

    public GameObject scoreUI;
    public GameObject timeUI;

    private void Start()
    {
        timeLeft = 25.0f;
        timeStartedWith = timeLeft;
        GameManager.instance.getPlayerData().resetCoinsThisGame();

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

        cancelButton.onClick.AddListener(resumeGame);
    }


    private void Update()
    {
        if (!m_Jump)
        {
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            //AudioSource.PlayClipAtPoint(quit, new Vector3());
            doPauseGame();
        }
    }

    protected void LateUpdate()
    {
      
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {

        updateTimeCounter();

        //This is necessary to lock positions and rotations...otherwise dude goes all crazy.
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
    

    private void updateTimeCounter()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = (int)timeLeft + "";

        if(timeLeft < 0f)
        {
            doTimeOver();
        }
        else
        {

            //SPEED UP CHARACTER OVER TIME
            m_Character.m_MoveSpeedMultiplier += (Time.deltaTime) / 30;
        }

    }

    private void doPauseGame()
    {
       
        if (showingPauseUI == false && !gameOver)
        {
            Time.timeScale = 0;
            showingPauseUI = true;
            pauseUI.SetActive(showingPauseUI);

        }else
        {
            //resumeGame();
        }
        
        
    }

    private void doGameOver()
    {
        if (!gameOver)
        {

            hideScoreAndTime();

            //Show stumble animation
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("stumble");

            //Show game over screen
            Animator gameOverAnim = gameOverUI.GetComponent<Animator>();
            gameOverAnim.SetTrigger("game_over");
            
            BankEntry be = new BankEntry(ScoreText.runnerScore, "Earned", DateTime.Now);

            GameManager.instance.getPlayerData().addBankEntry(be);
            GameManager.instance.saveGame();

            gameOver = true;

        }
    }

    private void doTimeOver()
    {
        if (!gameOver)
        {
            
            hideScoreAndTime();

            //Stop character
            m_Character.m_MoveSpeedMultiplier = 0;
            m_Character.m_AnimSpeedMultiplier = 0;

            //Change text
            gameOverUI.GetComponentInChildren<Text>().text = "Times Up!";
            
            //Show game over screen
            Animator gameOverAnim = gameOverUI.GetComponent<Animator>();
            gameOverAnim.SetTrigger("game_over");

            BankEntry be = new BankEntry(ScoreText.runnerScore, "Earned", DateTime.Now);

            GameManager.instance.getPlayerData().addBankEntry(be);
            GameManager.instance.saveGame();
            
            gameOver = true;
            
        }
    }


    private void resumeGame()
    {
        showingPauseUI = !showingPauseUI;
        pauseUI.SetActive(showingPauseUI);
        Time.timeScale = 1;
    }

    private void hideScoreAndTime()
    {
        scoreUI.SetActive(false);
        timeUI.SetActive(false);
    }



}
