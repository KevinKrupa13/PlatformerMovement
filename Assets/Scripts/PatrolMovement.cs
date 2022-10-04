using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xPos;
    private float direction = 1;
    private float speed = 3;

    private float distance;

    public Transform platform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xPos = rb.position.x;

        distance = platform.lossyScale.x / 2;
        distance = distance - 0.25F;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x >= (xPos + distance)) {
                direction = -1;
        } else if (rb.position.x <= (xPos - distance)) {
                direction = 1;
        }
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
}
