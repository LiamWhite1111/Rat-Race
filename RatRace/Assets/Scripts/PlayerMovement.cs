using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    float speedX, speedY;
    Rigidbody2D rb;

    Animator anim; // Anne
    private bool facingLeft = true; //Anne
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();   
    anim = GetComponent<Animator>(); //Anne
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        rb.linearVelocity = new Vector2(speedX, speedY);

        Animate(); //Anne
        if (speedX < 0 && !facingLeft || speedX > 0 && facingLeft)
        {
            Flip();
        }
    }

    void Animate() //Anne
    {
        anim.SetFloat("MoveX", speedX);
        anim.SetFloat("MoveY", speedY);
       
    }

    void Flip() //Anne
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;

    }
}
