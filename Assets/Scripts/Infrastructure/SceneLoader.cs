using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public event Action LoadStarted; 
    public event Action LoadEnded;
    private bool _loading;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _loading = false;
    }

    public void Load(string name)
    {
        if (_loading == false)
        {
            StartCoroutine(LoadScene(name));
        }
    }

    private IEnumerator LoadScene(string nextScene)
    {
        _loading = true;
        LoadStarted?.Invoke();

        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

        while (!waitNextScene.isDone)
            yield return null;
        
        _loading = false;
        LoadEnded?.Invoke();
    }
}