using UnityEngine;

namespace TimeApprentice
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private float checkRadius = .4f;
        [SerializeField] private LayerMask groundMask;

#if UNITY_EDITOR
        [field: SerializeField] public bool ED_DebugMode { get; private set; }
#endif

        private bool wasReset = true;
        private bool isGrounded = false;

        private void LateUpdate()
        {
            isGrounded = false;
            wasReset = true;
        }

        public bool GetIsGrounded()
        {
            if (!wasReset) return isGrounded;

            wasReset = false;
            isGrounded = Physics.CheckSphere(this.transform.position, checkRadius, groundMask);
            return isGrounded;
        }

        private void OnDrawGizmos()
        {
            if (!ED_DebugMode) return;
            Gizmos.DrawWireSphere(this.transform.position, checkRadius);
        }
    }
}
