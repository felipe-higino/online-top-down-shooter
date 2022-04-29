using System;
using System.Collections.Generic;
using UnityEngine;

namespace Libs.InlineScriptableObject.Showcase
{
    public class SO_MyInline : ScriptableObject
    {
        public int myint;
        public List<string> myStringList;
        public OtherNestedClass otherNestedClass;
        public NestedClass[] nestedArray;

        [SerializeField, Range(0, 1)]
        private double myrange1;
        [SerializeField, HideInInspector]
        private double _myrange1;

        public double Myrange1
        {
            get => myrange1;
            set
            {
                if (value != _myrange1)
                {
                    myrange1 = value;

                    var notifier = FindObjectOfType<EditorNotifier>();
                    notifier?.Notify();
                }

                _myrange1 = myrange1;
            }
        }

        [Serializable]
        public class NestedClass
        {
            public GameObject gameobjectref;
            public OtherNestedClass otherNestedClass;
            public OtherNestedClass[] otherNestedClassArray;
        }

        [Serializable]
        public class OtherNestedClass
        {
            public string name;
            public myenum enumm;
            [Range(0, 1)]
            public double myrange;
        }

        public enum myenum { enum1, enum2 }

        private void OnValidate()
        {
            Myrange1 = myrange1;
        }
    }
}