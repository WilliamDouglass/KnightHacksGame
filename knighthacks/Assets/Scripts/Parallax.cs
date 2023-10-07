using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class Parallax : MonoBehaviour
{
    private float legnth, startpos;
    [SerializeField] private GameObject camera;
    [SerializeField] private float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        //legnth = GetComponent<SpriteRenderer>().bounds.size.x;

        
    }

    private void FixedUpdate()
    {
        float dist = (camera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist,transform.position.y, transform.position.z);
    }
}
