using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, PlayerInput.IGameplayActions
{
    [SerializeField] private Vector3 directionVector;

    [SerializeField] private InputAction movement;
    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private float movementSpeed = 25f;

    private void Awake()
    {
        playerInput = new PlayerInput();
        movement = playerInput.Gameplay.Movement;
        playerInput.Gameplay.SetCallbacks(this);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void Update()
    {
        transform.position += movementSpeed * Time.deltaTime * transform.up;
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 contextDirectionVector = context.ReadValue<Vector2>();
        Vector3 inputDirectionVector= new Vector3(contextDirectionVector.x, contextDirectionVector.y, 0);
        Vector3 currentDirectionVector = GetDirectionVectorFromEulerAngle(transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        float targetZRotation = GetEulerAngleFromVector(contextDirectionVector);

        if (!(inputDirectionVector == currentDirectionVector) && !(inputDirectionVector == -currentDirectionVector))
        {
            transform.Rotate(Vector3.forward
                            ,Mathf.DeltaAngle(transform.rotation.eulerAngles.z, targetZRotation)
                            ,Space.World
                            );
        }
    }

    private float GetEulerAngleFromVector(Vector3 inputVector)
    {
        if (inputVector.x > 0)
        {
            return -Mathf.Rad2Deg * Mathf.Acos(inputVector.y / inputVector.magnitude);
        }
        else
        {
            return Mathf.Rad2Deg* Mathf.Acos(inputVector.y / inputVector.magnitude);
        }
    }

    private Vector3 GetDirectionVectorFromEulerAngle(float eulerAngle)
    {
        Vector3 outputVector = new Vector3(-Mathf.Sin(eulerAngle), Mathf.Cos(eulerAngle), 0);
        return outputVector;
    }
}
