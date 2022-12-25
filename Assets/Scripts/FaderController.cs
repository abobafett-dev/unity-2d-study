using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FaderController : MonoBehaviour
{
    private Queue<string> _scenes;

    private bool _isLoading;

    private static FaderController _instance;
    
    public static FaderController instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _scenes = new Queue<string>();
        // _scenes.Enqueue("F0");
        _scenes.Enqueue("L0");
        _scenes.Enqueue("F1");
        _scenes.Enqueue("L1");
        _scenes.Enqueue("F2");
        _scenes.Enqueue("L2");
        
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
        LoadScene(_scenes.Dequeue());
    }
    
    private void LoadScene(string sceneName)
    {
        if (_isLoading)
            return;

        var currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == sceneName)
            throw new Exception("Сцена уже загружена");

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
    }
}