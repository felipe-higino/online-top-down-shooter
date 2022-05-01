using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OTDS.Character.Showcase
{

    public class UnityEvent_ICharacterShoot : MonoBehaviour, Interfaces.ICharacterShoot
    {
        [SerializeField] UnityEvent OnShootStart;
        [SerializeField] UnityEvent OnShootEnd;

        public void CloseFire()
        {
            OnShootStart.Invoke();
        }

        public void OpenFire()
        {
            OnShootEnd.Invoke();
        }
    }

}