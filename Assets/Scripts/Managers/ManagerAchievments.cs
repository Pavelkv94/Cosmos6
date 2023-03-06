using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IG;

namespace Cosmos6
{
    public class ManagerAchievments : SingletonManager<ManagerAchievments>
    {

        private void OnEnable()
        {
            ManagerScore.Instance.OnNewScore += CheckAchievments;
        }

        private void OnDisable()
        {
            ManagerScore.Instance.OnNewScore -= CheckAchievments;
        }
        private void CheckAchievments(int newScore)
        {
            if (newScore > 9)
            {
                Debug.Log("CONGRATULATS!!");//ЛОГИКА
            }
        }
    }
}