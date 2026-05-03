using UnityEngine;
using UnityEngine.AI;

public class CatAI : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 6f;
    private NavMeshAgent agent;
    private Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (target)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            float t = 1 - Mathf.Clamp01(distance / 10f);
            agent.speed = Mathf.Lerp(minSpeed, maxSpeed, t);
            agent.SetDestination(target.position);
        }
    }
}