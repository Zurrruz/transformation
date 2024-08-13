using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class Timer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private int _maxCount;
    private bool _isClicked;
    private int _count;
    private float _delay;
    private Coroutine _coroutine;

    public event Action<float> ValueChanged;

    private void Start()
    {
        _delay = 0.5f;
        _count = 0;
        _isClicked = true;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isClicked)
            _coroutine = StartCoroutine(Count(_delay, _count));
        else
            if (_coroutine != null)
                StopCoroutine(_coroutine);

        _isClicked = !_isClicked;
    }

    private IEnumerator Count(float delay, int start)
    {
        var wait = new WaitForSeconds(delay);

        for (int i = start; i < _maxCount; i++)
        {
            _count = i;
            ValueChanged?.Invoke(_count);
            yield return wait;
        }
    }
}
