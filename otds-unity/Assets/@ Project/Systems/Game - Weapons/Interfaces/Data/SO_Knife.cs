using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Weapons.Data
{
    [System.Serializable]
    public class KnifeData
    {
        [SerializeField] private float timeVisible;
        [SerializeField] private float recoverTime;

        public float TimeVisible => timeVisible;
        public float RecoverTime => recoverTime;
    }

    [CreateAssetMenu(fileName = "SO_Knife", menuName = "ScriptableObject/Weapons/SO_Knife", order = 0)]
    public class SO_Knife : ScriptableObject
    {
        [SerializeField]
        private KnifeData data;
        public KnifeData Data => data;
    }
}