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
    public Servidor servidor;
    public TMP_InputField NameInput;
    public TMP_InputField PassInput;
    public TextMeshProUGUI mensaje;
    public Button button;

    public void iniciarSesion()
    {
        StartCoroutine(Iniciar());
    }

    public void resgitrarUsuario()
    {
        StartCoroutine(registrarse());
    }
    IEnumerator Iniciar()
    {
        string[] datos = new string[2];
        datos[0] = NameInput.textComponent.text.ToString();
        Debug.Log(NameInput.text);
        datos[1] = PassInput.textComponent.text;
        Debug.Log(PassInput.text);

        StartCoroutine(servidor.ConsumirServicio("login", datos));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        mensaje.text = servidor.respuesta.mensaje;
        if (servidor.respuesta.codigo == 205)
        {
            servidor.username = datos[0];
            button.interactable= true;
        }
    }

    IEnumerator registrarse()
    {
        string[] datos = new string[2];
        datos[0] = NameInput.textComponent.text.ToString();
        Debug.Log(NameInput.text);
        datos[1] = PassInput.textComponent.text;
        Debug.Log(PassInput.text);

        StartCoroutine(servidor.ConsumirServicio("Registro", datos));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        mensaje.text = servidor.respuesta.mensaje;
        if (servidor.respuesta.codigo == 201)
        {
            servidor.username = datos[0];
            button.interactable = true;
        }
    }

}

