using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cosmos6
{
    public class ShipHealth : MonoBehaviour, IDamagedable
    {
        [SerializeField] private float _health;
        public float Health => _health;

        private void Start()
        {

        }

        public void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
        {
            _health -= damageAmount;
            if (_health <= 0)
            {
                Debug.Log($"Attacker: {sender.gameObject.name}");
                Debug.Log($"Attacker Fraction: {sender.ShipFraction}");
                Destroy(gameObject);
            }
        }

        public void ReceiveHeal(float healAmount, Vector3 hitPosition, GameAgent sender)
        {
            throw new System.NotImplementedException();
        }
    }
}