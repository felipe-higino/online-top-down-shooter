using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.PlayerState.Interfaces
{
    /// <summary>
    /// server-side sensible data that can't be trusted to clients
    /// </summary>
    public interface IPlayerState
    {
        //server
        Weapons.Data.SO_SimpleGun CurrentGun { get; }
        Transform GunSpawnPoint { get; }
        Transform PlayerLocation { get; }

        //client
        GameObject CurrentGunInstance { get; set; }
    }
}