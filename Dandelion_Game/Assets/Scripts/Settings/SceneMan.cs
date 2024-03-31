/*      System       */
using System.Collections;
using System.Collections.Generic;
/*      Unity       */
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    //[SerializeField] private LoadingScreenObjects loadingScreen;
    /*private void Awake() {
        loadingScreen.obj.SetActive(false);
    }
    private void Start() {
        if (GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreenObjects>() == null) Debug.LogWarning("Warning: 'loadingScreen' in null");
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").GetComponent<LoadingScreenObjects>();
        
    }*/
    public void SceneNum(int Num){
        SceneManager.LoadScene(Num);
        //LoadAsynchronously(Num);
    }
    public void SceneName(string Nam){
        SceneManager.LoadScene(Nam);
        //LoadAsynchronously_STR(Nam);
    }
    public void LevelSceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /*public void SceneNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/
    /*IEnumerator LoadAsynchronously(int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

		loadingScreen.obj.SetActive(true);

		while(!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / 0.9f);

			loadingScreen.slider.value = progress;

			yield return null;
		}
	}
    IEnumerator LoadAsynchronously_STR(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.obj.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingScreen.slider.value = progress;

            yield return null;
        }
    }*/
}
