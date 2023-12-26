using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{

    public int blood;
    public float moveSpeed = 2.0f;
    public AudioClip hurtSound;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       MoveChicken();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            blood -= 1;
            GetComponent<AudioSource>().PlayOneShot(hurtSound);
            if (blood <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void MoveChicken()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

}
