using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroBehavior : MonoBehaviour {

    public EggStatSystem mEggStat = null;
    public float mHeroSpeed = 20f;
    public float kHeroRotateSpeed = 90f/2f; // 90-degrees in 2 seconds
    public Text ToggleText;

    public bool isControlMouse = true;
    // public Text ToggleText;

	void Start () {
        Debug.Assert(mEggStat != null);
	}
	
	// Update is called once per frame
	void Update () {
        switchController();
        modifySpeed();
        rotate();
        // killSelf();
        ProcessEggSpwan();
    }

    private void modifySpeed() {
        mHeroSpeed += Input.GetAxis("Vertical");
        transform.position += transform.up * (mHeroSpeed * Time.smoothDeltaTime);
    }

    private void rotate() {
        transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") *
                                    (kHeroRotateSpeed * Time.smoothDeltaTime));
    }

    private void switchController() {
        if (Input.GetKey(KeyCode.M)) {
            isControlMouse = !isControlMouse;
        }

        check();
    }

    private void check() {
        if(isControlMouse == true) {
            Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            p.z = 0f;
            transform.position = p;
            ToggleText.text = "HERO: Drive(Mouse)";
        } else {
            Cursor.lockState = CursorLockMode.None;
            ToggleText.text = "HERO: Drive(KEY)";
        }
    }

    // void killSelf() {
    //     if(PlaneScript.touched == 10) {
    //         Destroy(gameObject);
    //         Application.Quit();
    //     }
    // }

    private void ProcessEggSpwan()
    {
        if (mEggStat.CanSpawn()) {
            if (Input.GetKey("space"))
                mEggStat.SpawnAnEgg(transform.position, transform.up);
        }
    }
}
