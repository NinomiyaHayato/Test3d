using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("playerÇÃç≈ëÂhp")]public int _maxHP;
    private ReactiveProperty<int> _hp;

    public ReactiveProperty<int> Hp => _hp;

    private void Awake()
    {
        _hp = new ReactiveProperty<int>(_maxHP);
    }
    public void TakeDamage(int damage)
    {
        _hp.Value = _hp.Value - damage;
        if(_hp.Value <= 0)
        {
            Debug.Log("éÄ");
        }
    }
}
