using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Island
{
    public class Ship : MonoBehaviour
    {
        [SerializeField]
        private Transform mytransform;

        [SerializeField]
        [Min(0)]
        private float speed;

        [SerializeField]
        private float startXPoint;

        [SerializeField]
        private float finishXPoint;

        [SerializeField]
        [Min(0)]
        private float delay;

        private bool isMoving = true;

        void Start()
        {
            mytransform.position = new Vector2(startXPoint, mytransform.position.y);
        }

        void Update()
        {
            if(isMoving)
            {
                mytransform.Translate(new Vector2(speed, 0) * Time.deltaTime);
                if(mytransform.position.x >= finishXPoint)
                {
                    isMoving = false;
                    mytransform.position = new Vector2(startXPoint, mytransform.position.y);
                    StartCoroutine(Delay());
                }
            }
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSecondsRealtime(delay);
            isMoving = true;
        }
    }
}
