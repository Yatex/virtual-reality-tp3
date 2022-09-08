using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropController : MonoBehaviour {
    [SerializeField] private float lowerLimit = 1.1f;
    [SerializeField] private List<int> ignoreLayers;
    [SerializeField] private List<int> poolLayers;
    [SerializeField] private GameObject poolPrefab;
    private float lifetime = 5f;
    
    void Update() {
        lifetime -= Time.deltaTime;
        if (transform.position.y <= lowerLimit || lifetime == 0) {
            if (transform.position.y <= lowerLimit) {
                var pos = new Vector3(transform.position.x, 0, transform.position.z);
                var pool = Instantiate(poolPrefab, pos, Quaternion.identity);
                pool.name = string.Format("Pool {0}", this.name);
            }
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider collider) {
        if (!ignoreLayers.Contains(collider.gameObject.layer)) {
            Destroy(this.gameObject);
        }
    }
}
