using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPaddle : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float direction;

    public float speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        var movement = new Vector2(0, direction * speed);
        rb2d.velocity = movement;
    }

    public void OnMove(InputValue value)
    {
        direction = value.Get<float>();

    }

}
