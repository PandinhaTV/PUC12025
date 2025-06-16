
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private CameraController cam;
    private bool canMove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cam = Camera.main.GetComponent<CameraController>();
    }

    void Update()
    {
        if (cam.IsScrolling())
        {
            canMove = false;
            return;
        }

        canMove = true;




        if (canMove)
        {
            // Get input
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();

            // Set animator parameters
            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);
            animator.SetBool("IsMoving", moveInput != Vector2.zero);
        }
            

        // Check for screen edge crossing
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0f) 
        {
            cam.MoveCamera(Vector2.left);
            // Move player to the right edge of the new screen
            transform.position = new Vector3(
                Mathf.Floor(transform.position.x / 16f) * 16f + 15f, // right side of new screen
                transform.position.y,
                transform.position.z
            );
        }
        else if (viewPos.x > 1f)
        {
            cam.MoveCamera(Vector2.right);
            // Move player to the left edge of the new screen
            transform.position = new Vector3(
                Mathf.Floor(transform.position.x / 16f) * 16f + 1f, // left side of new screen
                transform.position.y,
                transform.position.z
            );
        }
        else if (viewPos.y < 0f)
        {
            cam.MoveCamera(Vector2.down);
            
            // Move player to the top edge of the new screen
            transform.position = new Vector3(
                transform.position.x,
                Mathf.Floor(transform.position.y / 16f) * 16f + 15f,
                transform.position.z
            );
        }
        else if (viewPos.y > 1f)
        {
            cam.MoveCamera(Vector2.up);
            // Move player to the bottom edge of the new screen
            transform.position = new Vector3(
                transform.position.x,
                Mathf.Floor(transform.position.y / 16f) * 16f + 1f,
                transform.position.z
            );
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
