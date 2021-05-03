using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankplacement : MonoBehaviour
{
    public GameObject tankPrefab;
    private GameObject tank;

    private void OnMouseDown()
    {
        if(CanPlaceTank())
            tank = Instantiate(tankPrefab, transform.position, Quaternion.identity);
        else if (CanUpgradeTank())
        {
            tank.GetComponent<TankData>().IncreaseLevel();
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
