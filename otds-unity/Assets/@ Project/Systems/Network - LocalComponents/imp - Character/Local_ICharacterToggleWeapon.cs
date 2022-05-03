using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;

namespace OTDS.Character.Showcase
{
    public class Local_ICharacterToggleWeapon : MonoBehaviour, OTDS.Character.Interfaces.ICharacterToggleWeapon
    {
        [Inject] OTDS.Weapons.Interfaces.ISimpleGunSpawner gunSpawner;
        [Inject] OTDS.PlayerState.Interfaces.IPlayerState playerState;

        [Inject]
        private void Init(
            OTDS.Weapons.Interfaces.ISimpleGunsDatabaseGetter databaseGetter)
        {
            m_avaiableWeapons = databaseGetter.database.Table.List.Select(x => x.Data).ToList();
        }

        private List<Weapons.Data.SO_SimpleGun> m_avaiableWeapons;

        private int _index = 0;
        private int Index
        {
            get => _index;
            set
            {
                var loopIndex = value;
                var lastIndex = m_avaiableWeapons.Count - 1;
                if (value < 0)
                    loopIndex = lastIndex;
                if (value > lastIndex)
                    loopIndex = 0;

                _index = loopIndex;

                var weapon = m_avaiableWeapons[Index];
                gunSpawner.GivePlayerSimpleGun(weapon);
            }
        }

        private bool SetupIndex()
        {
            var currentGun = playerState.CurrentGun;
            if (null == currentGun)
                return false;

            var currentIndex = m_avaiableWeapons.IndexOf(currentGun);
            _index = currentIndex;

            return true;
        }

        public void OnNegative()
        {
            if (SetupIndex())
                Index--;
        }

        public void OnPositive()
        {
            if (SetupIndex())
                Index++;
        }
    }
}