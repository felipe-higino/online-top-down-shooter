using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OTDS.Input;

namespace OTDS.Character.Client
{

    public class CharacterInputsBase : MonoBehaviour, GameInputs.ICharacterActions
    {
        protected GameInputs m_GameInputs;

        protected void Awake()
        {
            m_GameInputs = new GameInputs();

            m_GameInputs.Character.AimPosition.performed += OnAimPosition;

            m_GameInputs.Character.Movement.performed += OnMovement;
            m_GameInputs.Character.Movement.canceled += OnMovement;

            m_GameInputs.Character.Shoot.performed += OnShoot;
            m_GameInputs.Character.Shoot.canceled += OnShoot;
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
            Debug.Log("aim");
        }

        public virtual void OnMovement(InputAction.CallbackContext context)
        {
            Debug.Log("move");
        }

        public virtual void OnShoot(InputAction.CallbackContext context)
        {
            Debug.Log("shoot");
        }
    }

}