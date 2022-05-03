using System;

namespace OTDS.Weapons.Interfaces
{
    public interface ISimpleGunSpawner
    {
        void GivePlayerSimpleGun(Data.SO_SimpleGun simpleGun);
    }
}