using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
        SceneManager.UnloadSceneAsync(0);
    }

    public void easy()
    {
        GameManager.setDifficulty(2);
        GameManager.gotoStage(1);
    }

    public void hard()
    {
        GameManager.setDifficulty(1);
        GameManager.gotoStage(1);
    }
}
