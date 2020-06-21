#pragma strict
var showGUI : boolean = false;
var MenusPause : GameObject;

function Start () {
	MenusPause=GameObject.Find("MenusPause");
}

function Update () {

if(Input.GetKeyDown(KeyCode.Escape)){
	showGUI = !showGUI;
	}
if(showGUI == true){
	MenusPause.SetActive(true);
	Time.timeScale=0;

	}
else{
	MenusPause.SetActive(false);
	Time.timeScale=1;
	}

}

function Quitt(){
	Application.Quit();
		
	}
