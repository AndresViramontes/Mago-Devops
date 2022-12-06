using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonBD : MonoBehaviour
{


    public NavMeshController NP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown(){
        Debug.Log("OnMouseDown: "+ this.name);
        NP = FindObjectOfType<NavMeshController>();
        if(this.name == "Boton BD"){
            NP.BDSearch();
        }
        else{
            if(this.name == "Boton Lenguaje"){
                NP.LengaugeSearch();
            }
            else{
                if(this.name == "Boton Plataforma"){
                    NP.PlatformSearch();
                }
            }
        }
    }
}
