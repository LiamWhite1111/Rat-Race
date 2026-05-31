using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public AudioClip movementSound;
    float speedX, speedY;
    Rigidbody2D rb;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        rb.linearVelocity = new Vector2(speedX, speedY);

        if (speedX != 0 || speedY != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = movementSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
