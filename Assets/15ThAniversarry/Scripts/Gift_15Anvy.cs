using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift_15Anvy : MonoBehaviour
{
    public static Gift_15Anvy instance;
    public float TouchTime;
    public bool IsCollected;
    public bool IsTouched;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        IsCollected = false;
        IsTouched = false;
        TouchTime = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsTouched)
        //{
        //    CountTouchTime();
        //}
    }
    public void CountTouchTime()
    {
        TouchTime = -Time.deltaTime;
        if (TouchTime <= 0)
        {
            IsCollected = true;
            Debug.Log("Collected Gift Box");
        }
    }
    public IEnumerator CountTime()
    {
        yield return new WaitForSeconds(TouchTime);
        IsCollected = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !IsCollected)
        {
            StartCoroutine(CountTime());
            Debug.Log("Touched The Gift Box");
        }
    }
}
