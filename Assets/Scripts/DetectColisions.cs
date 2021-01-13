using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectColisions : MonoBehaviour
{
    public int hp = 10;

    public GameObject projectileDestroyer;
    public GameObject completionScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Instantiate(projectileDestroyer, new Vector3(transform.position.x, transform.position.y, transform.position.z), gameObject.transform.rotation);
            completionScreen.SetActive(true);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            hp--;
            if (Random.Range(0, 100) > 50)
            {
                GameManager.addXp(1);
            }
        }
    }
}
