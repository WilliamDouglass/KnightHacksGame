using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScrpts : MonoBehaviour
{
    [SerializeField] private int StartGameSceneIndex = 1;
    
    public void PlayGame(){
        SceneManager.LoadScene(StartGameSceneIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    }

   

}
