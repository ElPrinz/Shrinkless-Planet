using UnityEngine;
public class HalfScreenTouchMovement : MonoBehaviour
{
    private float screenCenterX;
    private Rigidbody rb;
    public float rotationSpeed = 100f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // save the horizontal center of the screen
        screenCenterX = Screen.width * 0.5f;
    }

    private void Update()
    {
        // if there are any touches currently
        if (Input.touchCount > 0)
        {
            // get the first one
            Touch firstTouch = Input.GetTouch(0);

            // if it began this frame
            if (firstTouch.phase == TouchPhase.Began)
            {
                if (firstTouch.position.x > screenCenterX)
                {
                    // if the touch position is to the right of center
                    // move right
                    Vector3 yRotation = Vector3.up * firstTouch.position.x * rotationSpeed * Time.fixedDeltaTime;
                    Quaternion deltaRotation = Quaternion.Euler(yRotation);
                    rb.MoveRotation(Quaternion.Slerp(rb.rotation, deltaRotation, 50f * Time.deltaTime));
                }
                else if (firstTouch.position.x < screenCenterX)
                {
                    Vector3 yRotation = Vector3.up * firstTouch.position.x * rotationSpeed * Time.fixedDeltaTime;
                    Quaternion deltaRotation = Quaternion.Euler(yRotation);
                    rb.MoveRotation(Quaternion.Slerp(rb.rotation, deltaRotation, 50f * Time.deltaTime));
                    // if the touch position is to the left of center
                    // move left
                }
            }
        }
    }
}