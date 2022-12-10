using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float backgroundposition;
    private Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        backgroundposition = GetComponent<BoxCollider>().size.x / 2 ;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startpos.x - backgroundposition)
        {
            transform.position = startpos;
        }
        
    }
}
