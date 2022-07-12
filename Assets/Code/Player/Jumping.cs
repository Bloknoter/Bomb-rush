using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Components;

namespace Player.Components.MovingEngine
{
    public class Jumping : MonoBehaviour, ISwitchable
    {
        [SerializeField]
        protected Rigidbody2D myrigidbody;

        [SerializeField]
        private Collider2D BodyCollider;

        [SerializeField]
        private Transform CheckGroundPoint;

        [SerializeField]
        protected float JumpForce;

        private bool isEnabled = true;

        public bool IsEnabled 
        { 
            get { return isEnabled; }
            set
            {
                isEnabled = value;
            }
        }

        public bool IsGrounded
        {
            get
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(CheckGroundPoint.position, 0.1f, 1<< LayerMask.NameToLayer("Walls"));
                bool wasRigid = false;
                for(int i = 0; i < colliders.Length;i++)
                {
                    if(!colliders[i].isTrigger && colliders[i] != BodyCollider)
                    {
                        wasRigid = true;
                        break;
                    }
                }
                return wasRigid;
            }
        }

        public void Jump()
        {
            if (isEnabled)
            {
                if (IsGrounded)
                {
                    myrigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}
