using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menus : MonoBehaviour {

	public GameObject Canvas;

	public GameObject CanvasOptions;




	public void PlayGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void MenusQ(){
		Application.Quit ();
	}

	public void MenusOption (){

		Canvas.SetActive (false);
		CanvasOptions.SetActive (true);

			}
}
