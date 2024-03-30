using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Copied from Slide C#
    Rigidbody rig;
    CapsuleCollider collider;
    float originalHeight;
    public float reducedHeight;

    public CharacterController controller;


    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    //Copied from Slide C#
    public float slideSpeed = 10f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        rig = GetComponent<Rigidbody>();
        originalHeight = controller.height;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //Copied from Slide C#
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
            Sliding();
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            GoUp();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    //Copied from Slide C#
    private void Sliding()
    {
        controller.height = reducedHeight;
        // rig.AddForce(transform.forward * slideSpeed, ForceMode.VelocityChange);
        velocity.x *= slideSpeed;
    }
    private void GoUp()
    {
        controller.height = originalHeight;
    }
}
