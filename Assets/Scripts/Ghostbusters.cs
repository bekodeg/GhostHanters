using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghostbusters : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.Instance().player.gameObject)
        {
            Vector3 rot = Vector3.zero;
            if (transform.position.x > collision.transform.position.x)
                rot.y = -180.0f;
            transform.rotation = Quaternion.Euler(rot);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            GameManager.Instance().EndGame(false);
        }
    }
}
