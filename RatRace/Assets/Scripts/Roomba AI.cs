using UnityEngine;

public class RoombaAI : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] public float roombaSpeed = 5f;
    private int waypointIndex = 0;
    private int direction = 1;

    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypoints.Length == 0) return;

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, roombaSpeed * Time.deltaTime);

        if (transform.position == waypoints[waypointIndex].transform.position)
        {
            if (waypointIndex == waypoints.Length - 1)
            {
                direction = -1;
            }
            else if (waypointIndex == 0)
            {
                direction = 1;
            }
            waypointIndex += direction;
        }
    }
}
