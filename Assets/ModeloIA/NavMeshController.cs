using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Threading;

public class NavMeshController : MonoBehaviour
{
    public GameObject EsferaEntregada;  // Variable que permite seleccionar el nuevo destino de la esfera 
    public GameObject objetivo;         // Objeto que representa la zona destino a donde debe llevarse la esfera 
    public EsferaDatos esfera;          // Objeto que representa la esfera
    public Vector3 aux;                 // Variable auxiliar para obtener coordenadas
    NavMeshAgent NPC;                   // NPC como agente de la ruta de navegación

    void Start(){
        objetivo = GameObject.Find("GameObject: Spawn");    // Se inicializa el objetivo del NPC
        aux = NPC.GetComponent<NavMeshAgent>().velocity;    // Se obtiene la velocidad de movimiento del NPC
    }



    void Update()
    {
            if(esfera.esferaCapturada){ //Condicional para verificar que la esfera este capturada
                objetivo = GameObject.Find("EsferaEntregada"); 
                //Encontrar el Objeto "Esfera Entregada" en el Área de Trabajo
                NPC.destination = GameObject.Find("EsferaEntregada").transform.position; 
                //Modificar destino de NPC a la posición del objeto "Esfera Entregada"
            }
            if(esfera.esferaEnDestino){ //Condicional para verificar que la esfera este en destino
                NPC.destination = GameObject.Find("GameObject: Spawn").transform.position; 
                //Modificar destino de NPC a la posicion inicial
                objetivo = GameObject.Find("GameObject: Spawn"); 
                //Encontrar el Objeto "Spawn" en el Área de Trabajo
            }
    }

    // Se busca la esfera en la Base de Datos  
    public void BDSearch(){
        NPC = GetComponent<NavMeshAgent>();     // Se hace referencia al objeto que representa el NPC
        int i = UnityEngine.Random.Range(1,4);  // Generación de número aleatorio 

        // Selección aleatoria del nivel de error para la esfera que el NPC va a capturar
        switch(i){

            // Se asigna como objetivo, una esfera sin error de base de datos
            case 1:
                objetivo = GameObject.Find("BD sin Error(Clone)");  
                esfera = GameObject.Find("BD sin Error(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("BD sin Error(Clone)").transform.position;
                    }
                }
                
                break;

            // Se asigna como objetivo, una esfera con error minimo de base de datos
            case 2:
                objetivo = GameObject.Find("BD con error minimo(Clone)");
                esfera = GameObject.Find("BD con error minimo(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("BD con error minimo(Clone)").transform.position;
                    }
                }
                break;

            // Se asigna como objetivo, una esfera con error medio de base de datos
            case 3:
                objetivo = GameObject.Find("BD con error medio(Clone)");
                esfera = GameObject.Find("BD con error medio(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("BD con error medio(Clone)").transform.position;
                    }
                }
                break;

            // Se asigna como objetivo, una esfera con error extremo de base de datos
            case 4:
                objetivo = GameObject.Find("BD con error extremo(Clone)");
                esfera = GameObject.Find("BD con error extremo(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("BD con error extremo(Clone)").transform.position;
                    }
                }
                break;
            }
    }

   // Se busca la esfera que representa un error de Lenguaje
    public void LengaugeSearch(){
        NPC = GetComponent<NavMeshAgent>();     // Se hace referencia al objeto que representa el NPC
        int i = UnityEngine.Random.Range(1,4);  // Generación de número aleatorio 

        // Selección aleatoria del nivel de error para la esfera que el NPC va a capturar
        switch(i){

            // Se asigna como objetivo, una esfera sin error de Lenguaje
            case 1:
                objetivo = GameObject.Find("Lenguaje sin Error(Clone)");
                esfera = GameObject.Find("Lenguaje sin Error(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Lenguaje sin Error(Clone)").transform.position;
                    }
                }
                break;

            // Se asigna como objetivo, una esfera con error mínimo de Lenguaje
            case 2:
                objetivo = GameObject.Find("Lenguaje con error minimo(Clone)");
                esfera = GameObject.Find("Lenguaje con error minimo(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Lenguaje con error minimo(Clone)").transform.position;
                    }
                }
                break;

            // Se asigna como objetivo, una esfera con error medio de Lenguaje
            case 3:
                objetivo = GameObject.Find("Lenguaje con error medio(Clone)");
                esfera = GameObject.Find("Lenguaje con error medio(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Lenguaje con error medio(Clone)").transform.position;
                    }
                }
                break;

            // Se asigna como objetivo, una esfera con error extremo de Lenguaje
            case 4:
                objetivo = GameObject.Find("Lenguaje con error extremo(Clone)");
                esfera = GameObject.Find("Lenguaje con error extremo(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Lenguaje con error extremo(Clone)").transform.position;
                    }
                }
                break;
        }
    }

   // Se busca la esfera que representa un error de Plataforma
    public void PlatformSearch(){
        NPC = GetComponent<NavMeshAgent>();     // Se hace referencia al objeto que representa el NPC
        int i = UnityEngine.Random.Range(1,4);  // Generación de número aleatorio 

        // Selección aleatoria del nivel de error para la esfera que el NPC va a capturar
        switch(i){

            // Se asigna como objetivo, una esfera sin error de Plataforma
            case 1:
                objetivo = GameObject.Find("Plataforma sin Error(Clone)");
                esfera = GameObject.Find("Plataforma sin Error(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Plataforma sin Error(Clone)").transform.position;
                    }
                }
                break;

            // Se asigna como objetivo, una esfera sin error de Plataforma
            case 2:
                objetivo = GameObject.Find("Plataforma con error minimo(Clone)");
                esfera = GameObject.Find("Plataforma con error minimo(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Plataforma con error minimo(Clone)").transform.position;
                    }
                }
                break;

            // Se asigna como objetivo, una esfera sin error de Plataforma
            case 3:
                objetivo = GameObject.Find("Plataforma con error medio(Clone)");
                esfera = GameObject.Find("Plataforma con error medio(Clone)").GetComponent<EsferaDatos>();
 
                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                        if(!esfera.esferaCapturada){
                            NPC.destination = GameObject.Find("Plataforma con error medio(Clone)").transform.position;
                        }
                }
                break;
 
             // Se asigna como objetivo, una esfera sin error de Plataforma
           case 4:
                objetivo = GameObject.Find("Plataforma con error extremo(Clone)");
                esfera = GameObject.Find("Plataforma con error extremo(Clone)").GetComponent<EsferaDatos>();

                // Se comprueba si la esfera ha sido capturada o se encuentra en el destino
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Plataforma con error extremo(Clone)").transform.position;
                    }
                }
                break;
        }
    }

}