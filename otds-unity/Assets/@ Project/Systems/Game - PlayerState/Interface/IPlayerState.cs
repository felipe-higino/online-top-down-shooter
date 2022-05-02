using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.PlayerState.Interface
{
    public interface IPlayerState
    {
        GameObject CurrentGun { get; set; }
        int CurrentLife { get; set; }
        int Current { get; set; }
    }
}