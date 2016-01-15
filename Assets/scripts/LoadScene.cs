using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    private AsyncOperation async;

    IEnumerator LoadSceneGame()
    {
        async = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        while (!async.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
    }
	void Update () {
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            StartCoroutine(LoadSceneGame());

        }
	}
}
