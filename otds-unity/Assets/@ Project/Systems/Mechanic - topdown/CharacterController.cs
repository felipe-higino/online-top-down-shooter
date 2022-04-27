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

        [SerializeField] private A_CharacterMovement characterMovement;

        public void OnAimPosition(InputAction.CallbackContext context)
        {
            var position = context.ReadValue<Vector2>();
            Debug.Log($"position: {position.x}, {position.y}");
        }

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            characterMovement.MoveDirection = direction;
        }
    }

}