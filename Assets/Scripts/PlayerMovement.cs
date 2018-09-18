using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    private Vector3 input;
    private float maxSpeed = 5f;
    private Vector3 spawn;
    public GameObject deathParticles;
    public TimeManager timeManager;
	// Use this for initialization
	void Start () {
        spawn = transform.position;
	}
	
    // Update is called once per frame
	void Update () {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed) {
            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
        if (transform.position.y < -2)
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            timeManager.DoSlowmotion();
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "Enemy") {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        MyGameManager.CompleteLevel();
    }

    void Die() {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        transform.position = spawn;
    }
}
