using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class In_Game_UI_Handler : MonoBehaviour
{
    [SerializeField] private GameObject m_pauseMenu;

    public void Resume()
    {
        m_pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        m_pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnClickMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
