using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookToMovementDirection(); // ABSTRACTION
    }

    private void LookToMovementDirection()
    {
        Vector3 lookAt = gameObject.GetComponent<Rigidbody>().velocity;
        if (!lookAt.Equals(new Vector3(0, 0, 0)))
            transform.rotation = Quaternion.LookRotation(lookAt);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }


    }
}
