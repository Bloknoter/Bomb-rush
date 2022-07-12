using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Components;

namespace Player.Components.MovingEngine
{
    public class Movement : MonoBehaviour, ISwitchable
    {
        [SerializeField]
        protected Rigidbody2D myrigidbody;

        [SerializeField]
        protected float MovementSpeed;

        private float Xmovement;

        public enum LookingDirectionEnum
        {
            Left = -1, Right = 1
        }

        private LookingDirectionEnum lookingDirection;

        private bool isEnabled = true;

        private void FixedUpdate()
        {
            myrigidbody.velocity = new Vector2(Xmovement, myrigidbody.velocity.y);
            Xmovement = 0;
        }

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
            }
        }

        public LookingDirectionEnum LookingDirection
        {
            get { return lookingDirection; }
        }

        public bool IsMoving
        {
            get { return Xmovement != 0; }
        }

        public void StopMoving()
        {
            Xmovement = 0;
        }

        public void MoveLeft()
        {
            if (isEnabled)
            {
                lookingDirection = LookingDirectionEnum.Left;
                Xmovement = -MovementSpeed /** 100 * Time.deltaTime*/;
            }
        }

        public void MoveRight()
        {
            if (isEnabled)
            {
                lookingDirection = LookingDirectionEnum.Right;
                Xmovement = MovementSpeed /** 100 * Time.deltaTime*/;
            }
        }
    }
}
