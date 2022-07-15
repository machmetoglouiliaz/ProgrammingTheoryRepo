using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Vector3 arrowOffset;
    [SerializeField] private float arrowForcePower;
    [SerializeField] private float mouseDistanceToCamera;

    private GameObject arrow;
    private Rigidbody arrowRb;
    private Vector3 arrowForceDirection;
    private Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            arrow = Instantiate(arrowPrefab, transform.position + arrowOffset, arrowPrefab.transform.rotation);
            arrowRb = arrow.GetComponent<Rigidbody>();
        }

        if(arrow != null)
        {
            mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = mouseDistanceToCamera;
            arrowForceDirection =  mousePosition - arrow.transform.position;
        }

        if (Input.GetMouseButtonUp(0))
        {
            arrowRb.useGravity = true;
            Debug.Log(arrowForceDirection + " : " + Input.mousePosition + " " + mousePosition + " : " + arrow.transform.position);
            arrowRb.AddForce(arrowForceDirection.normalized * arrowForcePower, ForceMode.Impulse);
            arrow = null;
        }
    }
}
