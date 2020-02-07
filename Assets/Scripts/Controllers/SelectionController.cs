using System;
using GeekBrains;
using UnityEngine;

namespace Geekbrains
{
    public class SelectionController : BaseController, IExecute
    {
        private readonly Camera _mainCamera;
        private readonly Vector2 _center;
        private readonly float _dedicateDistance = 10;
        private GameObject _dedicatedObj;
        private ISelectObject _selectedObj;
        private bool _nullString;
        private bool _isSelectedObj;

        public SelectionController()
        {
            _mainCamera = Camera.main;
            _center = new Vector2(Screen.width / 2, Screen.height / 2);
        }

        public void Execute()
        {
            if (!IsActive) return;
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(_center), out var hit, _dedicateDistance))
            {
                SelectObject(hit.collider.gameObject);
                _nullString = false;
            }
            else if(!_nullString)
            {
                UiInterface.SelectionObjMessageUi.Text = String.Empty;
                _nullString = true;
                _dedicatedObj = null;
                _isSelectedObj = false;
            }
            if (_isSelectedObj)
            {
                // Действие над объектом

            }

        }

       private void SelectObject(GameObject obj)
       {
           if (obj == _dedicatedObj) return;
           _selectedObj = obj.GetComponent<ISelectObject>();
           if (_selectedObj != null)
           {
               UiInterface.SelectionObjMessageUi.Text = _selectedObj.GetMessage();
               _isSelectedObj = true;
           }else {
               UiInterface.SelectionObjMessageUi.Text = String.Empty; 
               _isSelectedObj = false;
           }
           _dedicatedObj = obj;
        }
    }
}