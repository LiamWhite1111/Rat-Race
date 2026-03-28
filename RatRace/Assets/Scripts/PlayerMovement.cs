using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    float speedX, speedY;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();   

    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}
