using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Character
{
    public class NonAut_CharacterMovement : A_CharacterMovement
    {
        [SerializeField] private Transform characterTransform;
        //TODO: extract to balance
        [SerializeField] private float velocity = 1f;

        //input loop
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