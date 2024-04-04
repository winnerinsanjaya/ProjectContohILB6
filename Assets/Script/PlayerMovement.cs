using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed; //bikin variable speed
    private Rigidbody rb; //bikin variable Rigidbody (untuk mengambil component Rigidbody)

    [SerializeField]
    private float jumpForce; //bikin variable buat kekuatan lompat

    [SerializeField]
    private bool isGrounded; //menyimpan data apakah player adsa di tanah/tidak

    [SerializeField]
    private int maxJumpCount; //variable untuk batasan lompat player

    private int jumpCount; //variable untuk menghitung lompatan player sementara

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //assign/mengambil komponen rigidbody ke variable "rb"
    }

    private void Update()
    {
        float hInput = Input.GetAxis("Horizontal"); //local variable untuk menyimpan axis horizontal
        float vInput = Input.GetAxis("Vertical"); //local variable untuk menyimpan axis vertical


        //penjabaran panjang
        /*
        transform.Translate(Vector3.right * Time.deltaTime * speed * hInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vInput);
        */
        //singkatnya
        Vector3 direction = new Vector3(hInput, 0f, vInput);
        transform.Translate(direction * Time.deltaTime * speed);



        //lompat pakai cara cek apakah di tanah
        /*
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }*/


        //double jump
        if (Input.GetKeyDown(KeyCode.Space) &&  jumpCount< maxJumpCount) //cek kondisi apakah true untuk lompat
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            //reset kondisi lompat
            jumpCount = 0;
            isGrounded = true;
        }
    }
}
