using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Libs.BoilerplateWrappers
{
    /// <summary>
    /// Extend this to create a component that has the method <see cref="A_CallInsideUpdate.Call"/> that is called every frame by a [Update] Singleton GameObject
    /// </summary>
    public abstract class A_CallInsideUpdate : MonoBehaviour
    {
        /// <summary>
        /// Called every frame by a [Replication Loop] Singleton GameObject
        /// </summary>
        public abstract void Call();

        private static List<A_CallInsideUpdate> callables = new List<A_CallInsideUpdate>();
        private static UpdateComponent m_replicationLoop;

        private void Awake()
        {
            InstantiateLoop();
            callables.Add(this);
        }

        private void OnDestroy()
        {
            callables.Remove(this);
        }

        private void InstantiateLoop()
        {
            if (null != m_replicationLoop)
                return;

            var newGameObject = new GameObject("[Update]");
            m_replicationLoop = newGameObject.AddComponent<UpdateComponent>();
        }

        /// <summary>
        /// Helper Component, just to have an Update loop
        /// </summary>
        private class UpdateComponent : MonoBehaviour
        {
            private void Update()
            {
                foreach (var replicable in A_CallInsideUpdate.callables)
                {
                    replicable.Call();
                }
            }
        }
    }
}
