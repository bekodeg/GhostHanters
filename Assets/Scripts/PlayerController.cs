using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float MaxPower = 5.0f;
    public float power;

    SpriteRenderer spriteRen;
    Rigidbody2D rb;
    [SerializeField] [Range(0, 100)] float maxSpeed;
    [SerializeField] [Range(0, 10)] float reverseAcceleration;
    [SerializeField] [Range(1, 100)] int forceJump;
    [SerializeField] [Range(0, 100)] int minPover;
    public bool superGhost = false;
    public bool CanMove { get; set; } = true;
    bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        power = MaxPower;
        spriteRen = transform.GetComponent<SpriteRenderer>();
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 speed = rb.velocity;
        speed.x -= reverseAcceleration * Math.Sign(speed.x);
        if (h != 0 && CanMove)
        {
            if (h > 0)
            {
                spriteRen.flipX = true;
                speed.x = maxSpeed;
            }
            else
            {
                spriteRen.flipX = false;
                speed.x = -maxSpeed;
            }
        }
        if (power == 0)
        {
            canJump = false;
        }
        if (canJump && v > 0 && power > 0)
        {
            power -= Time.deltaTime * 2.2f;
            speed.y += forceJump;
        }
        else if (power < MaxPower)
        {
            power += Time.deltaTime * 0.5f;
        }
        power = Mathf.Clamp(power, 0f, MaxPower);
        if (power >= minPover) canJump = true;
        int x = Math.Sign(speed.x);
        speed.y = Mathf.Clamp(speed.y, -forceJump*1.5f, forceJump);
        speed.x = Mathf.Clamp(speed.x, -maxSpeed * 3, maxSpeed * 3);
        rb.velocity = speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bonus>())
            collision.gameObject.GetComponent<Bonus>().Use(this);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<triggerZone>())
        {
            collision.gameObject.GetComponent<triggerZone>().Use();
        }
    }
}