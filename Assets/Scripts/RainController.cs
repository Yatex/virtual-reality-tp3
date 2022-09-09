using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour {
    [SerializeField] private GameObject dropPrefab;
    [SerializeField] private float maxRainArea;
    [SerializeField] private float dropHeight;
    [SerializeField] private float dropVelocity;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource rainAudioSource;

    private float dropTime;
    private float songTime;
    private int dropCount;
    private float dropFrequency;

    void Start() {
        dropTime = 0;
        songTime = 0;
        dropCount = 0;
        dropFrequency = float.MaxValue;
    }

    void Update() {
        dropTime += Time.deltaTime;
        songTime += Time.deltaTime;

        if (!musicAudioSource.isPlaying) {
            dropFrequency = float.MaxValue;
            rainAudioSource.Stop();
        }

        if (songTime >= 1f && musicAudioSource.isPlaying) {
            var spectrum = new float[64];
            var songIntensity = 0f; 
            musicAudioSource.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
            for (int i = 0; i < 64; i++) {
                songIntensity += 10 * Mathf.Pow(Mathf.Abs(spectrum[i]), 0.2f);
            }
            songIntensity = songIntensity / 64;
            var dropsPerSecond = FrequencyFunc(songIntensity);
            var rainVolume = volumeFunc(songIntensity);
            if (dropsPerSecond > 0) {
                dropFrequency = 1 / dropsPerSecond;
                dropVelocity = velocityFunc(songIntensity);
                if (!rainAudioSource.isPlaying) rainAudioSource.Play();
                rainAudioSource.volume = rainVolume;
            } else {
                dropFrequency = float.MaxValue;
                rainAudioSource.Pause();
            }
            Debug.Log(string.Format("SongIntensity: {0} | DropsPerSec {1} | DropsSpeed: {2} | Rain Volume {3}", songIntensity, dropsPerSecond, dropVelocity, rainVolume));
            songTime = 0;
            dropTime = 0;
        }

        if (dropTime >= dropFrequency) {
            var dropAmount = Mathf.RoundToInt(dropTime / dropFrequency);
            for (int i = 0; i < dropAmount; i++) {
                float x = Random.Range(-maxRainArea, maxRainArea);
                float z = Random.Range(-maxRainArea, maxRainArea);
                var drop = Instantiate(dropPrefab, new Vector3(x, dropHeight, z), Quaternion.identity);
                drop.name = string.Format("Drop {0}", dropCount);
                var dropRigidBody = drop.GetComponent<Rigidbody>();
                dropRigidBody.velocity = new Vector3(0, -dropVelocity, 0);
                dropCount++;
            }
            dropTime = 0;
        }
    }

    private float FrequencyFunc(float x) {
        var y = (650f*x) - 600;
        if (y < 0) y = 0;
        return y;
    }

    private float velocityFunc(float x) {
        var y = 36f*x - 50f;
        if (y < 0) y = 0;
        if (y > 70) y = 70;
        return y;
    }

    private float volumeFunc(float x) {
        var y = x / 4.5f;
        if (y > 1) y = 1; 
        if (y < 0) y = 0;
        return y;
    }
}
