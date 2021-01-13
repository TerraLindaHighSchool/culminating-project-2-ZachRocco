using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    private float shotCooldown;
    public float speed = 10.0f;
    private float xRange = 12;
    private float zRangePos = 23;
    private float zRangeNeg = -8;
    public GameObject projectilePrefab;
    private int lives = 3;
    public GameObject gameOverObject;
    public TextMeshProUGUI energyHUD;
    public TextMeshProUGUI livesHUD;
    public GameObject projectileDestroyer;

    private float normSpeed;
    private Scene previousScene;
    private float iframes;

    // Start is called before the first frame update
    void Start()
    {
        normSpeed = speed;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
        SceneManager.UnloadSceneAsync(previousScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            HUDManager();
            gameOverObject.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        //slow movement w/shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = normSpeed / 2;
        }
        else speed = normSpeed;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        var combinedInput = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(combinedInput.normalized * Time.deltaTime * speed);
        //keep player in bound :)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < zRangeNeg)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeNeg);
        }
        if (transform.position.z > zRangePos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangePos);
        }

        //fire weapon
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Z)) && shotCooldown <= 0.0f)
        {
            //Launch Projectile. . :D
            fireProjectile();
        }
        shotCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (GameManager.getXp(0) >= GameManager.getXp(2) + 100)
            {
                GameManager.addXp(-100);
                Instantiate(projectileDestroyer, new Vector3(transform.position.x, transform.position.y, transform.position.z), projectilePrefab.transform.rotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.addXp(25);
            Debug.Log(GameManager.getXp(0));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            previousScene = SceneManager.GetActiveScene();
            GameManager.gotoStage(-1);
        }
    }

    public void gotoMenu()
    {
        previousScene = SceneManager.GetActiveScene();
        GameManager.gotoStage(0);
    }

    public void gotoNextStage()
    {
        previousScene = SceneManager.GetActiveScene();
        GameManager.gotoStage(-1);
    }

    public void reloadStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void fireProjectile()
        {
        switch(GameManager.getLevel())
        {
            case 1:
                shotCooldown = 0.1f;
                Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), projectilePrefab.transform.rotation);
                break;
            case 2:
                shotCooldown = 0.1f;
                Instantiate(projectilePrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 2), projectilePrefab.transform.rotation);
                Instantiate(projectilePrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z + 2), projectilePrefab.transform.rotation);
                break;
            case 3:
                shotCooldown = 0.1f;
                Instantiate(projectilePrefab, new Vector3(transform.position.x + 0.75f, transform.position.y, transform.position.z + 2), Quaternion.Euler(0, 2, 0));
                Instantiate(projectilePrefab, new Vector3(transform.position.x - 0.75f, transform.position.y, transform.position.z + 2), Quaternion.Euler(0, -2, 0));
                Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), projectilePrefab.transform.rotation);
                break;
            case 4:
                shotCooldown = 0.1f;
                Instantiate(projectilePrefab, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 2), Quaternion.Euler(0, 5, 0));
                Instantiate(projectilePrefab, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 2), Quaternion.Euler(0, -5, 0));
                Instantiate(projectilePrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 2), Quaternion.Euler(0, 1, 0));
                Instantiate(projectilePrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z + 2), Quaternion.Euler(0, -1, 0));
                break;
            case 5:
                shotCooldown = 0.1f;
                Instantiate(projectilePrefab, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z + 2), Quaternion.Euler(0, 10, 0));
                Instantiate(projectilePrefab, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z + 2), Quaternion.Euler(0, -10, 0));
                Instantiate(projectilePrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 2), Quaternion.Euler(0, 5, 0));
                Instantiate(projectilePrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z + 2), Quaternion.Euler(0, -5, 0));
                Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), projectilePrefab.transform.rotation);
                break;
            default:
                break;
        }
    }

    public void LateUpdate()
    {
        HUDManager();
        iframes -= Time.deltaTime;
        Debug.Log(iframes);
    }

    private void HUDManager()
    {
        energyHUD.text = "<u>Energy</u>\n" + (GameManager.getXp(0));
        livesHUD.text = "<u>Lives</u>\n" + (lives);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && iframes <= 0)
        {
            Destroy(other.gameObject);
            lives--;
            iframes = 2;
            Instantiate(projectileDestroyer, new Vector3(transform.position.x, transform.position.y, transform.position.z), projectilePrefab.transform.rotation);
        }
    }
}
