using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;
    public static GameManager Instance()
    {
        return _gameManager;
    }
    [SerializeField] GameObject playerCan;
    [SerializeField] GameObject win;
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject playerP;
    #region player
    public PlayerController player { get; private set; }
    public Text hint;
    private int _money;
    [SerializeField] Text moneyText;
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
    string scene = "Main";

    private void Awake()
    {
        if (GameManager.Instance() == null)
            _gameManager = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
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
        SceneManager.LoadScene(scene);
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
