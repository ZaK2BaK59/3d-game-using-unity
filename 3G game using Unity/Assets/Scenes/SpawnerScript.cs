using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour
{
    public GameObject cubePrefab;
    public float spawnInterval = 3f;
    public float fallSpeed = 1f; 
    public float minRandomVelocity = -1f; 
    public float maxRandomVelocity = 1f;  

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            float randomX = Random.Range(transform.position.x - 3.5f, transform.position.x + 3.5f);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

            GameObject spawnedCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            Rigidbody cubeRigidbody = spawnedCube.GetComponent<Rigidbody>();

            if (cubeRigidbody != null)
            {
                
                float randomVelocityX = Random.Range(minRandomVelocity, maxRandomVelocity);
                float randomVelocityY = Random.Range(-fallSpeed, -fallSpeed); 
                Vector3 randomFallVelocity = new Vector3(randomVelocityX, randomVelocityY, 0f);

                cubeRigidbody.velocity = randomFallVelocity;
            }

            timer = 0f;
        }
    }
}
