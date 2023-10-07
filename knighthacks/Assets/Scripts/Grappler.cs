using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    [SerializeField] GameObject grapplePrefab = null;
    [SerializeField] float projectileSpeed = 10;
    [SerializeField] float cooldown = 1;

    GameObject grappleObj = null;
    bool canFire = true;

    void Update()
    {
        if (Input.GetAxisRaw("Grapple") == 1 && canFire && grappleObj == null)
        {
            Debug.Log("Firing.");
            Grapple();
            StartCoroutine(Cooldown());
        } 
        else if(Input.GetAxisRaw("Grapple") == 1 && canFire && grappleObj != null)
        {
            Debug.Log("Retracting.");
            Destroy(grappleObj);
            StartCoroutine(Cooldown());
        }
    }
    void Grapple()
    {
        grappleObj = Instantiate(grapplePrefab, transform.position, GetFacingAngle(transform.position, MouseFollow.mousePos.position), transform);
        grappleObj.GetComponent<Rigidbody2D>().velocity = grappleObj.transform.right * projectileSpeed;
    }
    public Quaternion GetFacingAngle(Vector2 origin, Vector2 target)
    {
        target.x -= origin.x;
        target.y -= origin.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(new Vector3(0, 0, angle));
    }
    IEnumerator Cooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }
}
