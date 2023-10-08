using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Grappler : MonoBehaviour
{
    [SerializeField] GameObject grapplePrefab = null;
    [SerializeField] float cooldown = 1;
    [SerializeField] float seekRange = 10;

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
        GameObject closest = null;
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        var targetsInRange = Physics2D.OverlapCircleAll(transform.position, seekRange);
        float leastDistance = Mathf.Infinity;
        foreach (var target in targetsInRange)
        {
            var squaredDist = (target.gameObject.transform.position - mousePos).sqrMagnitude;
            //if (squaredDist < leastDistance && (targetLayers.value >> target.gameObject.layer) == 1) // Checks if potential target's layer is in the set layermask
            if (squaredDist < leastDistance && target.CompareTag("Hookable"))
            {
                closest = target.gameObject;
                leastDistance = squaredDist;
            }
        }
        if(closest != null)
        {
            grappleObj = Instantiate(grapplePrefab, closest.transform.position, transform.rotation, transform);
        }
        
    }
    IEnumerator Cooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }
}
