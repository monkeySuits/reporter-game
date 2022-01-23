using MoreMountains.Feedbacks;
using UnityEngine;

/*
 * Responsible for player movement actions
 */

namespace devlog98.Backdoor {

#pragma warning disable 649

    public class PlayerMovement : MonoBehaviour {
        [Header("Walk")]
        [SerializeField] private CharacterController controller; // reference to character controller responsible for movement
        [SerializeField] private float speed = 11f; // movement speed
        private float speedMultiplier = 1f; // multiplier used to change base speed
        private Vector2 horizontalInput; // stores horizontal movement

        [Header("Jump")]
        [SerializeField] private float jumpHeight = 3.5f; // maximum jump height
        [SerializeField] private float gravity = -30f; // custom gravity
        [SerializeField] private float coyoteTimer = 0.2f; // threshold after exitting ground to jump again
        private float canJump; // if character can jump
        private bool isJumping; // if character is jumping

        [Header("Crouch")]
        [SerializeField] private float crouchHeight = 0.5f; // used to scale the character vertically
        [SerializeField] private float crouchSpeed; // speed to perform crouch action
        [SerializeField] [Range(0f, 1f)] private float crouchSlowdown; // slowdown when walking and crouching
        private bool isCrouching; // if character is crouching

        [Header("Collisions")]
        [SerializeField] private LayerMask groundMask; // used to check for ground collisions
        [SerializeField] private float groundRadiusCollision = 0.1f; // radius size to be checked against ground
        private Vector3 verticalVelocity; // upwards or downwards velocity on player
        private bool isGrounded; // if character is on the floor

        [Header("Feedbacks")]
        [SerializeField] private Animator animator; // reference to player animatoro
        [SerializeField] private MMFeedbacks walkFeedback; // feedbacks
        [SerializeField] private MMFeedbacks jumpFeedback;

        private void Update() {
            Walk();
            Crouch();
            Jump();
        }

        private void Walk() {
            // walk on the ground
            if ((horizontalInput.x != 0f || horizontalInput.y != 0f) && verticalVelocity.y == 0f) {
                //animator.SetBool("isWalking", true);
            }
            else {
                //animator.SetBool("isWalking", false);
            }

            Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * (speed * speedMultiplier);
            controller.Move(horizontalVelocity * Time.deltaTime);
        }

        private void Crouch() {
            // crouch
            if (isCrouching) {
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(transform.localScale.x, crouchHeight, transform.localScale.z), crouchSpeed * Time.deltaTime);
            }
            else {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, crouchSpeed * Time.deltaTime);
            }
        }

        private void Jump() {
            // reset vertical velocity when grounded
            isGrounded = Physics.CheckSphere(transform.position, groundRadiusCollision, groundMask);
            if (isGrounded) {
                verticalVelocity.y = 0f;
                canJump = coyoteTimer;
            }
            else {
                canJump -= Time.deltaTime;
            }

            // jump
            if (isJumping) {
                if (canJump > 0) {
                    //jumpFeedback.PlayFeedbacks();
                    verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
                }

                isJumping = false;
            }

            // apply gravity
            verticalVelocity.y += gravity * Time.deltaTime;
            controller.Move(verticalVelocity * Time.deltaTime);
        }

        // get horizontal input
        public void ReceiveInput(Vector2 hInput) {
            if (!PlayerLock.instance.IsLocked) {
                horizontalInput = hInput;
            }
            else {
                horizontalInput = Vector2.zero;
            }
        }

        // get crouch input
        public void OnCrouchPressed() {
            if (!PlayerLock.instance.IsLocked) {
                isCrouching = !isCrouching;

                // slowdown base movement if needed
                if (isCrouching) {
                    speedMultiplier = crouchSlowdown;
                }
                else {
                    speedMultiplier = 1f;
                }
            }
        }

        // get jump input
        public void OnJumpPressed() {
            if (!PlayerLock.instance.IsLocked) {
                isJumping = true;
            }
            else {
                isJumping = false;
            }
        }

        // play footstep sound effect
        public void MakeFootstep() {
            //walkFeedback.PlayFeedbacks();
        }
    }
}