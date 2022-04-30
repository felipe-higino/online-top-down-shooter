using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OTDS.Bullets.Interfaces
{
    public class BulletData
    {
        public float startVelocity;
        public Vector2 spawnPosition;
        public Quaternion spawnRotation;

        public BulletData(SO_BulletData bulletData, Transform playerTransform)
        {
            startVelocity = bulletData.StartVelocity;
            spawnRotation = playerTransform.rotation;
            //TODO: OFFSET CALCULATION
            spawnPosition = playerTransform.position;
        }
    }
}