using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public Transform chickenTransform;
    public int numberOfChickens;
    public int rowOfChickens;
    public Transform gameOverPrefab;
    public AudioClip backgoundSound;
    public List<Chicken> chickens;
    public List<Chicken> renderedChickens;
    public List<Heart> hearts;
    public GameOver gameOver;
    public Character character;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = backgoundSound;
        audioSource.volume -= 0.9f;
        audioSource.Play();
        renderedChickens = new List<Chicken>();
        StartCoroutine(DelayedFunction());
    }

    // Coroutine for delayed execution
    IEnumerator DelayedFunction()
    {
        yield return new WaitForSeconds(1.5f);
        SpawnChickens();
        StartCoroutine(Stage1());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Rendered chicken: " + renderedChickens.Count);
    }

    private void SpawnChickens()
    {
        // Spawn multiple chickens
        Vector3 position = chickenTransform.position;
        for (int i = 0; i < rowOfChickens; i++)
        {
            Chicken chicken = chickens[Random.Range(0, chickens.Count)];
            Renderer renderer = chicken.GetComponent<Renderer>();
            position.y -= renderer.bounds.size.y + 0.1f;
            for (int j = 0; j < numberOfChickens; j++)
            {
                chicken.SetId(i * numberOfChickens + (j + 1));
                renderedChickens.Add(chicken);
                Instantiate(chicken, position, transform.rotation);
            }
        }
    }

    public bool ChangeHeart(int sparate)
    {
        int countRendered = 0;
        hearts.ForEach(item =>
        {
            if (item.getActive())
            {
                countRendered++;
            }
        });
        if (sparate > 0 && countRendered < 5) {
            hearts[countRendered].setActive(true);
        }
        if (sparate < 0 && countRendered > 0)
        {
            hearts[countRendered - 1].setActive(false);
        }
        if (countRendered == 1 && sparate < 0)
        {
            Instantiate(gameOver, gameOverPrefab.position, transform.rotation);
            return true;
        }
        return false;
    }

    private IEnumerator Stage1()
    {
        yield return new WaitForSeconds(5f);

        renderedChickens.ForEach(chicken =>{
            chicken.type = 1;
        });
    }
}
