using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Curtain _curtain;
        
        public event Action LoadStarted;
        public event Action LoadEnded;
        private bool _loading;
        private string _loadingSceneName;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _loading = false;
        }

        public void Load(string name)
        {
            if (_loading == false)
            {
                _loadingSceneName = name;
                _curtain.ScreenHide += StartLoadScene;
                _curtain.Show();
            }
        }

        private void StartLoadScene()
        {
            _curtain.ScreenHide -= StartLoadScene;
            StartCoroutine(LoadScene(_loadingSceneName));
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
            _curtain.Hide();
        }
    }
}