using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Libs.InlineScriptableObject.Showcase
{
    public class MyInline : MonoBehaviour
    {
        [Range(0, 1)]
        public double myrange;
        public double MyRange
        {
            get => myrange; set
            {
                myrange = value;
                Debug.Log($"[{name}] MyRange setted to {value}");
            }
        }

        [SerializeField]
        MonoMyInline MonoMyInline;
        [SerializeField]
        MonoMyInline MonoMyInline2;
        [SerializeField]
        MonoMyInline MonoMyInline3;
        [SerializeField]
        MonoMyInline[] MonoMyInlinelist;

        [SerializeField]
        SO_MyInline myInlineSO;

        public void CallSomething()
        {
            Debug.Log(myInlineSO.otherNestedClass.myrange);
        }

        private void OnValidate()
        {
            Debug.Log($"{name} is validating");
        }
    }
}