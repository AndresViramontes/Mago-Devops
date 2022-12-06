using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomDataBase : MonoBehaviour
{
    public Transform pos; 

    public GameObject[] objectsToInstantiate;

    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < 12; i++){
        InstantiateObject();
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InstantiateObject(){
        
        float randomX = Random.Range(15, 38);
        float randomY = Random.Range(0, 22);
        int n = Random.Range(0,objectsToInstantiate.Length);
        Instantiate(objectsToInstantiate[n],new Vector3(randomX, 5, randomY),objectsToInstantiate[n].transform.rotation);
    }
}
