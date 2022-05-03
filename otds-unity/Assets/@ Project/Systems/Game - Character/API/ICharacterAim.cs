using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character.Interfaces
{

    public interface ICharacterAim
    {
        Func<Vector2> AimDirectionGetter { get; set; }
    }

}