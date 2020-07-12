using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_level : MonoBehaviour
{

    public string level_name;

    public void LoadLevel(string level_name) { SceneManager.LoadScene(level_name); }//load a level
    public void EndGame() { Application.Quit(); }//exit the game

    //-------------------------------------------------------------------------------------------
    void FixedUpdate()//leave for title screen
    {
        if (Input.GetKey(KeyCode.Escape)) //if escape
        {
            if (SceneManager.GetActiveScene().name == "scn_title") //if title then exit game
            {
                SceneManager.LoadScene("scn_title");
            }
            else //if any other level then go to title
            {
                Application.Quit();
            }
        }
    }

}
