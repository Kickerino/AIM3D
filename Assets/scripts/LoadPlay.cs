using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadPlay : MonoBehaviour {
    private AsyncOperation async;

    IEnumerator LoadSceneGame()
    {
        async = SceneManager.LoadSceneAsync(3, LoadSceneMode.Single);
        while (!async.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            StartCoroutine(LoadSceneGame());

        }
    }
}
