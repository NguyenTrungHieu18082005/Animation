using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderExample : MonoBehaviour
{
    public BoxCollider myBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider.isTrigger = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
