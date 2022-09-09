using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;
    public AudioClip audioClip5;
    public AudioClip audioClip6;

    private KeyCode _playSong1= KeyCode.Alpha1;
    private KeyCode _playSong2 = KeyCode.Alpha2;
    private KeyCode _playSong3 = KeyCode.Alpha3;
    private KeyCode _playSong4 = KeyCode.Alpha4;
    private KeyCode _playSong5 = KeyCode.Alpha5;
    private KeyCode _playSong6 = KeyCode.Alpha6;
    private KeyCode _noSong = KeyCode.S;
    //private KeyCode _playSong3 = KeyCode.Alpha3;
    //private KeyCode _playSong4 = KeyCode.Alpha4;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_playSong1))
        {
            audioSource.Stop();
            audioSource.clip = audioClip1;
            audioSource.Play();
        }
        if (Input.GetKey(_playSong2))
        {
            audioSource.Stop();
            audioSource.clip = audioClip2;
            audioSource.Play();
        }
        if (Input.GetKey(_playSong3))
        {
            audioSource.Stop();
            audioSource.clip = audioClip3;
            audioSource.Play();
        }
        if (Input.GetKey(_playSong4))
        {
            audioSource.Stop();
            audioSource.clip = audioClip4;
            audioSource.Play();
        }
        if (Input.GetKey(_playSong5))
        {
            audioSource.Stop();
            audioSource.clip = audioClip5;
            audioSource.Play();
        }
        if (Input.GetKey(_playSong6))
        {
            audioSource.Stop();
            audioSource.clip = audioClip6;
            audioSource.Play();
        }
        if (Input.GetKey(_noSong))
        {
            audioSource.Stop();
        }
    }
}
