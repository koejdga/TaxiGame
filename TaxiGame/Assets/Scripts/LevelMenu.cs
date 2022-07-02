using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public int Level;
    public void playLevel(int Level)
    {
        this.Level = Level;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
