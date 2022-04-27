using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Mechanics.Topdown
{
    public class NonAut_CharacterAim : A_CharacterAim
    {
        [SerializeField] Transform characterTransform;

        private void Update()
        {
            var aimDirection = AimDirection_Getter();
            var zAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            characterTransform.eulerAngles = new Vector3(0, 0, zAngle);

            Debug.DrawLine(characterTransform.position, characterTransform.position + ((Vector3)aimDirection * 5));
        }
    }
}