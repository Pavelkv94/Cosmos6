using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using IG;

namespace Cosmos6
{
    public class ManagerScore :  SingletonManager<ManagerScore>
    {
        public int Score;
        public TextMeshProUGUI ScoreText;

        public Action<int> OnAddScore;

        public Action<int> OnNewScore;

        private void Start()
        {
            if (ScoreText == null)
                Debug.LogError("ManagerScore. ScoreText null");
            else
                ScoreText.text = Score.ToString();
        }

        private void OnEnable()
        {
            OnAddScore += IncreaseScore;
        }

        private void OnDisable()
        {
            OnAddScore -= IncreaseScore;
        }

        public void AddScore(int scoreDelta)
        {
            if (OnAddScore != null)
                OnAddScore(scoreDelta);
        }

        public void IncreaseScore(int scoreDelta)
        {
            Score += scoreDelta;//добавляем очки
            ScoreText.text = Score.ToString();

            if (OnNewScore != null)
                OnNewScore(Score);
        }
    }

}