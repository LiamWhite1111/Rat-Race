using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelEndUI : MonoBehaviour
{
    public GameObject levelEndPanel;
    public TextMeshProUGUI levelEndText;
    public string levelEndMessage = "Level Complete!";

    void Start()
    {
        levelEndPanel.SetActive(false);
    }

    public void ShowLevelEnd()
    {
        EndCutscene endCutscene = FindObjectOfType<EndCutscene>();
        if (endCutscene != null)
        {
            endCutscene.StartCutscene();
        }
        else
        {
            levelEndPanel.SetActive(true);
            levelEndText.text = levelEndMessage;
            Time.timeScale = 0f;
            StartCoroutine(LoadNextScene());
        }
    }

    private System.Collections.IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

