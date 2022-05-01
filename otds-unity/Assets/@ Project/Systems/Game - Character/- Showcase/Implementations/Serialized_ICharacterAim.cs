using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character.Showcase
{

    public class Serialized_ICharacterAim : MonoBehaviour, Interfaces.ICharacterAim
    {
        public Func<Vector2> AimDirectionGetter { get; set; } = () => Vector2.zero;

        [SerializeField] Transform characterTransform;

        private void Update()
        {
            var aimDirection = AimDirectionGetter();
            var zAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            characterTransform.eulerAngles = new Vector3(0, 0, zAngle);

            Debug.DrawLine(characterTransform.position, characterTransform.position + ((Vector3)aimDirection * 5));
        }
    }

}