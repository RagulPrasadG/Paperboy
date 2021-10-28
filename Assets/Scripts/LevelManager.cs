using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingBar;
    public void LevelLoader(int sceneIndex){
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingPanel.SetActive(true);

        while(!operation.isDone){

            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            
            loadingBar.value = progress;

            yield return null;
        }
    }
}
