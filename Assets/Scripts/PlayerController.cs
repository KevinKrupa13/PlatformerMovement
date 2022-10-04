using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Rigidbody2D rb;
    private float moveSpeed = 9;
    private float input = 1;
    private float jumpSpeed = 15;

    private bool isGrounded;
    public Transform feetPos;
    private float checkRadius = 0.3F;
    public LayerMask whatIsGround;

    public Transform headPos;
    private bool isHeaded;

    private float jumpTimeCounter;
    private float jumpTime = 0.25F;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        isHeaded = Physics2D.OverlapCircle(headPos.position, checkRadius, whatIsGround);

        jumping();
        
    }

    void FixedUpdate() {
        if (input != 0) {
            gameObject.transform.localScale = new Vector3(input, 1, 1);
        }
        rb.velocity = new Vector2(moveSpeed * input, rb.velocity.y);
    }

    public void jumping() {
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpSpeed;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping && !isHeaded) {
            if (jumpTimeCounter > 0) {
                rb.velocity = Vector2.up * jumpSpeed;
                jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
                rb.AddForce(new Vector2(0, -5));
            }
        } else {
            isJumping = false;
            rb.AddForce(new Vector2(0, -5));
        }
        
        if (Input.GetKeyUp(KeyCode.Space)) {
            isJumping = false;
            rb.AddForce(new Vector2(0, -5));
        }
    }
}
