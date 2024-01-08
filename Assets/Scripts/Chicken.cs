using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private int id;

    public int blood;
    public AudioClip hurtSound;
    public float fallSpeed;

    public Transform preTransform;

    public Feather feather;
    public float featherFallSpeed;
    
    public Power power;
    public float powerFallSpeed;

    public Gift gift;
    public float giftFallSpeed;

    public Egg egg;
    public float eggFallSpeed;
    public float eggSeconds;
    public int type;

    public ChickenThighs chickenThighs;

    public void SetId(int id)
    {
        this.id = id;
    }

    // Start is called before the first frame update
    void Start()
    {
        blood = 3;
        fallSpeed = 0.5f;
        featherFallSpeed = 2f;
        eggFallSpeed = 1.5f;
        eggSeconds = 4f;
        powerFallSpeed = 1.5f;
        giftFallSpeed = 1.5f;
        type = 0;
        StartCoroutine(AddEgg());
    }

    // Update is called once per frame
    void Update()
    {

        switch (type)
        {
            case 1:
                MoveDownChicken();
                break;
            case 2:
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GetComponent<AudioSource>().PlayOneShot(hurtSound);
            blood -= 1;
            if (blood <= 0)
            {
                Vector3 _direction = preTransform.position;
                ChickenThighs newChickenThighs = Instantiate(chickenThighs, _direction, transform.rotation);
                Physics2D.IgnoreCollision(newChickenThighs.GetComponent<Collider2D>(), GetComponent<Collider2D>());

                if (Random.Range(1, 5) == 1)
                {
                    Instantiate(power, _direction, transform.rotation);
                };
                if (Random.Range(1, 5) == 1)
                {
                    Instantiate(gift, _direction, transform.rotation);
                };
                PreDestroy(gameObject);
            }

            Vector3 direction = preTransform.position;
            Feather newFeather = Instantiate(feather, direction, transform.rotation);

            Rigidbody2D rb = newFeather.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.down * featherFallSpeed, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Character"))
        {
            PreDestroy(gameObject);
        }
    }
        
    void PreDestroy(GameObject gameObject)
    {
        int index = FindAnyObjectByType<MainScript>()
            .renderedChickens.FindIndex(item => item.id == id);
        if (index >= 0)
        {
            FindAnyObjectByType<MainScript>()
            .renderedChickens.RemoveAt(index);
        }

        Destroy(gameObject);
    }

    void MoveDownChicken()
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
            Physics2D.IgnoreCollision(newEgg.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Rigidbody2D rb = newEgg.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.down * eggFallSpeed, ForceMode2D.Impulse);
            yield return new WaitForSeconds(Random.Range(eggSeconds, eggSeconds + 5f));
        }
    }

}
