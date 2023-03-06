using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos6
{
    public class Engine : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 0.5f;
        void Start()
        {

        }

        // Update is called once per frame
        public Vector3 Thrust()
        {
            return Vector3.forward * _moveSpeed * Time.deltaTime;
        }

        public float GetSpeed()
        {
            return _moveSpeed;
        }
    }
}