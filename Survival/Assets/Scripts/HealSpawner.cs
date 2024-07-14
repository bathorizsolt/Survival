using UnityEngine;

public class HealSpawner : MonoBehaviour
{
    public GameObject healPrefab;
    public float spawnInterval = 10f;
    public float xRangeMin = -13f;
    public float xRangeMax = 13f;
    public float spawnHeight = 4f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnHeal), spawnInterval, spawnInterval);
    }

    private void SpawnHeal()
    {
        float randomX = Random.Range(xRangeMin, xRangeMax);
        Vector2 spawnPosition = new Vector2(randomX, spawnHeight);
        Instantiate(healPrefab, spawnPosition, Quaternion.identity);
    }

}