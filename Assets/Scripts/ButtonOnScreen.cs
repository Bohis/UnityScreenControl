using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ButtonOnScreen : MonoBehaviour, 
    IPointerClickHandler, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler, IPointerEnterHandler {
    
    ///<summary>
    /// ������� �������������� � �������
    /// </summary>
    public UnityEvent OnClickButton;

    ///<summary>
    /// ����� ������ ������ � ������
    /// </summary>
    public UnityEvent OnEnterButton;
    ///<summary>
    /// ����� ������ ������� �� ������
    /// </summary>
    public UnityEvent OnExitButton;

    ///<summary>
    /// ���������� ��� ������� �� ������
    /// </summary>
    public UnityEvent OnDownButton;
    ///<summary>
    /// ���������� ������ ���������� ������
    /// </summary>
    public UnityEvent OnUpButton;

    [Tooltip("�������� ��������� � �������")]
    public bool debug = false;

    public UnityEvent OnHold;
    private IEnumerator hold;

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

        hold = Holding();
        StartCoroutine(hold);
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
        if (hold != null) StopCoroutine(hold);
        hold = null;

        SendDebug("Up");
        OnUpButton?.Invoke();
    }
}
