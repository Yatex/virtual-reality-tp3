using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour {
    [SerializeField] private float lowerLimit = 1.1f;
    private float lifetime = 5f;
    
    void Update() {
        lifetime -= Time.deltaTime;
        if (transform.position.y <= lowerLimit || lifetime == 0) {
            Destroy(this.gameObject);
        }
    }
}
