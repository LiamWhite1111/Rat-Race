using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndCutscene : MonoBehaviour
{
    public GameObject cutscenePanel;
    public TextMeshProUGUI cutsceneText;
    public GameObject objectiveText;
    public AudioClip cutsceneSound;
    public string[] lines;
    public int nextSceneIndex;
    private int currentLine = 0;
    private bool cutsceneActive = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cutscenePanel.SetActive(false);
    }

    public void StartCutscene()
    {
        if (lines.Length == 0)
        {
            SceneManager.LoadScene(nextSceneIndex);
            return;
        }
        Time.timeScale = 0f;
        cutscenePanel.SetActive(true);
        cutsceneActive = true;
        cutsceneText.text = lines[0];
        if (objectiveText != null) objectiveText.SetActive(false);
        if (cutsceneSound != null)
        {
            audioSource.clip = cutsceneSound;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (cutsceneActive && Input.GetKeyDown(KeyCode.Return))
        {
            NextLine();
        }
    }

    private void NextLine()
    {
        currentLine++;
        if (currentLine < lines.Length)
        {
            cutsceneText.text = lines[currentLine];
        }
        else
        {
            EndCutsceneSequence();
        }
    }

    private void EndCutsceneSequence()
    {
        cutscenePanel.SetActive(false);
        cutsceneActive = false;
        audioSource.Stop();
        if (objectiveText != null) objectiveText.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneIndex);
    }
}