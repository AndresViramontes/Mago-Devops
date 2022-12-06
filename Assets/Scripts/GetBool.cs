using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBool : MonoBehaviour
{

    public Animator m_Animator;
    bool m_Subir;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = transform.parent.GetComponent<Animator>();
        m_Subir = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("e") && m_Subir == false){
            m_Animator.SetBool("Subir", true);
            m_Subir = true;
        }
        else
        {
            m_Animator.SetBool("Subir", false);
            m_Subir = false;
        }
    }
}
