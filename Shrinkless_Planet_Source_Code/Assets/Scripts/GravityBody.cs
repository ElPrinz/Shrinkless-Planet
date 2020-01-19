using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{

    private GravityAttractor attractor;
    private Rigidbody rb;

    public bool placeOnSurface = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        attractor = GravityAttractor.instance;
    }

    void FixedUpdate()
    {
        if (placeOnSurface)
            attractor.PlaceOnSurface(rb);
        else
            attractor.Attract(rb);
    }

}
