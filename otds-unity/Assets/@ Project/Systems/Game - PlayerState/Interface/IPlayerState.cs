using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.PlayerState.Interface
{
    public interface IPlayerState
    {
        Weapons.Data.SO_SimpleGun CurrentGun { get; }
        GameObject PlayerRoot { get; }
        Transform GunSpawnPoint { get; }
        // GameObject CurrentGun { get; set; }
        // int CurrentLife { get; set; }
    }
}