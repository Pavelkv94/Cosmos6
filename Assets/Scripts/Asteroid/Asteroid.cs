using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cosmos6
{
    public class Asteroid : MonoBehaviour
    {
        //минимальный размер
        [SerializeField] private float _minScale = 0.6f;
        //максимальный размер
        [SerializeField] private float _maxScale = 1.6f;
        //вращение
        [SerializeField] private float _rotationOffset = 100f;

        private Vector3 _randomRotation;
        private void Start()
        {
            Vector3 originalScale = transform.localScale;
            Vector3 newScale = new Vector3(
                Random.Range(_minScale, _maxScale),
                Random.Range(_minScale, _maxScale),
                Random.Range(_minScale, _maxScale));
            // выше то же самое в рагементах, оси Х У Z
            // newScale.x = Random.Range(_minScale, _maxScale);
            // newScale.y = Random.Range(_minScale, _maxScale);
            // newScale.z = Random.Range(_minScale, _maxScale);

            // Устанавливаем итоговый размер
            transform.localScale = new Vector3(
                originalScale.x * newScale.x,
                originalScale.y * newScale.y,
                originalScale.z * newScale.z);

            // Устанавливаем итоговое вращение
            _randomRotation = new Vector3(
                Random.Range(-_rotationOffset, _rotationOffset),
                Random.Range(-_rotationOffset, _rotationOffset),
                Random.Range(-_rotationOffset, _rotationOffset));


        }

        private void Update()
        {
            transform.Rotate(_randomRotation * Time.deltaTime);
        }
    }
}