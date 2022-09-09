using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour {
    [SerializeField] private GameObject dropPrefab;
    [SerializeField] private float maxRainArea;
    [SerializeField] private float dropsPerSecond;
    [SerializeField] private float dropHeight;
    [SerializeField] private float dropVelocity;
    [SerializeField] private AudioSource audioSource;

    private float dropTime;
    private float songTime;
    private int dropCount;
    private float dropFrequency;

    void Start() {
        dropTime = 0;
        songTime = 0;
        dropCount = 0;
        dropFrequency = 1 / dropsPerSecond;
    }

    void Update() {
        dropTime += Time.deltaTime;
        songTime += Time.deltaTime;

        if (songTime >= 1) {
            var spectrum = new float[64];
            var songIntensity = 0f; 
            audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
            for (int i = 0; i < 64; i++) {
                songIntensity += 10 * Mathf.Pow(Mathf.Abs(spectrum[i]), 0.2f);
            }
            songIntensity = songIntensity / 64;
            var newDropsPerSecond = dropsPerSecond + FrequencyFunc(songIntensity);
            dropFrequency = 1 / newDropsPerSecond;
            dropVelocity = velocityFunc(songIntensity);
            Debug.Log(string.Format("Intensity: {0} | Frequency {1} | Velocity: {2}", songIntensity, newDropsPerSecond, dropVelocity));
            songTime = 0;
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
        return (250.5f*x) - 275.7f;
    }

    private float velocityFunc(float x) {
        return 35.03f*x - 42.03f;
    }
}
