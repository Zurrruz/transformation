using System.Collections;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;

public class DisplayTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Timer _timer;

    private void Start()
    {
        _text.text = "";
    }

    private void OnEnable()
    {
        _timer.ValueChanged += DispleyCount;
    }
    private void OnDisable()
    {
        _timer.ValueChanged -= DispleyCount;
    }

    private void DispleyCount(float count)
    {
        _text.text = count.ToString();
    }
}

