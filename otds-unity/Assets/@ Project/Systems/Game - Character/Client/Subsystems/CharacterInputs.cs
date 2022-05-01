using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OTDS.Input;
using UnityEngine.InputSystem;
using Zenject;
using OTDS.Character.Interfaces;


namespace OTDS.Character.Client
{
    public class CharacterInputs : MonoBehaviour, GameInputs.ICharacterActions
    {
        [Space(15)]
        [Header("References")]
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Camera mainCamera;

        private GameInputs m_GameInputs;

        [Inject] private ICharacterMove m_characterMove;
        [Inject] private ICharacterAim m_characterAim;
        [Inject] private ICharacterShoot m_characterShoot;

        private void Awake()
        {
            m_GameInputs = new GameInputs();

            m_GameInputs.Character.AimPosition.performed += OnAimPosition;

            m_GameInputs.Character.Movement.performed += OnMovement;
            m_GameInputs.Character.Movement.canceled += OnMovement;

            m_GameInputs.Character.Shoot.performed += OnShoot;
            m_GameInputs.Character.Shoot.canceled += OnShoot;
        }

        private void OnEnable()
        {
            m_GameInputs.Enable();
        }

        private void OnDisable()
        {
            m_GameInputs.Disable();
        }

        public void OnAimPosition(InputAction.CallbackContext context)
        {
            var mouseScreenPosition = context.ReadValue<Vector2>();
            m_characterAim.AimDirectionGetter = () =>
            {
                var mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
                return ((Vector2)mouseWorldPosition - (Vector2)playerTransform.position).normalized;
            };
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            var moveDirection = context.ReadValue<Vector2>();
            m_characterMove.MoveDirection = moveDirection;
        }

        public void OnShoot(InputAction.CallbackContext context)
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