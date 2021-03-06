using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_Screen : MonoBehaviour
{
    [SerializeField] private Slider m_slider;
    [SerializeField] private Text m_loadingText;
    [HideInInspector] public int _sceneToBeLoaded;

    public void Load_Scene()
    {
        StartCoroutine(Scene_Loading());
    }

    IEnumerator Scene_Loading()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneToBeLoaded);

        while (!operation.isDone)
        {

            float m_progress = Mathf.Clamp01(operation.progress / 0.9f);

            m_slider.value = m_progress;

            m_loadingText.text = "Loading... " + (m_progress * 100f).ToString("0") + "%";

            yield return null;
        }
    }
}
