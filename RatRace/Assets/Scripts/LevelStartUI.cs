using UnityEngine;
using TMPro;

public class LevelStartUI : MonoBehaviour
{
    public GameObject levelStartPanel;
    public TextMeshProUGUI levelText;
    public string levelName = "Level 1";

    void Start()
    {
        levelStartPanel.SetActive(true);
        levelText.text = levelName;
        Time.timeScale = 0f;
        StartCoroutine(HideLevelStart());
    }

    private System.Collections.IEnumerator HideLevelStart()
    {
        yield return new WaitForSecondsRealtime(3f);
        levelStartPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}