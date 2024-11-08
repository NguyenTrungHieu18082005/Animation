using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Dichuyen : MonoBehaviour
{
    public float speed = 10.0f; // Tốc độ di chuyển của đối tượng

    public float verticalSpeed = 5.0f; // Tốc độ bay lên/xuống

    public bool isFacingRight = true; // Kiểm tra quay đầu

    public Vector2 velocity = Vector2.zero;  // Vận tốc hiện tại của nhân vật

    // nhảy 
    private Rigidbody2D rB; // để tao áp lực nhảy
    public float jumpForce = 5.0f; // Lực nhảy của nhân vật
    public Animator animator; // Animator để điều khiển animation
    private bool isGrounded = true; // kiểm tra nhân vật đang ở trên mặt đất


    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {

        // Lấy đầu vào từ phím A/D hoặc Mũi tên Trái/Phải để di chuyển ngang
        float horizontal = Input.GetAxisRaw("Horizontal");
        // Lấy đầu vào từ phím W/S hoặc Mũi tên Lên/Xuống để di chuyển dọc
        float forward = Input.GetAxisRaw("Vertical");

        // Tạo vector di chuyển cơ bản
        Vector3 move = transform.forward * forward * speed * Time.deltaTime;
        move += transform.right * horizontal * speed * Time.deltaTime;



        //quay đầu
        if (horizontal < 0 && isFacingRight) // Di chuyển sang trái
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            isFacingRight = false;
        }
        else if (horizontal > 0 && !isFacingRight) // Di chuyển sang phải
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            isFacingRight = true;
        }

        //chay
        if (horizontal != 0 || forward != 0)
        {
            animator.SetBool("idle", false);
            animator.SetBool("isruning", true);
        }
        else
        {
            animator.SetBool("isruning", false);
            animator.SetBool("idle", true);

        }

        //nhảy
         // Chỉ cho phép nhảy khi nhân vật đang ở trên mặt đất
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("jump", true);
        }
    





    // // Kiểm tra phím Mũi tên Lên để bay lên và Mũi tên Xuống để bay xuống
    // if (Input.GetKey(KeyCode.UpArrow))
    // {
    //     move += transform.up * verticalSpeed * Time.deltaTime; // Bay lên
    // }
    // else if (Input.GetKey(KeyCode.DownArrow))
    // {
    //     move -= transform.up * verticalSpeed * Time.deltaTime; // Bay xuống
    // }

    // // chay
    // if (horizontal != 0)
    // {
    //     animator.SetBool("Chay", true);  // Bật animation chạy
    // }
    // else
    // {
    //     animator.SetBool("Chay", false); // Tắt animation chạy
    // }



    // // nhảy
    // if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
    //     rB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //     isGrounded = false;
    //     animator.Play("Jump");
    // }

    // Cập nhật vị trí của đối tượng
    transform.position += move;
    }
}
// Animation

