using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    public GameObject developersPanel;

    public void PlayGame()
    {
        Application.LoadLevel("F0");
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
