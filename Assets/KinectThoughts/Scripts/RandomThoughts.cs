using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomThoughts : MonoBehaviour
{
    public GameObject[] thoughts;
    // Start is called before the first frame update
    void Start()
    {
        thoughts[Random.Range(0, thoughts.Length)].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
