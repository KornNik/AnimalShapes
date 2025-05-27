using Helpers;
using Helpers.Extensions;
using UnityEngine;
using Behaviours;
using System;

namespace Inputs
{
    abstract class BaseInputs : IInitialization, IInputEvents
    {
        public event Action<Ray> RayProjected;
        public event Action<Vector3> MousePosition; 

        protected Camera _camera;
        protected bool _isCanProcessing = true;
        protected InputActions _inputsActions;
        protected Vector3 _screenClickPosition;



        public BaseInputs()
        {
            Initialization();
        }

        public Camera Camera => _camera;
        public InputActions InputsActions => _inputsActions;

        public virtual void Initialization()
        {
            _camera = Camera.main;
            _inputsActions = Services.Instance.Inputs.ServicesObject;
        }
        public void Update()
        {
            UpdateControll();
        }

        protected virtual void UpdateControll()
        {
            if (IsTouchingPerform())
            {
                ProjectRay();
                _isCanProcessing = false;
            }
            else
            {
                _isCanProcessing = true;
            }
        }
        protected void ProjectRay()
        {
            if (_isCanProcessing)
            {
                var ray = GetScreenInputRay();
                RayProjected?.Invoke(ray);
                MousePosition?.Invoke(_screenClickPosition);
            }
        }

        protected abstract Ray GetScreenInputRay();
        protected abstract Vector2 GetScreenInputPosition();
        protected abstract bool IsTouchingPerform();
    }
}
