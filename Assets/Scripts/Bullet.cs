using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 12;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // Move the bullet upward
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Destroy the bullet when it goes off-screen
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
