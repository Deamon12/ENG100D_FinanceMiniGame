using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(SideRunnerCharacter))]
public class SideRunnerCharacterControl : MonoBehaviour
{
    // 
    private SideRunnerCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
    private Transform m_Cam;                  // A reference to the main camera in the scenes transform
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

    public float z_axis = -8;
	public float turnSpeed = 0.002f;

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
        // read inputs
        //float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float h = 1;
        //float v = CrossPlatformInputManager.GetAxis("Vertical");      //Disable depth moving
        //bool crouch = Input.GetKey(KeyCode.C);
        bool crouch = false;

        // calculate move direction to pass to character
        if (m_Cam != null)
        {
            // calculate camera relative direction to move:
            //m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 0)).normalized;
            // m_Move = 0 * m_CamForward + h * m_Cam.right;
            //m_Move = new Vector3(1, 0, 0);

            //print("h * m_Cam.right: " + h * m_Cam.right);
            //print("m_CamForward: " + m_CamForward);
            //print("m_Move: " + m_Move);

            

            //transform.Translate(Time.deltaTime, 0, 0, Camera.main.transform);

        }
        else
        {
            // we use world-relative directions in the case of no main camera
            //m_Move = 0 * Vector3.forward + h * Vector3.right;
        }

#if !MOBILE_INPUT
        // walk speed multiplier
        //No walking.... 
        //if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif


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


        
        
        m_Jump = false;
    }
}
