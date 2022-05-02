using System;
using UnityEngine;

namespace OTDS.Weapons.Interfaces
{
    public interface IKnifeAttack
    {
        void SingleAttack(Data.KnifeData data, Action Start, Action End);
    }

    // public interface ISimpleGunShoot
    // {
    //     void Shoot(Data.SimpleGunData data, Action );
    // }
}