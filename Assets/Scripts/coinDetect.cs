using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coinDetect : MonoBehaviour {

	public GameManager gameManager;
	private GameObject car;
	public AudioClip coinS;
	public Slider healthSlider;
	
	public Text coinCollected;
	public Text score;
	public int coinC=0;
	// Use this for initialization
	void Start () {
		//maximum health of the player
		healthSlider.value = 100;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//detect collision of car with other objects
	void OnTriggerEnter(Collider col){			
		if(col.gameObject.tag == "coin"){				//detect collision with coin
			AudioSource.PlayClipAtPoint(coinS,transform.position); 
			Destroy(col.gameObject);
			col.gameObject.SetActive(false);
			coinC++;
			addCoin();
		}
		if(col.gameObject.tag == "cube"){
							//detect collision with wood cube box
			if(healthSlider.value >= 10)
			healthSlider.value -= 10;
			else{
				gameManager.panelGO.SetActive(true);
				gameManager.car.SetActive(false);
				Time.timeScale = 0;						//pause the screen
			}
			
		}

		if(col.gameObject.tag == "tree"){				//detect collision with trees
			if(healthSlider.value >= 15)
			healthSlider.value -= 15;
			else{
				gameManager.panelGO.SetActive(true);	//show gameover panel
				gameManager.car.SetActive(false);
				Time.timeScale = 0;						//pause the screen
			}
			
		}


		if(col.gameObject.tag == "fuel"){
			AudioSource.PlayClipAtPoint(coinS,transform.position); 	//play coin sound
			Destroy(col.gameObject);								//destroy fuel object
			col.gameObject.SetActive(false);
			gameManager.timer += 10;							//add time to the timer

		}
	}


	void addCoin(){			//add coin and score test on the gui
		coinCollected.text = "Coins Collected: " + coinC;
		score.text = "Score: " + (coinC * 5);
		
		
	}
	
}
