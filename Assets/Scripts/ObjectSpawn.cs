using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> objToSpawnUp = new(), objToSpawnDown = new(), spawners = new();
    [SerializeField] float randValue;
    [SerializeField] Transform playerTransform;
    [SerializeField] float transformValue;

    private void Update()
    {
        RandSpawn();
    }

    void RandSpawn()
    {
        if(playerTransform.position.x > transformValue)
        {
            randValue = Random.Range(0, 2);
            if (randValue == 0)
            {
                SpawnDown();
            }
            else if(randValue == 1)
            {
                SpawnUp();
            }

            transformValue += 5;
        }

    }

    void SpawnDown()
    {
        float rand = Random.Range(0, 3);
        if(rand == 0)
        {
            Instantiate(objToSpawnDown[0], spawners[0].transform.position, Quaternion.identity);
        }
        else if( rand == 1)
        {
            Instantiate(objToSpawnDown[1], spawners[0].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(objToSpawnDown[2], spawners[0].transform.position, Quaternion.identity);
        }
    }

    void SpawnUp()
    {
        float rand = Random.Range(0, 1);
        if (rand == 0)
        {
            Instantiate(objToSpawnUp[0], spawners[1].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(objToSpawnUp[1], spawners[1].transform.position, Quaternion.identity);
        }
    }

}
