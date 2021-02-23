using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{

    public float jumpForce = 7f;

    private Animator animator;
    private Rigidbody2D myRigidbody2D;
    private GroundDetector groundDetector;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        groundDetector = GetComponent<GroundDetector>();
    }

    private void Update()
    {
        if(animator != null)
        {
            animator.SetFloat("yVelocity", myRigidbody2D.velocity.y);
        }
    }

    public void Jump()
    {
        if(groundDetector == null || groundDetector.onGround)
        {
            myRigidbody2D.velocity += new Vector2(0f, jumpForce);
            
            if(myRigidbody2D.velocity.y > jumpForce)
            {
                myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpForce);
            }
        }
    }
}
