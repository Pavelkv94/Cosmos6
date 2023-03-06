using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos6
{
    //Класс который представляет собой контейнер с ссылками для подсистем
    public class Spaceship : MonoBehaviour
    {
        public GameAgent ShipAgent;
        //Awake срабатывает перед Start

        private void Awake()
        {
            if (ShipAgent == null)
                ShipAgent = GetComponent<GameAgent>();
        }

    }
}