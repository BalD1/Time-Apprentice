using StdNounou.Core;
using StdNounou.Core.ComponentsHolder;
using StdNounou.Stats;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TimeApprentice
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviourEventsHandler
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private BaseComponentHolder componentHolder;
        [SerializeField] private GroundCheck groundCheck;
        private MonoStatsHandler statsHandler;

        public float jh = 3f;

        private Vector3 velocity;
        private Vector2 inputValue;

        private void Reset()
        {
            characterController = this.GetComponent<CharacterController>();
        }

        protected override void Awake()
        {
            base.Awake();
            componentHolder.HolderTryGetComponent(E_ComponentsKeys.StatsHandler, out statsHandler);
        }

        protected override void EventsSubscriber()
        {
            PlayerInputsHandlerEvents.OnMovementsInputs += OnMovementInput;
        }

        protected override void EventsUnSubscriber()
        {
            PlayerInputsHandlerEvents.OnMovementsInputs -= OnMovementInput;
        }

        private void OnMovementInput(InputAction.CallbackContext context)
        {
            inputValue = context.ReadValue<Vector2>();
        }

        private void Update()
        {
            HandleMovements();
            HandleVerticalMovements();
        }

        private void HandleMovements()
        {
            if (!statsHandler.StatsHandler.TryGetFinalStat(E_StatsKeys.Speed, out float speed))
            {
                this.LogError($"Could not find speed stat in {statsHandler}.");
                return;
            }

            Vector3 movement = (transform.right * inputValue.x) + (transform.forward * inputValue.y);
            characterController.Move(movement * speed * Time.deltaTime);
        }

        private void HandleVerticalMovements()
        {
            if (velocity.y < 0 && groundCheck.GetIsGrounded())
            {
                velocity.y = -2f;
            }

            if (Input.GetButtonDown("Jump") && groundCheck.GetIsGrounded())
            {
                velocity.y = Mathf.Sqrt(jh * -2f * Gamerules.Gravity);
            }

            velocity.y += Gamerules.Gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
