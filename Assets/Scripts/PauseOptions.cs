using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


//Este script proporciona la funcionalidad del boton de pausa de la partida

public class PauseOptions : MonoBehaviour
{

    public GameObject GamePanel; // Panel que contiene el boton y el cronometro
    public GameObject PausePanel; // panel que contiene el menu de pausa



    public void OpenPanel(GameObject panel) // Dersactiva ambos paneles y activa unicamente el que fie enviado por parametro
    {
        GamePanel.SetActive(false);
        PausePanel.SetActive(false);


        panel.SetActive(true);

    }


   public void  GoToMain() // Devuelve a la escena menu principal
   {
        SceneManager.LoadScene("MainMenuScene");
   }


}
