using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookable : MonoBehaviour
{
    [SerializeField] DistanceJoint2D joint;
    public void AttachPlayer()
    {
        joint.enabled = true;
    }
    public void DetachPlayer()
    {
        joint.enabled = false;
    }
}
