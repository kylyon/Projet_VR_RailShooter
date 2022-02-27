using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	public Button playButton;
	public Button quitButton;

	public Canvas menu;
	public Canvas hud;
	public Canvas endgame;
	public GameObject setting;
    
	void Start()
    {
	    // add event handler
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(ExitGame);
        
        setting.SetActive(false);
        hud.gameObject.SetActive(false);
        endgame.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKey(KeyCode.Escape))
	    {
		    Pause();
	    }
    }

	public  void Play()
	{
		GameManager.Instance().StartGame();
		hud.gameObject.SetActive(true);
		menu.gameObject.SetActive(false);
		endgame.gameObject.SetActive(false);
		playButton.onClick.AddListener(Unpause);
	}
	
	public void Setting()
	{
		setting.gameObject.SetActive(true);
	}
	
	public void ExitSetting()
	{
		setting.gameObject.SetActive(false);
	}

	public void Quit()
	{
		playButton.onClick.AddListener(Play);
		menu.gameObject.SetActive(true);
		hud.gameObject.SetActive(false);
		endgame.gameObject.SetActive(false);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
	
	void Pause()
	{
		menu.gameObject.SetActive(true);
		hud.gameObject.SetActive(false);
		endgame.gameObject.SetActive(false);
	}
	
	void Unpause()
	{
		hud.gameObject.SetActive(true);
		menu.gameObject.SetActive(false);
		endgame.gameObject.SetActive(false);
	}

	public void EndGameUI()
	{
		menu.gameObject.SetActive(false);
		hud.gameObject.SetActive(false);
		endgame.gameObject.SetActive(true);
		playButton.onClick.AddListener(Play);
	}
}
