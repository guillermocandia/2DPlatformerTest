using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

namespace Platformer2D
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Character2D : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private float speed_walk = 40.0f;
        [SerializeField] private float speed_run = 100.0f;

        private Rigidbody2D rg2D;
        private Animator anim;
        private bool facingRight = true;

        [HideInInspector] public float move;
        [HideInInspector] public bool running;
        private bool grounded;

        // aux
        private Vector3 velocity;

        void Awake() 
        {
            rg2D = GetComponent<Rigidbody2D> ();
            anim = GetComponent<Animator>();
        }

        void FixedUpdate()
        {
            grounded = true;

            if (grounded)
            {
                Move();
            }

            if ((move > 0 && !facingRight) || (move < 0 && facingRight))
            {
                Flip();
            }
        }

        private void Move ()
        {
            velocity = Vector3.zero;
            velocity.y = rg2D.velocity.y;
            velocity.x = move * (running ? speed_run : speed_walk) * Time.fixedDeltaTime;

            rg2D.velocity = velocity;

            anim.SetFloat("Speed", Mathf.Abs(move));
            anim.SetBool("Running", running);
        }


        private void Flip()
        {
            facingRight = !facingRight;
            transform.Rotate(0, 180, 0);
        }
    }
}
