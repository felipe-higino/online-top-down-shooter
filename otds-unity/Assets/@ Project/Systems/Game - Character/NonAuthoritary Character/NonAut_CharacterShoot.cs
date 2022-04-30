using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OTDS.Character.Interfaces;

namespace OTDS.Character.NonAuthoritary
{
    public class NonAut_CharacterShoot : MonoBehaviour, ICharacterShoot
    {
        //make dynamiacally assigned, instead of serialized 
        [SerializeField] Transform bulletSpawnPoint;

        public void CloseFire()
        {
            throw new System.NotImplementedException();
        }

        public void OpenFire()
        {
            if (enabled)
            {
                bulletSpawnPoint.gameObject.SendMessage("SpawnNewBullet");
            }
        }

        private void OnEnable() { }
    }

}