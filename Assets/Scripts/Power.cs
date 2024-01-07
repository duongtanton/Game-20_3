using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public float powerFallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        powerFallSpeed = 1.5f;
        IgnoreCollider2D(new List<string>() { "Egg", "Power", "Bullet", "Gift", "Chicken", "ChickenThighs"});
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.down * powerFallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
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
