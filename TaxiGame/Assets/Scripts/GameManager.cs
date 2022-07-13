using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject YouHaveAnOrder;
    public GameObject MapObject;
    public GameObject MapCanvas;
    public GameObject GameOver;
    public GameObject WinCanvas;
    public GameObject PauseCanvas;
    public GameObject CongratsCanvas;

    public Stopwatch stopwatch;

    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    private static int Level;
    public ScrollRect MapScrollRect;


    public GameObject[] Cars = new GameObject[6];
    private GameObject CurrentCar;

    public GameObject[] Triggers = new GameObject[6];
    private GameObject CurrentTrigger;

    public GameObject[] Cones = new GameObject[6];
    private GameObject CurrentCone;

    public Image CurrentMap;
    public Image CurrentMap_2lvl;
    public Image CurrentMap_3lvl;
    public GameObject Map;
    public GameObject Map_2lvl;
    public GameObject Map_3lvl;

    public Sprite[] Maps = new Sprite[6];

    Dictionary<int, int> threeStars = new();
    Dictionary<int, int> twoStars = new();


    void Start()
    {
        threeStars[1] = 20;
        threeStars[2] = 43;
        threeStars[3] = 60;
        threeStars[4] = 90;
        threeStars[5] = 120;

        twoStars[1] = 28;
        twoStars[2] = 60;
        twoStars[3] = 70;
        twoStars[4] = 100;
        twoStars[5] = 140;


        GameOver.SetActive(false);
        PauseCanvas.SetActive(false);
        WinCanvas.SetActive(false);
        CongratsCanvas.SetActive(false);

        MapCanvas.SetActive(true);
        MapObject.SetActive(false);
        YouHaveAnOrder.SetActive(true);

        Map.SetActive(false);
        Map_2lvl.SetActive(false);
        Map_3lvl.SetActive(false);

        Time.timeScale = 0;
        Level = LevelMenu.Level;

        CurrentCar = Cars[1];
        CurrentCone = Cones[1];
        CurrentTrigger = Triggers[1];

        SetLevel(Level);
    }

    public void SetLevel(int Level)
    {
        CurrentCar.SetActive(false);
        CurrentCone.SetActive(false);
        CurrentTrigger.SetActive(false);


        Cars[Level].SetActive(true);
        Cones[Level].SetActive(true);
        Triggers[Level].SetActive(true);

        if (Level == 2)
        {
            Map_2lvl.SetActive(true);
            MapScrollRect.content = CurrentMap_2lvl.rectTransform;
        }
        else if (Level == 3)
        {
            Map_3lvl.SetActive(true);
            MapScrollRect.content = CurrentMap_3lvl.rectTransform;
        }
        else
        {
            Map.SetActive(true);
            MapScrollRect.content = CurrentMap.rectTransform;
            CurrentMap.sprite = Maps[Level];
        }

        CurrentCar = Cars[Level];
        CurrentCone = Cones[Level];
        CurrentTrigger = Triggers[Level];

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (YouHaveAnOrder.activeSelf)
            {
                YouHaveAnOrder.SetActive(false);
                MapObject.SetActive(true);
            }
            else if (MapObject.activeSelf)
            {
                MapObject.SetActive(false);
                MapCanvas.SetActive(false);
                Time.timeScale = 1;
                stopwatch.StartStopwatch();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) Resume();
            else Pause();
        }

        if (CurrentCar.transform.position.y < 29)
        {
            GameOver.SetActive(true);
        }
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        if (Level == 5)
        {
            CongratsCanvas.SetActive(true);
        }
        else
        {
            LevelMenu.Level++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Resume()
    {
        stopwatch.StartStopwatch();

        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        stopwatch.StopStopwatch();

        PauseCanvas.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    int LastLevel = 5;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    public GameObject NextLevelButton;
    public GameObject MenuButton;
    public GameObject ContinueButton;

    public static int[] AmountOfStars = new int[6];

    public void CompleteLevel()
    {
        stopwatch.StopStopwatch();
        float time = stopwatch.CurrentTime;

        WinCanvas.SetActive(true);
        if (time < threeStars[Level])
        {
            SaveSystem.SaveLevelStars(Level, 3);
            AmountOfStars[Level] = 3;
            Star1.SetActive(true);
            Star2.SetActive(true);
            Star3.SetActive(true);
        }
        else if (time < twoStars[Level])
        {
            SaveSystem.SaveLevelStars(Level, 2);
            if (AmountOfStars[Level] == 1)
            {
                AmountOfStars[Level] = 2;
            }
            Star1.SetActive(true);
            Star2.SetActive(true);
        }
        if (time > twoStars[Level])
        {
            SaveSystem.SaveLevelStars(Level, 1);
            AmountOfStars[Level] = 1;
            Star1.SetActive(true);
        }

        if (LevelMenu.Level == LastLevel && SaveSystem.LastCompleteLevel != LastLevel)
        {
            NextLevelButton.SetActive(false);
            MenuButton.SetActive(false);
            ContinueButton.SetActive(true);
        }
    }
}