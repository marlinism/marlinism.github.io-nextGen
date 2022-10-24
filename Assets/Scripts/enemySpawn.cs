using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public Text touchedText;

    public Text WayPointText;

    int maxEnemies = 10;

    private bool seq = true;

    // Start is called before the first frame update
    async void Start()
    {

        while(GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies) {
            float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y * 90 / 100, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y * 90 / 100);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x * 90 / 100, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x * 90 / 100);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0.0f);
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        while(GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies) {
            float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y * 90 / 100, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y * 90 / 100);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x * 90 / 100, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x * 90 / 100);
            Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0.0f);
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        }
        TouchedMore();
        Waypoint();
    }

    public void TouchedMore() {
        touchedText.text = "TouchedEnemy(" + EnemyBehavior.touched + ")";
    }

    public void Waypoint() {
        if (Input.GetKey("j")) {
            seq = !seq;
        }
        check();
    }

    private void check() {
        if(seq == false) {
            WayPointText.text = "WAYPOINTS:(Random)";
        } else {
            WayPointText.text = "WAYPOINTS:(Sequence)";
        }
    }
}
