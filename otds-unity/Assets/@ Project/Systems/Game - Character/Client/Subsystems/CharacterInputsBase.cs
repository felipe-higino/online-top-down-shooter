using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OTDS.Input;
using OTDS.Character.Interfaces;

namespace OTDS.Character.Client
{

    public class CharacterInputsBase : MonoBehaviour, GameInputs.ICharacterActions
    {
        [Space(15)]
        [Header("References")]
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Camera mainCamera;

        protected GameInputs m_GameInputs;

        protected virtual ICharacterMove CharacterMove { get; set; } = null;
        protected virtual ICharacterAim CharacterAim { get; set; } = null;
        protected virtual ICharacterShoot CharacterShoot { get; set; } = null;
        protected virtual ICharacterToggleWeapon CharacterToggleWeapon { get; set; } = null;

        protected virtual void Awake()
        {
            m_GameInputs = new GameInputs();

            if (null != CharacterAim)
            {
                m_GameInputs.Character.AimPosition.performed += OnAimPosition;
            }

            if (null != CharacterMove)
            {
                m_GameInputs.Character.Movement.performed += OnMovement;
                m_GameInputs.Character.Movement.canceled += OnMovement;
            }

            if (null != CharacterShoot)
            {
                m_GameInputs.Character.Shoot.performed += OnShoot;
                m_GameInputs.Character.Shoot.canceled += OnShoot;
            }

            if (null != CharacterToggleWeapon)
            {
                m_GameInputs.Character.ToggleWeapon.performed += OnToggleWeapon;
            }
        }

        protected void OnEnable()
        {
            m_GameInputs.Enable();
        }

        protected void OnDisable()
        {
            m_GameInputs.Disable();
        }

        public virtual void OnAimPosition(InputAction.CallbackContext context)
        {
            var mouseScreenPosition = context.ReadValue<Vector2>();
            CharacterAim.AimDirectionGetter = () =>
            {
                var mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
                return ((Vector2)mouseWorldPosition - (Vector2)playerTransform.position).normalized;
            };
        }

        public virtual void OnMovement(InputAction.CallbackContext context)
        {
            var moveDirection = context.ReadValue<Vector2>();
            CharacterMove.MoveDirection = moveDirection;
        }

        public virtual void OnShoot(InputAction.CallbackContext context)
        {
            var buttonDown = context.ReadValueAsButton();
            if (buttonDown)
            {
                CharacterShoot.OpenFire();
            }
            else
            {
                CharacterShoot.CloseFire();
            }
        }

        public virtual void OnToggleWeapon(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<float>();

            if (value < 0)
            {
                CharacterToggleWeapon.OnNegative();
                return;
            }

            if (value > 0)
            {
                CharacterToggleWeapon.OnPositive();
                return;
            }
        }
    }

}