using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
        IgnoreCollider2D(new List<string>() {"Character", "Gift", "Power", "ChickenThighs"});
        GetComponent<AudioSource>().PlayOneShot(shootSound);
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

    private void IgnoreCollider2D(List<string> tags)
    {
        tags.ForEach(item =>
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(item);
            for (int i = 0; i < gameObjects.Length; i++)
            {
                GameObject current = gameObjects[i];
                Physics2D.IgnoreCollision(current.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        });
    }
}
