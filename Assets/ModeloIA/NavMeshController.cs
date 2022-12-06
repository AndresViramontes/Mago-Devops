using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Threading;

public class NavMeshController : MonoBehaviour
{
    public GameObject EsferaEntregada;
    public GameObject objetivo;
    public EsferaDatos esfera;
    NavMeshAgent NPC;

    public Vector3 aux;

    void Start(){
        objetivo = GameObject.Find("GameObject: Spawn");
        aux = NPC.GetComponent<NavMeshAgent>().velocity;
    }



    void Update()
    {
            if(esfera.esferaCapturada){
                objetivo = GameObject.Find("EsferaEntregada");
                NPC.destination = GameObject.Find("EsferaEntregada").transform.position;
            }
            if(esfera.esferaEnDestino){
                NPC.destination = GameObject.Find("GameObject: Spawn").transform.position;
                objetivo = GameObject.Find("GameObject: Spawn");
            }
    }

    public void BDSearch(){
        NPC = GetComponent<NavMeshAgent>();
        int i = UnityEngine.Random.Range(1,4);

        switch(i){
            case 1:
                objetivo = GameObject.Find("BD sin Error(Clone)");
                esfera = GameObject.Find("BD sin Error(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("BD sin Error(Clone)").transform.position;
                    }
                }
                
                break;
            case 2:
                objetivo = GameObject.Find("BD con error minimo(Clone)");
                esfera = GameObject.Find("BD con error minimo(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("BD con error minimo(Clone)").transform.position;
                    }
                }
                break;
            case 3:
                objetivo = GameObject.Find("BD con error medio(Clone)");
                esfera = GameObject.Find("BD con error medio(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("BD con error medio(Clone)").transform.position;
                    }
                }
                break;
            case 4:
                objetivo = GameObject.Find("BD con error extremo(Clone)");
                esfera = GameObject.Find("BD con error extremo(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("BD con error extremo(Clone)").transform.position;
                    }
                }
                break;
            }
    }

    public void LengaugeSearch(){
        NPC = GetComponent<NavMeshAgent>();
        int i = UnityEngine.Random.Range(1,4);

        switch(i){
            case 1:
                objetivo = GameObject.Find("Lenguaje sin Error(Clone)");
                esfera = GameObject.Find("Lenguaje sin Error(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Lenguaje sin Error(Clone)").transform.position;
                    }
                }
                break;
            case 2:
                objetivo = GameObject.Find("Lenguaje con error minimo(Clone)");
                esfera = GameObject.Find("Lenguaje con error minimo(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Lenguaje con error minimo(Clone)").transform.position;
                    }
                }
                break;
            case 3:
                objetivo = GameObject.Find("Lenguaje con error medio(Clone)");
                esfera = GameObject.Find("Lenguaje con error medio(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Lenguaje con error medio(Clone)").transform.position;
                    }
                }
                break;
            case 4:
                objetivo = GameObject.Find("Lenguaje con error extremo(Clone)");
                esfera = GameObject.Find("Lenguaje con error extremo(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Lenguaje con error extremo(Clone)").transform.position;
                    }
                }
                break;
        }
    }

    public void PlatformSearch(){
        NPC = GetComponent<NavMeshAgent>();
        int i = UnityEngine.Random.Range(1,4);

        switch(i){
            case 1:
                objetivo = GameObject.Find("Plataforma sin Error(Clone)");
                esfera = GameObject.Find("Plataforma sin Error(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Plataforma sin Error(Clone)").transform.position;
                    }
                }
                break;
            case 2:
                objetivo = GameObject.Find("Plataforma con error minimo(Clone)");
                esfera = GameObject.Find("Plataforma con error minimo(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Plataforma con error minimo(Clone)").transform.position;
                    }
                }
                break;
            case 3:
                objetivo = GameObject.Find("Plataforma con error medio(Clone)");
                esfera = GameObject.Find("Plataforma con error medio(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Plataforma con error medio(Clone)").transform.position;
                    }
                }
                break;
            case 4:
                objetivo = GameObject.Find("Plataforma con error extremo(Clone)");
                esfera = GameObject.Find("Plataforma con error extremo(Clone)").GetComponent<EsferaDatos>();
                if(!esfera.esferaEnDestino){
                    if(!esfera.esferaCapturada){
                        NPC.destination = GameObject.Find("Plataforma con error extremo(Clone)").transform.position;
                    }
                }
                break;
        }
    }

}
