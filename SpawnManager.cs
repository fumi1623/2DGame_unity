using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy1;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = Instantiate(enemy1) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
