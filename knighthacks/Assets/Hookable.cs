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
    }
    public void AttachPlayer()
    {
        joint.enabled = true;
        player.UpdateAttach(true);
    }
    public void DetachPlayer()
    {
        joint.enabled = false;
        player.UpdateAttach(false);
    }
}
