using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos6
{
    public class AsteroidHealth : MonoBehaviour, IDamagedable
    {
        public float Health { get; set; }
        [SerializeField] private GameObject PrebafEffectDestroy; //эффект разрушения

        [SerializeField] private GameObject PrebafAsteroidDivision; //эффект разрушения

        public bool Destroyed = false; //вводим переменную чтобы не вызывать эффект уничтожения от каждой пушки

        public int DivisionCounter = 2; //переменная для количество раз появления обломков
        public void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
        {
            Health -= damageAmount;

            if (Health <= 0 && !Destroyed) // Если здоровье меньше 0 и обьект не разрушен
            {
                if (PrebafEffectDestroy)
                    Instantiate(PrebafEffectDestroy, transform.position, Quaternion.identity);

                if (PrebafAsteroidDivision != null && DivisionCounter > 0)
                {
                    //Делаем осколки астероида
                    Vector3 Shard1Pos = new Vector3(
                    transform.position.x + Random.Range(-0.2f, 0.2f),
                    transform.position.y + Random.Range(-0.2f, 0.2f),
                    transform.position.z + Random.Range(-0.2f, 0.2f));

                    Vector3 Shard2Pos = new Vector3(
                    transform.position.x + Random.Range(-0.2f, 0.2f),
                    transform.position.y + Random.Range(-0.2f, 0.2f),
                    transform.position.z + Random.Range(-0.2f, 0.2f));
                    // +/- PrebafAsteroidDivision.transform.localeScale - чтобы они не были друг в друге
                    var s1 = Instantiate(PrebafAsteroidDivision, Shard1Pos + PrebafAsteroidDivision.transform.localScale, Quaternion.identity);
                    var s2 = Instantiate(PrebafAsteroidDivision, Shard2Pos - PrebafAsteroidDivision.transform.localScale, Quaternion.identity);

                    //Уменьшаем количество разваливания астероида и детей на обломки
                    s1.GetComponent<AsteroidHealth>().DivisionCounter = DivisionCounter--;
                    s2.GetComponent<AsteroidHealth>().DivisionCounter = DivisionCounter--;
                }

                ManagerScore.Instance.AddScore(1);//начисление очков

                Destroyed = true;  // Если еще какое оружие попадет в уже разрушенный обьект, то больше код не отработает

                Destroy(gameObject);
            }
        }

        public void ReceiveHeal(float healAmount, Vector3 hitPosition, GameAgent sender)
        {
            throw new System.NotImplementedException();
        }
        void Start()
        {

        }
    }
}