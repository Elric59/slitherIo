using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retour : MonoBehaviour {
	[SerializeField]
	private GameObject Canvas;
	[SerializeField]
	private GameObject CanvasOptions;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void back (){
		CanvasOptions.SetActive (false);
		Canvas.SetActive (true);
	}
}

	
