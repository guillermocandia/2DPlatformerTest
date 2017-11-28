using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerTest
{
    [RequireComponent(typeof(Character2D))]
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private Character2D character2D;
        [SerializeField] private Transform origin;
        [SerializeField] private List<LayerMask> groundList;
        [SerializeField] private float radius = 0.1f;

        private Vector3 target;

        void FixedUpdate()
        {
            foreach (LayerMask ground in groundList)
            {
                RaycastHit2D hit = Physics2D.Raycast(origin.position, -transform.up, radius, ground);
            
                if (hit.collider != null)
                {
                    character2D.grounded = true;
                    return;
                }
            }
            character2D.grounded = false;
        }

        void OnDrawGizmosSelected ()
        {
            target = origin.position + new Vector3(0, -radius, 0);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(origin.position, target);
        }
    }
}