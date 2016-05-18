using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour {
    public Button start;
    public Button exit;
    
    public Canvas MainMenu;

	// Use this for initialization
	void Start () {

        MainMenu = MainMenu.GetComponent<Canvas>();
        start = start.GetComponent<Button>();
        exit = exit.GetComponent<Button>();
        

        



    }
	
	// Update is called once per frame
	public void StartLevel()
    {
        Application.LoadLevel(1);
        
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
