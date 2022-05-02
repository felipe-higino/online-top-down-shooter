using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Weapons.Data
{

    [CreateAssetMenu(fileName = "SO_SimpleGun", menuName = "ScriptableObject/Weapons/SO_SimpleGun", order = 0)]
    public class SO_SimpleGun : ScriptableObject
    {
        [SerializeField] private int maxBullets;
        [SerializeField] private float shootRate;
    }

}