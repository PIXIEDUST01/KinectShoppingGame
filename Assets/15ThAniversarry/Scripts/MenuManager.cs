using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public float WaitTimer;
    public bool IsStarted;
    // Start is called before the first frame update
    void Start()
    {
        WaitTimer = 3f;
        IsStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !IsStarted)
        {
           StartCoroutine(PlayMainScene());
        }
    }
    public IEnumerator PlayMainScene()
    {
        yield return new WaitForSeconds(WaitTimer);
        SceneManager.LoadScene(1);
        IsStarted = true;
    }
}
