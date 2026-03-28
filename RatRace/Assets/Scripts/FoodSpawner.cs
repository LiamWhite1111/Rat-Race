using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

 public GameObject foodPrefab;
    public int foodCount = 10;
    public float minX = -10f, maxX = 10f;
    public float minY = -10f, maxY = 10f;

    private void SpawnFood(){
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Instantiate(foodPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < foodCount; i++){
            SpawnFood();
        }
    }    
}
