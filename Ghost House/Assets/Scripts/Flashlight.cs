using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour {

    public bool lightOn = true;
	// Flashlight power capacity
	public int maxPower = 4;
	// Useable flashlight power
	public int currentPower;

	public int batDrainAmt;

	public float batDrainDelay;

	bool draining = false; 

	Light light;
	// Gets Battery UI Text
	public Text batteryText;

	// Use this for initialization
	void Start () {
		//Add power to flashlight
		currentPower = maxPower;
		print("power = " + currentPower);
		
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
			light.enabled = false;
		}
		
		else if (Input.GetKeyUp(KeyCode.L) && !lightOn){
			lightOn = true;
			light.enabled = true;
		}
		//Update Battery UI text
		batteryText.text = currentPower.ToString();
	  

	  //Drain Battery Life
	  if(currentPower > 0 && lightOn){
		  if(!draining){
			  	StartCoroutine(BatteryDrain(batDrainDelay,batDrainAmt));
		  }
		  else if(currentPower <= 0){
			  lightOn = false;
			  light.enabled = false;
		  }
	  }
	}
	public void setLightOn(){
		lightOn = true;
	}

	public bool isLightOn(){
		return lightOn;
	}

	IEnumerator BatteryDrain(float delay, int amount){
		if(lightOn){
			draining = true;

		yield return new WaitForSeconds(delay);
		print(currentPower);
		currentPower -= amount;
		}
		if(currentPower <= 0){
			currentPower = 0;
			print("Battery is dead!");
			light.enabled = false;
		}

		draining = false;
	}
}
