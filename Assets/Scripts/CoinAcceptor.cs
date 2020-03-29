using UnityEngine;
using UnityEngine.UI;

public class CoinAcceptor : triggerZone
{
    public int attempts = 0;
    [SerializeField] Text stat;
    public override void Use()
    {
        GameManager.Instance().hint.text = "Pres E to exchenge";
        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance().Money > 0)
        {
            attempts += 1;
            stat.text = attempts.ToString("00");
            GameManager.Instance().Money -= 1;

        }
    }
}
