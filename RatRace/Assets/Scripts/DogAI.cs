using UnityEngine;

public class DogAI : MonoBehaviour
{
    public float dogSpeed = 4f;
    public float radius = 6f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    Vector3 spawnPosition;

    private void Awake()
    {
    rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.Find("Player").transform;
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target){
            float distance = Vector3.Distance(transform.position, target.position);
            if(distance <= radius){
                Vector3 direction = (target.position - transform.position).normalized;
                moveDirection = direction;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
            } else {
                Vector3 direction = (spawnPosition - transform.position).normalized;
                moveDirection = direction;
                if(Vector3.Distance(transform.position, spawnPosition) < 0.1f){
                    moveDirection = Vector2.zero;
                }
            }
        }
        
    }
    private void FixedUpdate(){
        if(target){
            rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * dogSpeed;
        }
    }
}
