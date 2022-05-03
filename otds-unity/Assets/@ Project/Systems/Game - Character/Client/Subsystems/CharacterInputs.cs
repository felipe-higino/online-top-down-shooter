using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OTDS.Character.Interfaces;

namespace OTDS.Character.Client
{
    public class CharacterInputs : CharacterInputsBase
    {
        protected override ICharacterMove CharacterMove { get; set; }
        protected override ICharacterAim CharacterAim { get; set; }
        protected override ICharacterShoot CharacterShoot { get; set; }
        protected override ICharacterToggleWeapon CharacterToggleWeapon { get; set; }

        protected override void Awake()
        {
            CharacterMove = GetComponent<ICharacterMove>();
            CharacterAim = GetComponent<ICharacterAim>();
            CharacterShoot = GetComponent<ICharacterShoot>();
            CharacterToggleWeapon = GetComponent<ICharacterToggleWeapon>();

            base.Awake();
        }
    }

}