using System;

namespace OTDS.Weapons.Interfaces
{
    public interface ISimpleGunsDatabaseGetter
    {
        Data.SO_SimpleGunRelations database { get; }
    }
}