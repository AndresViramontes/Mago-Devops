using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsStatistics : MonoBehaviour
{
     // esta funcion sirve para agregar la funcionalidad a los botones del area des estadisticas

     public void  GoToMain()
   {
        SceneManager.LoadScene("MainMenuScene"); // Envia a escena de menu principal
   }

}
