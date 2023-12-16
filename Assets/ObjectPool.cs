using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Header("�ŏ��ɒʏ�̃I�u�W�F�N�g�����������邩")] int _maxNormalCount;
    [SerializeField, Header("�ŏ��ɓ���ȃI�u�W�F�N�g�����������邩")] int _maxSpecialCount;
    [SerializeField, Header("�ŏ��ɒ��e����I�u�W�F�N�g�����������邩")] int _maxRicochetCount;

    public List<GameObject> _objectNormalPool = new List<GameObject>();
    public List<GameObject> _objectSpecialPool = new List<GameObject>();
    public List<GameObject> _objectRicochetPool = new List<GameObject>();

    [SerializeField] ObjectFactory _bulletFactory; // �ʏ�̒e�A����Ȓe�A���e�𐶐����邽�߂̃t�@�N�g���[

    private void Awake()
    {
        CreatePool(_maxNormalCount, _objectNormalPool, _bulletFactory,_bulletFactory.CreateNormalBullet);
        CreatePool(_maxSpecialCount, _objectSpecialPool, _bulletFactory, _bulletFactory.CreateSpecialBullet);
        CreatePool(_maxRicochetCount, _objectRicochetPool, _bulletFactory, _bulletFactory.CreateRicochetBullet);
    }

    public void CreatePool(int maxCount, List<GameObject> pool, ObjectFactory factory, Func<Vector3, GameObject> createMethod)
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject bullet = createMethod(Vector3.zero);
            bullet.SetActive(false);
            pool.Add(bullet);
            bullet.transform.parent = this.transform;
        }
    }

    public GameObject GetBullet(Vector3 position, List<GameObject> pool)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeSelf == false)
            {
                GameObject bullet = pool[i];
                bullet.transform.position = position;
                bullet.SetActive(true);
                return bullet;
            }
        }
        //�S��Object���g�p���Ă����ꍇ
        GameObject newBullet;
       if(pool == _objectNormalPool)
        {
            newBullet = _bulletFactory.CreateNormalBullet(position);
            return newBullet;
        }
       else if(pool == _objectSpecialPool)
        {
            newBullet = _bulletFactory.CreateSpecialBullet(position);
            return newBullet;
        }
       else
        {
            newBullet = _bulletFactory.CreateRicochetBullet(position);
            return newBullet;
        }
    }
}
