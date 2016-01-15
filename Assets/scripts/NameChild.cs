using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NameChild : MonoBehaviour {
    public static int villagers = 25;
    private bool CanDie = true;
    private AsyncOperation async;
    private int sceneToLoad;

	void Update () {
        if (villagers <= 0)
        {
            StartCoroutine(LoadScene());
            
        }

        if(CanDie == true)
        {
            StartCoroutine(RipVillager());
        }
	}

    IEnumerator RipVillager()
    {
        CanDie = false;
        yield return new WaitForSeconds(6f);
        villagers--;
        CanDie = true;
    }
    IEnumerator LoadScene()
    {
        villagers = 25;
        async = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        while (!async.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
    }
}
