using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankplacement : MonoBehaviour
{
    public GameObject tankPrefab;
    private GameObject tank;

    private void OnMouseDown()
    {
        if (CanPlaceTank())
        {
            int cost = tankPrefab.GetComponent<TankData>().level[0].cost;
            if(GameManager.singleton.GetCoins() >= cost)
            {
                tank = Instantiate(tankPrefab, transform.position, Quaternion.identity);
                GameManager.singleton.SetCoins(GameManager.singleton.GetCoins()
                    - tank.GetComponent<TankData>().currentLevel.cost);
            }
            
        }
            
        else if (CanUpgradeTank())
        {
            int cost = tank.GetComponent<TankData>().GetNextLevel().cost;
            if(GameManager.singleton.GetCoins() >= cost)
            {
                tank.GetComponent<TankData>().IncreaseLevel();
                GameManager.singleton.SetCoins(GameManager.singleton.GetCoins()
                    - tank.GetComponent<TankData>().currentLevel.cost);
            }
            
        }
    }

    private bool CanPlaceTank()
    {
        if(tank == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CanUpgradeTank()
    {
        if(tank != null)
        {
            TankData data = tank.GetComponent<TankData>();
            TankLevel nextLevel = data.GetNextLevel();
            if(nextLevel != null)
            {
                return true;
            }
           
        }
        return false;
    }
}
