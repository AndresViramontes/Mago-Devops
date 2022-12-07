using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Estadisticas : MonoBehaviour 
{
    public TextMeshProUGUI partida;
    public TextMeshProUGUI usuario;
    public TextMeshProUGUI equipo;
    public TextMeshProUGUI duracion;
    public TextMeshProUGUI dificultad;
    public TextMeshProUGUI mensaje;
    public TextMeshProUGUI ganado;
    public Servidor servidor;//objeto servidor que se necesita para la conexion a este 

    //funcion que se manda llamar apenas se habilita la pantalla para
    //que las estadisticas se recuperen
    public void OnEnable()
    {
        GeneraEstadisticas();
    }
    //llamado al hilo del servicio de estadistica
    public void GeneraEstadisticas()
    {

        StartCoroutine(estadisticas());
    }

    //funcion que solicita el servicio de estaditacas dentro del servidor
    IEnumerator estadisticas()
    {
        //llenado de los datos  obtenindolos del inicio de sesion y del registro
        string[] datos = new string[1];
        datos[0] = servidor.username;
        Debug.Log(servidor.username);

        //conexion con el servidor enviando el nombre del servicio a consumir 
        // y los datos que necesita dicho servicio atravez dek arreglo 
        StartCoroutine(servidor.ConsumirServicio("Estadistica", datos));
        //recuperacion de la respuesta que envia el servidor
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        mensaje.text = servidor.respuesta.mensaje.ToString();
        //llamado a la funcion para cargar los datos en la interfaz
        cargaEstadisticas();
    }
    //Funcion que carga los datos repuerados del servidor dentro de la interfaz de usuario
    void cargaEstadisticas()
    {
        //ciclo que revisa la lista de estadisticas en las respuesta que regresa el servidor 
        foreach(Estadistica e in servidor.respuesta.respuesta)
        {
            Debug.Log(e.idPartida.ToString());
            partida.text += "\n" + e.idPartida.ToString();
            usuario.text += "\n" + servidor.username.ToString();
            equipo.text += "\n" + e.equipo.ToString();
            duracion.text += "\n" + e.duracion.ToString();
            dificultad.text += "\n" + e.dificultad.ToString();
            if (e.ganado == 1)
            {
                ganado.text += "\n" + "Si";
            }
            else
            {
                ganado.text += "\n" + "No";
            }
        }
    }

}