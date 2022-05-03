using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace OTDS.Character.Client
{

    public class CharacterInputsUnityEvents : CharacterInputsBase
    {

        [Header("-- Shoot --")]
        [SerializeField] UnityEvent OnShootStart;
        [SerializeField] UnityEvent OnShootEnd;

        public override void OnAimPosition(InputAction.CallbackContext context)
        {
            // base.OnAimPosition(context);
        }

        public override void OnMovement(InputAction.CallbackContext context)
        {
            // base.OnMovement(context);
        }

        public override void OnShoot(InputAction.CallbackContext context)
        {
            var buttonDown = context.ReadValueAsButton();
            if (buttonDown)
            {
                OnShootStart.Invoke();
            }
            else
            {
                OnShootEnd.Invoke();
            }
        }
    }

}