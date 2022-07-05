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

    public Transform Trigger;
    public Transform RedCube;
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public bool GameIsRunning = false;
    private static int Level;

    public GameObject[] Cars = new GameObject[6];
    private GameObject CurrentCar;

    public GameObject[] Triggers = new GameObject[6];
    private GameObject CurrentTrigger;

    public GameObject[] RedCubes = new GameObject[6];
    private GameObject CurrentCube;

    public Image CurrentLevel;
    public Sprite[] Maps = new Sprite[6];

    public bool FirstLoading;


    void Start()
    {
        GameOver.SetActive(false);
        PauseCanvas.SetActive(false);
        WinCanvas.SetActive(false);

        MapCanvas.SetActive(true);
        MapObject.SetActive(false);
        YouHaveAnOrder.SetActive(true);

        Time.timeScale = 0;
        Level = LevelMenu.Level;

        CurrentCar = Cars[1];
        CurrentCube = RedCubes[1];
        CurrentTrigger = Triggers[1];

        SetLevel(Level);
    }

    public void SetLevel(int Level)
    {
        CurrentCar.SetActive(false);
        CurrentCube.SetActive(false);
        CurrentTrigger.SetActive(false);

        CurrentLevel.sprite = Maps[Level];

        Cars[Level].SetActive(true);
        RedCubes[Level].SetActive(true);
        Triggers[Level].SetActive(true);

        CurrentCar = Cars[Level];
        CurrentCube = RedCubes[Level];
        CurrentTrigger = Triggers[Level];

        Debug.Log(CurrentCar);
        Debug.Log(Cars[Level]);
        Debug.Log("Hello world");

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
            // one more scene (congratulations)
            // мабуть треба зробити так, щоб не було кнопки наступний рівень після 5 рівня
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
        WinCanvas.SetActive(true);
    }


    
}