using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 10.0f;
    private float timeSinceLastSpawn = 0.0f;
    private int prefabCount = 0;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval && prefabCount < 6)
        {
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
            prefabCount++;
            timeSinceLastSpawn = 0.0f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}
