using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (MeshRenderer))]
public class MatScroller : MonoBehaviour {
	
	public float HorizSpeed = 1.0f;
	public float VertSpeed = 1.0f;

	public float HorizUVMin = 1.0f;
	public float HorizUVMax = 2.0f;

	public float VertUVMin = 1.0f;
	public float VertUVMax = 2.0f;


	private MeshRenderer MeshR = null;

	void Awake() {
		MeshR = GetComponent<MeshRenderer>();
	}

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentOffset = MeshR.material.mainTextureOffset;

		if (currentOffset.x > HorizUVMax) {
			currentOffset.x = HorizUVMin;
		} else {
			currentOffset.x += Time.deltaTime * HorizSpeed;
		}

		if (currentOffset.y > VertUVMax) {
			currentOffset.y = VertUVMin;
		} else {
			currentOffset.y += Time.deltaTime * VertSpeed;
		}
		
		MeshR.material.mainTextureOffset = currentOffset;
	}
}
