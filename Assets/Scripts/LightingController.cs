using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    public GameObject lighting1;
    public GameObject lighting2;
    public GameObject lighting3;

    public GameObject audio;
    public AudioSource music;

    void Start()
    {
        EndLighting();
        EndThunder(); 
    }

    void StartLighting()
    {
        int r = Random.Range(0, 3);
        switch (r)
        {
            case 0:
                lighting1.SetActive(true);
                Invoke("EndLighting", .75f);    // in 75 ms it will call EndLighting 
                Invoke("StartThunder", .100f);  // in 200 ms it will call StartThunder   
                break;
            case 1:
                lighting2.SetActive(true);   
                Invoke("EndLighting", .100f);  
                Invoke("StartThunder", .200f);
                break;  
            case 2:
                lighting3.SetActive(true);   
                Invoke("EndLighting", .125f);  
                Invoke("StartThunder", .400f);  
                break;
            default:
                Debug.LogError("StartLighting error");
                break;
        }
    }

    void EndLighting()
    {
        lighting1.SetActive(false);   
        lighting2.SetActive(false);   
        lighting3.SetActive(false);

        float rand = Random.Range(30f, 60f);
        Invoke("StartLighting", rand);
    }

    void StartThunder()
    {
        audioSource.SetActive(true);
        Invoke("EndThunder", 3.5f);
    }

    void EndThunder()
    {
        audioSource.SetActive(false);
    }

    void Update()
    {
        var spectrum = new float[64];
        var songIntensity = 0f;
        music.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
        for (int i = 0; i < 64; i++)
        {
            songIntensity += 10 * Mathf.Pow(Mathf.Abs(spectrum[i]), 0.2f);
        }
        if (songIntensity > 160.0)
        {
            StartLighting();
        }
        if (music.isPlaying)
        {
            songIntensity = 0.0f;
        }
    }
}
