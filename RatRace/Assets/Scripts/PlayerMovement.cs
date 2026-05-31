using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public AudioClip walkSound;
    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource;
    private Vector2 movement;
    private Vector2 lastDirection = Vector2.down;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        bool isMoving = movement != Vector2.zero;
        animator.SetBool("isWalking", isMoving);

        if (isMoving)
        {
            lastDirection = movement;

            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                animator.SetFloat("InputX", movement.x > 0 ? 1 : -1);
                animator.SetFloat("InputY", 0);
                animator.SetFloat("LastInputX", movement.x > 0 ? 1 : -1);
                animator.SetFloat("LastInputY", 0);
            }
            else
            {
                animator.SetFloat("InputX", 0);
                animator.SetFloat("InputY", movement.y > 0 ? 1 : -1);
                animator.SetFloat("LastInputX", 0);
                animator.SetFloat("LastInputY", movement.y > 0 ? 1 : -1);
            }

            if (!audioSource.isPlaying && walkSound != null)
            {
                audioSource.clip = walkSound;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            animator.SetFloat("InputX", 0);
            animator.SetFloat("InputY", 0);
            audioSource.Stop();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * speed;
    }
}
