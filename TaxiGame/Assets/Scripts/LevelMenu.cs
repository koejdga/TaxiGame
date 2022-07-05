using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public static int Level;
    public int LevelParameter;
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;

    private void Awake()
    {
        // adding a delegate with no parameters
        // level1.onClick.AddListener(NoParamaterOnclick);

        // adding a delegate with parameters
        level1.onClick.AddListener(delegate { LoadLevel(1); });
        level2.onClick.AddListener(delegate { LoadLevel(2); });
        level3.onClick.AddListener(delegate { LoadLevel(3); });
        level4.onClick.AddListener(delegate { LoadLevel(4); });
        level5.onClick.AddListener(delegate { LoadLevel(5); });
    }

    private void LoadLevel(int level)
    {
        Level = level;
        SceneManager.LoadScene("Game");
    }

    private void ParameterOnClick(string test)
    {
        Debug.Log(test);
    }



    private void Update()
    {
        // if (level1.clicked == true)



    }


    public void playLevel()
    {
        Level = LevelParameter;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
