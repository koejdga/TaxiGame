using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    
    public static int Level;
    public Button[] levels = new Button[6];
    public ShowStars[] ShowStarsOfLevel = new ShowStars[6];
    public TextMeshProUGUI[] levelTexts = new TextMeshProUGUI[6];
    private Color32 availableLevelColor = new(255, 165, 0, 255);

    private void Start()
    {
        for (int level = 1; level < SaveSystem.LastCompleteLevel + 1; level++)
        {
            levelTexts[level].color = availableLevelColor;
            ShowStarsOfLevel[level].DisplayStars(GameManager.AmountOfStars[level]);
        }

        levelTexts[SaveSystem.LastCompleteLevel + 1].color = availableLevelColor;
    }


    private void Awake()
    {
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
