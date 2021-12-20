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

    [Tooltip("Отправка сообщений в консоль")]
    public bool debug = false;


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
    }

    public void OnPointerEnter(PointerEventData eventData) {
        SendDebug("Enter");
        OnEnterButton?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData) {
        SendDebug("Exit");
        OnExitButton?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData) {
        SendDebug("Up");
        OnUpButton?.Invoke();
    }
}
