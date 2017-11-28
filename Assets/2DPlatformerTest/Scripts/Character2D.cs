using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

namespace PlatformerTest
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character2D : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private float speed_walk = 40.0f;
        [SerializeField] private float speed_run = 100.0f;
        [SerializeField] private float speed_jump = 100.0f;
        [SerializeField] private float max_jump_height = 64.0f;
        [SerializeField] private bool air_control;

        private Rigidbody2D rg2D;
        private Animator anim;
        private bool facingRight = true;
        private Transform groundDetector;
        private bool canJump = true;

        [HideInInspector] public float move;
        [HideInInspector] public bool running;
        [HideInInspector] public bool jump;
        [HideInInspector] public bool grounded;

        // aux
        private Vector3 velocity;
        private float jump_height;

        void Awake() 
        {
            rg2D = GetComponent<Rigidbody2D> ();
            anim = GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            if (!grounded && !jump)
            {
                canJump = false;
            }

            if (jump && canJump)
            {
                Jump();
            }
                
            if (grounded)
            {
                jump_height = 0;
                canJump = true;
            }

            if (grounded || air_control)
            {
                Move();
            }

            if ((rg2D.velocity.x > 0 && !facingRight) || (rg2D.velocity.x < 0 && facingRight))
            {
                Flip();
            }

            anim.SetFloat("Speed", Mathf.Abs(move));
            anim.SetBool("Running", running);
            anim.SetBool("Grounded", grounded);
            anim.SetFloat("VSpeed", rg2D.velocity.y);
        }

        private void Move ()
        {
            velocity = Vector3.zero;
            velocity.y = rg2D.velocity.y;
            velocity.x = move * (running ? speed_run : speed_walk) * Time.fixedDeltaTime;

            rg2D.velocity = velocity;
        }
            

        private void Jump ()
        {
            if (jump_height < max_jump_height)
            {
                rg2D.velocity = new Vector3(rg2D.velocity.x, speed_jump * Time.fixedDeltaTime, 0);
                jump_height += speed_jump * Time.fixedDeltaTime;
            }
        }

        private void Flip ()
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);
        }
        
    }
}
