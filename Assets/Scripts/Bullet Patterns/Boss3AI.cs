using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3AI : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject projectilePrefab1;

    private float cooldown;
    private int attackPhase;
    private GameObject player;
    private GameObject prismStyle;

    // Start is called before the first frame update
    void Start()
    {
        attackPhase = 1;
        prismStyle = projectilePrefab;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime/ GameManager.getDifficulty();
        if (transform.position.z > 22)
        {
            transform.Translate(new Vector3(0, 0, -0.05f));
        }
        else
        if (cooldown <= 0)
        {
            attack();
        }
    }

    private void switchPrismStyle()
    {
        if(prismStyle == projectilePrefab)
        {
            prismStyle = projectilePrefab1;
        }
        else
        {
            prismStyle = projectilePrefab;
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
        cooldown = 14;
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 36; i++)
        {
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 10 * i, 0));
            switchPrismStyle();
        }
        yield return new WaitForSeconds(0.5f * GameManager.getDifficulty());
        for (int i = 0; i < 36; i++)
        {
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 10 * i + 5, 0));
            switchPrismStyle();
        }
        yield return new WaitForSeconds(0.5f * GameManager.getDifficulty());
        for (int f = 0; f < 3; f++)
        {
            for (int i = 0; i < 50; i++)
            {
                Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 5 * i, 0));
                Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 5 * -i, 0));
                switchPrismStyle();
                yield return new WaitForSeconds(0.0005f);
            }
            yield return new WaitForSeconds(0.4f * GameManager.getDifficulty());
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 182, 0));
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 184, 0));
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 176, 0));
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 178, 0));
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 180, 0));
            switchPrismStyle();
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.2f * GameManager.getDifficulty());
        for (int i = 0; i < 36; i++)
        {
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 5 * i, 0));
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 5 * -i, 0));
            switchPrismStyle();
            yield return new WaitForSeconds(0.005f);
        }
        yield return new WaitForSeconds(0.25f * GameManager.getDifficulty());
        for (int i = 0; i < 200; i++)
        {
            float randomNumber = Random.Range(0, i / 25);
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 10 * i - randomNumber, 0));
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 10 * -i + randomNumber, 0));
            switchPrismStyle();
            yield return new WaitForSeconds(0.01f - 0.0001f * i);
        }
        if (GetComponent<DetectColisions>().hp <= 600)
        {
            attackPhase = 2;
            cooldown = 2;
        }
    }

    IEnumerator attack2()
    {
        cooldown = 2;
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 36; i++)
        {
            Instantiate(prismStyle, new Vector3(transform.position.x + 10 + Random.Range(-3, 3), transform.position.y, transform.position.z), Quaternion.Euler(0, 180, 0));
            switchPrismStyle();
            Instantiate(prismStyle, new Vector3(transform.position.x - 10 - Random.Range(-3, 3), transform.position.y, transform.position.z), Quaternion.Euler(0, 180, 0));
            switchPrismStyle();
            yield return new WaitForSeconds(0.075f * GameManager.getDifficulty());
        }
        for (int i = 0; i < 4; i++)
        {
            Instantiate(prismStyle, new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y, transform.position.z), Quaternion.Euler(0, 180, 0));
            switchPrismStyle();
            Instantiate(prismStyle, new Vector3(transform.position.x - Random.Range(-3, 3), transform.position.y, transform.position.z), Quaternion.Euler(0, 180, 0));
            switchPrismStyle();
            yield return new WaitForSeconds(0.075f * GameManager.getDifficulty());
        }
        for (int i = 0; i < 4; i++)
        {
            Instantiate(prismStyle, new Vector3(transform.position.x + Random.Range(25, 30), transform.position.y, Random.Range(-8, 23)), Quaternion.Euler(0, -90, 0));
            switchPrismStyle();
            Instantiate(prismStyle, new Vector3(transform.position.x - Random.Range(25, 30), transform.position.y, Random.Range(-8, 23)), Quaternion.Euler(0, 90, 0));
            switchPrismStyle();
            yield return new WaitForSeconds(0.075f * GameManager.getDifficulty());
        }
        if (GetComponent<DetectColisions>().hp <= 300)
        {
            attackPhase = 3;
            cooldown = 5;
        }
    }

    IEnumerator attack3()
    {
        cooldown = 1;
        for (int i = 0; i < 500; i++)
        {
            float randomNumber = Random.Range(0, i / 25);
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 10 * i - randomNumber, 0));
            Instantiate(prismStyle, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 10 * -i + randomNumber, 0));
            switchPrismStyle();
            yield return new WaitForSeconds(0.01f * GameManager.getDifficulty() - 0.0001f * i);
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
