using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaderController : MonoBehaviour
{
    private List<string> _scenes;
    private int _scenesIndex;

    private bool _isLoading;

    private static FaderController _instance;

    public static FaderController instance => _instance;

    public int _countLoad;
    public float _playerSpeed = 2f;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _scenes = new List<string>();
        _scenes.Add("F0");
        _scenes.Add("F0");
        _scenes.Add("L1");
        _scenes.Add("F0");
        _scenes.Add("L2");
        _scenes.Add("F0");
        _scenes.Add("L0");
        _scenes.Add("F0");
        _scenes.Add("mainMenu");

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            NextScene();
        }
    }

    public void NextScene()
    {
        LoadScene(_scenes[_scenesIndex]);
    }

    private void LoadScene(string sceneName)
    {
        if (_isLoading)
            return;

        _countLoad++;
        _scenesIndex++;

        if (_scenesIndex == _scenes.Count)
            _scenesIndex = 0;

        var currentSceneName = SceneManager.GetActiveScene().name;
        // if (currentSceneName == sceneName)
        //     throw new Exception("Сцена уже загружена");

        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        _isLoading = true;

        var waitFading = true;
        Fader.instance.FadeIn(() => waitFading = false);

        while (waitFading)
            yield return null;

        var async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
            yield return null;

        async.allowSceneActivation = true;

        waitFading = true;
        Fader.instance.FadeOut(() => waitFading = false);

        while (waitFading)
            yield return null;

        _isLoading = false;
        Fader.instance.canvas.enabled = false;
    }
}