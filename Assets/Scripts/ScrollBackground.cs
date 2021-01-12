using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private Vector3 initialTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        initialTransform = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -15.0f * Time.deltaTime);
        if(transform.position.z <= -20)
        {
            transform.position = initialTransform;
        }
    }
}
