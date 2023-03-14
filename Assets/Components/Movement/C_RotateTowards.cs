using UnityEngine;

public class C_RotateTowards : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5.0f;
    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (target) target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 targetDirection = target.position - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            if (spriteRenderer != null)
            {
                spriteRenderer.flipY = (target.position.x < transform.position.x);
            }
        }
    }
}

 