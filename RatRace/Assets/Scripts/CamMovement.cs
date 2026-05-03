using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private float dampTime = 0f;
    [SerializeField] private Vector3 followOffset = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 cameraOffset = new Vector3(0, 0, -10f);
    private Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
            return;
        }
        Vector3 targetPos = target.position + followOffset + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dampTime);
    }
}