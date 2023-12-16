using System.Collections.Generic;
using UnityEngine;

public class AnimationTestPlay : MonoBehaviour
{
    Animator _anim;
    [SerializeField, Header("�A�j���[�V�����̖��O")] List<string> _animNames;
    [SerializeField,Header("�ǂ�animation����͂��߂邩")]int _animCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (_animCount == _animNames.Count)
            {
                _animCount = 0;
            }
            _anim.Play(_animNames[_animCount]);
            _animCount++;
        }
    }
}
