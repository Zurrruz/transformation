using System.Collections;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private int _maxCount;
    private bool _isClicked;
    private int _count;
    private float _delay;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isClicked)
            StartCoroutine(Count(_delay, _count));
        else
            StopAllCoroutines();

        _isClicked = !_isClicked;
    }

    private void Start()
    {
        _text.text = "";
        _isClicked = true;
        _count = 0;
        _delay = 0.5f;
    }

    private IEnumerator Count(float delay, int start)
    {
        var wait = new WaitForSeconds(delay);

        for (int i = start; i < _maxCount; i++)
        {
            _count = i;
            DispleyCount(_count);
            yield return wait;
        }        
    }

    private void DispleyCount(int count)
    {
        _text.text = count.ToString();
    }
}

