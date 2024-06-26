
using Cinemachine;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshRenderer))]

public class Player : NetworkBehaviour
{
    [SerializeField] private float _force;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer) return; 
        _rb = GetComponent<Rigidbody>();
        var cinemachine = FindFirstObjectByType<CinemachineVirtualCamera>();
        cinemachine.Follow = transform;
        cinemachine.LookAt = transform;


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
            Return(other.gameObject);
        }    
    }
    private void Return(GameObject obj)
    {
        ObjectPool.Instance.ReturnOne(obj);
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        Destroy(other.gameObject, 1f);
    }
}