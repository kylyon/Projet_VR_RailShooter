using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    public UIDocument UIDocument;
    Button playButton;
    Button quitButton;
    
	void Start()
    {
        var root = UIDocument.rootVisualElement;
        
        playButton = root.Q<Button>("playButton");
        quitButton = root.Q<Button>("quitButton");
        
        // add event handler
        playButton.clickable.clicked += Play;
        quitButton.clickable.clicked += Quit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void Play()
	{
		UIDocument.gameObject.SetActive(false);
	}

	void Quit()
	{
		UIDocument.gameObject.SetActive(false);
	}
}
