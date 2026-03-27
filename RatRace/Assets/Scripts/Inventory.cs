using UnityEngine;

public class Inventory : MonoBehaviour
{
	public int maxinv = 5;
	private int currentinv = 0;

	private void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Collectible")){
			Pickup(other.GetComponent<Collection>());

		}
	}

	private void Pickup(Collection collectible){
	if(collectible is FoodCollection){
		if(currentinv>= maxinv){
			Debug.Log("Inventory Full");
			return;
			}
		if(collectible.Pickup()){
			currentinv ++;
			Debug.Log("Food Collected: "+ currentinv + "/" + maxinv);
			}
		}
	}


}
