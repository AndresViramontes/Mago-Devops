using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Login : MonoBehaviour
{
    public Servidor servidor;//objeto servidor que se necesita para la conexion a este 
    public TMP_InputField NameInput;
    public TMP_InputField PassInput;
    public TextMeshProUGUI mensaje;
    public Button button;

    //llamado al hilo que realiza el inicio de sesion
    public void iniciarSesion()
    {
        StartCoroutine(Iniciar());
    }
    //llamdo al hilo que realiza el inicio de sesion
    public void resgitrarUsuario()
    {
        StartCoroutine(registrarse());
    }

   //funcion que realiza la solicitud al servidor de inicio de sesion
   //utiliza los datos obtenidos de la interfaz de usuario
    IEnumerator Iniciar()
    {
        //llenado de los datos  obtenindolos de la interfaz de ususario 
        string[] datos = new string[2];
        datos[0] = NameInput.textComponent.text.ToString();
        Debug.Log(NameInput.text);
        datos[1] = PassInput.textComponent.text;
        Debug.Log(PassInput.text);
        //conexion con el servidor enviando el nombre del servicio a consumir 
        // y los datos que necesita dicho servicio atravez dek arreglo 
        StartCoroutine(servidor.ConsumirServicio("login", datos));
        //recuperacion de la respuesta que envia el servidor
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        mensaje.text = servidor.respuesta.mensaje;
        //habilitacion del boton de estadisticas
        if (servidor.respuesta.codigo == 205)
        {
            servidor.username = datos[0];
            button.interactable= true;
        }
    }
    //funcion que realiza la solicitud al servidor de registro de usuario
    //utiliza los datos obtenidos de la interfaz de usuario
    IEnumerator registrarse()
    {
        //llenado de los datos  obtenindolos de la interfaz de ususario 
        string[] datos = new string[2];
        datos[0] = NameInput.textComponent.text.ToString();
        Debug.Log(NameInput.text);
        datos[1] = PassInput.textComponent.text;
        Debug.Log(PassInput.text);
        //conexion con el servidor enviando el nombre del servicio a consumir 
        // y los datos que necesita dicho servicio atravez dek arreglo 
        StartCoroutine(servidor.ConsumirServicio("Registro", datos));
        //recuperacion de la respuesta que envia el servidor
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        mensaje.text = servidor.respuesta.mensaje;
        //habilitacion del boton de estadisticas
        if (servidor.respuesta.codigo == 201)
        {
            servidor.username = datos[0];
            button.interactable = true;
        }
    }

}

