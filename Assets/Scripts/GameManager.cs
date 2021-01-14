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
    private static int xpRequirement = 100;
    private static int maxLevel = 5;
    private static int maxXp = 500;
    private static float difficulty = 1;

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
                return xpRequirement;
            default:
                return 0;
        }
    }

    private static void checkLevel()
    {
        level = xp / 100 + 1;
        if(level > maxLevel)
        {
            level = maxLevel;
        }
        /*if(xp >= xp_requirement)
        {
            if (max_level > level)
            {
                //last_xp_requirement = xp_requirement;
                //xp_requirement += 100;
            }
            else
            {
                if(xp > xp_requirement)
                {
                    xp = xp_requirement;
                }
            }
        }*/
        if(xp > maxXp)
        {
            xp = maxXp;
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

    public static void setDifficulty(float input)
    {
        difficulty = input;
    }

    public static float getDifficulty()
    {
        return difficulty;
    }
}
