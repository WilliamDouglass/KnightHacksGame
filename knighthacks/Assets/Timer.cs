using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
    float timer = 200;
    private TextMeshProUGUI text;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log(timer);
        int mins = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer - (mins * 60));
        int millis = Mathf.FloorToInt(100 * (timer - (mins * 60) - seconds));
        text.text = $"{mins:D2}:{seconds:D2}:{millis:D2}";

    }
}
