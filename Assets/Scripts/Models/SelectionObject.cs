using System;
using UnityEngine;

namespace Geekbrains
{
    public sealed class SelectionObject : BaseObjectScene, ISelectObject
    {
        [SerializeField] private string _name;
        protected override void Awake()
        {
            base.Awake();
            if (_name == String.Empty)
            {
                _name = gameObject.name;
            }
        }

        public string GetMessage()
        {
            return _name;
        }
    }
}