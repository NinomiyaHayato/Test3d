using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UiManager : MonoBehaviour
{
    [SerializeField] Slider _slider;
    public PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _slider.maxValue = _playerController._maxHP;
        _playerController.Hp.Subscribe(hp => UpdateSlider(hp)).AddTo(this);
    }

    void UpdateSlider(int hp)
    {
        _slider.value = hp;
    }
}
