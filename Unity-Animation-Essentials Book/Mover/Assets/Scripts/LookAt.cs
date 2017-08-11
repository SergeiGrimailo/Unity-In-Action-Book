using System.Collections;
using UnityEngine;

public class LookAt : MonoBehaviour {

	private Transform ThisTransform = null;

	public Transform Target = null;

	public float RotateSpeed = 100f;

	void Awake() {
		ThisTransform = GetComponent<Transform>();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(TrackRotation(Target));
	}

	IEnumerator TrackRotation(Transform Target) {
		while (true) {
			if (ThisTransform != null && Target != null) {
				Vector3 relativePos = Target.position - ThisTransform.position;
				Quaternion NewRotation = Quaternion.LookRotation(relativePos);

				ThisTransform.rotation = Quaternion.RotateTowards(ThisTransform.rotation,
					NewRotation, RotateSpeed * Time.deltaTime);
			}

			yield return null;
		}
	} 
	
	// Update is called once per frame
	void Update () {		
	}
}
