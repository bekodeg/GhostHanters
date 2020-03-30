using UnityEngine;
using UnityEngine.Events;

public class teleport : MonoBehaviour
{
    [SerializeField] bool standartR;
    [SerializeField] Collider2D standartBen;
    [SerializeField] CoinAcceptor box;
    bool revers;
    Collider2D beneficiary;
    UnityAction OnTeleportBegin;
    void ChangePlayer()
    {
        GameManager.Instance().player.CanMove = true;
    }
    private void Start()
    {
        revers = standartR;
        beneficiary = standartBen;
        OnTeleportBegin = ChangePlayer;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager.Instance().player.gameObject)
        {
            GameManager.Instance().player.CanMove = false;
            if (box.attempts <= 0)
            {
                revers = true;
                beneficiary = gameObject.GetComponent<Collider2D>();
            }
            else
            {
                box.attempts -= 1;
<<<<<<< HEAD
=======
                box.
            }
>>>>>>> clock
            Clock.Instance().SetTimer(1f, OnTeleportBegin);
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
    }
}
