using UnityEngine;

public static class SaveSystem
{

    public static int LastCompleteLevel = 0;
    public static int[] LevelStars = new int[6];

    public static void SaveLastCompleteLevel()
    {
        PlayerPrefs.SetInt("LastComleteLevel", LastCompleteLevel);
    }

    public static void SaveLevelStars(int Level, int LevelStars)
    {
        if (Level == 1)
        {
            PlayerPrefs.SetInt("1levelStars", LevelStars);
        }
        else if (Level == 2)
        {
            PlayerPrefs.SetInt("2levelStars", LevelStars);
        }
        else if (Level == 3)
        {
            PlayerPrefs.SetInt("3levelStars", LevelStars);
        }
        else if (Level == 4)
        {
            PlayerPrefs.SetInt("4levelStars", LevelStars);
        }
        else if (Level == 5)
        {
            PlayerPrefs.SetInt("5levelStars", LevelStars);
        }
    }

    public static void LoadProgress()
    {
        LastCompleteLevel = PlayerPrefs.GetInt("LastComleteLevel", 0);
        GameManager.AmountOfStars[1] = PlayerPrefs.GetInt("1levelStars", 0);
        GameManager.AmountOfStars[2] = PlayerPrefs.GetInt("2levelStars", 0);
        GameManager.AmountOfStars[3] = PlayerPrefs.GetInt("3levelStars", 0);
        GameManager.AmountOfStars[4] = PlayerPrefs.GetInt("4levelStars", 0);
        GameManager.AmountOfStars[5] = PlayerPrefs.GetInt("5levelStars", 0);
    }

    public static void ResetProgress()
    {
        LevelMenu.isReset = true;

        PlayerPrefs.SetInt("LastComleteLevel", 0);
        PlayerPrefs.SetInt("1levelStars", 0);
        PlayerPrefs.SetInt("2levelStars", 0);
        PlayerPrefs.SetInt("3levelStars", 0);
        PlayerPrefs.SetInt("4levelStars", 0);
        PlayerPrefs.SetInt("5levelStars", 0);
        LastCompleteLevel = 0;
        GameManager.AmountOfStars[1] = 0;
        GameManager.AmountOfStars[2] = 0;
        GameManager.AmountOfStars[3] = 0;
        GameManager.AmountOfStars[4] = 0;
        GameManager.AmountOfStars[5] = 0;
    }
}
