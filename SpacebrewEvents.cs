using UnityEngine;
using System.Collections;

public class SpacebrewEvents : MonoBehaviour {

	SpacebrewClient sbClient;
	bool lightState = false;

	//define var to make the hook move
	Vector3 End_pos;
	Vector3 Start_pos;
	private float distance;
	//define hook position
	bool hookUP = false;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find ("SpacebrewObject"); // the name of your client object
		sbClient = go.GetComponent <SpacebrewClient> ();

		//GameObject hook = GameObject.Find ("SpacebrewObject"); // the name of your client object

		// register an event with the client and a callback function here.
		// COMMON GOTCHA: THIS MUST MATCH THE NAME VALUE YOU TYPED IN THE EDITOR!!
		//sbClient.addEventListener (this.gameObject, "launchSatellite");
		//sbClient.addEventListener (this.gameObject, "lightOn");
		//sbClient.addEventListener (this.gameObject, "letters");
		sbClient.addEventListener (this.gameObject, "Julius_Up");
		sbClient.addEventListener (this.gameObject, "Julius_Down");
		sbClient.addEventListener (this.gameObject, "Julius_Right");
		sbClient.addEventListener (this.gameObject, "Julius_Left");
		sbClient.addEventListener (this.gameObject, "Julius_Line");

		sbClient.addEventListener (this.gameObject, "Micol_Up");
		sbClient.addEventListener (this.gameObject, "Micol_Down");
		sbClient.addEventListener (this.gameObject, "Micol_Right");
		sbClient.addEventListener (this.gameObject, "Micol_Left");
		sbClient.addEventListener (this.gameObject, "Micol_Line");

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			print ("Sending Spacebrew Message");
			// name, type, value
			// COMMON GOTCHA: THIS MUST MATCH THE NAME VALUE YOU TYPED IN THE EDITOR!!
			sbClient.sendMessage("buttonPress", "boolean", "true");
		}
		
		//send message but no idea what it means
		foreach (char c in Input.inputString) {
			if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
				sbClient.sendMessage("buttonPress", "boolean", "true");
			}
		}
	}

	public void OnSpacebrewEvent(SpacebrewClient.SpacebrewMessage _msg) {
		print ("Received Spacebrew Message");
		print (_msg);

		//PITCH
		if (_msg.name == "Julius_Up") {
			//double check that something is actually coming through
			print("PitchUp got through!");
			
			//find in the hierarchy the object you want to be modified
			GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/FishingPole_P1/Pole/node-0");
			//affect its rotation
			go.gameObject.transform.Rotate(5,0,0);
		}

		if (_msg.name == "Julius_Down") {
			//double check that something is actually coming through
			print("PitchDown got through!");
			
			//find in the hierarchy the object you want to be modified
			GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/FishingPole_P1/Pole/node-0");
			//affect its rotation
			go.gameObject.transform.Rotate(-5,0,0);
		}

		//ROLL
		if (_msg.name == "Julius_Left") {
			//double check that something is actually coming through
			print("RollLeft got through!");
			
			//find in the hierarchy the object you want to be modified
			GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/FishingPole_P1/Pole/node-0");
			//affect its rotation
			go.gameObject.transform.Rotate(0,0,-5);
		}

		if (_msg.name == "Julius_Right") {
			//double check that something is actually coming through
			print("RollRight got through!");
			
			//find in the hierarchy the object you want to be modified
			GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/FishingPole_P1/Pole/node-0");
			//affect its rotation
			go.gameObject.transform.Rotate(0,0,5);
		}

		/*//FISHING HOOK
		if (_msg.name == "Julius_Line") {
			//double check that something is actually coming through
			print("Line got through!");
			
			if (_msg.value == "true") {
				//find in the hierarchy the object you want to be modified
			GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/FishingPole_P1/Pole/node-0/Fish_hook/node-0");
			
			//move the hook in or out of the bathtub
			distance += 0.01f;
			
			//define start position
			Start_pos = go.gameObject.transform.position;

			//check where the hook is and move it consequently
			if (hookUP == false){
				End_pos =  Start_pos + new Vector3 (0, 500, 0);
			}
			else if (hookUP == true){
				End_pos =  Start_pos - new Vector3 (0, 500, 0);
			}
			//once the hook has been move convert its position to the opposit of where it started from
			go.gameObject.transform.position = Vector3.Lerp(Start_pos, End_pos, distance);
			Start_pos = End_pos;
			hookUP = !hookUP;
			}
			*/
			
		
		
		
		
		//PITCH
		if (_msg.name == "Micol_Up") {
			//double check that something is actually coming through
			print("PitchUp got through!");
			
			//find in the hierarchy the object you want to be modified
			GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/FishingPole_P2/Pole/node-0");
			//affect its rotation
			go.gameObject.transform.Rotate(5,0,0);
		}

		if (_msg.name == "Micol_Down") {
			//double check that something is actually coming through
			print("PitchDown got through!");
			
			//find in the hierarchy the object you want to be modified
			GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/FishingPole_P2/Pole/node-0");
			//affect its rotation
			go.gameObject.transform.Rotate(-5,0,0);
		}

		//ROLL
		if (_msg.name == "Micol_Left") {
			//double check that something is actually coming through
			print("RollLeft got through!");
			
			//find in the hierarchy the object you want to be modified
			GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/FishingPole_P2/Pole/node-0");
			//affect its rotation
			go.gameObject.transform.Rotate(0,0,-5);
		}

		if (_msg.name == "Micol_Right") {
			//double check that something is actually coming through
			print("RollRight got through!");
			
			//find in the hierarchy the object you want to be modified
			GameObject go = GameObject.Find("BaseBoARd/YourObjectsGoHere/FishingPole_P2/Pole/node-0");
			//affect its rotation
			go.gameObject.transform.Rotate(0,0,5);
		}

		}
	}
