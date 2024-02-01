using StdNounou.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TimeApprentice
{
    public class PlayerLook : MonoBehaviourEventsHandler
    {
        [SerializeField] private float mouseSensitivity = 100f;
        [SerializeField] private Transform playerBody;

        private float xRotation;

        protected override void EventsSubscriber()
        {
            PlayerInputsHandlerEvents.OnLookInputs += OnLookInputs;
        }

        protected override void EventsUnSubscriber()
        {
            PlayerInputsHandlerEvents.OnLookInputs -= OnLookInputs;
        }

        private void OnLookInputs(InputAction.CallbackContext context)
        {
            Vector2 axis = context.ReadValue<Vector2>();
            float mouseX = axis.x * mouseSensitivity * Time.deltaTime;
            float mouseY = axis.y * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            this.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
