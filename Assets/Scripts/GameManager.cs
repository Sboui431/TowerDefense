using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text coinslabel;
    public int coins = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowCoins();
    }

    public void SetCoins(int value)
    {
        coins = value;
    }

    public int GetCoins()
    {
        return coins;
    }

    public void ShowCoins()
    {
        coinslabel.GetComponent<Text>().text = "Coins: " + coins;
    }
}
