using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomDataBase : MonoBehaviour
{
    public Transform pos; //Instancia de un Transform pos

    public GameObject[] objectsToInstantiate; //Instancia de un GameObject[] objectsToInstantiate. Como un Array.

    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < 12; i++){ //Ciclo for para la cantidad de pelotas a generar.
        InstantiateObject(); //Llamado a la Función InstantiateObject().
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateObject(){ //Función para Instanciar Objectos.
        
        float randomX = Random.Range(15, 38); //Generación de valores random en un rango especifico.
        float randomY = Random.Range(0, 22); //Generación de Valores random en un rango especifico.
        int n = Random.Range(0,objectsToInstantiate.Length); //Instancia de un Int n con valor random en un rango de 0 hasta el tamaño de objectsToInstantiate
        Instantiate(objectsToInstantiate[n],new Vector3(randomX, 5, randomY),objectsToInstantiate[n].transform.rotation); //Llamada a Función Predefinida Instantiate con el valor n(la pelota al azar),la posicion random generada y una rotacion señalada.
    }
}
