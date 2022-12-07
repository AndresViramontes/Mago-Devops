using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaDatos : MonoBehaviour
{

    public GameObject esfera; //Instancia de un GameObject esfera

    public NavMeshController aux; //Instancia de un NavMeshControler(Script) auxiliar

    public GameObject SujetadorManoo; //Instancia de un GameObject SujetadorMano

    public GameObject DestinoEsferaa; //Instancia de un GameObject DestinoEsfera

    public bool esferaCapturada; //Instancia de un Boleano EsferaCapturada
    public bool esferaEnDestino; //Instancia de un Boleano EsferaEnDestino

    public Collider other;      //Instancia de un Collider Other

    //Función que se ejecuta al incio del script(Parte de Estructura Básica)
    void Start(){
        DestinoEsferaa = GameObject.Find("DestinoEsferas"); //Ordenando al Objeto Buscar "DestinoEsferas" dentro del Área de Trabajo
        SujetadorManoo = GameObject.Find("SujetadorMano");  //Ordenando al Objeto buscar "SujetadorMano" dentro del Área de Trabajo
    }

    //Función que se actualiza en cada fotograma de la ejecución del juego(Parte de Estructura Básica)
    void Update()
    {
        if(esferaCapturada == true) //Condicional para asegurar que la pelota haya sido tomada por el NPC.
        {
            esfera.transform.position = GameObject.Find("SujetadorMano").transform.position;    //Si es "true" la posicion de la pelota pasa a ser la posicion de la mano del NPC.
            esfera.GetComponent<Rigidbody>().isKinematic = true; 
        }
        if(other.tag == "DestinoEsferas"){ //Si la pelota se encuentra en el lugar donde debe de ser entregada
            esferaEnDestino = true;  //Esfera en Destino pasa a ser True
            esferaCapturada = false; //Esfera Capturada para a ser false
        }
    }

    //Función para encontrar la pelota dentro del Área de Trabajo
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="NPC" && !esferaEnDestino && esfera.Equals(GameObject.Find("NPC").GetComponent<NavMeshController>().objetivo)) //Condicional para saber si el NPC se encuentra donde esta la pelota
        {
            esferaCapturada = true; //Esfera Capturada pasa a ser True
        }

        if(other.tag=="DestinoEsferas") // Si esfera esta en su destino
        {
            esferaEnDestino = true; //Esfera en Destino pasa a ser True
            esferaCapturada = false; //Esfera Capturada pasa a ser False
            esfera.GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("EsferaEntregada").GetComponent<BoxCollider>().enabled = false; //El collider del lugar donde se tiene que entregar deja de existir para que la pelota pueda pasar.            
        }
    }
}
