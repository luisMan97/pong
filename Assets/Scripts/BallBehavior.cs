using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    public Transform paddle;
    public bool gameStarted; // Si no se asigna un valor por defecto tomará false
    public Rigidbody2D rbBall;   
    float posDif;
    public AudioSource ballAudio;

    // Start is called before the first frame update
    void Start()
    {
        //rbBall = GetComponent<Rigidbody2D>(); // referencia por código
        posDif = paddle.position.x - transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted) 
        {
            transform.position = new Vector3(paddle.position.x - posDif, paddle.position.y, paddle.position.z);

            if (Input.GetMouseButtonDown(0)) // El click izquiero al ser el primero es el 0
            {
                rbBall.velocity = new Vector2(8, 8);
                gameStarted = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ballAudio.Play();
    }
}
