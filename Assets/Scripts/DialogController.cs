using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _player2;

    [SerializeField] private float _delay;

    [SerializeField] private CinemachineVirtualCamera _camera;
    
    private float _oldDelay;

    private TextMeshProUGUI _text;
    private List<DialogFragment> _phrase;

    private bool _isDialog;
    private bool _isPhrase;
    private int _index;

    

    private void Start()
    {
        _oldDelay = _delay;
        _text = _canvas.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _phrase = new List<DialogFragment>
        {
            new(_player, "Фраза героя"),
            new(_player2, "Фраза второго"),
            new(_player, "Вторая фраза героя"),
            new(_player2, "Вторая фраза второго"),
            new(_player, "Да да да")
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dialog(_phrase);
        }
    }

    private IEnumerator ShowText(string text)
    {
        _isPhrase = true;
        foreach (var symbol in text)
        {
            _text.text += symbol;

            yield return new WaitForSeconds(_delay);
        }

        Debug.Log("Конец");
        _isPhrase = false;
        _index++;
    }

    private void Dialog(List<DialogFragment> dialog)
    {
        if (!_isDialog)
            StartDialog();

        if (_index >= dialog.Count && !_isPhrase)
            EndDialog();
        
        if (_isDialog)
            NextPhrase(dialog[_index]);
        
    }

    private void NextPhrase(DialogFragment fragment)
    {
        if (_isPhrase)
        {
            _delay = 0.01f;
            return;
        }

        _text.text = "";
        _delay = _oldDelay;
        _camera.Follow = fragment.Entity.transform;
        StartCoroutine(ShowText(fragment.Text));
    }

    private void StartDialog()
    {
        _isDialog = true;
        _index = 0;
        _canvas.gameObject.SetActive(true);
    }
    
    private void EndDialog()
    {
        _isDialog = false;
        _canvas.gameObject.SetActive(false);
        _camera.Follow = _player.transform; //todo это возможно уберём
        FaderController.instance.NextScene();
    }
}