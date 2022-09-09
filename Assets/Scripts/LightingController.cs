using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingController : MonoBehaviour
{
    [SerializeField] float lightingTrigger = 2.5f;
    public GameObject lighting1;
    public GameObject lighting2;
    public GameObject lighting3;

    public GameObject audioSource;
    public AudioSource music;
    private float time;

    void Start()
    {
        EndLighting();
        EndThunder();
        time = 0;
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
    }

    void StartThunder()
    {
        audioSource.SetActive(true);
        Invoke("EndThunder", 2.0f);
    }

    void EndThunder()
    {
        audioSource.SetActive(false);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.2f) {
            var spectrum = new float[64];
            var songIntensity = 0f;
            music.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
            for (int i = 0; i < 64; i++)
            {
                songIntensity += 10 * Mathf.Pow(Mathf.Abs(spectrum[i]), 0.2f);
            }
            songIntensity = songIntensity / 64f;
            if (songIntensity > lightingTrigger)
            {
                StartLighting();
            }
            if (music.isPlaying)
            {
                songIntensity = 0.0f;
            }
            time = 0;
        }
    }
}
