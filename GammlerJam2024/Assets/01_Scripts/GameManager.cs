using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gmManager;
    public BGManager bgManager;

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
        StartCoroutine(LoadConvoScene(2));
        StartCoroutine(LoadConvoScene(3));
        StartCoroutine(LoadConvoScene(4));
        StartCoroutine(LoadConvoScene(5));
        StartCoroutine(LoadConvoScene(6));
        StartCoroutine(LoadConvoScene(7));
        StartCoroutine(LoadConvoScene(8));

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



    #region Screen aspect ration

    private float lastWidth;
    private float lastHeight;

    void Update()
    {
        if (lastWidth != Screen.width)
        {
            Screen.SetResolution(Screen.width, Screen.width * (16 / 9), false);
        }
        else if (lastHeight != Screen.height)
        {
            Screen.SetResolution(Screen.height * (9 / 16), Screen.height, false);
        }

        lastWidth = Screen.width;
        lastHeight = Screen.height;
    }
    #endregion
}
