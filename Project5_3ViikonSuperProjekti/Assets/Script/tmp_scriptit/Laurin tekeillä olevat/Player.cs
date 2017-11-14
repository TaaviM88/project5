using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float inputDirection; // x value of our movevector
    private float verticalVelocity; // Y value of our move vector

    public float jumpForce = 10.0f;
    public float speed = 5.0f;
    public float gravity = 1.0f;
    public float hoverHeight = 0.2f;
    private bool secondJumpAvail = false;

    private Vector3 moveVector;
    //lastmotionilla lukittiin hypyn suunta
    private Vector3 lastMotion;
    private CharacterController controller;
	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        IsControllerGrounded();
        moveVector = Vector3.zero;
        inputDirection = Input.GetAxis("Horizontal") * speed;
        //hyppy joka on mahdollinen kun grounded
        if(IsControllerGrounded())
        {
            verticalVelocity = 0;

            if(Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
                //Kun ilmassa secondjump on aktiivinen
                secondJumpAvail = true;
            }
            moveVector.x = inputDirection;
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                if(secondJumpAvail)
                {
                    verticalVelocity = jumpForce;
                    secondJumpAvail = false;
                }
            }

                verticalVelocity -= gravity * Time.deltaTime;
                moveVector.x = lastMotion.x;
        }

        moveVector.y = verticalVelocity;
      //  moveVector = new Vector3(inputDirection, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
        lastMotion = moveVector;

    }
    // Raycast grounded check https://www.youtube.com/watch?v=8Cado6CzZUA&list=PLLH3mUGkfFCWwekOW1OMxyyIgc-Qm1OhI&index=10
    private bool IsControllerGrounded()
    {
        Vector3 leftRayStart;
        Vector3 rightRayStart;

        leftRayStart = controller.bounds.center;
        rightRayStart = controller.bounds.center;

        leftRayStart.x -= controller.bounds.extents.x;
        rightRayStart.x += controller.bounds.extents.x;

        Debug.DrawRay(leftRayStart, Vector3.down, Color.red);
        Debug.DrawRay(rightRayStart, Vector3.down, Color.blue);

        if (Physics.Raycast(rightRayStart, Vector3.down, (controller.height / 2) + hoverHeight))
            return true;

        if (Physics.Raycast(leftRayStart, Vector3.down, (controller.height / 2) + hoverHeight))
            return true;

        return false;
    }

    //walljump
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
      if(controller.collisionFlags == CollisionFlags.Sides)
        {
            if(Input.GetButtonDown("Jump"))
            {
                moveVector = hit.normal * speed;
                verticalVelocity = jumpForce;
            }

        }
    }

}
