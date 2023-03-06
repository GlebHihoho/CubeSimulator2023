using System;
using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private float _rollSpeed = 5f;
    private Vector3 _pivotPoint;
    private Vector3 _axis;
    private bool _isMoving;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Vector3.zero;
        // Vector3.one;
        // Vector3.right;
        // Vector3.forward;
        // Vector3.up;
        
        if (_isMoving) return;

        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }
    }

    private void Move(Vector3 direction)
    {
        var verticalComponent = Vector3.down;
        var hasWall = HasWallInDirection(direction);
        if (hasWall)
        {
            verticalComponent = Vector3.up;
        }
        
        _pivotPoint = (direction / 2f) + (verticalComponent / 2f) + transform.position;
        _axis = Vector3.Cross(Vector3.up, direction);

        StartCoroutine(Roll(_pivotPoint, _axis));
    }

    private bool HasWallInDirection(Vector3 direction)
    {
        return Physics.Raycast(transform.position, direction, 0.55f);
    }
    
    

    private IEnumerator Roll(Vector3 pivot, Vector3 axis)
    {
        _isMoving = true;
        _rigidbody.isKinematic = true;

        for (int i = 0; i < 90 / _rollSpeed; i++)
        {
            transform.RotateAround(pivot, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        
        _rigidbody.isKinematic = false;
        _isMoving = false;
    }

    private void OnDrawGizmos()
    {
        // Gizmos.color = Color.red;
        // Gizmos.DrawSphere(_pivotPoint, 0.2f);
        // Gizmos.DrawRay(_pivotPoint, _axis);
    }
}
