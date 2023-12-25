using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bulletPrefab;
    public Bullet bullet;
    public Transform bulletTransform;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Move()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = Vector3.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        Vector3 bulletStartPosition = bulletTransform.position;
        Quaternion spaceshipRotation = bulletTransform.rotation;


        Vector3 direction1 = bulletTransform.position;
        Vector3 direction2 = bulletTransform.position;
        Vector3 direction3 = bulletTransform.position;
        direction2.x -= 0.25f;
        direction3.x += 0.25f;

        Instantiate(bullet, direction1, transform.rotation);
        Instantiate(bullet, direction2, transform.rotation);
        Instantiate(bullet, direction3, transform.rotation);
    }

}
