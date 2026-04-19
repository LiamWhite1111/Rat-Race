using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

 public GameObject foodPrefab;
    public int foodCount = 10;
    public float minX = -10f, maxX = 10f;
    public float minY = -10f, maxY = 10f;
    public float spawnRadius = 0.5f;
    public float minDistanceBetweenFood = 2f;

    private void SpawnFood()
    {
        Vector3 spawnPos;
        int maxAttempts = 20;
        int attempts = 0;
        do
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            spawnPos = new Vector3(x, y, 0);
            attempts++;
        } while ((Physics2D.OverlapCircle(spawnPos, spawnRadius) != null ||
                 Physics2D.OverlapCircle(spawnPos, minDistanceBetweenFood, LayerMask.GetMask("Food")) != null)
                 && attempts < maxAttempts);

        if (attempts < maxAttempts)
        {
            Instantiate(foodPrefab, spawnPos, Quaternion.identity);
        }
    }

    void Start()
    {
        for (int i = 0; i < foodCount; i++)
        {
            SpawnFood();
        }
    }
}
