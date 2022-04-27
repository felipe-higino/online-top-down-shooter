using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OTDS.Input;

namespace OTDS.Character
{
    public class CharacterController : MonoBehaviour, GameInputs.IGameplayActions
    {
        [Space(15)]
        [Header("Injected Dependencies")]
        //TODO: DECOUPLE THIS
        [SerializeField] Transform playerTransform;
        //TODO: DECOUPLE THIS
        [SerializeField] Camera mainCamera;

        [SerializeField] private A_CharacterMovement characterMovement;
        [SerializeField] private A_CharacterAim characterAim;

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
    }

}