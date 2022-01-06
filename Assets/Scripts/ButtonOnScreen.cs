using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonOnScreen : MonoBehaviour, 
    IPointerClickHandler, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler, IPointerEnterHandler {
    
    ///<summary>
    /// События взаимодействия с кнопкой
    /// </summary>
    public UnityEvent OnClickButton;

    ///<summary>
    /// Когда курсор входит в кнопку
    /// </summary>
    public UnityEvent OnEnterButton;
    ///<summary>
    /// Когда курсор выходит из кнопки
    /// </summary>
    public UnityEvent OnExitButton;

    ///<summary>
    /// Происходит при нажатии на кнопку
    /// </summary>
    public UnityEvent OnDownButton;
    ///<summary>
    /// Происходит просле отпускания кнопки
    /// </summary>
    public UnityEvent OnUpButton;


    public UnityEvent OnHold;
    private IEnumerator hold = null;

    [Tooltip("Отправка сообщений в консоль")]
    public bool debug = false;

    private void StartCorotuneHold() {
        if (hold != null) return;
        
        hold = Holding();
        StartCoroutine(hold);
    }

    private void EndCorotuneHold() {
        if (hold != null) StopCoroutine(hold);
        hold = null;
    }

    private IEnumerator Holding() {
        while (true) {
            OnHold?.Invoke();
            yield return new WaitForFixedUpdate();
        }
    }

    private void SendDebug(string message) {
        if (debug) {
            Debug.Log(message);
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        SendDebug("Click");
        OnClickButton?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData) {
        SendDebug("Down");
        OnDownButton?.Invoke();

        StartCorotuneHold();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        SendDebug("Enter");

        StartCorotuneHold();

        OnEnterButton?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData) {
        SendDebug("Exit");

        EndCorotuneHold();

        OnExitButton?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData) {
        EndCorotuneHold();

        SendDebug("Up");
        OnUpButton?.Invoke();
    }
}
