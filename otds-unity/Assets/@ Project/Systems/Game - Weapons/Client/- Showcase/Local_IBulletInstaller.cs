using UnityEngine;
using OTDS.Bullets.Interfaces;

namespace OTDS.Weapon.Client.Showcase
{
    public class Local_IBulletInstaller : MonoBehaviour, IBulletSpawner
    {
        public GameObject currentBulletPrefab;

        public void SpawnNewBullet()
        {
            throw new System.NotImplementedException();
        }
    }
}