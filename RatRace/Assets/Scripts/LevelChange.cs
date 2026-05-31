using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public int sceneBuildIndex;
    public bool isLevelEnd = false;
    public bool isLastLevel = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory.currentinv >= inventory.requiredFood)
            {
                if (isLastLevel)
                {
                    GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
                    if (gameOverUI != null) gameOverUI.ShowGameOver();
                }
                else if (isLevelEnd)
                {
                    LevelEndUI levelEndUI = FindObjectOfType<LevelEndUI>();
                    if (levelEndUI != null) levelEndUI.ShowLevelEnd();
                }
                else
                {
                    TutorialComplete tutorialComplete = FindObjectOfType<TutorialComplete>();
                    if (tutorialComplete != null)
                    {
                        tutorialComplete.ShowTutorialComplete();
                    }
                    else
                    {
                        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                    }
                }
            }
            else
            {
                Debug.Log("Need " + (inventory.requiredFood - inventory.currentinv) + " more food to exit!");
            }
        }
    }
}