using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour
{
    float timer = 0;
    private TextMeshProUGUI text;
    bool isActive = true;

    public void StopTimer()
    {
        isActive = false;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            int mins = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer - (mins * 60));
            int millis = Mathf.FloorToInt(100 * (timer - (mins * 60) - seconds));
            text.text = $"{mins:D2}:{seconds:D2}:{millis:D2}";
        }
    }
}
