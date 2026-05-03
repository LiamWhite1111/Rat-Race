using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public int sceneBuildIndex;
    public int requiredFood = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory.currentinv >= requiredFood)
            {
                Debug.Log("Switching to scene " + sceneBuildIndex);
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
            else
            {
                Debug.Log("Need " + (requiredFood - inventory.currentinv) + " more food to exit!");
            }
        }
    }
}