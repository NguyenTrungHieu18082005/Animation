using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DiChuyenThu : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public int tocDo = 4;
    public float leftright;

    public bool isFaceingRight = true;
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        leftright = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(tocDo * leftright, rb.velocity.y);

        if (isFaceingRight == true && leftright == -1)
        {
            transform.localScale = new Vector3(-100, 100, 100);
            isFaceingRight = false;
        }
        if (isFaceingRight == false && leftright == 1)
        {
            transform.localScale = new Vector3(100, 100, 100);
            isFaceingRight = true;

        }
        anim .SetFloat("diChuyen" ,Mathf.Abs(leftright) );

        if(Input.GetKeyDown(KeyCode.P)){
            anim.SetTrigger("TanCong");

        }
    }

    // Animation
     
}
