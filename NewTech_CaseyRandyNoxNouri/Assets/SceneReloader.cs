using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    public float waitRealtime = 5f;

    public void ReloadCurrentScene()
    {
        StartCoroutine(Coroutine());

        IEnumerator Coroutine()
        {
            yield return new WaitForSecondsRealtime(waitRealtime);

            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
