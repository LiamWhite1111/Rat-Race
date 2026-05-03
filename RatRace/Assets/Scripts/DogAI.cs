using UnityEngine;
using UnityEngine.AI;

public class DogAI : MonoBehaviour
{
    public float dogSpeed = 4f;
    public float radius = 6f;
    private NavMeshAgent agent;
    private Transform target;
    private Vector3 spawnPosition;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = dogSpeed;
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
        spawnPosition = transform.position;
    }

    void Update()
    {
        if (target)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance <= radius)
            {
                agent.SetDestination(target.position);
            }
            else
            {
                agent.SetDestination(spawnPosition);
            }
        }
    }
}
