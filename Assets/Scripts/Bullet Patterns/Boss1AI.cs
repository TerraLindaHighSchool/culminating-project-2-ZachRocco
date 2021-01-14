using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour
{
    public GameObject projectilePrefab;

    private float cooldown;
    private int attackPhase;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        attackPhase = 1;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime/ GameManager.getDifficulty();
        if (transform.position.z > 18)
        {
            transform.Translate(new Vector3(0, 0, -0.05f));
        }
        else
        if (cooldown <= 0)
        {
            attack();
        }
    }

    private void attack()
    {
        switch(attackPhase)
        {
            case 1:
                StartCoroutine(attack1());
                break;
            case 2:
                StartCoroutine(attack2());
                break;
            case 3:
                StartCoroutine(attack3());
                break;
            case 4:
                StartCoroutine(attack4());
                    break;
            default:
                break;
        }
    }

    IEnumerator attack1()
    {
        cooldown = 2;
        yield return new WaitForSeconds(1* GameManager.getDifficulty());
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), projectilePrefab.transform.rotation);
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 190, 0));
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 170, 0));
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(player.transform.position - transform.position));
        yield return new WaitForSeconds(1* GameManager.getDifficulty());
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), projectilePrefab.transform.rotation);
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 200, 0));
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 160, 0));
        attackPhase = 2;
        if (GetComponent<DetectColisions>().hp <= 200)
        {
            attackPhase = 3;
            cooldown = 1;
        }
    }

    IEnumerator attack2()
    {
        cooldown = 2;
        yield return new WaitForSeconds(0.2f);
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(player.transform.position - transform.position));
        yield return new WaitForSeconds(0.2f);
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(player.transform.position - transform.position));
        yield return new WaitForSeconds(0.2f);
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(player.transform.position - transform.position));
        yield return new WaitForSeconds(0.2f);
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(player.transform.position - transform.position));
        yield return new WaitForSeconds(3);
        attackPhase = 1;
        if (GetComponent<DetectColisions>().hp <= 200)
        {
            attackPhase = 3;
            cooldown = 1;
        }
    }

    IEnumerator attack3()
    {
        cooldown = 1;
        yield return new WaitForSeconds(0.5f* GameManager.getDifficulty());
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), projectilePrefab.transform.rotation);
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 190, 0));
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 170, 0));
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(player.transform.position - transform.position));
        yield return new WaitForSeconds(0.5f);
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), projectilePrefab.transform.rotation);
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 200, 0));
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 160, 0));
        if (GetComponent<DetectColisions>().hp <= 100)
        {
            attackPhase = 4;
            cooldown = 1;
        }
    }

    IEnumerator attack4()
    {
        cooldown = 1;
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.05f);
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(player.transform.position - transform.position));
            yield return new WaitForSeconds(0.05f);
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(player.transform.position - transform.position));
            yield return new WaitForSeconds(0.05f);
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(player.transform.position - transform.position));
            yield return new WaitForSeconds(0.05f);
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.LookRotation(player.transform.position - transform.position));
        }
    }
}
