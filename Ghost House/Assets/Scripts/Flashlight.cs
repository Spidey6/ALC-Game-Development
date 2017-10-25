using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

    public bool lightOn;

	Light light;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
		// Set Light default to ON
		lightOn = true;
		light.enabled = true;

	
	}
	
	// Update is called once per frame
	void Update () {
		// Toggle light on/off when l key is pressed.
		if (Input.GetKeyUp (KeyCode.L) && lightOn) {
            lightOn = false;
			light.enabled = true;
		}
		
		else if (Input.GetKeyUp(KeyCode.L) && !lightOn){
			lightOn = true;
			light.enabled = true;
		}
	
	}
	
}
