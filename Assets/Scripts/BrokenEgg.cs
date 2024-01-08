using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenEgg : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallSpeed;

    void Start()
    {
        fallSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }
}
