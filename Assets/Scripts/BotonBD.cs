using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonBD : MonoBehaviour
{


    public NavMeshController NP; //Creacion de NavMeshController NP
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown(){ //Función para cuando se presionan los respectivos botones del NPC.
        Debug.Log("OnMouseDown: "+ this.name); //Menciona en consola cual boton se presiono.
        NP = FindObjectOfType<NavMeshController>(); //NP encontrara dentro del Área de Trabajo, NavMeshController
        if(this.name == "Boton BD"){ //Condicional para cuando se presiono el botón de Base de Datos
            NP.BDSearch(); //Ejecutar Función BDSearch().
        }
        else{
            if(this.name == "Boton Lenguaje"){ //Condicional para cuando se presiona el botón de Lenguaje
                NP.LengaugeSearch(); //Ejecutar Función LenguageSearch().
            }
            else{
                if(this.name == "Boton Plataforma"){ //Condicional para cuando se presiona el botón de Plataforma
                    NP.PlatformSearch(); //Ejectuar Función PlatformSearch().
                }
            }
        }
    }
}
