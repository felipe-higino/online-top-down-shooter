using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Libs.InlineScriptableObject.Showcase
{

    public class EditorNotifier : MonoBehaviour
    {
        [SerializeField]
        private string message;

        public void Notify()
        {
            Debug.Log(message);
        }
    }
}
