using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkspeed;
    [SerializeField] private float movespeed;
    // [SerializeField] private float jumpHeight;
    [SerializeField] private bool isgrounded;
    [SerializeField] private float groundcheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    protected Joystick joy;
    private Animator anim;


    private Vector3 moveforward;
    private Vector3 velocity;

    private CharacterController controller;



    //calling functions in the begining of the game
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        joy = FindObjectOfType<Joystick>();
        anim = GetComponentInChildren<Animator>();
    }

    //calling functions in every frame of the game
    private void Update()
    {
        Move();
    }




    //player's all movements
    private void Move()
    {
        isgrounded = Physics.CheckSphere(transform.position, groundcheckDistance, groundMask);

        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float movez = joy.Vertical;
        float movex = joy.Horizontal;
        moveforward = new Vector3(movex, 0, movez).normalized;

        if (moveforward != Vector3.zero)
        {
            Walk();
            transform.forward = moveforward;
            anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
        }

        else if (moveforward == Vector3.zero)
        {
            Idle();
            anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        }

        /*
                if (isgrounded)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        Jump();
                    }

                }*/

        controller.Move(moveforward * movespeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    //walk function 
    private void Walk()
    {

        movespeed = walkspeed;
    }



    //idle function
    private void Idle()
    {
        movespeed = 0;
    }


}