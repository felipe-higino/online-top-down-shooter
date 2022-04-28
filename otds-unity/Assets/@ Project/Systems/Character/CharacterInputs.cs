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


        [Space(15)]
        [Header("Injected Dependencies")]
        [SerializeField] private A_CharacterMovement characterMovement;
        [SerializeField] private A_CharacterAim characterAim;
        [SerializeField] private A_CharacterShoot characterShoot;

        private GameInputs m_GameInputs;

        private void Awake()
        {
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
            characterAim.AimDirection_Getter = () =>
            {
                var mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
                return ((Vector2)mouseWorldPosition - (Vector2)playerTransform.position).normalized;
            };
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            var moveDirection = context.ReadValue<Vector2>();
            characterMovement.MoveDirection = moveDirection;
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            characterShoot.OpenFire();
        }
    }

}