using System;
using UnityEngine;

public class ShoeSpawner : MonoBehaviour
{
    public GameObject shoePrefab;
    public float spawnInterval = 18f;
    private float elapsedTime = 0f;
    public float xRangeMin = -10f;
    public float xRangeMax = 10f;
    public float spawnHeight = 4f;

    void Update()
    {
        elapsedTime += Time.unscaledDeltaTime;

        if (elapsedTime >= spawnInterval)
        {
            SpawnShoe();
            elapsedTime = 0f;
        }
    }

    void SpawnShoe()
    {
        float spawnX = UnityEngine.Random.Range(xRangeMin, xRangeMax);
        Vector2 spawnPosition = new Vector2(spawnX, spawnHeight);
        Instantiate(shoePrefab, spawnPosition, Quaternion.identity);
    }
}
