using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public int blood;
    public AudioClip hurtSound;
    public float fallSpeed;

    public Transform preTransform;

    public Feather feather;
    public float featherFallSpeed;

    public Egg egg;
    public float eggFallSpeed;
    public float eggSeconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AddEgg());
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
            GetComponent<AudioSource>().PlayOneShot(hurtSound);
            blood -= 1;
            if (blood <= 0)
            {
                Destroy(gameObject);
            }

            Vector3 direction = preTransform.position;
            Feather newFeather =  Instantiate(feather, direction, transform.rotation);

            Rigidbody2D rb = newFeather.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.down * featherFallSpeed, ForceMode2D.Impulse);
        }
 
    }
        
    void MoveChicken()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    IEnumerator AddEgg()
    {
        yield return new WaitForSeconds(eggSeconds);
        while (true)
        {
            Vector3 direction = preTransform.position;
            Egg newEgg = Instantiate(egg, direction, transform.rotation);
            Rigidbody2D rb = newEgg.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.down * eggFallSpeed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(Random.Range(eggSeconds, eggSeconds + 5f));
        }
    }
}
