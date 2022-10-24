using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wayPointF : MonoBehaviour
{
    public GameObject waypointObject;
    Vector3 spawnPosition = new Vector3(-21f, -2f, 0.0f);
    // Start is called before the first frame update
    void Start()
    {
        waypointObject.transform.position = spawnPosition;
        for(int i = 0; i < 1; i++) {
            Instantiate(waypointObject, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        while(GameObject.FindGameObjectsWithTag("F").Length < 1) {
            float spawnY = Random.Range
                    (spawnPosition.y - 15, spawnPosition.y + 15);
            float spawnX = Random.Range
                (spawnPosition.x - 15, spawnPosition.x + 15);
            spawnPosition = new Vector3(spawnX, spawnY, 0.0f);
            waypointObject.transform.position = spawnPosition;
            Instantiate(waypointObject, spawnPosition, Quaternion.identity);
        }
    }
}
