using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[ExecuteInEditMode]
public class TraysPosition : MonoBehaviour
{
    private int numberOfTrays => GetTrayCount();
    public int NumberOfTrays => numberOfTrays;

    [SerializeField] private MyGameActions playerInput;

    [Range(0f,10f)]
    [SerializeField] private float spacing;
    public float Spacing => spacing;

    [Range(-10f,10f)]
    [SerializeField] private float height;
    public float Height => height;

    [Range(0, 10f)]
    [SerializeField] private float smoothFactor;

    void Start()
    {
        playerInput = new MyGameActions();
        playerInput.Enable();
    }

    private void Update()
    {
        Vector2 inputVector = playerInput.Player.PlateMovement.ReadValue<Vector2>();
        Vector2 targetPos = (Vector2)transform.position + inputVector;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothFactor);
    }

    int GetTrayCount()
    {
        return this.gameObject.transform.childCount;
    }
}
