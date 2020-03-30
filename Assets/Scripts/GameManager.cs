using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager _gameManager;
    public static GameManager Instance()
    {
        return _gameManager;
    }
    private void Awake()
    {
        if (GameManager.Instance() == null)
            _gameManager = this;
        DontDestroyOnLoad(this);
    }
    #endregion singleton
    #region canvas
    GameObject win;
    GameObject Lose;
    GameObject playerCan;
    public Text hint;
    public Text moneyText;
    public Transform canvas
    {
        set
        {
            win = value.GetChild(0).gameObject;
            Lose = value.GetChild(1).gameObject;
            if (value.childCount > 2)
            {
                playerCan = value.GetChild(2).gameObject;
                moneyText = playerCan.transform.GetChild(0).GetComponent<Text>();
                hint = playerCan.transform.GetChild(1).GetComponent<Text>();
            }
        }
    }
    #endregion
    #region player
    [SerializeField] GameObject playerP;
    public PlayerController player { get; private set; }
    private int _money;
    [SerializeField] int startHelse;
    int helse;
    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            moneyText.text = _money.ToString("000");
        }
    }
    #endregion
    //int points = 0;
    public int skore;
    [SerializeField] int requiredAccount;
    Transform spavnPoint;

    public void newSpavn(Transform spavn)
    {
        spavnPoint = spavn;
    }
    public void firstSpavn(Transform spavn)
    {
        if (spavnPoint == null)
        {
            spavnPoint = spavn;
        }
        GameObject p = GameObject.Instantiate(playerP, spavnPoint.position, spavnPoint.rotation, null);
        player = p.GetComponent<PlayerController>();
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("restart");
    }
    public void load(int scenIndex)
    {
        print("load");
        SceneManager.LoadScene(scenIndex);
    }
    public void EndGame(bool victory)
    {
        if (!victory)
        {
            playerCan.SetActive(false);
            if (helse <= 0)
                Lose.SetActive(true);
            else
            {
                helse--;
                restart();
            }
        }
        else if (skore >= requiredAccount)
        {
            playerCan.SetActive(false);
            win.SetActive(true);
        }
    }
}
