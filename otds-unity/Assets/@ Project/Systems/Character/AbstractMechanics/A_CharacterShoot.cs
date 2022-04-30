using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character
{
    public abstract class A_CharacterShoot : MonoBehaviour
    {
        public abstract void OpenFire();
        //TODO: gun position (offset and bullet spawn position relative to gun)
    }
}