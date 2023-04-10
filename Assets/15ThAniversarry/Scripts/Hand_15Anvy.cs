using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_15Anvy : MonoBehaviour
{
    public float Touchtime;
    public bool Istouched;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Istouched)
        {
            TouchTimer();
        }
    }
    public void TouchTimer()
    {
        Touchtime = -Time.deltaTime;
        if (Touchtime <= 0)
        {
            Touchtime = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Gift") && !Istouched)
        {
            Istouched = true;
        }
    }
}
