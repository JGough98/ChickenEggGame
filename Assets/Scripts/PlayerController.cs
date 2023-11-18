using CG.Scripts.Controles.PlayerInput;
using CG.Scripts.Controles.PlayerInput.Interpreted;
using UnityEngine;


namespace CG.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rb;
        [SerializeField]
        private Transform camera;

        [SerializeField]
        private float speed;
        [SerializeField]
        private float maxRunningSpeed;
        [SerializeField]
        private float runningSpeedAccelaration;
        [SerializeField]
        private float jumpForce;
        [SerializeField]
        private float roatationSpeed;

        private float currentSpeed;

        private IPlayerInput playerInput;


        private Vector3 PlayerDirection => playerInput.MovementDirection(camera.forward, camera.right);


        private void Awake()
        {
            playerInput = new InterpretedPlayerInput(new RawPlayerInput());
        }


        void Start()
        {

        }

        private void Update()
        {
            playerInput.Update();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            var playerDirection = PlayerDirection;
            
            Rotate(playerDirection);
            Move(playerDirection);
            if (playerInput.Jump.Tapped)
            {
                Jump();
            }
        }

        private void Rotate(Vector3 playerDirection)
        {
            var rotateStep = roatationSpeed * Time.deltaTime;
            var newDirection = Vector3.RotateTowards(transform.forward, playerDirection, rotateStep, 0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        private void Move(Vector3 playerDirection)
        {
            var playerMovement = playerDirection * GetSpeed() * Time.deltaTime;
            playerMovement.y = rb.velocity.y;
            rb.velocity = playerMovement;
        }

        private void Jump()
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        private float GetSpeed()
        {
            if (playerInput.IsRunning)
            {
                currentSpeed += runningSpeedAccelaration * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0, maxRunningSpeed);
            }
            else
            {
                currentSpeed = speed;
            }
            Debug.Log(currentSpeed);
            return currentSpeed;
        }
    }
}