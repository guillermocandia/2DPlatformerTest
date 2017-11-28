using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PlatformerTest
{
    [RequireComponent(typeof(Character2D))]
    public class Character2DUserControl : MonoBehaviour
    {
        private Character2D character2D;
       
        private float move;
        private bool running;
        private bool jump;

        private void Awake()
        {
            character2D = GetComponent<Character2D>();
        }
            
        private void Update()
        {
            move = Input.GetAxis("Horizontal");
            running = Input.GetButton("Fire3");
            jump = Input.GetButton("Jump");

            character2D.running = running;
            character2D.move = move;
            character2D.jump = jump;
        }

    }
}
