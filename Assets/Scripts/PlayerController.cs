using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;                //Floating point variable to store the player's movement speed.
    public float jump;

    private Rigidbody rb;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private float currentJump;
    private bool isJumping = true;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb = GetComponent<Rigidbody>();
        currentJump = jump;
        Physics.gravity = new Vector3(0f,-500f,0f);
    }

    void Update()
    {
        // change the KeyCode to work with the jump input of any controller
        if (Input.GetKey(KeyCode.W))
        {
            if (!isJumping)
            {
                rb.AddForce(new Vector3(0f, jump, 0f), ForceMode.Force);
                isJumping = true;
            }
            else
            {
                currentJump += Physics.gravity.y;
                if (currentJump < 0f)
                {
                    currentJump = 0f;
                }
                rb.AddForce(new Vector3(0f, currentJump, 0f), ForceMode.Force);
            }
        }
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.velocity = new Vector3(moveHorizontal, 0f, 0f) * speed;
    }

    private void OnCollisionStay(Collision collision)
    {
        //Remember to get the collision tags
        isJumping = false;
        currentJump = jump;
        Debug.Log("Collision detected");
    }
}