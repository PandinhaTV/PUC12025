using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float moveSpeed = 5f; // Units per second

    private bool isMoving = false;
    private Vector2 input;
    private Vector3 startPos;
    private Vector3 endPos;
    private float moveTimer;

    void Update()
    {
       
    }

    public void Move(float inputX, float inputY)
    {
        if (!isMoving)
        {
            input = new Vector2(inputX, inputY);

            // Prevent diagonal movement
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                // Start moving to next tile
                startPos = transform.position;
                endPos = startPos + new Vector3(input.x, input.y, 0);
                moveTimer = 0f;
                isMoving = true;
            }
        }
    }
    void FixedUpdate()
    {
        if (isMoving)
        {
            moveTimer += Time.fixedDeltaTime * moveSpeed;
            transform.position = Vector3.Lerp(startPos, endPos, moveTimer);

            if (moveTimer >= 1f)
            {
                transform.position = endPos; // Snap to grid
                isMoving = false;
            }
        }
    }
}
