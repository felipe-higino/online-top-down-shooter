using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character.NonAuthoritary
{
    public class NonAut_ICharacterShoot : ICharacterShoot
    {
        //make dynamiacally assigned, instead of serialized 
        // [SerializeField] Transform bulletSpawnPoint;

        public void OpenFire()
        {
            Debug.Log("called open fire in NonAut_ICharacterShoot");
            // bulletSpawnPoint.gameObject.SendMessage("SpawnNewBullet");
        }
    }

}