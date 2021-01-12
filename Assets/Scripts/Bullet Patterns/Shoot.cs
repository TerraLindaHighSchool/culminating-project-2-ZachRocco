using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), projectilePrefab.transform.rotation);
    }
}
