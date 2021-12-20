using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class StickOnScreen : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public float range;
    public Vector2 side;

    private Vector3 startPos;

    public UnityEvent<Vector2> moveStick;


    private void Start() {
        startPos = transform.position;
    }


    [Tooltip("Отправка сообщений в консоль")]
    public bool debug = false;

    private void SendDebug(string message) {
        if (debug) {
            Debug.Log(message);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        SendDebug("BeginDrag");
        side = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData) {
        Vector3 newPos = (Vector3)eventData.position - startPos;
        

        if (newPos.magnitude <= range) {
            transform.position = startPos + newPos;
        }
        else {
            newPos = newPos.normalized * range;
            transform.position = startPos + newPos;
        }

        side = newPos.normalized;


        SendDebug($"Drag {side}");
    }

    private void FixedUpdate() {
        moveStick?.Invoke(side);
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.position = startPos;
        side = Vector2.zero;
        SendDebug("EndDrag");
    }
}
