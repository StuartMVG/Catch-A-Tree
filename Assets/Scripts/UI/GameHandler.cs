using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatchTree.UI
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText = null;
        [SerializeField] Slider timerBar;
        private int playerScore = 0;

        void Start()
        {
            UpdateScore();
            timerBar.maxValue = 1.0f;
        }
        private void OnEnable()
        {
            EventHandler.UpdateScoreEvent += AddScore;
            EventHandler.UpdateTimerEvent += UpdateTimer;
            EventHandler.ResetGameEvent += ResetGameScore;
        }
        private void OnDisable()
        {
            EventHandler.UpdateScoreEvent -= AddScore;
            EventHandler.UpdateTimerEvent -= UpdateTimer;
            EventHandler.ResetGameEvent -= ResetGameScore;
        }

        public void RestartGameButton()
        {
            EventHandler.CallResetGameEvent();
        }
        private void UpdateTimer(float timeLeft, float maxTime)
        {
            float timePercentageLeft = (timeLeft/maxTime);
            timerBar.value = (timePercentageLeft);

        }

        private void AddScore(int scoreAmount)
        {
                playerScore += scoreAmount;
                UpdateScore();
        }

        private void UpdateScore()
        {
                scoreText.SetText("Score: " + playerScore.ToString());
        }

        private void ResetGameScore()
        {
            playerScore = 0;
            UpdateScore();
        }
    }
    
}

