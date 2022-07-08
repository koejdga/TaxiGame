using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    
    public static int Level;
    public Button[] levels = new Button[6];
    public ShowStars[] ShowStarsOfLevel = new ShowStars[6];


    private void Start()
    {
        for (int level = 1; level < SaveSystem.LastCompleteLevel + 1; level++)
        {
            ShowStarsOfLevel[level].DisplayStars(GameManager.AmountOfStars[level]);
        }
    }


    private void Awake()
    {
        // level1.onClick.AddListener(NoParamaterOnclick);

        levels[1].onClick.AddListener(delegate { LoadLevel(1); });
        levels[2].onClick.AddListener(delegate { LoadLevel(2); });
        levels[3].onClick.AddListener(delegate { LoadLevel(3); });
        levels[4].onClick.AddListener(delegate { LoadLevel(4); });
        levels[5].onClick.AddListener(delegate { LoadLevel(5); });
    }

    private void LoadLevel(int level)
    {
        if (level < SaveSystem.LastCompleteLevel + 2)
        {
            Level = level;
            SceneManager.LoadScene("Game");
        }
    }
}
