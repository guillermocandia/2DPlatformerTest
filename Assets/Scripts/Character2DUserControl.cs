using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Platformer2D
{
    [RequireComponent(typeof(Character2D))]
    public class Character2DUserControl : MonoBehaviour
    {
        private Character2D character2D;
       
        private float move;
        private bool running;

        private void Awake()
        {
            character2D = GetComponent<Character2D>();
        }
            
        private void Update()
        {
            

        }
            
        private void FixedUpdate()
        {
            move = Input.GetAxis("Horizontal");
            running = Input.GetButton("Fire3");

            character2D.running = running;
            character2D.move = move;
        }
    }
}