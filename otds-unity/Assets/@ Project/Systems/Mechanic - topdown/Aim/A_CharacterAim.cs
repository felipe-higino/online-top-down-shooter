using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Mechanics.Topdown
{
    public abstract class A_CharacterAim : MonoBehaviour
    {
        public Func<Vector2> AimDirection_Getter = () => Vector2.zero;
    }

}