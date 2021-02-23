using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ProjectileShooter))]
public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private Jumper jumper;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private ProjectileShooter projectileShooter;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        jumper = GetComponent<Jumper>();
        animator = GetComponent<Animator>();
        projectileShooter = GetComponent<ProjectileShooter>();

        projectileShooter.SetDirection(new Vector3(1f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        //Moving Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            mover.AccelerateInDirection(new Vector2(-1f, 0f));
            projectileShooter.SetDirection(new Vector3(-1f, 0f));
            //spriteRenderer.flipX = true;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z);
            animator.SetBool("running", true);
        }

        //Moving Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            mover.AccelerateInDirection(new Vector2(1f, 0f));
            projectileShooter.SetDirection(new Vector3(1f, 0f));
            //spriteRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);
            animator.SetBool("running", true);
        }


        // Moving Up
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            jumper.Jump();
            
        }

        // If no keys are pressed let the animator know
        if (Input.anyKey == false)
        {
            animator.SetBool("running", false);
        }
    }
}