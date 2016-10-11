using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {
    
    
    public Canvas MainMenu;

	// Use this for initialization
	void Start () {

        MainMenu = MainMenu.GetComponent<Canvas>();
        
        

        



    }
	
	// Update is called once per frame
	public void StartLevel()
    {
        
        Application.LoadLevel(1);
        Time.timeScale = 1;

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {

        Time.timeScale = 1;
        MainMenu.enabled = false;

        
    }
}
