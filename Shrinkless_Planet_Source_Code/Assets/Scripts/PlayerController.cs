using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float rotationSpeed = 100f;
    private float rotation;
    private Rigidbody rb;
    public Planet ps;
    public float maxSize;
    public float minSize;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        PlayerMove();       
   
    }

    void PlayerMove()
    {
        rotation = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position + transform.forward* moveSpeed * Time.fixedDeltaTime);
        Vector3 yRotation = Vector3.up * rotation * rotationSpeed * Time.fixedDeltaTime;
        Quaternion deltaRotation = Quaternion.Euler(yRotation);
        Quaternion targetRotation = rb.rotation * deltaRotation;
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 50f * Time.deltaTime));
        //transform.Rotate(0f, rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
      
    }
private void OnTriggerStay(Collider other)
    {


        if (other.transform.name == "Cylinder+")
        {
            Debug.Log("IN " + other.transform.tag + other.transform.name);
            ps.shrinkSpeed = 0.05f;

        }

        else if (other.transform.name == "Cylinder-")
        {
            Debug.Log("OFF " + other.transform.tag + other.transform.name);
           
            //if (ps.transform.localScale.x > 3.5f)
            //                ps.shrinkSpeed = .05f;
            //else
                 ps.shrinkSpeed = -0.05f;

        }

    }

}
