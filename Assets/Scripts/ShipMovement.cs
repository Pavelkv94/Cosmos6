using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos6
{
    public class ShipMovement : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 90;

        public Transform SpaceShip; // ссылка на оболочку корабля
        [SerializeField] private List<Engine> Engines; //Массив двигателей
        private SpeedDisplay speedDisplay;
        void Start()
        {
            speedDisplay = FindObjectOfType<SpeedDisplay>();
        }

        // Update is called once per frame
        void Update()
        {
            Turn();
            Move();
        }

        private void Turn()
        {
            float yaw = _rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime; //a d
            float pitch = _rotationSpeed * Input.GetAxis("Vertical") * Time.deltaTime; //w s
            float roll = _rotationSpeed * Input.GetAxis("Roll") * Time.deltaTime; //q e

            SpaceShip.Rotate(pitch, yaw, roll);
        }
        private void Move()
        {
            Vector3 resultingThrust = new Vector3(); //резултативная скорость двигателй
            float resultSpeed = 0f;
            //проход по массиву двигателей и у каждого элемента мы вызывает метод тяги этого двигателя  Trust
            foreach (var engine in Engines)
            {
                resultingThrust = resultingThrust + engine.Thrust();
                resultSpeed += engine.GetSpeed();
            }

            SpaceShip.Translate(resultingThrust);

            // Display the speed using the SpeedDisplay script
            if (speedDisplay != null)
            {
                speedDisplay.DisplaySpeed(resultSpeed);
            }

        }
    }
}