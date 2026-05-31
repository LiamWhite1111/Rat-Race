using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private float dampTime = 0.3f;
    [SerializeField] private Vector3 followOffset = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 cameraOffset = new Vector3(0, 0, -10f);
    private Transform target;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        target = player;
    }

    void Update()
    {
        if (target == null)
        {
            target = player;
            return;
        }
        Vector3 targetPos = target.position + followOffset + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dampTime, Mathf.Infinity, Time.unscaledDeltaTime);
    }

    public void LookAt(Transform newTarget, float duration)
    {
        StartCoroutine(LookAtRoutine(newTarget, duration));
    }

    private System.Collections.IEnumerator LookAtRoutine(Transform newTarget, float duration)
    {
        target = newTarget;
        yield return new WaitForSecondsRealtime(duration);
        target = player;
    }
}
