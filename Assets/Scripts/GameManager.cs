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

    private static int level = 1;
    private static int xp;
    private static int xp_requirement = 100;
    private static int last_xp_requirement;
    private static int max_level = 5;

    public static void addXp(int xpToAdd)
    {
        xp += xpToAdd;
        checkLevel();
    }

    public static int getLevel()
    {
        return level;
    }

    public static int getXp(int type)
    {
        switch(type)
        {
            case 0:
                return xp;
            case 1:
                return xp_requirement;
            case 2:
                return last_xp_requirement;
            default:
                return 0;
        }
    }

    private static void checkLevel()
    {
        if(xp >= xp_requirement)
        {
            if (max_level > level)
            {
                last_xp_requirement = xp_requirement;
                xp_requirement += level * 50;
                level++;
            }
            else
            {
                if(xp > xp_requirement)
                {
                    xp = xp_requirement;
                }
            }
        }
        if(xp < last_xp_requirement)
        {
            xp = last_xp_requirement;
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
