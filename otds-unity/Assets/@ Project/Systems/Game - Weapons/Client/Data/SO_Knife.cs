using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Weapons.Client
{
    [CreateAssetMenu(fileName = "SO_Knife", menuName = "ScriptableObject/Weapons/SO_Knife", order = 0)]
    public class SO_Knife : ScriptableObject
    {
        [SerializeField] float attackRate;
    }
}