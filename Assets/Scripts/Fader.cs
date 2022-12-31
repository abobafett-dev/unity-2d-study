using System;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private const string FADER_PATH = "Fader";

    [SerializeField] private Animator _animator;

    private static Fader _instance;

    public Canvas canvas;

    public static Fader instance
    {
        get
        {
            if (_instance == null)
            {
                var prefab = Resources.Load<Fader>(FADER_PATH);
                _instance = Instantiate(prefab);
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
            canvas.enabled = false;
        }
    }

    public bool isFading { get; private set; }

    private Action _fadedInCallback;
    private Action _fadedOutCallback;

    public void FadeIn(Action fadedInCallback)
    {
        if (isFading)
            return;

        canvas.enabled = true;
        isFading = true;
        _fadedInCallback = fadedInCallback;
        _animator.SetBool("faded", true);
    }

    public void FadeOut(Action fadedOutCallback)
    {
        if (isFading)
            return;

        isFading = true;
        _fadedOutCallback = fadedOutCallback;
        _animator.SetBool("faded", false);
    }

    private void FadeInAnimationOver()
    {
        _fadedInCallback?.Invoke();
        _fadedInCallback = null;
        isFading = false;
    }

    private void FadeOutAnimationOver()
    {
        _fadedOutCallback?.Invoke();
        _fadedOutCallback = null;
        isFading = false;
    }
}