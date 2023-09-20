using UnityEngine;

public class CTF_AnimalMovement : MonoBehaviour
{
    private bool isDragging = false;
    private Camera mainCamera;
    private float initialYPosition;

    private Vector2 screenOffset;
    [SerializeField] private CTF_PauseManager pauseManager;
    [SerializeField] private GameObject gameResumeTimerCanvas;
    [SerializeField] private Animator animator; 
    [SerializeField] private CTF_HealthManager healthManager;

    private void Start()
    {
        mainCamera = Camera.main;
        initialYPosition = transform.position.y;
    }

    private void Update () 
    {
        HandleMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Correct"))
        {
            CTF_GameManager.Instance.IncreaseScore(1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Incorrect"))
        {
            animator.SetTrigger("ShowRedPanel");
            CTF_GameManager.Instance.ReduceHealth(1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("heart")) 
        {
            healthManager.IncreaseHealth(1);
            Destroy(collision.gameObject);
        }
    }

    private void HandleMovement()
    {
        if (pauseManager.IsGamePaused() == false && gameResumeTimerCanvas.activeSelf == false)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Vector3 touchPosition = touch.position;
                    touchPosition.z = mainCamera.WorldToScreenPoint(transform.position).z;

                    if (GetComponent<Collider2D>().OverlapPoint(mainCamera.ScreenToWorldPoint(touchPosition)))
                    {
                        isDragging = true;
                        screenOffset = (Vector2)transform.position - (Vector2)mainCamera.ScreenToWorldPoint(touchPosition);
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    isDragging = false;
                }
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;

                if (GetComponent<Collider2D>().OverlapPoint(mainCamera.ScreenToWorldPoint(mousePosition)))
                {
                    isDragging = true;
                    screenOffset = (Vector2)transform.position - (Vector2)mainCamera.ScreenToWorldPoint(mousePosition);
                }
            }
            else
            {
                isDragging = false;
            }

            if (isDragging)
            {
                Vector3 currentScreenPoint = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;
                currentScreenPoint.z = mainCamera.WorldToScreenPoint(transform.position).z;
                Vector3 currentPosition = mainCamera.ScreenToWorldPoint(currentScreenPoint) + (Vector3)screenOffset;
                currentPosition.y = initialYPosition;

                // Clamp the position to the screen boundaries
                Vector3 clampedPosition = ClampToScreen(currentPosition, 95f);

                transform.position = clampedPosition;
            }
        }
    }

    private Vector3 ClampToScreen(Vector3 position, float edgeOffset)
{
    // Create a new vector to store the clamped position, initially set to the input position.
    Vector3 clampedPosition = position;

    // Convert the world-space position to viewport coordinates (values between 0 and 1).
    Vector3 viewportPosition = mainCamera.WorldToViewportPoint(position);

    // Clamp the x and y coordinates of the viewportPosition, considering the edge offset.
    viewportPosition.x = Mathf.Clamp01(viewportPosition.x);
    viewportPosition.y = Mathf.Clamp01(viewportPosition.y);

    // Calculate the screen edges considering the edge offset.
    float minX = edgeOffset / mainCamera.pixelWidth;
    float minY = edgeOffset / mainCamera.pixelHeight;
    float maxX = 1 - minX;
    float maxY = 1 - minY;

    // Clamp the viewportPosition considering the edge offset.
    viewportPosition.x = Mathf.Clamp(viewportPosition.x, minX, maxX);
    viewportPosition.y = Mathf.Clamp(viewportPosition.y, minY, maxY);

    // Convert the clamped viewport position back to world-space coordinates.
    clampedPosition = mainCamera.ViewportToWorldPoint(viewportPosition);

    // Set the y-coordinate of the clamped position to the initial Y position.
    clampedPosition.y = initialYPosition;

    // Return the clamped position.
    return clampedPosition;
}

}
