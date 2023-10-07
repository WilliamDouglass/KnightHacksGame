using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float smoothing = 0.1f;
    [SerializeField] BoxCollider2D viewBox = null;

    bool isFollowing = true;
    PlayerController player;
    Camera cam;
    
    void Start()
    {
        player = PlayerController.instance;
        cam = GetComponent<Camera>();
        CenterCamera();
    }
    void FixedUpdate()
    {
        FollowPlayer();
    }
    public void SetViewbox(BoxCollider2D viewBox)
    {
        this.viewBox = viewBox;
    }
    public void SetCameraSize(float size)
    {
        cam.orthographicSize = size;
    }
    public void CenterCamera()
    {
        transform.position = GetClampedPos();
    }
    public void SetFollowing(bool isFollowing)
    {
        this.isFollowing = isFollowing;
    }
    private Vector3 GetClampedPos()
    {
        var min = viewBox.bounds.min;
        var max = viewBox.bounds.max;
        var x = player.transform.position.x;
        var y = player.transform.position.y;

        // Ortho size (Distance from center to top) multiplied by resolution for dist from center to side of screen
        var cameraHalfX = cam.orthographicSize * ((float)Screen.width / Screen.height);

        // Ensures camera stays within view box bounds
        x = Mathf.Clamp(x, min.x + cameraHalfX, max.x - cameraHalfX);
        y = Mathf.Clamp(y, min.y + cam.orthographicSize, max.y - cam.orthographicSize);

        return new Vector3(x, y, transform.position.z);

    }
    void FollowPlayer()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, GetClampedPos(), smoothing);
        }
    }
}