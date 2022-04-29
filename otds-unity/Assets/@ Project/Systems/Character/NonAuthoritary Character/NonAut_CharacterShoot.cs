using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character.NonAuthoritary
{
    public class NonAut_CharacterShoot : A_CharacterShoot
    {
        //make dynamiacally assigned, instead of serialized 
        [SerializeField] Transform bulletSpawnPoint;

        public override void OpenFire()
        {
            if (enabled)
            {
                bulletSpawnPoint.gameObject.SendMessage("SpawnNewBullet");
            }
        }

        private void OnEnable() { }
    }

}