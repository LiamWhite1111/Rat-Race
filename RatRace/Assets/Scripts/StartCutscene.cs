using UnityEngine;
using TMPro;

public class StartCutscene : MonoBehaviour
{
    public GameObject cutscenePanel;
    public TextMeshProUGUI cutsceneText;
    public GameObject objectiveText;
    public AudioClip cutsceneSound;
    public string[] lines;
    private int currentLine = 0;
    private bool cutsceneActive = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (cutscenePanel != null) cutscenePanel.SetActive(false);
        if (objectiveText != null) objectiveText.SetActive(false);
    }

    public void Begin()
    {
        if (lines.Length == 0)
        {
            Time.timeScale = 1f;
            if (objectiveText != null) objectiveText.SetActive(true);
            return;
        }
        Time.timeScale = 0f;
        cutscenePanel.SetActive(true);
        cutsceneActive = true;
        cutsceneText.text = lines[0];
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
            EndCutscene();
        }
    }

    private void EndCutscene()
    {
        cutscenePanel.SetActive(false);
        cutsceneActive = false;
        Time.timeScale = 1f;
        audioSource.Stop();
        if (objectiveText != null) objectiveText.SetActive(true);
    }
}
