using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public float gravity = -9.81f;

    public LayerMask ground;
    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public float jumpheight = 5f;

    bool isGrounded;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, grounddistance, ground);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);
    }
}
