using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Handler : MonoBehaviour
{
    [SerializeField] private GameObject m_loadingScreeen;
    [SerializeField] private GameObject m_mainMenu;
    [SerializeField] private Loading_Screen setSceneIndex;

    public void OnClickPlayButton()
    {
        setSceneIndex._sceneToBeLoaded = SceneManager.GetActiveScene().buildIndex + 1;
        m_loadingScreeen.SetActive(true);
        m_mainMenu.SetActive(false);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
