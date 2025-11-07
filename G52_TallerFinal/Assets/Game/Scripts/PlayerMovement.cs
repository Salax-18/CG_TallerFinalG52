using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool hasJumped = false;

    [Header("Ajustes de movimiento")]
    public float speed = 3.5f;
    public float jumpHeight = 2f;
    public float gravity = -20f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
      
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if (hasJumped)
            {
                hasJumped = false;
                anim.ResetTrigger("Jump");
                anim.SetBool("isFalling", false);
            }
        }

  
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical"); 

        Vector3 move = new Vector3(x, 0f, z).normalized;

      
        if (move.magnitude >= 0.1f)
        {
            controller.Move(move * speed * Time.deltaTime);

          
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }

        anim.SetFloat("speed", move.magnitude);

        
        if (Input.GetButtonDown("Jump") && isGrounded && !hasJumped)
        {
            hasJumped = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            anim.SetTrigger("Jump");
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
        bool isFalling = !isGrounded && velocity.y < -0.1f;
        anim.SetBool("isFalling", isFalling);
    }
}
