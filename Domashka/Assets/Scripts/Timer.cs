using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

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
        StartWork();
        StopWork();

        _isClicked = !_isClicked;
    }

    private void StartWork()
    {
        if (_isClicked)
            _coroutine = StartCoroutine(Count(_delay));
    }

    private void StopWork()
    {
        if (_isClicked == false)
            if (_coroutine != null)
                StopCoroutine(_coroutine);
    }

    private IEnumerator Count(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (_count < _maxCount)
        {
            _count++;
            ValueChanged?.Invoke(_count);
            yield return wait;
        }
    }
}


