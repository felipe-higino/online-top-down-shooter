using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OTDS.Bullets.Interfaces;
using Photon.Pun;

namespace OTDS.Network.PhotonComponents
{
    /// <summary>
    /// Solves bullet data synced with photon server (prefab spawn)
    /// </summary>
    public class BulletDataResolver : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;

        private float m_secondsLifetime;

        public void Init(BulletData bulletData)
        {
            //server-side responsibilities
            Movement(bulletData.startVelocity, S_NetworkedAvatar.Instance.transform.right);
            BulletLifetime(bulletData.bulletLifetime);
        }


        private void Movement(float startVelocity, Vector2 direction)
        {
            rb.AddForce(direction * startVelocity);
        }

        private void BulletLifetime(float bulletLifetime)
        {
            m_secondsLifetime = bulletLifetime;
            StartCoroutine(Chronometer());
        }

        private IEnumerator Chronometer()
        {
            yield return new WaitForSeconds(m_secondsLifetime);
            PhotonNetwork.Destroy(gameObject);
        }

        //TODO: CURRENT GUN SPAWN APPROACH
        //TODO: SPAWN RATE
    }

}