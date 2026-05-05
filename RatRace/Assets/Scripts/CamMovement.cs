using UnityEngine;

public class CamMovement : MonoBehaviour
{
   [SerializeField] private Transform target;
   [SerializeField] private float damptime = 0f;
   [SerializeField] private Vector3 followOffset = Vector3.zero;

   private Vector3 velocity = Vector3.zero;
   private Vector3 cameraOffset = new Vector3(0, 0, -10f);

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDes = target.position + followOffset + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetDes, ref velocity, damptime);
        
    }
}
