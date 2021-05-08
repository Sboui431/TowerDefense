using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text coinslabel;
    public int coins = 1000;

    public Text waveLabel;
    public bool gameover;
    private int wave;

    public Text healthLabel;
    public GameObject[] healthIndicator;
    private int health;
    public static GameManager singleton;
    public GameObject gameOverPanel;

    private void Awake()
    {
        if (singleton == null)
        
            singleton = this;

            else if(singleton != this)
            {
                Destroy(gameObject);
                DontDestroyOnLoad(gameObject);
            }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        SetWave(0);
        SetHealth(4);
        
    }

    void Update()
    {
        ShowCoins();
        ShowWave();
        ShowHealth();
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetWave(int value)
    {
        wave = value;
    }

    public void ShowWave()
    {
        waveLabel.text = "Wave: " + wave;
    }

    public void SetHealth(int value)
    {
        health = value;

        if(health <= 0 && !gameover)
        {
            gameover = true;
            Time.timeScale = 0.0f;
            gameOverPanel.SetActive(true);
        }

        for (int i = 0; i < healthIndicator.Length; i++)
        {
            if (i < health)
            {
                healthIndicator[i].SetActive(true);
            }
            else
            {
                healthIndicator[i].SetActive(false);
            }
        }
    }

    public void ShowHealth()
    {
        healthLabel.text = "Health: " + health;
    }

    // Update is called once per frame
   

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
        coinslabel.text = "Coins: " + coins;
    }
}
