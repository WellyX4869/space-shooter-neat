using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Loading Settings")]
    public GameObject loadingScreen;
    public GameObject loadingWheel;
    public float rotationDegreePerSecond;

    private void Awake()
    {
        instance = this;
        loadingScreen.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive);
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public void LoadGame()
    {
        loadingScreen.SetActive(true);
        scenesLoading.Clear();
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.GAMEPLAY, LoadSceneMode.Additive));
        StartCoroutine(LoadAnimation());
    }

    public void LoadMainMenu()
    {
        loadingScreen.SetActive(true);
        scenesLoading.Clear();
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndexes.GAMEPLAY));
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive));
        StartCoroutine(LoadAnimation());
    }

    float totalSceneProgress;
    public IEnumerator LoadAnimation()
    {
        while (true)
        {
            // Loading Animation
            loadingWheel.transform.RotateAround(loadingWheel.transform.position, Vector3.back, rotationDegreePerSecond * Time.deltaTime);

            for (int i = 0; i < scenesLoading.Count; i++)
            {
                totalSceneProgress = 0;

                foreach (AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }

                totalSceneProgress = (totalSceneProgress / scenesLoading.Count);
            }

            if (totalSceneProgress >= 1f)
            {
                break;
            }
            yield return null;
        }

        loadingScreen.SetActive(false);
    }
}
