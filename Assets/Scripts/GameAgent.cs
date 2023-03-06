using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos6
{
    public class GameAgent : MonoBehaviour
    {
        //Фракции в игре
        public enum Fraction
        {
            Players,
            Aliens,
            Impery
        }

        public Fraction ShipFraction;
    }
}