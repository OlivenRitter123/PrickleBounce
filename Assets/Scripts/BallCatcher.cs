using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCatcher : MonoBehaviour
{
    public UIManager uiManager;
    public float moveDistance = 3f;
    public float moveSpeed = 2f;
    public UIManager uiManager; 

    // public GameObject winText;
    public Shooter shooter;

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private float timer;
    private bool won;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.position;

        // if (winText != null)
        //     winText.SetActive(false);
    }

    void FixedUpdate()
    {
        if (won) return;

        timer += Time.fixedDeltaTime;

        float x = startPosition.x
                  + Mathf.Sin(timer * moveSpeed) * moveDistance;

        rb.MovePosition(new Vector2(x, startPosition.y));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (won || !collision.CompareTag("Ball")) return;

        won = true;
        Destroy(collision.gameObject);

        // if (winText != null)
        //     winText.SetActive(true);

        if (shooter != null)
            shooter.enabled = false;

        Debug.Log("Gewonnen!");
        uiManager.NextLevel();
    }
}