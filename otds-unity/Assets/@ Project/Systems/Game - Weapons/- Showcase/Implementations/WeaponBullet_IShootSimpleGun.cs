using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Weapons.Showcase
{

    public class WeaponBullet_IShootSimpleGun : MonoBehaviour, Interfaces.IShootSimpleGun
    {
        public void SingleShoot()
        {
            Debug.Log("single shoot");
        }
    }

}