using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
using DG.Tweening;

public class Spinner : MonoBehaviour
{
    private float _duration = 3f;

    private void Start() {
        ProgressBar _progressBar = GetComponent<UIDocument>().rootVisualElement.Q<ProgressBar>("spinner");
        Button _button = GetComponent<UIDocument>().rootVisualElement.Q<Button>("button");

        _button.clicked += () => {
            DOTween.To(() => 0, x => _progressBar.title = $"Loading {x}%", 100, _duration).SetEase(Ease.Linear);
            DOTween.To(() => 0, x => _progressBar.lowValue = x, 100, _duration).SetEase(Ease.Linear);
        };

        _button.RegisterCallback<MouseCaptureEvent>(e => { print("MouseCaptureEvent"); }, TrickleDown.TrickleDown);

        // TODO: так себе решение изменять стили Ui элементов из кода. лучше этим заниматься аналогом css в юнити
        // _button.RegisterCallback<MouseEnterEvent>(e => { OnHoverUpButton(); }, TrickleDown.TrickleDown);
        // _button.RegisterCallback<MouseLeaveEvent>(e => { OnHoverDownButton(); }, TrickleDown.TrickleDown);

        // void OnHoverUpButton() {
        //     DOTween.To(() => 200, x => _button.style.width = x, 300, 0.3f).SetEase(Ease.Linear);
        // }

        // void OnHoverDownButton() {
        //     DOTween.To(() => 300, x => _button.style.width = x, 200, 0.3f).SetEase(Ease.Linear);
        // }
    }
}
