using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        public IEnumerable<BulletSimplegunSchema> List => list;
    }

    [CreateAssetMenu(fileName = "SO_BulletSimpleGun", menuName = "ScriptableObjects/Schemas/SO_BulletSimpleGun", order = 0)]
    public class SO_SimpleGunRelations : ScriptableObject
    {
        [SerializeField]
        private SimpleGunRelationsTable table;
        public SimpleGunRelationsTable Table => table;

        //Queries
        public BulletSimplegunSchema Find(Data.SO_SimpleGun gunID)
        {
            var dataToSpawn = Table.List.First(x => x.Data == gunID);
            if (null == dataToSpawn)
            {
                return null;
            }
            else
            {
                return dataToSpawn;
            }
        }

    }
}