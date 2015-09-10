using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {

    public Vector3 jumpForce;

    Rigidbody rb;
    int jumpCount;
    bool wallJump;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        jumpCount = 0;
        wallJump = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        InputControl();
        JumpLogic();
	}

    /*
     * Possibly add void OnCollisionStay(Contacts contact)
     * for wall jumping
     */

    void JumpLogic()
    {
        if (Input.GetKeyDown("space") && wallJump)
        {
            //transform.RotateAround(transform.position, transform.up, 180f);
            //GetComponent<Cam2>().rotationX += 180;
            //rb.AddRelativeForce(Vector3.back * 50);
            wallJump = false;
        }
        else if (Input.GetKeyDown("space") && jumpCount < 2)
        {
            rb.AddRelativeForce(jumpForce);
            jumpCount = jumpCount + 1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            jumpCount = 0;
        }
        /*if (collision.gameObject.tag.Equals("Wall"))
        {
            wallJump = true;
        }*/
        
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag.Equals("Ground"))
        {
            jumpCount = 1;
        }
        if (collisionInfo.gameObject.tag.Equals("Wall"))
        {
            wallJump = false;
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag.Equals("Wall"))
        {
            if (Input.GetKeyDown("space"))
            {
                GetComponent<Cam2>().rotationX = GetComponent<Cam2>().rotationX - 180;
                rb.AddRelativeForce(-Vector3.forward * 450);
            }
            wallJump = true;
        }
    }

    void InputControl()
    {
        if (jumpCount == 0)
        {
            if (Input.GetKey("w"))
            {
                rb.AddRelativeForce(Vector3.forward * 20);
            }
            if (Input.GetKey("a"))
            {
                rb.AddRelativeForce(Vector3.left * 20);
            }
            if (Input.GetKey("s"))
            {
                rb.AddRelativeForce(Vector3.back * 20);
            }
            if (Input.GetKey("d"))
            {
                rb.AddRelativeForce(Vector3.right * 20);
            }
        }
        else
        {
            if (Input.GetKey("w"))
            {
                rb.AddRelativeForce(Vector3.forward * 5);
            }
            if (Input.GetKey("a"))
            {
                rb.AddRelativeForce(Vector3.left * 5);
            }
            if (Input.GetKey("s"))
            {
                rb.AddRelativeForce(Vector3.back * 5);
            }
            if (Input.GetKey("d"))
            {
                rb.AddRelativeForce(Vector3.right * 5);
            }
        }
    }
}
