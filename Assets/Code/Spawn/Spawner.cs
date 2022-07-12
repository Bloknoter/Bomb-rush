using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab;

    [SerializeField]
    [Min(0.1f)]
    private float SpawningTime;

    [SerializeField]
    [Min(0.1f)]
    private float MinSpawningTime;

    [SerializeField]
    [Min(0.1f)]
    private float TimeMultiplier;

    [SerializeField]
    private float MinXPosition;

    [SerializeField]
    private float MaxXPosition;

    [SerializeField]
    private float YPosition;

    void Start()
    {
        
    }

    private bool wasSpawning;
    void Update()
    {
        if (!wasSpawning)
        {
            wasSpawning = true;
            StartCoroutine(Spawning());
        }
    }

    private IEnumerator Spawning()
    {
        yield return new WaitForSeconds(SpawningTime);
        GameObject item = Instantiate(Prefab);
        item.transform.position = new Vector2(Random.Range(MinXPosition, MaxXPosition), YPosition);
        item.transform.rotation = Quaternion.Euler(0, 0, Random.Range(120f, 240f));
        if (SpawningTime > MinSpawningTime)
            SpawningTime *= TimeMultiplier;
        wasSpawning = false;
    }
}
