using UnityEngine;
using System.Collections;

public class BatterySpawn : MonoBehaviour {



	public GameObject battery;
	public Transform spawnPoint;
	public float spawnTime;

	public bool batSpawned;


	// Use this for initialization
	void Start () {
		batSpawned = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(batSpawned == false){
			StartCoroutine(SpawnBat(spawnTime, battery));
		}
		else{

		}
	}


		void OnTriggerEnter(Collider other){
			if(other.gameObject.tag == "Battery"){
				batSpawned = true;
			}
			else {
				batSpawned = false;
			}





		}
			
		
		 
		 
	 
	 IEnumerator SpawnBat(float time, Rigidbody bat){
		yield return new WaitForSeconds(spawnTime);
		Instantiate(battery, spawnPoint.position, spawnPoint.rotation); 
	}

}