using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Libs.InlineScriptableObject.Showcase
{
    public class MonoMyInline : MonoBehaviour
    {
        [Range(0, 1)]
        public double myrange;
        [SerializeField]
        private int myint;

        [SerializeField]
        private UnityEvent OnValidation;

        [System.Serializable]
        public class SetDouble : UnityEvent<double> { }
        [SerializeField]
        private SetDouble OnSetDouble;

        private void OnValidate()
        {
            OnValidation.Invoke();
            OnSetDouble.Invoke(myrange);
        }
    }

}