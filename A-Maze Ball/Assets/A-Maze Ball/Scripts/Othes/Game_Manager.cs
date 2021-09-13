using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager _gameManager;

    public float _maxLeveTime = 300f;
    private float m_timeSpent;
    [HideInInspector] public bool _isGameOver = false, _hasFinished = false, _gamePlaying;
    [HideInInspector] public string _finalMessage;
    [HideInInspector] public int _penalties;
    public Text _timerText;

    private void Awake()
    {
        if (_gameManager == null)
            _gameManager = this.gameObject.GetComponent<Game_Manager>();
    }

    void Start()
    {
        _penalties = 0;
        _gamePlaying = false;
    }

    public void Begin()
    {
        _gamePlaying = true;
        m_timeSpent = 0f;
    }

    void Update()
    {
        if(!_isGameOver && _gamePlaying)
        {
            if (_hasFinished && m_timeSpent < _maxLeveTime)
                LevelComplete();

            else if (m_timeSpent >= _maxLeveTime)
            {
                m_timeSpent = _maxLeveTime;
                _timerText.text = "00:00";
                GameOver();
            }

            else
            {
                m_timeSpent += Time.deltaTime;
                float minutes = Mathf.FloorToInt((_maxLeveTime - m_timeSpent) / 60);
                float seconds = Mathf.FloorToInt((_maxLeveTime - m_timeSpent) % 60);
                _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
             }
        }
    }

    public int PenaltyPoints()
    {
        return _penalties * 30;
    }

    public int FinalScore()
    {
        int score = (int) (Mathf.Max(0, _maxLeveTime - m_timeSpent) * 10);

        return score;
    }

    void LevelComplete()
    {
        Audio_Manager.instance.Play_Audio("victory");
        _finalMessage = "YOU WIN!!!";
        _isGameOver = true;
        _gamePlaying = false;
        Time.timeScale = 0f;
    }

    void GameOver()
    {
        Audio_Manager.instance.Play_Audio("game_over");
        _finalMessage = "TIME UP!";
        _isGameOver = true;
        _gamePlaying = false;
        Time.timeScale = 0f;
    }
}
