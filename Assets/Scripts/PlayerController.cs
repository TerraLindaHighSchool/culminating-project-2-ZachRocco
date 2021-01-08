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
    public float xRange = 20;
    public GameObject projectilePrefab;
    private int lives = 3;
    private bool gameover;
    public TextMeshProUGUI gameOverText;
    public GameObject menuButton;
    public TextMeshProUGUI HUD;

    private float normSpeed;
    private Scene previousScene;

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
        HUDManager();

        if (lives <= 0)
        {
            gameover = true;
            Debug.Log("ship will explode here");
            gameOverText.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
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
        if (transform.position.z < -xRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -xRange);
        }
        if (transform.position.z > xRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, xRange);
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
            if (GameManager.getXp(0) >= GameManager.getXp(2) + 50)
            {
                GameManager.addXp(-50);
                Debug.Log("bomb " + GameManager.getXp(0));
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

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log(GameManager.getLevel() + ", " + GameManager.getXp(1) + ", " + GameManager.getXp(2));
        }
    }

    public void gotoMenu()
    {
        previousScene = SceneManager.GetActiveScene();
        GameManager.gotoStage(0);
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
    }

    private void HUDManager()
    {
        HUD.text = "Xp: " + (GameManager.getXp(0) - GameManager.getXp(2));
    }
}
