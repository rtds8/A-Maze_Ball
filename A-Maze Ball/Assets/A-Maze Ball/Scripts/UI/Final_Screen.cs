using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Final_Screen : MonoBehaviour
{
    [SerializeField] private GameObject m_finalSreen;
    [SerializeField] private Text m_finalMessage, m_finalScore, m_acquiredScore, m_penaltyPoints;

    private void Update()
    {
        if(Game_Manager._gameManager._isGameOver)
        {
            m_finalSreen.SetActive(true);
            m_finalMessage.text = Game_Manager._gameManager._finalMessage;
            m_acquiredScore.text = "ACQUIRED POINTS: " + Game_Manager._gameManager.FinalScore().ToString();
            m_penaltyPoints.text = "PENALTY POINTS: -" + Game_Manager._gameManager.PenaltyPoints().ToString();
            int finalScore = Game_Manager._gameManager.FinalScore() - Game_Manager._gameManager.PenaltyPoints();
            if (finalScore < 0)
                finalScore = 0;
            m_finalScore.text = "FINAL SCORE: " + finalScore.ToString();
        }
    }
}
