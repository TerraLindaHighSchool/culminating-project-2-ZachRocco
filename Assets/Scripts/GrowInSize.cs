using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowInSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(Time.deltaTime * 50, Time.deltaTime * 50, Time.deltaTime * 50);
        if(transform.localScale.x >= 100)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
