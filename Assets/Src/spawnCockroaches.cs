using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCockroaches : MonoBehaviour
{
    [SerializeField]
    private GameObject cockroach;
    [SerializeField]
    private float cooldownSeconds;
    private float timeSinceSpawn = float.MaxValue;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        
        if (timeSinceSpawn > cooldownSeconds)
        {
            SpawnCockroach();
            timeSinceSpawn = 0;
        }
       
    }

    void SpawnCockroach()
    {
        var toSpawn = Instantiate(cockroach);
        toSpawn.transform.position = new Vector2(Random.Range(-1, 1), -1);
    }
}
