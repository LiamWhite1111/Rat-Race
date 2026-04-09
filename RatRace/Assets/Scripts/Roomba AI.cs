using UnityEngine;

public class RoombaAI : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    public float roombaSpeed = 5f;

    private int waypointIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
    if (waypointIndex <= waypoints.Length - 1){
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, roombaSpeed * Time.deltaTime);
        if(transform.position == waypoints[waypointIndex].transform.position){
            waypointIndex = (waypointIndex + 1)  % waypoints.Length;
        }
    }
    }
}
