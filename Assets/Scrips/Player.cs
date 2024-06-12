
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _force;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 force = transform.forward * _force;
            _rb.AddForce(force, ForceMode.VelocityChange);
        }
       
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("obstacle"))
        {
            Debug.Log("Player colleded with" + other.gameObject.name);
            Debug.Log("Player colleded with force" + other.impulse);
            Debug.Log("Player colleded with relative veloccity" + other.relativeVelocity);
            Debug.Log("Player colleded with contract points" + other.contacts[0].point);

        }    
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Destroy(other.gameObject, 1f);
    }
}