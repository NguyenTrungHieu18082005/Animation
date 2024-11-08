using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyExample : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody myRigidbody;
    void Start()
    {
        myRigidbody.mass = 5.0f;
        myRigidbody.velocity = Vector3.one;
    }
}
