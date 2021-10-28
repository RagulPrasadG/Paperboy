using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public void LoadLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }
}
