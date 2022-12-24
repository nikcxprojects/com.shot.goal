using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float force = 25;
    private Vector2 LastVelocity { get; set; }
    private Rigidbody2D Rigidbody { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = FindObjectOfType<Player>().transform.position + Vector3.up * 0.25f;
        Rigidbody.velocity = Player.Velocity.normalized * force;
    }

    private void Update()
    {
        LastVelocity = Rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = LastVelocity.magnitude;

        Vector2 direction = Vector2.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        Rigidbody.velocity = direction * Mathf.Max(speed, 0);
    }
}
