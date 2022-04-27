using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OTDS.Input;

namespace OTDS.Mechanics.Topdown
{
    public class CharacterController : MonoBehaviour, GameInputs.IGameplayActions
    {
        [Space(15)]
        [Header("Injected Dependencies")]
        //TODO: DECOUPLE THIS
        [SerializeField] Transform playerTransform;
        //TODO: DECOUPLE THIS
        private Camera m_Camera;

        [SerializeField] private A_CharacterMovement characterMovement;
        [SerializeField] private A_CharacterAim characterAim;

        private void Awake()
        {
            m_Camera = Camera.main;
        }

        public void OnAimPosition(InputAction.CallbackContext context)
        {
            var mouseScreenPosition = context.ReadValue<Vector2>();
            characterAim.AimDirection_Getter = () =>
            {
                var mouseWorldPosition = m_Camera.ScreenToWorldPoint(mouseScreenPosition);
                return ((Vector2)mouseWorldPosition - (Vector2)playerTransform.position).normalized;
            };
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            var moveDirection = context.ReadValue<Vector2>();
            characterMovement.MoveDirection = moveDirection;
        }
    }

}