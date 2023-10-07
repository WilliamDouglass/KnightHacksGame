using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Hook : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask destroyOnContact;

    Hookable attachedHook;
    bool isAttached = false;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3[] pos = { transform.position, PlayerController.instance.transform.position };
        lineRenderer.SetPositions(pos);
        if (isAttached)
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = attachedHook.transform.position;
        }
        if(Physics2D.Linecast(transform.position, PlayerController.instance.transform.position, destroyOnContact))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Colliding with: {other.gameObject.layer}");
        if (other.CompareTag("Hookable"))
        {
            Debug.Log("Attaching.");
            isAttached = true;
            attachedHook = other.GetComponent<Hookable>();
            attachedHook.AttachPlayer();
        }
        else if ((destroyOnContact.value & (1 << other.gameObject.layer)) > 0)
        {
            Debug.Log("Destroying.");
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        isAttached = false;
        attachedHook?.DetachPlayer();
    }
}
