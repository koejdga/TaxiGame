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

    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public bool GameIsRunning = false;
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

    public bool FirstLoading;


    void Start()
    {
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
                GameIsRunning = true;
            }
        }

        if (CurrentCar.transform.position.y < 29)
        {
            GameOver.SetActive(true);
        }

        if (GameIsRunning)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused) Resume();
                else Pause();
            }
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
            FirstLoading = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseCanvas.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CompleteLevel()
    {
        if (Level != 5)
        {
            WinCanvas.SetActive(true);
        }
        else
        {
            CongratsCanvas.SetActive(true);
        }
    }
}