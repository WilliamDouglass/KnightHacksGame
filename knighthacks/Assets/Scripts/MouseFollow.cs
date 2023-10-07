using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public static Transform mousePos;
    Camera mainCamera;
    private void Awake()
    {
        mousePos = transform;
        mainCamera = Camera.main;
    }
    private void Update()
    {
        transform.position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

}