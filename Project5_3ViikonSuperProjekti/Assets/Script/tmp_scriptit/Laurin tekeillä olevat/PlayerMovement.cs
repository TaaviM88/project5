using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float inputDirection; // x value of our movevector
    private float verticalVelocity; // Y value of our move vector

    public float jumpForce = 10.0f;
    public float speed = 5.0f;
    public float gravity = 1.0f;
    public float hoverHeight = 0.2f;
    private bool secondJumpAvail = false;
    private bool _facingRight = true;
    public float value;

    private Animator anime;
    private Rigidbody rigidbody;
    private Vector3 moveVector;
    //lastmotionilla lukittiin hypyn suunta
    private Vector3 lastMotion;
    private CharacterController controller;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anime = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IsControllerGrounded();
        moveVector = Vector3.zero;
        //saisko tähän määritettyä että jos inputtia ei tule on x velocity yhtäkuin 0?
        inputDirection = Input.GetAxis("P1movement") * speed;
        value = Input.GetAxis("P1movement");
        //Debug.Log(value);
        if (value > 0)
        {
            
            if (_facingRight == false)
            {
                Flip();
            }
            anime.SetInteger("AnimChar", 1);
        }

        if (value < 0)
        {
           
            if (_facingRight == true)
            {
                Flip();
            }
            anime.SetInteger("AnimChar", 1);
        }

        if (value == 0)
        {
           anime.SetInteger("AnimChar", 0);
        }

        //Debug.Log(inputDirection);
        //hyppy joka on mahdollinen kun grounded
        if (IsControllerGrounded())
        {
            verticalVelocity = 0;

            if (Input.GetButtonDown("P1Jump"))
            {
                verticalVelocity = jumpForce;
                //Kun ilmassa secondjump on aktiivinen
                secondJumpAvail = true;
            }
            moveVector.x = inputDirection;
        }
        else
        {
            
            if (Input.GetButtonDown("P1Jump"))
            {
                if(secondJumpAvail)
                {
                    verticalVelocity = jumpForce;
                    secondJumpAvail = false;
                }
            }

                verticalVelocity -= gravity * Time.deltaTime;
            //Jos haluat vapaan liikkumisen ja vapaan hyppy suunnan, ota kaksi seuraavaa käyttöön
                //moveVector.x = inputDirection;
                //moveVector.y = inputDirection;
            //Jos haluat fixedjump ota käyttöön
                moveVector.x = lastMotion.x;
        }

        moveVector.y = verticalVelocity;
      //  moveVector = new Vector3(inputDirection, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
        lastMotion = moveVector;

    }
    void FixedUpdate()
    {   //tässä tippumis animaation laukaisu rigidbodylla
        Debug.Log(moveVector.y);
        if (moveVector.y > 0f)
        {
            Debug.Log("hyppaan");
            anime.SetInteger("AnimChar", 2);
        }
        else if (moveVector.y < 0f)
        {
            Debug.Log("tipun");
            anime.SetInteger("AnimChar", 3);
        }
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
        {
            //Debug.Log("osuu varpaat");
            return true;
        }
            

        if (Physics.Raycast(leftRayStart, Vector3.down, (controller.height / 2) + hoverHeight))
        {
            //Debug.Log("osuu kantapaa");
            return true;
        }

        //Debug.Log("ei osu maahan");
        return false;

    }

    //walljump
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
      if(controller.collisionFlags == CollisionFlags.Sides)
        {
            if(Input.GetButtonDown("P1Jump"))
            {
                moveVector = hit.normal * speed;
                verticalVelocity = jumpForce;
            }
            
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }

}
