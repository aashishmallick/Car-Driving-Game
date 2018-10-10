using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject car;
	public coinDetect coinDetectT;
	public GameObject panelGO;
	//public GameObject playBut;
	public int coinC;
	public Text panelCoin;
	public Text panelScore;
	public float timer=60;
	 public Text timerText;
	 public GameObject winPanel;
	 public GameObject pausePanel;
	 private bool pauseCounter = false;
	 

	// Use this for initialization
	void Start () {
		panelGO.GetComponent<GameObject>();
		panelGO.SetActive(false);				//hide the panel (game over)
		winPanel.SetActive(false);				//hide the panel (pause)
		pausePanel.SetActive(false);	
		//playBut.SetActive(true);
		
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;					//time according to system time
		float minutes = Mathf.Floor(timer/60);		//convert seconds into minutes
		int seconds = (int)(timer%60);				//and remaining as seconds
		if(timer >= 0){
			timerText.text = "Time Left : " + minutes + ":" + seconds;			//display time on the gui
			if(coinDetectT.coinC == 150){
				winPanel.SetActive(true);
				car.SetActive(false);	
				Time.timeScale = 0;
			}
		}
		if(timer <= 0){
			Timer();
		}
	}

	void Timer(){
		panelGO.SetActive(true);
		coinC = coinDetectT.coinC;
		panelCoin.text = "Total Coins Collected: " + coinC.ToString();			//show coin text on gui
		panelScore.text = "Total Score: " + (coinC * 5).ToString();				//show score text on gui
		Time.timeScale = 0;
		car.SetActive(false);
		
	}  

	public void retryButton(){
		panelGO.SetActive(false);
		coinDetectT.coinC = 0;
		timer = 60;
		Time.timeScale = 1;
		SceneManager.LoadScene("Car");			//reload the scene again
		
	}     

	public void exitButton(){
		Application.Quit();					//quit the application
	}


	public void pauseGame(){
		if(pauseCounter == false){
			Time.timeScale = 0;
			pausePanel.SetActive(true);
			pauseCounter = true;
		}
		else{
			Time.timeScale = 1;					//resume the screen play
			pausePanel.SetActive(false);
			pauseCounter = false;
		}
		
	}
}
