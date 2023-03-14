using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_LinearMovement : MonoBehaviour
{

    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

}
