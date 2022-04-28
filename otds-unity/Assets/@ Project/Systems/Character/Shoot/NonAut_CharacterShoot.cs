using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character
{
    public class NonAut_CharacterShoot : A_CharacterShoot
    {
        //make dynamiacally assigned, instead of serialized 
        [SerializeField] Bullets.BulletSpawner bulletSpawner;
        //make dynamiacally assigned, instead of serialized 
        [SerializeField] Transform bulletSpawnPoint;

        public override void OpenFire()
        {
            bulletSpawner.SpawnNewBullet(bulletSpawnPoint);
        }

    }

}