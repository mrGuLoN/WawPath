using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolIdentificate : MonoBehaviour
{
    public PollObjects.ObjectInfo.ObjectType Type => type;
    [SerializeField] private PollObjects.ObjectInfo.ObjectType type;

    private bool _fire = false;

    public void Start()
    {
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        if (_fire == false)
        {
            StartCoroutine(Destroy());
            _fire = true;
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1);
        _fire = false;
        PollObjects.Instance.DestroyGameObject(this.gameObject);
    }
}
