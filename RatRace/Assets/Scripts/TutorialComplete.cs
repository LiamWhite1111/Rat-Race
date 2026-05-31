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
        StartCoroutine(LoadNextLevel());
    }

    private System.Collections.IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
