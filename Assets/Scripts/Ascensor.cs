using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ascensor : MonoBehaviour
{

    public Animator anim;   //Tomar Animator de Unity
    bool m_Subir;           //Bandera para valor inicial.

    // Start es llamado antes de que el primer frame se actualice.
    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();   //Obtener componente Animator y almacenar el estado de parenting 
        m_Subir = false;                                    //Valor inicial de la bandera
    }

    // Update es llamado una vez por frame.
    void Update()
    {
        
    }

    private void OnMouseDown(){

        Debug.Log("OnMouseDown: "+ this.name);  //Validar el click del boton del raton
        if(this.name == "Boton1")               //Condicional para asegurar que el click fue presionado en el area del Boton1
        {
            if(m_Subir == false)                
            {
                anim.SetBool("Subir", true);    //Si la bandera inicial es falsa, el Animator será activado.
                m_Subir = true;                 //La bandera pasará al estado "true"
            }
            else
            {
                anim.SetBool("Subir", false);   //Si la bandera inicial es verdadera, el Animator será desactivado.
                m_Subir = false;                //La bandera pasará al estado "false"
            }
        }
    }
}
