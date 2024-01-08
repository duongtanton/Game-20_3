using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public float totalTime = 0f;
    private float currentTime;
    private bool stop;

    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        textMeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            currentTime += Time.deltaTime;
            string minutes = Mathf.Floor(currentTime / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");
            int milliseconds = Mathf.FloorToInt((currentTime * 1000) % 1000);

            textMeshPro.text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }
}
