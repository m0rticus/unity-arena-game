using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
    public float jumpPower;
    public float fastFallSpeed;
    public float linearMovement;
    public float maxLinearVelocity;
    public float dashCooldown;
    public float dashForce;
    public float dashSpeedDuration;
    public int numberJumps;
    public Rigidbody2D rb;
    public SpawnEnemies spawner;

    private float lastDashTime = -100000;
    private int remainingJumps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        remainingJumps = numberJumps;
    }

    public void Update()
    {
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //Vector3 tempVect = new Vector3(h, v, 0);
        //tempVect = tempVect.normalized * speed * Time.deltaTime;
        //rb.MovePosition(rb.transform.position + tempVect);
        if (Input.GetKey("a"))
        {
            if (Time.time - lastDashTime > dashCooldown && Input.GetKey(KeyCode.LeftShift))
            {
                lastDashTime = Time.time;
                if (rb.velocity.x > 0)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
                rb.AddForce(Vector2.left * dashForce);
            }
            else
            {
                rb.AddForce(Vector2.left * linearMovement);
            }
        }
        if (Input.GetKey("d"))
        {
            if (Time.time - lastDashTime > dashCooldown && Input.GetKey(KeyCode.LeftShift))
            {
                lastDashTime = Time.time;
                if (rb.velocity.x < 0)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
                rb.AddForce(Vector2.right * dashForce);
            }
            else
            {
                rb.AddForce(Vector2.right * linearMovement);
            }
        }

        if (Input.GetKeyDown("space"))
        {
            if (remainingJumps > 0)
            {
                if (rb.velocity.y < 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                }
                rb.AddForce(Vector2.up * jumpPower);
                remainingJumps--;
            }
        }
        if (Input.GetKey("s"))
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            rb.AddForce(Vector2.down * fastFallSpeed);
        }

        if (Mathf.Abs(rb.velocity.x) > maxLinearVelocity)
        {
            if (Time.time - lastDashTime > dashSpeedDuration)
            {
                if (rb.velocity.x < 0)
                {
                    rb.velocity = new Vector2(maxLinearVelocity * -1, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(maxLinearVelocity, rb.velocity.y);
                }
            }
        }

        //Debug.Log("Eye velocity: " + rb.velocity);
        //Debug.Log("Jumps: " + remainingJumps);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "projectile(Clone)")
        {
            if (collision.gameObject.tag == "Wall")
            {
                Collider2D collider = collision.collider;
                Vector3 contactPoint = collision.contacts[0].point;
                Vector3 center = collider.bounds.center;
                if (contactPoint.y > center.y)
                {
                    remainingJumps = numberJumps;
                }
            }
            if (collision.gameObject.tag == "Enemy")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
