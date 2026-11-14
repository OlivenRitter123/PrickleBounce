using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    private InputAction shootAction;

    public GameObject balls;
    public Transform shootPoint;
    public float shootForce = 5f;

    public int maxBalls = 10;
    private int ballsShot = 0;

    void Start()
    {
        shootAction = InputSystem.actions.FindAction("Player/Shoot", true);
        shootAction.Enable();
    }

    void Update()
    {
        if (shootAction.WasPressedThisFrame() && ballsShot < maxBalls)
        {
            GameObject ball = Instantiate(
                balls, shootPoint.position, shootPoint.rotation
            );

            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

            rb.AddForce(
                -transform.up * shootForce,
                ForceMode2D.Impulse
            );

            ballsShot++;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(
                -transform.position * shootForce,
                ForceMode2D.Impulse
            );
        }
    }
}