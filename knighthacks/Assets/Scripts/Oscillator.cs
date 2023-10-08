using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 distance;

    Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float oscillateFactor = 0.5f * (1 + Mathf.Sin(speed * Time.time - (Mathf.PI / 2)));
        transform.position = Vector2.Lerp(startPos, startPos + distance, oscillateFactor);
    }
}
