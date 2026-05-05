using UnityEngine;

public class RoombaAI : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] public float roombaSpeed = 5f;
    private int waypointIndex = 0;
    private int direction = 1;


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypoints.Length == 0) return;

        Vector3 target = waypoints[waypointIndex].position;
        target.z = transform.position.z;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            roombaSpeed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target) < 0.05f)
        {
            if (waypointIndex == waypoints.Length - 1)
                direction = -1;
            else if (waypointIndex == 0)
                direction = 1;

            waypointIndex += direction;
        }
    }
}
