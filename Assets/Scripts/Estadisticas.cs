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
    public Servidor servidor;


    public void OnEnable()
    {
        GeneraEstadisticas();
    }

    public void GeneraEstadisticas()
    {

        StartCoroutine(estadisticas());
    }


    IEnumerator estadisticas()
    {
        string[] datos = new string[1];
        datos[0] = servidor.username;
        Debug.Log(servidor.username);


        StartCoroutine(servidor.ConsumirServicio("Estadistica", datos));
        yield return new WaitForSeconds(0.5f);
        yield return new WaitUntil(() => !servidor.ocupado);
        mensaje.text = servidor.respuesta.mensaje.ToString();
        cargaEstadisticas();
    }

    void cargaEstadisticas()
    {
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