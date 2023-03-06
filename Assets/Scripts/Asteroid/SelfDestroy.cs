using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos6
{
    //Скрипт чтобы уничтожение астероидов не зацикливалось
    public class SelfDestroy : MonoBehaviour
    {
        public float TimeBeforeExplosive = 2f;
        void Start()
        {
            StartCoroutine(SelfDestruct());
        }

        // Update is called once per frame
        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(TimeBeforeExplosive);

            Destroy(gameObject);
        }
    }
}