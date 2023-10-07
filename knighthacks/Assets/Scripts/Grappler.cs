using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    [SerializeField] GameObject grapple;
    [SerializeField] float projectileSpeed = 10;

    void Update()
    {
        if (Input.GetAxisRaw("Grapple") == 1)
        {
            Grapple();
        }
    }
    void Grapple()
    {
        var grappleObj = Instantiate(grapple, transform.position, GetFacingAngle(transform.position, MouseFollow.mousePos.position));
        grappleObj.GetComponent<Rigidbody2D>().velocity = grappleObj.transform.right * projectileSpeed;
    }
    public Quaternion GetFacingAngle(Vector2 origin, Vector2 target)
    {
        target.x -= origin.x;
        target.y -= origin.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
