using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cosmos6
{
    public interface IWeapon
    {
        Vector3 FireWeapon(Vector3 targetPosition);
        void Damage(float DamageAmount, Vector3 targetHitPosition, GameAgent sender);
        void VisualFireWeapon(Vector3 targetPosition);
    }
}