using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject[] arrowPrefabs;
    [SerializeField] private Vector3 arrowOffset;
    [SerializeField] private float arrowForcePower;
    [SerializeField] private float mouseDistanceToCamera;

    private GameObject arrow;
    private Rigidbody arrowRb;
    private Vector3 arrowForceDirection;
    private Vector3 mousePosition;
    private int arrowType;
    // Start is called before the first frame update
    void Start()
    {
        arrowType = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) arrowType =  arrowType == 0 ? 1 : 0;
        if (Input.GetMouseButtonDown(0))
        {
            arrow = Instantiate(arrowPrefabs[arrowType], transform.position + arrowOffset, arrowPrefabs[arrowType].transform.rotation);
            arrowRb = arrow.GetComponent<Rigidbody>();
        }

        if(arrow != null)
        {
            CalculateArrowDirection();// ABSTRACTION
        }

        if (Input.GetMouseButtonUp(0))
        {
            Shoot();// ABSTRACTION
        }
    }

    // ABSTRACTION
    private void CalculateArrowDirection()
    {
        mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, mouseDistanceToCamera);
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        arrowForceDirection = mousePosition - arrow.transform.position;
        arrow.transform.rotation = Quaternion.LookRotation(arrowForceDirection);
    }

    // ABSTRACTION
    private void Shoot()
    {
        arrowRb.useGravity = true;
        arrowRb.AddForce(arrowForceDirection.normalized * arrowForcePower, ForceMode.Impulse);
        arrow = null;
    }
}
