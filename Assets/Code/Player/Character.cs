using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Components.MovingEngine;

namespace Player
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Movement movement;

        [SerializeField]
        private Jumping jumping;

        [SerializeField]
        private Health health;

        [SerializeField]
        private DialogSystem.Dialog dialog;

        [SerializeField]
        protected Animator myanimator;

        [SerializeField]
        protected SpriteRenderer myrenderer;

        void Start()
        {
            health.OnValueChangedEvent += OnHealthChanged;
        }

        void Update()
        {
            myrenderer.flipX = movement.LookingDirection == Movement.LookingDirectionEnum.Right;
            if (health.HealthValue > 0)
            {
                if (movement.IsMoving)
                {
                    myanimator.SetInteger("state", 1);
                }
                else
                {
                    myanimator.SetInteger("state", 0);
                }
            }
        }

        public void Jump()
        {
            jumping.Jump();
            myanimator.SetTrigger("jump");
        }

        public void MoveLeft()
        {
            movement.MoveLeft();
        }

        public void MoveRight()
        {
            movement.MoveRight();
        }

        public void OnHealthChanged(int previousvalue, int newvalue)
        {
            if(newvalue <= 0)
            {
                dialog.Close();
                myanimator.SetTrigger("hit");
                myanimator.SetInteger("state", 2);
                movement.IsEnabled = false;
                jumping.IsEnabled = false;
            }
            else if(newvalue - previousvalue < 0)
            {
                myanimator.SetTrigger("hit");
                dialog.Open();
            }
        }
    }
}
