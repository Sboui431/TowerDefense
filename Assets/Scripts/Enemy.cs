using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject[] waypoints;
    private int currentWaypoints;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = waypoints[currentWaypoints].transform.position;
        Vector3 endPosition = waypoints[currentWaypoints + 1].transform.position;

        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;

        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

        if (gameObject.transform.position.Equals(endPosition))
        {
            if(currentWaypoints < waypoints.Length - 2)
            {
                currentWaypoints++;
                lastWaypointSwitchTime = Time.time;
                RotateEnemy();
            }
            else
            {
                CameraShake.instance.StartShake();
                Destroy(gameObject);
                GameManager.singleton.SetHealth(GameManager.singleton.GetHealth() - 1);
            }
            
        }
    }

    private void RotateEnemy()
    {
        Vector3 newStartPosition = waypoints[currentWaypoints].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoints + 1].transform.position;

        Vector3 newDirection = (newEndPosition - newStartPosition);

        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;

        transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }

}
