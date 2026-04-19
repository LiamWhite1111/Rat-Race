using UnityEngine;

public class cheese : MonoBehaviour
{
    public CheeseCounter cheeseCounter;

void Start()
    {
        cheeseCounter = FindFirstObjectByType<CheeseCounter>();
    }
 
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
           cheeseCounter.AddPoints(1);
        }
    }


}
