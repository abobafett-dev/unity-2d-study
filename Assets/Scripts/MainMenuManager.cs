using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject developersPanel;
    public Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (canvas != null && Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled;
        }
    }

    public void PlayGame()
    {
        FaderController.instance.NextScene();
    }

    public void СontinueGame()
    {
        canvas.enabled = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void DevelopersPanel()
    {
        developersPanel.SetActive(true);
    }

    public void ExitDevelopersPanel()
    {
        developersPanel.SetActive(false);
    }
}