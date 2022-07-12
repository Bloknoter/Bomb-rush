using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Island
{
    public class Totem : MonoBehaviour
    {
        [SerializeField]
        private Transform mytransform;

        [SerializeField]
        private GameObject BulletPrefab;

        [SerializeField]
        private Transform ShootPoint;

        [SerializeField]
        [Min(0)]
        private float movingSpeed;

        [SerializeField]
        private float upperYDelayLevel;

        [SerializeField]
        private float lowerYDelayLevel;

        [SerializeField]
        [Min(0)]
        private float delay;

        private enum DirectionEnum { Up, Down}

        private DirectionEnum direction = DirectionEnum.Down;

        private bool isMoving = true;

        void Start()
        {
            mytransform.position = new Vector2(mytransform.position.x, upperYDelayLevel);
        }


        void Update()
        {
            if(isMoving)
            {
                if(direction == DirectionEnum.Up)
                {
                    mytransform.Translate(new Vector2(0, movingSpeed) * Time.deltaTime);
                    if(mytransform.position.y >= upperYDelayLevel)
                    {
                        direction = DirectionEnum.Down;
                        isMoving = false;
                        StartCoroutine(Delay());
                    }
                }
                else
                {
                    mytransform.Translate(new Vector2(0, -movingSpeed) * Time.deltaTime);
                    if (mytransform.position.y <= lowerYDelayLevel)
                    {
                        direction = DirectionEnum.Up;
                        isMoving = false; 
                        StartCoroutine(Delay());
                    }
                }
            }
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSecondsRealtime(delay);
            isMoving = true;
        }

        public void Shoot()
        {
            Instantiate(BulletPrefab, ShootPoint.position, Quaternion.identity);
        }
    }
}
