using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private PlayerInputHandler _playerInputHandler;


    private void Awake()
    {
        _playerInputHandler = PlayerInputHandler.Instance;
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (_playerInputHandler.MoveInput != Vector2.zero)
        {
            Vector3 targetPosition = transform.position;

            float moveInputX = _playerInputHandler.MoveInput.x;
            float moveInputY = _playerInputHandler.MoveInput.y;

            // Disable diagonal movement when both directions are entered. Then, set X to 1 or -1.
            if (moveInputX != 0 && moveInputY != 0)
            {
                moveInputY = 0;
                moveInputX = moveInputX > 0 ? 1 : -1;
            }

            targetPosition.x += moveInputX;
            targetPosition.y += moveInputY;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);
        }
    }
}
