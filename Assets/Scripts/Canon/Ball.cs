
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float bounceForce = 2f;
    public AudioClip bounceSound;

    private Rigidbody2D rb;
    private AudioSource audioSource;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || 
            collision.gameObject.CompareTag("Wall"))
        {
            Vector2 direction = collision.GetContact(0).normal;

            rb.AddForce(
                direction * bounceForce,
                ForceMode2D.Impulse
            );

            // 50 % Wahrscheinlichkeit
            if (Random.value < 0.5f && bounceSound != null)
            {
                audioSource.PlayOneShot(bounceSound);
            }

            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
