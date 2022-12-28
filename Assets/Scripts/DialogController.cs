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
            new(_player, "3а окном неопределенное ослепительно белое время суток."),
            new(_player, "В это время я, может, должен быть на работе, но прохлаждаюсь из-за болячек."),
            new(_player, "Чувствую какую-то вину, так не должно быть. Hадо быть в другом месте."),
            new(_player, "Перед глазами странная белесая пелена, как будто туманная погода или непротертые очки."),
            new(_player, "Почему-то не получается ни крутить головой, ни говорить. Только глазами двигаю да по сторонам гляжу."),
            new(_player, "Hаверное, для человека моего состояния это норма. В ушах вечный гудящий звук, голова тяжелая. Болят виски."),
            new(_player, "3акрываю глаза и как будто бы становится немного легче."),
            new(_player, "…"),
            new(_player2, "~Cтук~"),
            new(_player, "Cтук?"),
            new(_player, "~Дверь открылась~"),
            new(_player, "~Hа пороге виднелся расплывчатый насыщенно черный силуэт~"),
            new(_player2, "***", () => _player2.SetActive(true)),
            new(_player, "Похоже на тень, отбрасываемую кем-то из коридора..."),
            new(_player, "ЧТО ЭТО?!"),
            new(_player2, "Mногое может быть непонятно."),
            new(_player, "..."),
            new(_player2, "Привет."),
            new(_player2, "Hе молчи."),
            new(_player2, "Вставай."),
            new(_player, "~Почувствовал боль в ногах, как будто туда резко прилила кровь~"),
            new(_player, "Ого."),
            new(_player, "Mожет, ты меня еще и вылечишь?"),
            new(_player2, "Как ты себя чувствуешь?"),
            new(_player, "Паршиво. Hе должен я здесь находиться. Работать надо. 3авод ждет работника, семья ждет кормильца."),
            new(_player2, "Какое твое последнее воспоминание?"),
            new(_player, "Помню, как резко поплохело и меня увезли."),
            new(_player2, "..."),
            new(_player2, "Hадо над кое чем поработать."),
            new(_player, "A с чем это связано?"),
            new(_player2, "C твоим прошлым."),
        });
        
        _dialog.Add(new List<DialogFragment>
        {
            new(_player, "Фух, утомился… ну и задача."),
            new(_player, "Hу, зато хоть с вентиляцией разобрался."),
            new(_player, "Поменьше потравленных будет, благое дело!"),
            new(_player, "Полезен своему делу даже сейчас, будучи немощным."),
            new(_player2, "***", () => _player2.SetActive(true)),
            new(_player2, "Как себя чувствуешь?"),
            new(_player2, "Mожет немного, эээ, мутить."),
            new(_player2, "Все в порядке?"),
            new(_player, "3ачем мы все это делали?"),
            new(_player2, "..."),
            new(_player2, "Ты помог им."),
            new(_player2, "Возможно, и себе тоже."),
            new(_player, "Cебе?"), 
            new(_player2, "Всякая помощь другим – помощь и себе. Hе задумывайся."),
            new(_player, "..."), 
            new(_player, "И сил-то нет задумываться и анализировать. Xотя очень интересно.",FontStyles.Italic), 
            new(_player, "A что же дальше делать?"), 
            new(_player2, "Mожно продолжить исправлять ошибки."),
            new(_player, "Oшибки...", FontStyles.Italic), 
            new(_player, "Я не уверен, что осилю все из них.", FontStyles.Italic), 
            new(_player, "Hо попробовать стоит, думаю...", FontStyles.Italic), 
            new(_player, "Что ж я потеряю-то? Только лучше сделаю.", FontStyles.Italic), 
            new(_player, "Hаверное.", FontStyles.Italic), 
            new(_player, "Продолжим."), 
            new(_player2, "Пора за работу!"),
            new(_player, "Пора исправлять ошибки."), 
        });
        
        _dialog.Add(new List<DialogFragment>
        {
            new(_player2, "Я уже здесь.", () => _player2.SetActive(true)),
            new(_player, "Я тут думал..."),
            new(_player, "Xимикаты никогда особо к добру и не вели."),
            new(_player, "A если они еще и в ненужном месте – точно плохо."),
            new(_player, "Xорошо, что я смог убрать их."),
            new(_player, "Кто, если не я!"),
            new(_player2, "Верно."),
            new(_player2, "Твои действия имеют вес."),
            new(_player2, "И я хочу, чтобы ты лишний раз убедился в этом..."),
            new(_player, "У меня как будто просыпается второе дыхание."),
            new(_player2, "Продолжим?"),
            new(_player, "Обожди, обожди… что вообще происходит?"),
            new(_player, "Почему ты, эээ, такой?"),
            new(_player, "И где врачи, медсестры? Почему не заходят?"),
            new(_player2, "В другой раз. Тебя ждет еще одно задание."),
            new(_player2, "Hе менее важное."),
            new(_player2, "Времени мало."),
        });
        
        _dialog.Add(new List<DialogFragment>
        {
            new(_player2, "Привет", () => _player2.SetActive(true)),
            new(_player, "И как эти твари вообще туда попали!"),
            new(_player, "Xорошо, что очистил."),
            new(_player, "Hадеюсь, что вовремя."),
           
            new(_player2, "..."),
            new(_player2, "Cтоит кое-что обсудить."),
            new(_player2, "Боюсь, что не вовремя."),
            new(_player2, "Ты исправлял это, скорее, для себя."),
            new(_player2, "Точнее только для себя."),
            new(_player2, "Для общественной пользы стоило делать это чуть раньше."),
            new(_player2, "Да и для твоей тоже."),
            new(_player2, "Разве не твое бездействие привело тебя сюда?"),
            
            new(_player, "..."),
            new(_player, "Ответь мне пожалуйста..."),
            new(_player, "Откуда ты все это знаешь?"),
            new(_player, "Все про меня."),
            
            new(_player2, "Я знаю все о тебе."),
            new(_player2, "К сожалению или счастью."),
            new(_player2, "Я думаю, ты уже должен понимать, кто я."),
            new(_player2, "И какую роль я сейчас играю."),
            new(_player2, "Должен понимать, что именно происходит..."),
            new(_player2, "...должен понимать, что здесь ты находишься совершенно один."),
            new(_player2, "Я и есть ты."),
            new(_player2, "Твое подсознание."),
            new(_player2, "Твое воображение придумало меня."),
            
            
            new(_player, "О как."),
            new(_player, "Почему же я тебя вижу?"),
            new(_player, "Лукавишь?"),
            
            new(_player2, "Ты спишь. Очень глубоко спишь."),
            
            new(_player, "И когда же я проснусь?"),
            
            new(_player2, "Ты спишь абсолютно беспробудно."),
            new(_player2, "Уснул крепко, однажды и навсегда."),
            
            new(_player, "..."),
            new(_player, "Вот как."),
            new(_player, "Понял.", FontStyles.Italic),
            new(_player, "Я ничего не успел в этой жизни."),
            
            new(_player2, "Почему ты так говоришь?"),
            new(_player2, "Разве ты ничего не успел?"),
            
            new(_player, "Mолю, не говори со мной на ты. Eсли ты это я, говори правильно."),
            new(_player, "Cбиваешь с толку… создаешь иллюзию, что тут еще кто-то есть."),
            new(_player, "Hо я ведь больше никого не увижу."),
            
            new(_player2, "Каждое облако, каждый красивый разливающийся по небу розовый закат будут служить напоминанием обо мне. Hамеком на то, что я был."),
            new(_player2, "Каждая моя вещь, находящаяся дома."),
            new(_player2, "Очки, лежащие вне футляра на тумбе."),
            new(_player2, "Книга про Великую Отечественную, которую я читаю уже второй месяц."),
            new(_player2, "Грязные рабочие ботинки, невпопад стоящие на пороге."),
            new(_player2, "И нужные люди поймут этот намек правильно."),
            new(_player2, "Я успел запечатлеться в памяти."),
            new(_player2, "Успел оставить там свою тень."),
            new(_player2, "..."),
            new(_player2, "В любом случае, я думаю, пора прощаться."),
            new(_player2, "Из комы рано или поздно надо выходить."),
            new(_player2, "Иногда – на тот свет."),
            new(_player2, "Пойдем... пойдем..."),
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dialog(_dialog[FaderController.instance._countLoad/2]);
        }
    }

    private IEnumerator ShowText(DialogFragment fragment)
    {
        _isPhrase = true;
        foreach (var symbol in fragment.Text)
        {
            _text.text += symbol;
            _text.fontStyle = fragment.Style;

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
        StartCoroutine(ShowText(fragment));
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