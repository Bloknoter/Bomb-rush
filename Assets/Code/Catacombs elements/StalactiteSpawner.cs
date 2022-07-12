using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Catacombs
{
    public class StalactiteSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject StalactitePrefab;

        [SerializeField]
        private float minXSpawnZone;

        [SerializeField]
        private float maxXSpawnZone;

        [SerializeField]
        private float ySpawnLevel;

        [SerializeField]
        private float yStopLevel;

        [SerializeField]
        [Min(0)]
        private float deltaSpawnTime = 5f;

        void Start()
        {

        }

        private bool wasSpawning = false;

        void Update()
        {
            if(!wasSpawning)
            {
                wasSpawning = true;
                StartCoroutine(Spawning());
            }
        }

        private IEnumerator Spawning()
        {
            yield return new WaitForSecondsRealtime(deltaSpawnTime);
            Transform stalactite = Instantiate(StalactitePrefab).transform;
            stalactite.position = RandomSpawnPlace();
            int iterations = 100;
            for(int i = 0; i < iterations; i++)
            {
                stalactite.Translate(new Vector2(0, (yStopLevel - ySpawnLevel) / iterations));
                yield return new WaitForFixedUpdate();
            }

            iterations = 8;
            for (int i = 0; i < iterations; i++)
            {
                stalactite.Translate(new Vector2(0.2f, 0));
                yield return new WaitForSecondsRealtime(0.1f);
                stalactite.Translate(new Vector2(-0.2f, 0));
                yield return new WaitForSecondsRealtime(0.1f);
            }
            stalactite.gameObject.GetComponent<Stalactite>().IsMoving = true;
            wasSpawning = false;
        }

        private Vector2 RandomSpawnPlace()
        {
            return new Vector2(Random.Range(minXSpawnZone, maxXSpawnZone), ySpawnLevel);
        }
    }
}
