using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    [SerializeField] bool standartR;
    [SerializeField] Collider2D standartBen;
    [SerializeField] theExchangerOfCoins box;
    bool revers;
    Collider2D beneficiary;
    public bool isTimeStarted;

    private void Start()
    {
        revers = standartR;
        beneficiary = standartBen;
    }
    public void ChangeTimeStartedStatus(bool s)
    {
        isTimeStarted = s;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.Instance().player.gameObject)
        {
            isTimeStarted = true;
            if (box.attempts <= 0)
            {
                revers = true;
                beneficiary = gameObject.GetComponent<Collider2D>();
            }
            else
                box.attempts -= 1;
        }
        if (revers && collision.attachedRigidbody)
        {
            Rigidbody2D RB = collision.attachedRigidbody;
            Vector2 vel = RB.velocity;
            vel.x *= -1;
            RB.velocity = vel;
        }
        float indent = (beneficiary.bounds.size.x + collision.bounds.size.x) / 2 + 0.05f;
        Vector3 rel = Vector3.zero;
        Vector3 playerPos = collision.transform.position;
        rel.y = ((playerPos.y - gameObject.GetComponent<Collider2D>().bounds.center.y) * beneficiary.bounds.size.y) 
            / gameObject.GetComponent<Collider2D>().bounds.size.y + beneficiary.bounds.center.y;

        bool input = collision.transform.position.x - transform.position.x < 0;
        if ((input && revers) || !(input || revers))
        {
            rel.x = beneficiary.bounds.center.x - indent;
        }
        else
        {
            rel.x = beneficiary.bounds.center.x + indent;
        }
        rel.z = 40;
        collision.transform.position = rel;
        /*
        void Update()
        {
            if
        }
        */
    }
}
