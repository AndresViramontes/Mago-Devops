using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Json;
using UnityEditor.VersionControl;
using System.Linq;

[CreateAssetMenu(fileName = "Servidor", menuName = "Unity/Servidor", order = 1)]
public class Servidor : ScriptableObject
{
    public string servidor;
    public Servicio[] servicios;

    public string username = "";

    public bool ocupado = false;
    public Respuesta respuesta;

    public IEnumerator ConsumirServicio(string nombre, string[] datos)
    {
        char[] auxiliar;
        string aux;
        bool especial = false;
        respuesta = new Respuesta();
        ocupado = true;
        WWWForm formulario = new WWWForm();
        Servicio s = new Servicio();

        for (int i = 0; i < servicios.Length; i++)
        {
            if (servicios[i].nombre.Equals(nombre))
            {
                s = servicios[i];
                break;
            }
        }
        aux = datos[0];
        aux = aux.Substring(0, aux.Length - 1);
        auxiliar = aux.ToArray();

        foreach (char c in auxiliar)
        {
            Debug.Log(c);
            if (!char.IsLetterOrDigit(c))
            {
                especial = true;
                break;
            }
        }
        if (especial)
        {
            Debug.Log("hay un simbolo especial");
            respuesta.mensaje = "El Nombre de usuario no debe tener simbolos especiales";
            respuesta.codigo = 409;
        }
        else
        {
            Debug.Log(auxiliar);
            Debug.Log(aux);
            datos[0].Equals(auxiliar);
            for (int i = 0; i < s.parametros.Length; i++)
            {
                formulario.AddField(s.parametros[i], datos[i]);

            }
            if (formulario.headers.Count > 0)
            {
                Debug.Log("formulario lleno");
            }
            else
            {
                Debug.Log("formulario vacio");
            }
            Debug.Log(servidor + "/" + s.URL);
            UnityWebRequest www = UnityWebRequest.Post(servidor + "/" + s.URL, formulario);

            yield return www.SendWebRequest();

            if (www.downloadedBytes > 0)
            {
                Debug.Log("La respuesta NO esta vacia");
                Debug.Log(www.downloadedBytes.ToString());
            }
            else
            {
                Debug.Log("La respuesta esta vacia");
            }

            string jsonString;
            jsonString = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data, 2, www.downloadHandler.data.Length - 2);
            if (s.nombre == "Estadistica")
            {
                jsonString = jsonString.Remove(jsonString.Length - 3);
                jsonString = jsonString + "]}";
            }
            Debug.Log(jsonString);
            jsonString = jsonString.Replace('#', '"');
            Debug.Log(jsonString);

            if (www.result != UnityWebRequest.Result.Success)
            {
                respuesta = new Respuesta();
            }
            else
            {
                respuesta = JsonUtility.FromJson<Respuesta>(jsonString);

            }
        }
        ocupado = false;
    }

}

[Serializable]
public class Servicio
{
    public string nombre;
    public string URL;
    public string[] parametros;
}

[Serializable]
public class Respuesta
{
    public int codigo;
    public string mensaje;
    public List<Estadistica> respuesta;
}
[Serializable]
public class Estadistica
{
    public int idPartida;
    public string usuario;
    public string equipo;
    public string duracion;
    public string dificultad;
    public int ganado;
}