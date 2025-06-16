using UnityEngine;
using UnityEngine.UIElements;

public class ButtonInteract : MonoBehaviour
{
    public GameObject movePoint;
    public GameObject robot;
    public GameObject promptUI; // Assign your prompt UI object here
    private bool playerInRange = false;
    private RobotController robotController;
    void Start()
    {
        robotController = robot.GetComponent<RobotController>();
        if (promptUI != null)
            promptUI.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (promptUI != null)
                promptUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (promptUI != null)
                promptUI.SetActive(false);
        }
    }

    void Update()
    {
        
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {

            if (gameObject.name == "Right")
            {
                Debug.Log("Button Pressed! RIGHT");
                robotController.Move(1, 0);
            }
            if (gameObject.name == "Left")
            {
                Debug.Log("Button Pressed! Left");
                robotController.Move(-1, 0);
            }
            if (gameObject.name == "Up")
            {
                Debug.Log("Button Pressed! UP");
                robotController.Move(0, 1);
            }
            if (gameObject.name == "Down")
            {
                Debug.Log("Button Pressed! DOWN");
                robotController.Move(0, -1);
            }
            
            // TODO: Trigger your action (door open, dialogue, etc.)
        }
    }
}
