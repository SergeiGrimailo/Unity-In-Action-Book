using UnityEngine;
using UnityEngine.UI;

public class LabyrinthUIController : MonoBehaviour {

	[SerializeField]
	private Text scoreLabel;

	[SerializeField]
	private SettingsPopup settingsPopup;

	private int _score;

	void Awake() {
		Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	private void OnDestroy() {
		Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
	}

	private void OnEnemyHit() {
		_score += 1;
		scoreLabel.text = _score.ToString();
	}

	// Use this for initialization
	void Start () {
		_score = 0;
		scoreLabel.text = _score.ToString();
		settingsPopup.Close();

		Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (settingsPopup.gameObject.activeInHierarchy) {
				settingsPopup.Close();

				Cursor.lockState = CursorLockMode.Locked;				
				Cursor.visible = false;

			} else {
				settingsPopup.Open();

				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
	}

	public void OnOpenSettings() {
		settingsPopup.Open();
	}

	public void OnPointerDown() {
		Debug.Log("pointer down");
	}
}
