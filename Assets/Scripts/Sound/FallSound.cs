using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSound : MonoBehaviour
{
    [SerializeField] AudioSource fallSound;
    private float fallThresholdVelocity = 5f;
    private bool grounded = true;
    private bool previousGrounded = true;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Debug.Log("rb.velocity.y: " + rb.velocity.y);
        // Debug.Log(rb.velocity.y < -fallThresholdVelocity);
        if (!previousGrounded && grounded)
        {
            if (rb.velocity.y < -fallThresholdVelocity)
            {
                // Increase sound based on velocity
                fallSound.volume = Mathf.Clamp01(Mathf.Abs(rb.velocity.y) / fallThresholdVelocity);
                fallSound.Play();
            }
        }
        previousGrounded = grounded; // Update previous grounded state at end of frame
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Brick" || collision.gameObject.tag == "Wood" ||
            collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Brick" || collision.gameObject.tag == "Wood" ||
            collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}