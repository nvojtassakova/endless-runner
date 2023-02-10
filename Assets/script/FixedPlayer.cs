using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FixedPlayer: MonoBehaviour
{
    private Rigidbody rb;
    public float forwardSpeed = 3f;
    public float turningSpeed = 2f;
    public float jumpPower;
    private float input;
    int score = 0;
    public string enemyTag = "trap";
    public string coinTag = "coin";
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        input = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    public void Jump()
    {
        rb.velocity= new Vector3(input * turningSpeed, jumpPower, forwardSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            Restart();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(coinTag))
        {
            score++;
            Debug.Log("Tvoje skore je: " + score);
            Destroy(other.gameObject);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector3(input*turningSpeed, rb.velocity.y, forwardSpeed);
    }

}
