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
    public Transform Car;
    public Transform Trigger;
    public Transform RedCube;
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public bool GameIsRunning = false;
    private static int Level;
    bool FirstLoading = true;

    // public Transform[] TriggerPositions = new Transform[6];
    public Transform[] FinishPositions = new Transform[6];

    public Transform[] CarPositions = new Transform[6];

    public Image CurrentLevel;
    public Sprite[] Maps = new Sprite[6];




    void Start()
    {
        // CurrentLevel.sprite = levels[];
        GameOver.SetActive(false);
        PauseCanvas.SetActive(false);
        WinCanvas.SetActive(false);

        MapCanvas.SetActive(true);
        MapObject.SetActive(false);
        YouHaveAnOrder.SetActive(true);



        Time.timeScale = 0;
        Level = LevelMenu.Level;
        
        SetLevel(Level);
    }

    public void SetLevel(int Level)
    {
        CurrentLevel.sprite = Maps[Level];
        Car = CarPositions[Level];
        Trigger = FinishPositions[Level];
        RedCube = FinishPositions[Level];

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

        if (Car.position.y < 29)
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


















class LevelData
{
    int numberOfLevels = 5;

    public Image CurrentLevel;
    public Sprite[] levels = new Sprite[5];
    public Transform[] car = new Transform[5];
    public Transform[] trigger = new Transform[5];
    public Transform[] redPoint = new Transform[5];


    LevelData()
    {
        
    }


}