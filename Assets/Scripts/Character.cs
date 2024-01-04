using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Transform bulletTransform;
    public float rotationAmount;
    public float moveSpeed;
    public int bulletType;
    public int power;
    public Bullet bullet;
    public List<Bullet> bullets;
    public Explosion explosion;
    public AudioClip pickupItem;
    public PlusOne plusOne;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Rotate()
    {

    }
    void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        transform.position += moveVelocity * Time.deltaTime;

        float screenWidth = Camera.main.orthographicSize * 2 * Screen.width / Screen.height;
        float screenHeight = Camera.main.orthographicSize * 2;
        float minX = -screenWidth / 2;
        float maxX = screenWidth / 2;
        float minY = -screenHeight / 2;
        float maxY = screenHeight / 2;

        Vector2 size = GetSize(gameObject) + new Vector2(-0.5f, -0.5f);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX + size.x, maxX - size.x),
            Mathf.Clamp(transform.position.y, minY + size.y, maxY - size.y),
            transform.position.z
        );

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        switch (bulletType)
        {
            case 2:
                break;
            case 1:
            default:
                //bulletType == 1
                ShootBullet1();
                break;
        }
    }

    Vector2 GetSize(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();

        if (renderer != null)
        {
            return new Vector2(renderer.bounds.size.x, renderer.bounds.size.y);
        }
        else
        {
            Debug.LogError("Renderer component not found on the GameObject.");
            return Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            Explosion();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Egg"))
        {
            Explosion();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Power"))
        {
            GetComponent<AudioSource>().PlayOneShot(pickupItem);
        }
        if (collision.gameObject.CompareTag("ChickenThighs"))
        {
            GetComponent<AudioSource>().PlayOneShot(pickupItem);
            Vector3 direction = bulletTransform.position;
            direction.x += 0.5f;
            Instantiate(plusOne, direction, transform.rotation);
        }
    }

    private void ShootBullet1()
    {
        Bullet bullet = bullets[Random.Range(0, bullets.Count)];
        int center = power / 2;
        int redundant = power % 2;
        if (redundant == 1)
        {
            Vector3 direction = bulletTransform.position;
            Instantiate(bullet, direction, transform.rotation);
        }
        for (int i = 1; i <= center; i++)
        {
            Vector3 direction1 = bulletTransform.position;
            direction1.x += 0.25f * (i);
            Instantiate(bullet, direction1, transform.rotation);

            Vector3 direction2 = bulletTransform.position;
            direction2.x -= 0.25f * (i);
            Instantiate(bullet, direction2, transform.rotation);
        }
    }

    private void Explosion()
    {
        Vector3 direction = bulletTransform.position;
        Instantiate(explosion, direction, transform.rotation);
    }
}
