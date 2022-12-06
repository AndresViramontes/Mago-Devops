using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseOptions : MonoBehaviour
{

    public GameObject GamePanel;
    public GameObject PausePanel;



    public void OpenPanel(GameObject panel)
    {
        GamePanel.SetActive(false);
        PausePanel.SetActive(false);


        panel.SetActive(true);

    }


   public void  GoToMain()
   {
        SceneManager.LoadScene("MainMenuScene");
   }


}
