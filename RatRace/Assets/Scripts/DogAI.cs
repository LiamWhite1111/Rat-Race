using UnityEngine;
using UnityEngine.AI;

public class DogAI : MonoBehaviour
{
    public float dogSpeed = 4f;
    public float radius = 6f;
    private NavMeshAgent agent;
    private Transform target;
    private Vector3 spawnPosition;
    private Animator animator;
    private Vector2 lastDirection = Vector2.down;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = dogSpeed;
        animator = GetComponent<Animator>();
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

            Vector2 velocity = agent.velocity;
            bool isMoving = velocity.magnitude > 0.1f;
            animator.SetBool("isWalking", isMoving);

            if (isMoving)
            {
                lastDirection = velocity.normalized;

                if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
                {
                    animator.SetFloat("InputX", velocity.x > 0 ? 1 : -1);
                    animator.SetFloat("InputY", 0);
                    animator.SetFloat("LastInputX", velocity.x > 0 ? 1 : -1);
                    animator.SetFloat("LastInputY", 0);
                }
                else
                {
                    animator.SetFloat("InputX", 0);
                    animator.SetFloat("InputY", velocity.y > 0 ? 1 : -1);
                    animator.SetFloat("LastInputX", 0);
                    animator.SetFloat("LastInputY", velocity.y > 0 ? 1 : -1);
                }
            }
            else
            {
                animator.SetFloat("InputX", 0);
                animator.SetFloat("InputY", 0);
            }
        }
    }
}