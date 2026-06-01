using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialComplete : MonoBehaviour
{
    public GameObject tutorialCompleteUI;

    void Start()
    {
        tutorialCompleteUI.SetActive(false);
    }

    public void ShowTutorialComplete()
    {
        tutorialCompleteUI.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine(LoadNextLevel());
    }

    private System.Collections.IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
