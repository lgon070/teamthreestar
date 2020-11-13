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
    public Animator anim;
    float nextJump = 0;
    float jumpCoolDown = 1f;

    public AudioSource walkingSound;
    public AudioSource runningSound;

    private Vector3 direction;

    private bool isGrounded = true;

    [SerializeField]
    private float _speed = 5f;

    [SerializeField]
    private float _jumpSpeed = 0f;

    [SerializeField]
    private float _gravity = -9.8f;

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

        anim.SetBool("isJump", false);
        anim.SetBool("isRun", false);
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;



        if (direction.magnitude >= 0.1f) {
            if (Input.GetKey("left shift")) {
                _speed = 10f;
                anim.SetBool("isRun", true);
                
            }
            else {
                _speed = 5f;
                anim.SetBool("isRun", false);
                runningSound.Play();

            }
            anim.SetBool("isWalking", true);
            
            



            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * _speed * Time.deltaTime);

            if (Time.time > nextJump) {
                if (Input.GetButtonDown("Jump") && isGrounded) {
                    nextJump = Time.time + jumpCoolDown + 0.1f;
                    anim.SetBool("isJump", true);
                    direction.y = _jumpSpeed - _gravity * Time.deltaTime;
                    controller.Move(direction * Time.deltaTime);
                }
            }

        }

        else {
            anim.SetBool("isWalking", false);
            walkingSound.Stop();
        }

        if (Time.time > nextJump) {
            if (Input.GetButtonDown("Jump") && isGrounded) {
                nextJump = Time.time + jumpCoolDown;
                anim.SetBool("isJump", true);
                direction.y = _jumpSpeed - _gravity * Time.deltaTime;
                controller.Move(direction * Time.deltaTime);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }


}
