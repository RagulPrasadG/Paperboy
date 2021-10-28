using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField] GameObject gameOverPanel;
    public Slider volumeAdjustSlider;
    public Slider speedControlSlider;
    public Slider turnControlSlider;

    public static float speed;
    public static float turn;
    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            speed = speedControlSlider.value;
            turn = turnControlSlider.value;
        }
    }
    private void Start()
    {
        Time.timeScale = 1;
        instance = this;
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
