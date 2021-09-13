using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity_Slider : MonoBehaviour
{
    [SerializeField] private Slider m_sensitivitySlider;
    public int _sensitivity = 5;

    private void Awake()
    {
        _sensitivity = (int) m_sensitivitySlider.value;
    }

    public void ChangeSensitivity()
    {
        _sensitivity = (int) m_sensitivitySlider.value;
        PlayerPrefs.SetInt("Slider Sensitivity", _sensitivity);
    }
}
