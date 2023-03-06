using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos6
{
    public interface IDamagedable
    {
        float Health { get; }
        //аргументы - Количество урона, точка в которую мы поражаем обьект, обьект который нанес урон
        void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender);//damage
        void ReceiveHeal(float healAmount, Vector3 hitPosition, GameAgent sender);//heal

    }
}