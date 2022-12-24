using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int health;
    private int Health
    {
        get => health;
        set
        {
            health = value;

            if(health <= 0)
            {
                GetComponent<Rigidbody2D>().isKinematic = false;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(gameObject, 2.0f);
            }
        }
    }

    private Animation Animation { get; set; }

    public static Action OnCollisionEnter { get; set; }

    private void Start()
    {
        Animation = GetComponent<Animation>();
        Health = 1;
    }

    public void MoveDown()
    {
        transform.position += Vector3.down * 0.6f;
    }

    private void OnCollisionEnter2D()
    {
        OnCollisionEnter?.Invoke();
        Health--;
    }
}
