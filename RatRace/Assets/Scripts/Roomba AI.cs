using UnityEngine;

public class RoombaAI : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] public float roombaSpeed = 5f;
    private int waypointIndex = 0;
    private int direction = 1;
    private Animator animator;
    private Vector2 lastDirection = Vector2.down;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypoints.Length == 0) return;

        Vector2 moveDir = (waypoints[waypointIndex].position - transform.position).normalized;
        bool isMoving = Vector2.Distance(transform.position, waypoints[waypointIndex].position) > 0.1f;
        Debug.Log("isMoving: " + isMoving + " moveDir: " + moveDir);
        animator.SetBool("isWalking", isMoving);

        if (isMoving)
        {
            lastDirection = moveDir;

            if (Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.y))
            {
                animator.SetFloat("InputX", moveDir.x > 0 ? 1 : -1);
                animator.SetFloat("InputY", 0);
                animator.SetFloat("LastInputX", moveDir.x > 0 ? 1 : -1);
                animator.SetFloat("LastInputY", 0);
            }
            else
            {
                animator.SetFloat("InputX", 0);
                animator.SetFloat("InputY", moveDir.y > 0 ? 1 : -1);
                animator.SetFloat("LastInputX", 0);
                animator.SetFloat("LastInputY", moveDir.y > 0 ? 1 : -1);
            }
        }
        else
        {
            animator.SetFloat("InputX", 0);
            animator.SetFloat("InputY", 0);
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, roombaSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
        {
            if (waypointIndex == waypoints.Length - 1) direction = -1;
            else if (waypointIndex == 0) direction = 1;
            waypointIndex += direction;
        }
    }
}