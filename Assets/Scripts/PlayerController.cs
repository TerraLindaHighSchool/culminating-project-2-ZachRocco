using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    private float shotCooldown;
    public float speed = 10.0f;
    public float xRange = 20;
    public GameObject projectilePrefab;

    private float normSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        normSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //use movement ability
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = normSpeed/2;
        }
        else speed = normSpeed;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        var combinedInput = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(combinedInput.normalized * Time.deltaTime * speed);
        //keep player in bound :)
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -xRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -xRange);
        }
        if (transform.position.z > xRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, xRange);
        }

        //fire weapon
        if (Input.GetKey(KeyCode.Space) && shotCooldown <= 0.0f)
        {
            //Launch Projectile. . :D
            shotCooldown = 0.1f;
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        shotCooldown -= Time.deltaTime;

    }
}
