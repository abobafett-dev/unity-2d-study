using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject developersPanel;

    public void PlayGame()
    {
        FaderController.instance.NextScene();
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