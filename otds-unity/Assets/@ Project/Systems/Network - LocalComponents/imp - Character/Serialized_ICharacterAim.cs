using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character.Showcase
{

    public class Serialized_ICharacterAim : MonoBehaviour, Interfaces.ICharacterAim
    {
        public Func<Vector2> AimDirectionGetter { get; set; } = () => Vector2.zero;

        private Transform m_characterTransform;
        private void Awake()
        {
            m_characterTransform = GameObject.Find("<p> playerTransform").transform;
        }

        private void Update()
        {
            var aimDirection = AimDirectionGetter();
            var zAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            m_characterTransform.eulerAngles = new Vector3(0, 0, zAngle);

            Debug.DrawLine(m_characterTransform.position, m_characterTransform.position + ((Vector3)aimDirection * 5));
        }
    }

}