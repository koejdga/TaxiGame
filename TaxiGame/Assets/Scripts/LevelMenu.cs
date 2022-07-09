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
    public Color32 unavailableLevelColor = new(166, 130, 64, 255);

   public static bool isReset = false;

   public void CloseStarSets(int level)
    {
        ShowStarsOfLevel[level].CloseStars();
    }

    private void Start()
    {
        SaveSystem.LoadProgress();

        if (isReset)
        {
            for (int level = 2; level < 6; level++)
            {
                levelTexts[level].color = unavailableLevelColor;
                CloseStarSets(level);
            }
        }

        isReset = false;

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
