using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager
{
    private static int currentStage = 0;


    /*public static int getLives()
    {
        return lives;
    }

    public static void setLives(int value)
    {
        lives = value;
    }*/

    private static bool[] upgrades = new bool[] { false, false, false, false, false, false };

    /*
     * upgrade list:
     * none haha
     */

    public static void setUpgrade(int index, bool tf)
    {
        upgrades[index] = tf;
    }

    public static void resetUpgrade()
    {
        for(int i = 1; i < upgrades.Length; i++)
        {
            upgrades[i] = false;
        }
    }

    public static int gotoStage(int stage)
    {
        if(stage == -1)
        {
            stage = currentStage + 1;
        }

        SceneManager.LoadScene(stage);
        currentStage = stage;
        return stage;
    }

    public static int getStage()
    {
        return currentStage;
    }
}
