using System;

namespace OTDS.Weapons.Interfaces
{
    public interface IKnifeAttack
    {
        void SingleAttack(Data.KnifeData data, Action Start, Action End);
    }
}