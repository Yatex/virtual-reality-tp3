using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour {
    void Update() {
        if (transform.position.y <= 1.1) {
            Destroy(this.gameObject);
        }
    }
}
