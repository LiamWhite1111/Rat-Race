
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public Transform exitObject;
    public Transform enemyObject;
    public Transform cheeseObject;
    public TextMeshProUGUI tutorialText;
    private CamMovement cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CamMovement>();
        tutorialText.text = "";
        StartCoroutine(TutorialSequence());
    }

    private System.Collections.IEnumerator TutorialSequence()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 0f;

        ShowText("Collect the cheese!");
        cam.LookAt(cheeseObject, 3f);
        yield return new WaitForSecondsRealtime(4f);

        ShowText("Return to spawn to complete the level!");
        cam.LookAt(exitObject, 3f);
        yield return new WaitForSecondsRealtime(4f);

        ShowText("Watch out for enemies!");
        cam.LookAt(enemyObject, 3f);
        yield return new WaitForSecondsRealtime(4f);

        ShowText("Good luck!");
        yield return new WaitForSecondsRealtime(2f);
        tutorialText.text = "";
        Time.timeScale = 1f;
    }

    public void ShowText(string message)
    {
        tutorialText.text = message;
    }
}

