﻿using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class HeldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private Button _button;
    //event variable used to call a function from the player movement script
    public UnityEvent onRelease;
    private bool buttonPressed = false;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void FixedUpdate()
    {
        if (buttonPressed)
            _button.onClick?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_button.interactable) return;

        buttonPressed = true;

    }

    //when pointer released, invokes onRelease event

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        onRelease?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonPressed = false;
    }
}