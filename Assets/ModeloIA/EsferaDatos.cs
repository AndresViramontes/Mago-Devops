using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsferaDatos : MonoBehaviour
{

    public GameObject esfera;

    public NavMeshController aux;
    //public Transform sujetadorMano = GameObject.Find("SujetadorMano").GetComponent<Transform>();

    public GameObject SujetadorManoo;
    //public Transform destinoEsferas;

    public GameObject DestinoEsferaa;

    public bool esferaCapturada;
    public bool esferaEnDestino;

    public Collider other;

    void Start(){
        DestinoEsferaa = GameObject.Find("DestinoEsferas");
        SujetadorManoo = GameObject.Find("SujetadorMano");
    }

    void Update()
    {
        if(esferaCapturada == true)
        {
            //esfera.transform.SetParent(sujetadorMano);
            esfera.transform.position = GameObject.Find("SujetadorMano").transform.position;
            esfera.GetComponent<Rigidbody>().isKinematic = true;
        }
        if(other.tag == "DestinoEsferas"){
            esferaEnDestino = true;
            esferaCapturada = false;
            //esfera.GetComponent<Rigidbody>().isKinematic = false;
            //GameObject.Find("EsferaEntregada").GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="NPC" && !esferaEnDestino && esfera.Equals(GameObject.Find("NPC").GetComponent<NavMeshController>().objetivo))
        {
            esferaCapturada = true;
        }

        if(other.tag=="DestinoEsferas")
        {
            esferaEnDestino = true;
            esferaCapturada = false;
            esfera.GetComponent<Rigidbody>().isKinematic = false;
            GameObject.Find("EsferaEntregada").GetComponent<BoxCollider>().enabled = false;
            //esfera.transform.SetParent(destinoEsferas);
            
        }
    }
}
