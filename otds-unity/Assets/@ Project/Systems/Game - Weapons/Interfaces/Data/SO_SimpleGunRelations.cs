using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Weapons.Data
{
    [System.Serializable]
    public class BulletSimplegunSchema
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private GameObject gunPrefab;
        [SerializeField] private Weapons.Data.SO_SimpleGun data;

        public Weapons.Data.SO_SimpleGun Data => data;
        public GameObject BulletPrefab => bulletPrefab;
        public GameObject GunPrefab => gunPrefab;
    }

    [System.Serializable]
    public class SimpleGunRelationsTable
    {
        [SerializeField] private BulletSimplegunSchema[] list;
        public IEnumerable List => list;
    }

    [CreateAssetMenu(fileName = "SO_BulletSimpleGun", menuName = "ScriptableObjects/Schemas/SO_BulletSimpleGun", order = 0)]
    public class SO_SimpleGunRelations : ScriptableObject
    {
        [SerializeField]
        private SimpleGunRelationsTable table;
        public SimpleGunRelationsTable Table => table;

    }
}