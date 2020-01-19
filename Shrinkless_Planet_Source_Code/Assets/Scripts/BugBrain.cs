using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBrain : MonoBehaviour
{
    public Vector3 startForce;
    public GameObject info;
    
    private void Start()
    {
        info = GameObject.Find("Info");
        StartForce();
    }

    private void Update()
    {
        //if (info != null)
           
    }
    private void OnCollisionStay(Collision col)
    {
        //Debug.Log(col.transform.name);
        if (col.transform.name == "Player")
        {
            info.GetComponent<InfoUI>().addScore();
            Destroy(this.gameObject);
        }
 
    }

    void StartForce()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        rb.AddForce(startForce, ForceMode.Impulse);
    }
}
