using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public Vector3 startPosition;
    public CharacterController controller;
    public float turnSmoothTime = 1f;
    float turnSmoothVelocity;
    public Transform camera;
    private Animator anim;

    public AudioSource walkingSound;
    public AudioSource runningSound;


    private Vector3 direction;
    private float _speed = 5f;
    private float jumpSpeed = 7.0f;
    private float gravity = 14.0f;
    private float verticalVelocity;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded)
        {

            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("isWalking", false);
                anim.SetBool("isRun", false);
                anim.SetBool("isJump", true);
                verticalVelocity = jumpSpeed;
            }

        }

        else
        {
            anim.SetBool("isJump", false);
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);

        if (knockBackCounter <= 0)
        {

            //anim.SetBool("isJump", false);
            anim.SetBool("isRun", false);
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey("left shift"))
            {
                _speed = 10f;

                anim.SetBool("isRun", true);

            }
            else
            {
                _speed = 5f;
                anim.SetBool("isRun", false);


            }
            anim.SetBool("isWalking", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * _speed * Time.deltaTime);

        }

        else
        {
            anim.SetBool("isWalking", false);
            walkingSound.Play();
        }

    }

    public void KnockBack(Vector3 directionp)
    {
        knockBackCounter = knockBackTime;

        direction = directionp * knockBackForce;
        direction.y = knockBackForce;
    }
}
