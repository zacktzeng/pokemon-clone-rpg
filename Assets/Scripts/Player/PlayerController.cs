using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private PlayerInputHandler _playerInputHandler;

    private bool isMoving;

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
            if (!isMoving)
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

                StartCoroutine(DiscreteMoveTransition(targetPosition));
            }
        }
    }

    private IEnumerator DiscreteMoveTransition(Vector3 pTargetPosition)
    {
        isMoving = true;

        // Move player incrementally towards the target position until
        // player is close enough to the target position.
        while ((transform.position - pTargetPosition).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, pTargetPosition, _moveSpeed * Time.deltaTime);

            // Pause executing the transform.position update so that 
            // the next bits of position update happens in the next frame.
            yield return null;
        }

        isMoving = false;
    }
}
