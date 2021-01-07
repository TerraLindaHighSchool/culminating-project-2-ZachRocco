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
        if(lives <= 0)
        {
            gameover = true;
            Debug.Log("ship will explode here");
            gameOverText.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
        
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
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), projectilePrefab.transform.rotation);
        }
        shotCooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            previousScene = SceneManager.GetActiveScene();
            GameManager.gotoStage(-1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            lives--;
        }
    }

    public void gotoMenu()
    {
        previousScene = SceneManager.GetActiveScene();
        GameManager.gotoStage(0);
    }
}
