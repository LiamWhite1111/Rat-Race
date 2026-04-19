using TMPro;
using UnityEngine;

public class CheeseCounter : MonoBehaviour
{
   
   [SerializeField] TextMeshProUGUI cheeseCounter;

   int points = 0;

   public void AddPoints(int additionalPoints)
    {
        points += additionalPoints;
        cheeseCounter.text = "Cheese Collected: " + points;
    }

}    



