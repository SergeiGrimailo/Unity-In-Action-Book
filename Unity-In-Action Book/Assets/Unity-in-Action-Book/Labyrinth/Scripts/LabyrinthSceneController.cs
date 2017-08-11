using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthSceneController : MonoBehaviour {

	[SerializeField]
	private GameObject enemyPrefab;
	private GameObject _enemy;

	private float speed;

	void Awake() {
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGE, OnSpeedChange);
	}

	void OnDestroy() {
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGE, OnSpeedChange);
	}

	private void OnSpeedChange(float speed) {
		this.speed = speed;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (_enemy == null) {
			_enemy = Instantiate(enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3(0, 1, 0);
			float angle = Random.Range(0, 360);
			_enemy.transform.Rotate(0, angle, 0);
			WanderingAI ai = _enemy.GetComponent<WanderingAI>();
			if (ai != null) {
				ai.OnSpeedChange(this.speed);
			}
		}
	}
}
