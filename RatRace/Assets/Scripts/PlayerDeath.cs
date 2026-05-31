using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerContact : MonoBehaviour
{
    public bool isLastLevel = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You died");
            if (isLastLevel)
            {
                GameOverUI gameOverUI = FindObjectOfType<GameOverUI>();
                if (gameOverUI != null)
                {
                    gameOverUI.ShowGameOver();
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}