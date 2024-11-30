using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// PlayerInputHandler is a singleton class that
/// takes player input and converts it into 
/// move data for other scripts to consume.
/// </summary>
/// <remarks>
/// <a href="https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Actions.html">Unity Input Actions</a>
/// </remarks>
public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Asset Reference")]
    [SerializeField] private InputActionAsset _inputActionAsset;
    
    [Header("Input Action Map Name")]
    [SerializeField] private string _playerInputActionMapName = "Player";
    
    [Header("Input Action Names")]
    [SerializeField] private string _moveInputActionName = "Move";

    /// <summary>
    /// _moveInputAction stores the input action referenced
    /// by the asset, map, and action name.
    /// </summary>
    private InputAction _moveInputAction;

    /// <summary>
    /// MoveInput exposes the player's move input to other scripts.
    /// </summary>
    /// <value>
    /// Vector2 representing the player's move input.
    /// </value>
    public Vector2 MoveInput { get; private set; }

    public static PlayerInputHandler Instance { get; private set; }

    private void Awake()
    {
        // Implement singleton instance logics.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Assign the derived input action to the private input action field.
        _moveInputAction = _inputActionAsset.FindActionMap(_playerInputActionMapName).FindAction(_moveInputActionName);

        RegisterInputActions();
    }

    private void RegisterInputActions()
    {
        _moveInputAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        _moveInputAction.canceled += context => MoveInput = Vector2.zero;
    }

    private void OnEnable() {
        _moveInputAction.Enable();
    }

    private void OnDisable() {
        _moveInputAction.Disable();
    }
}
