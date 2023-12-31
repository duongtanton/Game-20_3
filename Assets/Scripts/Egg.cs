using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{

    public BrokenEgg brokenEgg;

    // Start is called before the first frame update
    void Start()
    {
        IgnoreCollider2D(new List<string>() { "Gift", "Power", "Chicken", "Egg"});
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        // Destroy the bullet when it goes off-screen
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Character"))
        {
            Vector3 direction = transform.position;
            Instantiate(brokenEgg, direction, transform.rotation);
            Destroy(gameObject);
        }
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
