using UnityEngine;

public class SettingsPopup : MonoBehaviour {

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {		
	}

	public void Open() {
		gameObject.SetActive(true);
	}

	public void Close() {
		gameObject.SetActive(false);
		
	}

	public void OnSubmitName(string name) {
		Debug.Log("Name: " + name);
	}

	public void OnSpeedValue(float speed) {
		Messenger<float>.Broadcast(GameEvent.SPEED_CHANGE, speed);
	}
}
