using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{

    Color originalColor;

    void Awake() {
        originalColor = GetComponent<MeshRenderer>().material.color;
    }

    private void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag == "Player") {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
        }
        
    }

    private void OnCollisionExit(Collision other) {
        GetComponent<MeshRenderer>().material.color = originalColor;
    }

}
