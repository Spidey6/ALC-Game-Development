﻿using UnityEngine;
using System.Collections;

public class Battery : MonoBehaviour {

	public int power = 4;

	public GameObject flashlight;
	public GameObject batterySpawn;

	GameObject player;

	int checkBat;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		batterySpawn = GameObject.FindWithTag("BatterySpawn");
		flashlight = player;

	
	}
	
	// Update is called once per frame
	void Update () {
		checkBat = flashlight.gameObject.GetComponentInChildren<Flashlight>().currentPower;
		print("CkBat = "+checkBat);
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player" && checkBat == 0){
			flashlight.gameObject.GetComponentInChildren<Flashlight>().currentPower = power;
			Destroy(gameObject);
			batterySpawn.gameObject.GetComponentInChildren<BatterySpawn>().BatteryPickup();
		}
	}

}
