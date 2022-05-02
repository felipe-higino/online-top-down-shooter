using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Weapons.Data
{
    [System.Serializable]
    public class KnifeData
    {
        public float timeVisible;
        public float recoverTime;
    }

    [CreateAssetMenu(fileName = "SO_Knife", menuName = "ScriptableObject/Weapons/SO_Knife", order = 0)]
    public class SO_Knife : ScriptableObject
    {
        public KnifeData data;
    }
}