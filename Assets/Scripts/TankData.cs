using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TankLevel
{
    public int cost;
    public GameObject display;
}

public class TankData : MonoBehaviour
{
    public List<TankLevel> level;
    public TankLevel currentLevel;

    private void OnEnable()
    {
        currentLevel = level[0];
        SetTankLevel(currentLevel);
    }

    public  TankLevel GetTankLevel()
    {
        return currentLevel;
    }

    public void  SetTankLevel(TankLevel tanklevel)
    {
        currentLevel = tanklevel;
        int currentLevelIndex = level.IndexOf(currentLevel);
        GameObject levelDisplay = level[currentLevelIndex].display;

        for (int i = 0; i < level.Count; i++)
        {
            if (levelDisplay != null)
            {
                if (i == currentLevelIndex)
                {
                    // Damit aktiviere ich einen Tank
                    level[i].display.SetActive(true);
                }
                else
                {
                    // Damit deaktiviere ich einen Tank. Er ist also nicht mehr im Spiel sichtbar und verwendbar.
                    level[i].display.SetActive(false);
                }
            }
        }
    }

    public void IncreaseLevel()
    {
        int currentLevelIndex = level.IndexOf(currentLevel);
        if(currentLevelIndex < level.Count - 1)
        {
            currentLevel = level[currentLevelIndex + 1];
            SetTankLevel(currentLevel);
        }
    }

    public TankLevel GetNextLevel()
    {
        int currentLevelIndex = level.IndexOf(currentLevel);
        int maxLevelIndex = level.Count - 1;
        if(currentLevelIndex < maxLevelIndex)
        {
            return level[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }
}
