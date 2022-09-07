using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour {
    [SerializeField] private GameObject dropPrefab;
    [SerializeField] private float maxRainArea;
    [SerializeField] private float dropsPerSecond;
    [SerializeField] private float dropHeight;

    private float time;
    private int dropCount;
    private float dropFrequency;

    void Start() {
        time = 0;
        dropCount = 0;
        dropFrequency = 1 / dropsPerSecond;
    }

    void Update() {
        time += Time.deltaTime;
        if (time >= dropFrequency) {
            var dropAmount = Mathf.RoundToInt(time / dropFrequency);
            for (int i = 0; i < dropAmount; i++) {
                float x = Random.Range(-maxRainArea, maxRainArea);
                float z = Random.Range(-maxRainArea, maxRainArea);
                var drop = Instantiate(dropPrefab, new Vector3(x, dropHeight, z), Quaternion.identity);
                drop.name = string.Format("Drop {0}", dropCount);
                dropCount++;
            }
            time = 0;
        }

    }
}
