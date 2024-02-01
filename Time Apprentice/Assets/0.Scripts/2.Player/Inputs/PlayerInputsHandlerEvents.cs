using System;
using UnityEngine.InputSystem;

namespace TimeApprentice
{
	public static class PlayerInputsHandlerEvents
	{
        public static event Action<InputAction.CallbackContext> OnLookInputs;
        public static void LookInputs_Call(this PlayerInputsHandler inputsHandler, InputAction.CallbackContext context)
            => OnLookInputs?.Invoke(context);

        public static event Action<InputAction.CallbackContext> OnMovementsInputs;
        public static void MovementsInputs_Call(this PlayerInputsHandler inputsHandler, InputAction.CallbackContext context)
            => OnMovementsInputs?.Invoke(context);

        public static event Action OnMouseDown;
        public static void MouseDown_Call(this PlayerInputsHandler inputsHandler)
            => OnMouseDown?.Invoke();

        public static event Action OnMouseUp;
        public static void MouseUp_Call(this PlayerInputsHandler inputsHandler)
            => OnMouseUp?.Invoke();

        public static event Action OnPausePressed;
        public static void PausePressed_Call(this PlayerInputsHandler inputsHandler)
            => OnPausePressed?.Invoke();

        public static event Action OnCloseYoungestMenu;
        public static void CloseYoungestMenu_Call(this PlayerInputsHandler inputsHandler)
            => OnCloseYoungestMenu?.Invoke();

        public static event Action OnInteract;
        public static void OnInteract_Call(this PlayerInputsHandler inputsHandler)
            => OnInteract?.Invoke();
    } 
}