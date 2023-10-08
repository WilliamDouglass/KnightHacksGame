using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Timer timer = FindObjectOfType<Timer>();
        timer?.StopTimer();
    }
}
