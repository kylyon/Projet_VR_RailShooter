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
    
	void Start()
    {
	    // add event handler
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
	    if (Input.GetKey(KeyCode.Escape))
	    {
		    Pause();
	    }
    }

	void Play()
	{
		hud.gameObject.SetActive(true);
		menu.gameObject.SetActive(false);
	}

	void Quit()
	{
		menu.gameObject.SetActive(true);
		hud.gameObject.SetActive(false);
	}
	
	void Pause()
	{
		menu.gameObject.SetActive(true);
		hud.gameObject.SetActive(false);
	}
}
