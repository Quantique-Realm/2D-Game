using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Char_Movement : MonoBehaviour
{
    private float horizontal;
    public float speed ;
    public float jumpingPower ;
    private bool isFacingRight = true;
    private Animator animator ;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
   

    // Update is called once per frame
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")&&isGrounded())
        {
            rb.velocity= new Vector2(rb.velocity.x,jumpingPower);
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity=new Vector2(rb.velocity.x,rb.velocity.y*0.5f);
        }
        animator.SetBool("isRunning", Mathf.Abs(horizontal) > 0f);

        Flip();
        
    }

    private bool isGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void Flip()
    {
        if(isFacingRight && horizontal<0f || !isFacingRight && horizontal>0f) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale  ;
            localScale.x *= -1f;
            
            
            transform.localScale = localScale;

        }
    }
}
