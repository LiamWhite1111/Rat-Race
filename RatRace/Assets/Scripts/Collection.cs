using UnityEngine;

public class Collection : MonoBehaviour
{
    private bool Collected = false;

    public bool Pickup(){
        if(Collected)
        return false;

    Collected = true;
    Destroy(gameObject);
    return true;

    }
}
