using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private LayerMask _solidObjectLayerMask;
    [SerializeField] private LayerMask _longGrassLayerMask;

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

                if (IsTargetPositionWalkable(targetPosition))
                {
                    StartCoroutine(DiscreteMoveTransition(targetPosition));
                }
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

        // Make sure that at the end of the coroutine movement transition,
        // player position is actually on the target position. It's important because
        // the while loop stops when it's Mathf.Epsilon apart.
        transform.position = pTargetPosition;

        isMoving = false;

        CheckEncounter();
    }

    private bool IsTargetPositionWalkable(Vector3 pTargetPosition)
    {
        Vector2 targetPosition2D = new(pTargetPosition.x, pTargetPosition.y);
        if (Physics2D.OverlapCircle(targetPosition2D, 0.1f, _solidObjectLayerMask) != null)
        {
            return false;
        }
        return true;
    }

    private bool IsPlayerOnLongGrass()
    {
        Vector2 playerPosition2D = new(transform.position.x, transform.position.y);
        if (Physics2D.OverlapCircle(playerPosition2D, 0.1f, _longGrassLayerMask) != null)
        {
            return false;
        }
        return true;
    }

    private void CheckEncounter()
    {
        if (IsPlayerOnLongGrass())
        {
            if (Random.Range(1, 101) <= 10)
            {
                Debug.Log("Encounter a wild pokemon");
            }
        }
    }
}
