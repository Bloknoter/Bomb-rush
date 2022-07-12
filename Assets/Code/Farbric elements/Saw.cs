using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Fabric
{
    public class Saw : MonoBehaviour
    {
        [SerializeField]
        private Transform mytransform;

        [SerializeField]
        private Transform[] pathPoints;

        [SerializeField]
        private float movingSpeed = 1f;

        [SerializeField]
        private float rotatingSpeed = 100f;

        private int currentPathPointTarget = 1;

        private enum DirectionEnum
        {
            Right, Left
        }

        private DirectionEnum direction = DirectionEnum.Right;

        void Start()
        {
            mytransform.position = pathPoints[0].position;
        }

        void Update()
        {
            mytransform.Rotate(0, 0, rotatingSpeed * Time.deltaTime);
            mytransform.position = Vector2.MoveTowards(mytransform.position, pathPoints[currentPathPointTarget].position, movingSpeed * Time.deltaTime);
            if (direction == DirectionEnum.Right)
            {
                if((Vector2)mytransform.position == (Vector2)pathPoints[currentPathPointTarget].position)
                {
                    currentPathPointTarget++;
                    if(currentPathPointTarget >= pathPoints.Length)
                    {
                        currentPathPointTarget = pathPoints.Length - 2;
                        direction = DirectionEnum.Left;
                    }
                }
            }
            else
            {
                if ((Vector2)mytransform.position == (Vector2)pathPoints[currentPathPointTarget].position)
                {
                    currentPathPointTarget--;
                    if (currentPathPointTarget < 0)
                    {
                        currentPathPointTarget = 1;
                        direction = DirectionEnum.Right;
                    }
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if(health != null)
            {
                health.HealthValue -= 1;
            }
        }
    }
}
