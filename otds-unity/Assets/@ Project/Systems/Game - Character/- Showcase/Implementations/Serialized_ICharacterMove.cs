using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character.Showcase
{

    public class Serialized_ICharacterMove : MonoBehaviour, Interfaces.ICharacterMove
    {
        public Vector2 MoveDirection { get; set; } = Vector2.zero;


        [SerializeField] private Transform characterTransform;
        [SerializeField] private float velocity = 1f;

        private void Update()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            var direction2D = new Vector3(MoveDirection.x, MoveDirection.y, 0);
            characterTransform.position += direction2D * velocity * Time.deltaTime;
        }

    }

}