using CG.ScriptableObjects.Scripts;
using CG.Scripts.Collision.Detection;
using CG.Scripts.Controles.PlayerInput;
using CG.Scripts.Controles.PlayerInput.Interpreted;
using CG.Scripts.Mechanics.Spawn;
using UnityEngine;


namespace CG.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rigidbody;
        
        [SerializeField]
        private Transform camera;

        [SerializeReference]
        private DirectionalRayCollision groundCollision;

        [SerializeField]
        private float roatationSpeed;
        [SerializeField]
        private float walkingSpeed;
        [SerializeField]
        private float maxRunningSpeed;
        [SerializeField]
        private float runningSpeedAccelaration;
        [SerializeField]
        private float jumpForce;
        [SerializeField]
        private JumpConfiguration jumpConfiguration;
        [SerializeField]
        private SpawnPostionManager spawnPostion;
        [SerializeField]
        private EggSpawn eggSpawn;


        private int currentJumpCount;

        private float currentSpeed;

        private IPlayerInput playerInput;


        private Vector3 PlayerDirection => playerInput.MovementDirection(
            camera.forward,
            camera.right);

        private bool CanJump
        {
            get
            {
                if(!playerInput.Jump)
                {
                    return false;
                }
                else if (groundCollision.Collided)
                {
                    currentJumpCount = jumpConfiguration.JumpCount;
                    return true;
                }

                currentJumpCount--;
                return currentJumpCount > 0;
            }
        }


        private void Awake()
        {
            playerInput = new InterpretedPlayerInput(new RawPlayerInput());
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

            if (CanJump)
            {
                Jump();
            }

            if(playerInput.LayEgg)
            {
                eggSpawn.TryAddEgg();
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
            playerMovement.y = rigidbody.velocity.y;
            rigidbody.velocity = playerMovement;
        }

        private void Jump()
        {
            var currentJumpForce = jumpForce * jumpConfiguration[jumpConfiguration.JumpCount - currentJumpCount];


            rigidbody.AddForce(transform.up * currentJumpForce, ForceMode.Impulse);
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
                currentSpeed = walkingSpeed;
            }

            return currentSpeed;
        }
    }
}