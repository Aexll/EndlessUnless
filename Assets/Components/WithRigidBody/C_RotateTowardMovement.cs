using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class C_RotateTowardMovement : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float RotationalSpeed = 10;
    [SerializeField] private float offsetRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(transform.position + new Vector3(rb.velocity.x*10,0,rb.velocity.y*10),Vector3.up);
        // On récupère la direction du mouvement du Rigidbody2D
        Vector2 directionMouvement = rb.velocity.normalized;

        // On calcule l'angle entre la direction du mouvement et l'axe horizontal
        float angle = Mathf.Atan2(directionMouvement.y, directionMouvement.x) * Mathf.Rad2Deg + offsetRotation; ;

        // On crée une rotation à partir de cet angle
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // On applique la rotation avec une interpolation lissée
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationalSpeed * Time.deltaTime);
    }
}
