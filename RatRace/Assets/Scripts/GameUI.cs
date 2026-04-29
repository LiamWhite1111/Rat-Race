using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI cheeseCount;
    public TextMeshProUGUI Objective;
    private Inventory inventory;
    public TextMeshProUGUI gameOver;
    public bool isLastLevel = false;

    void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        cheeseCount.text = "Cheese: " + inventory.currentinv + "/" + inventory.maxinv;

        if (inventory.currentinv < inventory.maxinv)
        {
            Objective.text = "Collect " + (inventory.maxinv - inventory.currentinv) + " more cheese to exit and watch out for enemies!";
        }
        else
        {
            Objective.text = "Return to spawn point!";
        }
    }
}