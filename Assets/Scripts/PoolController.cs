using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour {
    [SerializeField] private float lifetime = 0.5f;

    // Update is called once per frame
    void Update() {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) {
            Destroy(this.gameObject);
        }
    }
}
