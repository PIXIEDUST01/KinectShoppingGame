using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager_15Anvy : MonoBehaviour
{
    public int countdowntime;
    public float time;
    public float MinDelay;
    public float MaxDelay;
    public Text TimerText;
    public Text CountDownText;
   // public ParticleSystem Flowers;
    public GameObject GameScreen;
    public GameObject CongratsScreen;
    public GameObject LostScreen;
    public GameObject GiftBox;
    public Gift_15Anvy G15A;
    public Transform[] SpawnPoints;
    public GameObject[] RandomGifts;
    public bool IsGameStarted;
    public bool IsGameFinished;
    public int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        IsGameStarted = false;
        IsGameFinished = false;
        time = 30f;
        MinDelay = 15f;
        MaxDelay = 22f;
        TimerText.text = "Timer : " + time.ToString();
        GameScreen.SetActive(false);
        CongratsScreen.SetActive(false);
        LostScreen.SetActive(false);
        randomIndex = Random.Range(0, RandomGifts.Length);
        for(int i = 0; i < RandomGifts.Length; i++)
        {
            RandomGifts[i].SetActive(false);
        }
        
        StartCoroutine(CountDownTImer());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameStarted)
        {
            Timer();
        }
        if (RandomGifts[randomIndex].GetComponent<Gift_15Anvy>().IsCollected && time >= 0)
        {
            WonGift();
            Debug.Log("Won Gift");
        }
        if (RandomGifts[randomIndex].GetComponent<Gift_15Anvy>().IsCollected == false && time <= 0)
        {
            time = 0;
            LostGift();
            TimerText.text = "Timer : " + " " + (Mathf.Floor(time % 60f).ToString("00"));
            Debug.Log("TImeUp");

        }
        if (IsGameFinished)
        {
            StartCoroutine(ReloadStartScene());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Timer()
    {
        time -= Time.deltaTime;
        TimerText.text = "Timer : " + " " + (Mathf.Floor(time % 60f).ToString("00"));
        //if (time <= 0)
        //{
        //    time = 0;
        //   // LostGift();
        //    TimerText.text = "Timer : " + " " + (Mathf.Floor(time % 60f).ToString("00"));
        //    Debug.Log("TImeUp");

        //}
    }
    public IEnumerator CountDownTImer()
    {
        while (countdowntime > 0)
        {
            CountDownText.text = countdowntime.ToString();
            yield return new WaitForSeconds(1f);
            countdowntime--;
        }
        CountDownText.text = "Go!";
        yield return new WaitForSeconds(0.5f);
        CountDownText.gameObject.SetActive(false);
        StartGame();
        StartCoroutine(SpawnGift());
        
    }
    public IEnumerator SpawnGift()
    {
        float delay = Random.Range(MinDelay, MaxDelay);
        yield return new WaitForSeconds(delay);
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        Transform spawnPoint = SpawnPoints[spawnIndex];

        // GameObject SpawnedGifts = Instantiate(GiftBox, spawnPoint.position, GiftBox.transform.rotation);
        // Destroy(SpawnedGifts, 15f);
        // yield return new WaitForSeconds(3f);
        RandomGifts[randomIndex].SetActive(true);
        
    }
    public IEnumerator ReloadStartScene()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        GameScreen.SetActive(true);
       // Flowers.Play();
        TimerText.gameObject.SetActive(true);
        IsGameStarted = true;
    }
    public void WonGift()
    {
        GameScreen.SetActive(false);
       // Flowers.Stop();
        CongratsScreen.SetActive(true);
        TimerText.gameObject.SetActive(false);
        // IsGameStarted = true;
        IsGameFinished = true;
    }
    public void LostGift()
    {
        GameScreen.SetActive(false);
       // Flowers.Stop();
        LostScreen.SetActive(true);
        TimerText.gameObject.SetActive(false);
        IsGameFinished = true;
    }
}
