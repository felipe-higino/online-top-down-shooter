using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

namespace OTDS.Network.PhotonComponents
{

    public class OnAllChildrenDeactivated : MonoBehaviour, IPunInstantiateMagicCallback
    {
        [SerializeField] private UnityEvent onAllChildrenDisabled;

        private int _activeCount = -1;
        private int ActiveCount
        {
            get => _activeCount;
            set
            {
                _activeCount = value;
                if (ActiveCount == 0)
                {
                    onAllChildrenDisabled.Invoke();
                }
            }
        }

        public void OnPhotonInstantiate(PhotonMessageInfo info)
        {
            foreach (Transform child in transform)
            {
                var component = child.gameObject.AddComponent<OnDeactivateCallback>();
                component.owner = this;
            }
            if (ActiveCount == -1)
                ActiveCount = 0;
        }

        private class OnDeactivateCallback : MonoBehaviour
        {
            public OnAllChildrenDeactivated owner;

            private void OnEnable()
            {
                owner.ActiveCount++;
            }

            private void OnDisable()
            {
                owner.ActiveCount--;
            }
        }
    }

}