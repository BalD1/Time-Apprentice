using StdNounou.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace TimeApprentice
{
	[RequireComponent(typeof(PlayerInput))]
	public class PlayerInputsHandler : PersistentSingleton<PlayerInputsHandler>
    {
        [field: SerializeField] public PlayerInput InputsComponent { get; private set; }
        public Vector2 MovInputsValue { get; private set; }
        public Vector2 MouseMovInputsValue { get; private set; }

        public static bool IsMouseDown { get; private set; }

        private void Reset()
        {
            InputsComponent = this.GetComponent<PlayerInput>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            MouseMovInputsValue = context.ReadValue<Vector2>();
            this.LookInputs_Call(context);
        }

        public void OnMovements(InputAction.CallbackContext context)
        {
            MovInputsValue = context.ReadValue<Vector2>();
            this.MovementsInputs_Call(context);
        }

        public void OnMouse(InputAction.CallbackContext context)
        {
            if (context.performed) return;
            if (context.started)
            {
                IsMouseDown = true;
                this.MouseDown_Call();
                return;
            }
            IsMouseDown = false;
            this.MouseUp_Call();
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            this.PausePressed_Call();
        }

        public void CloseYoungestMenu(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            this.CloseYoungestMenu_Call();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            this.OnInteract_Call();
        }

        protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
        }

        protected override void OnSceneUnloaded(Scene scene)
        {
        }
    } 
}