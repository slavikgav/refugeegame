﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Country : MonoBehaviour {
    public string currentLevelName = "Game";

    public Country country = null;
	public static Country current = null;
	
	void Awake() {
		current = this;
	}

	public Vector3 getCountryPos(){
		return this.transform.position;
	}

	void OnTriggerEnter2D(Collider2D collider){
		HeroRefugee refugee = collider.GetComponent<HeroRefugee>();
		if(refugee){
 			Dictionary<President, Country> dict = MainController.instance.getList();
			foreach(KeyValuePair<President, Country> entry in dict)
			{
				if(entry.Value == country) entry.Key.run();
			}
		}
	}	
	
	void OnTriggerExit2D(Collider2D collider){
		HeroRefugee refugee = collider.GetComponent<HeroRefugee>();
		if(refugee){
 			Dictionary<President, Country> dict = MainController.instance.getList();
			foreach(KeyValuePair<President, Country> entry in dict){
				if(entry.Value == country) entry.Key.goHome();
			}
            if (refugee.getEscapedCountries() == 2){
                loadCustoms();
            }
		}
	}

	public Country getCountry(){
		return country;
	}

    public void loadCustoms(){
        LevelStats stats = MainController.instance.getStats();

        string str = JsonUtility.ToJson(stats);

        PlayerPrefs.SetString(currentLevelName, str);
        PlayerPrefs.SetInt("health", LivesPanel.instance.getAmountOfHealth());
        //PlayerPrefs.SetInt("frui", LivesPanel.instance.getAmountOfHealth());

        PlayerPrefs.Save();
        
        SceneManager.LoadScene("Customs");
        PlayerPrefs.Save();   
    }
}
