using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hookable : MonoBehaviour
{
    [SerializeField] DistanceJoint2D joint;

    PlayerController player;
    public void Start()
    {
        player = PlayerController.instance;
        joint.connectedBody = player.GetComponent<Rigidbody2D>();
    }
    public void AttachPlayer()
    {
        joint.enabled = true;
        joint.distance = Vector2.Distance(player.transform.position, joint.transform.position);
        player.UpdateAttach(true);
    }
    public void DetachPlayer()
    {
        joint.enabled = false;
        player.UpdateAttach(false);
    }
}
