using UnityEngine;

public class Ball : MonoBehaviour
{
    public float bounceForce = 2f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Wall"))
        {

            Vector2 direction = collision.GetContact(0).normal;

            rb.AddForce( 
                direction * bounceForce,
                ForceMode2D.Impulse
            );
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}