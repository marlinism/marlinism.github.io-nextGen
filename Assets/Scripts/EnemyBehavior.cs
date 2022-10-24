using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
    public GameObject[] mWayPoints;
	public float mSpeed = 20f;

	public static int destroyed = 0;

    public static int touched = 0;

    private int count = 0;

    public bool seq = true;

    int current = 0;
		
	// Use this for initialization
	void Start () {
		NewDirection();
	}
	
	// Update is called once per frame
	void Update () {
        stat();
        
		GlobalBehavior globalBehavior = GameObject.Find ("GameManager").GetComponent<GlobalBehavior>();
		
		GlobalBehavior.WorldBoundStatus status =
			globalBehavior.ObjectCollideWorldBound(GetComponent<Renderer>().bounds);
			
		if (status != GlobalBehavior.WorldBoundStatus.Inside) {
			NewDirection();
		}	

		if(count >= 4) {
            destroyed++;
            death();
        }
	}

    private void stat() {
        if (Input.GetKey("j")) {
            Debug.Log("Pressed!");
            seq = !seq;
        }
        check();
    }

    private void check() {
        if(seq == false) {
            MoveRan();
        } else {
            MoveSeq();
        }
    }

    private void MoveRan() {
        Quaternion rotation = Quaternion.LookRotation(transform.position - mWayPoints[current].transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        Vector3 currpos = mWayPoints[current].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, currpos, Time.deltaTime * mSpeed);

        if(transform.position == mWayPoints[current].transform.position) {
            current = Random.Range(0, mWayPoints.Length);
        }

        if(current >= mWayPoints.Length) {
            current = 0;
        }
    }

    private void MoveSeq() {
        Quaternion rotation = Quaternion.LookRotation(transform.position - mWayPoints[current].transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        Vector3 currpos = mWayPoints[current].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, currpos, Time.deltaTime * mSpeed);

        if(transform.position == mWayPoints[current].transform.position) {
            current += 1;
        }

        if(current >= mWayPoints.Length) {
            current = 0;
        }
    }

	private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Hero") {
            touched++;
            death();
        }

        if(collision.gameObject.tag == "Bullet") {
            count++;
            StartCoroutine(FadeAlphaToZero(GetComponent<SpriteRenderer>()));
        }
    }
    public void death() {
        Destroy(gameObject);
    }
    IEnumerator FadeAlphaToZero(SpriteRenderer renderer) {
        Color startColor = renderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        renderer.color = Color.Lerp(startColor, endColor, 0.25f);

        yield return null;
    }

	// New direction will be something completely random!
	private void NewDirection() {
		Vector3 v = Random.insideUnitCircle;
		transform.up = new Vector3(v.x, v.y, 0.0f);
	}
}
