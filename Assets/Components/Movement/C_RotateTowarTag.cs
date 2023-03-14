using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_RotateTowarTag : MonoBehaviour
{
    public string targetTag;
    private Transform target;
    private Transform Target
    {
        get {
            if (target == null)
            {
                var go = GameObject.FindGameObjectWithTag(targetTag);
                if(go != null)
                {
                    target = go.transform;
                }
            }
            return target;
        }
    }

    public float rotationSpeed = 5.0f;
    public SpriteRenderer spriteRenderer;
    public bool flipY = true;
    //public bool flipSprite;

    void Update()
    {
        if (Target != null)
        {
            Vector3 targetDirection = Target.position - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            if (spriteRenderer != null)
            {
                if(flipY)
                spriteRenderer.flipY = (Target.position.x < transform.position.x);
                else
                spriteRenderer.flipX = (Target.position.x < transform.position.x);
            }
        }
    }

}
