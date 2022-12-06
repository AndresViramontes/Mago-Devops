using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes
{
    public class EsferaDatos : MonoBehaviour
    {

        public GameObject esfera;
        public Transform sujetadorMano;
        public Transform destinoEsferas;

        public bool esferaCapturada;
        public bool esferaEnDestino;

        void Update()
        {
            if (esferaCapturada == true)
            {
                esfera.transform.SetParent(sujetadorMano);
                esfera.transform.position = sujetadorMano.position;
                esfera.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "NPC" && esferaEnDestino != true)
            {
                esferaCapturada = true;
            }

            if (other.tag == "DestinoEsferas")
            {
                esferaEnDestino = true;
                esferaCapturada = false;
                esfera.GetComponent<Rigidbody>().isKinematic = false;
                GameObject.Find("EsferaEntregada").GetComponent<BoxCollider>().enabled = false;
                esfera.transform.SetParent(destinoEsferas);

            }
        }
    }
}