using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerClickHandler
{
    public static Action StartGameAction;
    public static Action ShootAction;

    private void Awake()
    {
        StartGameAction = null;
        ShootAction = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Time.timeScale == 0)
            StartGameAction?.Invoke();
        else
            ShootAction?.Invoke();
            
    }
}
