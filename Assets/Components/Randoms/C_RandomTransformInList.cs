using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class C_RandomTransformInList : MonoBehaviour
{

    public List<Transform> points = new List<Transform>();
    private Vector3 currentPosition;
    private Quaternion currentRotation;
    public UnityEvent<Vector3> OnChangePosition;
    public UnityEvent<Quaternion> OnChangeRotation;

    public void ChoseRandom()
    {
        if(points != null && points.Count > 0)
        {
            points.Shuffle();
            currentPosition = points[0].position;
            currentRotation = points[0].rotation;
            OnChangePosition?.Invoke(currentPosition);
            OnChangeRotation?.Invoke(currentRotation);
        }
    }

/*    private void OnDrawGizmosSelected()
    {
        if(points== null || points.Count == 0) return;
        Gizmos.color = Color.cyan;
        foreach (var item in points)
        {
            Gizmos.DrawWireCube(item.position, item.localScale);
        }
    }*/
}
