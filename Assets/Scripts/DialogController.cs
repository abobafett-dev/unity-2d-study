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
    private List<List<DialogFragment>> _dialog;

    private bool _isDialog;
    private bool _isPhrase;
    private int _index;

    

    private void Start()
    {
        _oldDelay = _delay;
        _text = _canvas.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _dialog = new List<List<DialogFragment>>();
        _dialog.Add(new List<DialogFragment>
        {
            new(_player, "Я обычный работник обычного завода. Этакий работяга средних лет."),
            new(_player, "Безликий, маленький человек, – шестеренка системы. Большой, медленно раскручивающейся дымящей вредными парами системы."),
            new(_player, "Подумать только: большую часть отведенного времени нарабатывать жуткие мозоли на станках и дышать бог знает чем!"),
            new(_player, "Лучше пусть и не знает."),
            new(_player, "Работаю на химическом оружейном производстве в маленьком сибирском городе, затерянном глубоко в тайге."),
            new(_player, "Точнее работал."),
            new(_player, "Возможно, это и сложило меня в больничную койку. Кашляющего кровью, неестественно бледного, но вроде бы живого. "),
            new(_player, "И больше я не работаю."),
            new(_player, "Я замечал что-то похожее и раньше. Кашлял кровью и списывал на полторы пачки Беломора в день."),
            new(_player, "Я обычный работник обычного завода. Этакий работяга средних лет."),
            new(_player, "Домашние не замечали этого. В целом, они не особо замечали меня."),
            new(_player, "Вечно пропадал на работе, впрочем. Поэтому никто и не беспокоился, и я тем более тоже."),
            new(_player, "Подумаешь, кровь! Hашел из-за чего переживать."),
            new(_player, "Работал на заводе, носил протертую робу, ел глазунью на завтрак, пил растворимый кофе, нещадно дымил Беломор, существовал дальше без придуманных проблем."),
            new(_player, "Xватало реальных."),
            new(_player, "Потом слег. Очень плохо."),
            // new(_player, "", ()=> FaderController.instance.NextScene()),
            
        });
        
        _dialog.Add(new List<DialogFragment>
        {
            new(_player, "Hенадолго отключился, проснулся. Встать не могу, лишь открыл глаза."),
            new(_player, "За окном неопределенное ослепительно белое время суток."),
            new(_player, "В это время я, может, должен быть на работе, но прохлаждаюсь из-за болячек."),
            new(_player, "Чувствую какую-то вину, так не должно быть. Надо быть в другом месте."),
            new(_player, "Перед глазами странная белесая пелена, как будто туманная погода или непротертые очки."),
            new(_player, "Почему-то не получается ни крутить головой, ни говорить. Только глазами двигаю да по сторонам гляжу."),
            new(_player, "Hаверное, для человека моего состояния это норма. В ушах вечный гудящий звук, голова тяжелая. Болят виски."),
            new(_player, "Закрываю глаза и как будто бы становится немного легче."),
            new(_player, "…"),
            new(_player2, "~Стук~"),
            new(_player, "Стук?"),
            new(_player, "~Дверь открылась~"),
            new(_player, "~На пороге виднелся расплывчатый насыщенно черный силуэт~"),
            new(_player2, "***", () => _player2.SetActive(true)),
            new(_player, "Похоже на тень, отбрасываемую кем-то из коридора..."),
            new(_player, "ЧТО ЭТО?!"),
            new(_player2, "Многое может быть непонятно."),
            new(_player, "..."),
            new(_player2, "Привет."),
            new(_player2, "Hе молчи."),
            new(_player2, "Вставай."),
            new(_player, "~Почувствовал боль в ногах, как будто туда резко прилила кровь~"),
            new(_player, "Ого."),
            new(_player, "Может, ты меня еще и вылечишь?"),
            new(_player2, "Как ты себя чувствуешь?"),
            new(_player, "Паршиво. Не должен я здесь находиться. Работать надо. Завод ждет работника, семья ждет кормильца."),
            new(_player2, "Какое твое последнее воспоминание?"),
            new(_player, "Помню, как резко поплохело и меня увезли."),
            new(_player2, "..."),
            new(_player2, "Hадо над кое чем поработать."),
            new(_player, "А с чем это связано?"),
            new(_player2, "С твоим прошлым."),
        });
        
        _dialog.Add(new List<DialogFragment>
        {
            new(_player, "2Фраза героя"),
            new(_player2, "2Фраза второго"),
            new(_player, "2Вторая фраза героя"),
            new(_player2, "2Вторая фраза второго"),
            new(_player, "2Да да да")
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dialog(_dialog[FaderController.instance._countLoad/2]);
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
        ExecuteAction(fragment.Action);
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

    private void ExecuteAction(Action action)
    {
        action?.Invoke();
    }
}