using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPointBehavior : MonoBehaviour
{   
    private int count = 0;
    private bool show = true;

    void Update () {
        
		if(count >= 4) {
            death();
        }
        hideshow();
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Bullet") {
            count++;
            StartCoroutine(FadeAlphaToZero(GetComponent<SpriteRenderer>()));
        }
    }

    IEnumerator FadeAlphaToZero(SpriteRenderer renderer) {
        Color startColor = renderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        renderer.color = Color.Lerp(startColor, endColor, 0.25f);

        yield return null;
    }

    public void death() {
        Destroy(gameObject);
    }

    private void hideshow() {
        if (Input.GetKey("h")) {
            Debug.Log("Pressed!");
            show = !show;
        }
        check();
    }

    private void check() {
        if(show == false) {
            GetComponent<Renderer>().enabled = false;
        } else {
            GetComponent<Renderer>().enabled = true;
        }
    }

    
}
