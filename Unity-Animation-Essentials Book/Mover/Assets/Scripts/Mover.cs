using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float Speed = 1f;

	public Vector3 Direction = Vector3.zero;

	public AnimationCurve AnimCurve;

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		Transform ThisTransform = GetComponent<Transform>();
		ThisTransform.position += Direction.normalized * Speed 
			* AnimCurve.Evaluate(Time.time) * Time.deltaTime;
		if (Debug.isDebugBuild) Debug.Log("TimeDelta: " + Time.deltaTime);
	}
}
