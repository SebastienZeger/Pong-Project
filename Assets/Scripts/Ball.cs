using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [Header("BallHitPaddle")] public SoundCollection ballHitPaddle;
    [Header("BallHitWall")] public SoundCollection ballHitWall;
    
    public Rigidbody2D rb2d;
    private Vector2 direction;
    private AudioSource audioSource;
    [SerializeField] private float maxSpeed;

    public float speed;
    public float boostSpeed;
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.ball = this;
        ballMoveStart();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        CompareTag("Player");
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(ballHitPaddle.GetRandomClip());
            rb2d.AddForce(rb2d.velocity * boostSpeed);
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity,maxSpeed);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(ballHitWall.GetRandomClip());
        }
        
    }

    private void ballMoveStart()
    {
        float x = Random.Range(-1, 1);
        float y = Random.Range(-0.7f, 0.7f);
        if (x < 0)
        {
            x = -1;
        }
        else
        {
            x = 1;
        }
        direction = new Vector2(x, y);
        rb2d.velocity = direction * speed;
    }

    public IEnumerator RespawnBall(float directionX)
    {
        yield return new WaitForSeconds(1);
        float x = directionX;
        float y = Random.Range(-0.7f, 0.7f);
        direction = new Vector2(x, y);
        rb2d.velocity = direction * speed;
    }

    public void resetBallPos()
    {
        transform.position = Vector2.zero;
        rb2d.velocity = Vector2.zero;
    }
}
