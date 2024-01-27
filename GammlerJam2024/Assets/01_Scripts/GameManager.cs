using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gmManager;
    Coroutine sceneLoading;
    private void Awake()
    {
        if (gmManager == null)
        {
            gmManager = this;
        }
    }
    private void Start()
    {
        StartCoroutine(LoadConvoScene(1));

    }

    public IEnumerator LoadConvoScene(int sceneID)
    {
        if (!SceneManager.GetSceneByBuildIndex(sceneID).IsValid())
        {
            SceneManager.LoadScene(sceneID, LoadSceneMode.Additive);
        }
        while (!SceneManager.GetSceneByBuildIndex(sceneID).IsValid())
        {
            yield return null;
        }
        Debug.Log("Scene" +SceneManager.GetSceneAt(sceneID).name +" has loaded");

    }

    public GameObject SetNewConvo(int sceneID)
    {
        return SceneManager.GetSceneAt(sceneID).GetRootGameObjects()[0];
    }
}
