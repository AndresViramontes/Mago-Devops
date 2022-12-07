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
using UnityEditor.PackageManager;

[CreateAssetMenu(fileName = "Servidor", menuName = "Unity/Servidor", order = 1)]
public class Servidor : ScriptableObject
{
    public string servidor; 
    public Servicio[] servicios;//arreglo con los nombres de los servicos que puede el servidor

    public string username = "";//nombre del jugador que almacena para realizar la consulta de estadisticas

    public bool ocupado = false; //define si esta ocupado o no el servidor
    public Respuesta respuesta; //almacena la respuesta de la solicitud web

    public IEnumerator ConsumirServicio(string nombre, string[] datos)
    {
        //Incializacion de las variables necesarias para el servidor
        char[] auxiliar;
        string aux;
        bool especial = false;
        respuesta = new Respuesta();
        ocupado = true;//Se indica que el servidor esta ocupado
        WWWForm formulario = new WWWForm();//formulario de tipo web
        Servicio s = new Servicio();//Se incia un nuevo servico
        //###############################################

        //Ciclo que busca si existe el servico indicado
        for (int i = 0; i < servicios.Length; i++)
        {
            if (servicios[i].nombre.Equals(nombre))
            {
                s = servicios[i];
                break;
            }
        }
        //Seccion que permite evaluar si los nombres de usuario introducidos no contienen simbolos espciales
        aux = datos[0];
        aux = aux.Substring(0, aux.Length - 1);
        auxiliar = aux.ToArray();
        //Ciclo que busca dentro de la cadena si hay simbolos especiales de encontrar uno se activa una bandera y se ropmpe el ciclo
        foreach (char c in auxiliar)
        {
            Debug.Log(c);
            if (!char.IsLetterOrDigit(c))
            {
                especial = true;
                break;
            }
        }
        //Restriccion que impide seguir con el login o el registro de tener un simbolo espcial el nombre
        if (especial)
        {
            Debug.Log("hay un simbolo especial");
            respuesta.mensaje = "El Nombre de usuario no debe tener simbolos especiales";
            respuesta.codigo = 409;
        }
        //#############################################################################3#
        else
        {
            Debug.Log(auxiliar);
            Debug.Log(aux);
            datos[0].Equals(auxiliar);
            for (int i = 0; i < s.parametros.Length; i++)
            {
                formulario.AddField(s.parametros[i], datos[i]);//se añaden los campos necesarios al formulario
                                                               //que se enviara a la web 

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
            //Se genera una peticion web con el formulario que se lleno previamente
            UnityWebRequest www = UnityWebRequest.Post(servidor + "/" + s.URL, formulario);
            //Espera la respuesta del hilo con la conexion del servidor remoto 
            yield return www.SendWebRequest();

            //Condicionales que revisan si la respuesta que envia el servidor esta vacia o no
            if (www.downloadedBytes > 0)
            {
                Debug.Log("La respuesta NO esta vacia");
                Debug.Log(www.downloadedBytes.ToString());
            }
            else
            {
                Debug.Log("La respuesta esta vacia");
            }
            //################################################
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

//Clase que alacena el servicio del servidor
[Serializable]
public class Servicio
{
    public string nombre;//nombre de servicio
    public string URL;//direccion del servicio
    public string[] parametros;//parametros para el uso del servicio
}

//Clase que almacena las respuestas dadas por la solicitud web
[Serializable]
public class Respuesta
{
    public int codigo;//codigo de la respuesta
    public string mensaje;//mensaje de la respuesta
    public List<Estadistica> respuesta;//lista de las estadisticas
}
//Clase que almacena las estadisticas recuperadas de la base de datos
[Serializable]
public class Estadistica
{
    //Datos de la partida 
    public int idPartida;
    public string usuario;
    public string equipo;
    public string duracion;
    public string dificultad;
    public int ganado;
    //--------------------
}