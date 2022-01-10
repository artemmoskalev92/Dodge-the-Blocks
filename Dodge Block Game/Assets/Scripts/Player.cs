using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed = 15f;
    public float mapWidth = 5f;


    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPos = rb.position + Vector2.right * xAxis;
        newPos.x = Mathf.Clamp(newPos.x, -mapWidth, mapWidth);

        rb.MovePosition(newPos);
    }
    private void OnCollisionEnter2D()
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
