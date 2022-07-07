using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    
    public static int Level;
    public Button[] levels = new Button[6];

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
        Debug.Log("рівень під час завантаження рівня " + SaveSystem.LastCompleteLevel);
        if (level < SaveSystem.LastCompleteLevel + 2)
        {
            Level = level;
            SceneManager.LoadScene("Game");
        }
    }
}
