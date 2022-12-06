using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scenes
{
    public class NavMeshController : MonoBehaviour
    {
        public Transform EsferaEntregada;
        public Transform objetivo;
        public EsferaDatos esfera;

        void Update()
        {
            NavMeshAgent NPC = GetComponent<NavMeshAgent>();
            esfera = GameObject.Find("GameObject").GetComponent<EsferaDatos>();

            if (esfera.esferaEnDestino == false)
            {
                if (esfera.esferaCapturada == false)
                {
                    NPC.destination = objetivo.position;
                }

                if (esfera.esferaCapturada == true)
                {
                    objetivo = GameObject.Find("EsferaEntregada").GetComponent<Transform>();
                    NPC.destination = objetivo.position;

                }
            }

            if (esfera.esferaEnDestino == true)
            {
                //NPC.GetComponent<NavMeshAgent>().enabled = false;
                NPC.destination = GameObject.Find("ZonaInicioNPC").GetComponent<Transform>().position;
            }
        }
    }
}