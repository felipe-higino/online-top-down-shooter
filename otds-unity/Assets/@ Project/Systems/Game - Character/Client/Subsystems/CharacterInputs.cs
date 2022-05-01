using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using OTDS.Character.Interfaces;

namespace OTDS.Character.Client
{
    public class CharacterInputs : CharacterInputsBase
    {
        [Space(15)]
        [Header("References")]
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Camera mainCamera;

        [Inject] private ICharacterMove m_characterMove;
        [Inject] private ICharacterAim m_characterAim;
        [Inject] private ICharacterShoot m_characterShoot;

        public override void OnAimPosition(InputAction.CallbackContext context)
        {
            var mouseScreenPosition = context.ReadValue<Vector2>();
            m_characterAim.AimDirectionGetter = () =>
            {
                var mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
                return ((Vector2)mouseWorldPosition - (Vector2)playerTransform.position).normalized;
            };
        }

        public override void OnMovement(InputAction.CallbackContext context)
        {
            var moveDirection = context.ReadValue<Vector2>();
            m_characterMove.MoveDirection = moveDirection;
        }

        public override void OnShoot(InputAction.CallbackContext context)
        {
            var buttonDown = context.ReadValueAsButton();
            if (buttonDown)
            {
                m_characterShoot.OpenFire();
            }
            else
            {
                m_characterShoot.CloseFire();
            }
        }

    }

}