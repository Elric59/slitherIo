using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBckg : MonoBehaviour {
	
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer> ();

		Material mat = mr.material;

		Vector2 offset = mat.mainTextureOffset;

		offset.x = transform.position.x / 100;
		offset.y = transform.position.y / 100;

		mat.mainTextureOffset = offset;
	}
}
