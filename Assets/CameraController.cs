using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float scrollSpeed = 5f;
    private Vector3 targetPosition;
    private bool isScrolling = false;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (isScrolling)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, scrollSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                transform.position = targetPosition;
                isScrolling = false;
            }
        }
    }

    public void MoveCamera(Vector2 direction)
    {
        if (isScrolling) return;

        Vector3 moveAmount = new Vector3(direction.x * 10, direction.y * 10, 0); // assuming 16x16 screens
        targetPosition += moveAmount;
        isScrolling = true;
    }

    public bool IsScrolling()
    {
        return isScrolling;
    }
}


