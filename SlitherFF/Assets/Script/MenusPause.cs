using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenusPause : MonoBehaviour {

	public GameObject MenusPaus;

	public GameObject Option;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void MenusOption (){

		MenusPaus.SetActive (false);
		Option.SetActive (true);

	}
}
