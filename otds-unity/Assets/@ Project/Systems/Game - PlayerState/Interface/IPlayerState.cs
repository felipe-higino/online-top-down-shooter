using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.PlayerState.Interface
{
    /// <summary>
    /// server-side sensible data that can't be trusted to clients
    /// </summary>
    public interface IPlayerState
    {
        Weapons.Data.SO_SimpleGun CurrentGun { get; }
        Transform GunSpawnPoint { get; }
    }
}