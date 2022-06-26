using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject iceCream;
    public GameObject apple;
    public float spawnDelay;

    public float badIceCream = 0.2f;

    private void Start()
    {
        StartCoroutine (SpawnApple());
    }

    IEnumerator SpawnApple()
    {
        while (!gameOver)
        {
            GameObject appleToSpawn = RandomToSpawn();
            float randomXPos = Random.Range(-8, 8);
            Vector3 spawnPosition = new Vector3(randomXPos, 6, 0);
            Instantiate(appleToSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(1);

        }
    }

    GameObject RandomToSpawn()
    {
        float randomNum = Random.Range(0f, 1f);
        if (randomNum< badIceCream)
        {
            return iceCream;

        }
        else
        {
            return apple;
        }
    }
}
