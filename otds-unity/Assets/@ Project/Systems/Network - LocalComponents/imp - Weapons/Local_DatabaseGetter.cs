using System.Collections;
using System.Collections.Generic;
using OTDS.Weapons.Data;
using UnityEngine;

namespace OTDS.Weapons.Showcase
{
    public class Local_DatabaseGetter : MonoBehaviour, Interfaces.ISimpleGunsDatabaseGetter
    {
        [field: SerializeField] public SO_SimpleGunRelations database { get; set; }
    }

}