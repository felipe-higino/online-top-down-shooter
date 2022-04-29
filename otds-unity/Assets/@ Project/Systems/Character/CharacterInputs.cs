using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OTDS.Input;
using System;

namespace OTDS.Character
{
    public class CharacterInputs : MonoBehaviour, GameInputs.ICharacterActions
    {
        [Space(15)]
        [Header("Provisory")]
        //TODO: DECOUPLE THIS
        [SerializeField] Transform playerTransform;
        //TODO: DECOUPLE THIS
        [SerializeField] Camera mainCamera;


        private A_CharacterMovement m_characterMovement;
        private A_CharacterAim m_characterAim;
        private A_CharacterShoot m_characterShoot;

        private GameInputs m_GameInputs;

        private void Awake()
        {
            m_characterMovement = gameObject.ResolveComponent<A_CharacterMovement>();
            m_characterAim = gameObject.ResolveComponent<A_CharacterAim>();
            m_characterShoot = gameObject.ResolveComponent<A_CharacterShoot>();

            m_GameInputs = new GameInputs();
            m_GameInputs.Character.AimPosition.performed += OnAimPosition;
            m_GameInputs.Character.Movement.performed += OnMovement;
            m_GameInputs.Character.Movement.canceled += OnMovement;
            m_GameInputs.Character.Shoot.performed += OnShoot;
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
            m_characterAim.AimDirection_Getter = () =>
            {
                var mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
                return ((Vector2)mouseWorldPosition - (Vector2)playerTransform.position).normalized;
            };
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            var moveDirection = context.ReadValue<Vector2>();
            m_characterMovement.MoveDirection = moveDirection;
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            m_characterShoot.OpenFire();
        }
    }

}