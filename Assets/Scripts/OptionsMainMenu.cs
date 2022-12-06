using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMainMenu : MonoBehaviour
{
     //  Este script permite la funcionalidad del area de menu principal

    public GameObject PrincipalPanel; // Panel de menu principal
    public GameObject LoginPanel; // panel de inicio de sesion
    public GameObject NewGamePanel; //Panel de nueva partida
    public GameObject TeamPanel; // Panel de selecicon de equipo


    public void OpenPanel(GameObject panel) // Esta funcion cierra todos los paneles y activa el que fue enviado por parametro
    {
        PrincipalPanel.SetActive(false);
        LoginPanel.SetActive(false);
        NewGamePanel.SetActive(false);
        TeamPanel.SetActive(false);

        panel.SetActive(true);

    }


   public void  GoToStadistics() // Envia a la Escena de estadisticas
   {
        SceneManager.LoadScene("StatisticsScene");
   }

     public void  GoToGame() // Envia a el Escenario de juego
   {
        SceneManager.LoadScene("GameScenePlus");
   }


   public void ExitGame() // Cierra el juego
   {
        Application.Quit();
   }
}
