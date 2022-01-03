using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PollObjects.ObjectInfo.ObjectType Type => bullet;
    [SerializeField] private PollObjects.ObjectInfo.ObjectType bullet;
   
    [SerializeField] private PollObjects.ObjectInfo.ObjectType bloods;
    
    [SerializeField] private PollObjects.ObjectInfo.ObjectType wallBooms;

    public float speed, damage;
    [SerializeField] private float timeToDestroy;

    private bool _fire = false;

    private void Start()
    {
        StartCoroutine(Destroer());
        _fire = true;
    }

    private void FixedUpdate()
    {
        if (_fire == false)
        {
            StartCoroutine(Destroer());
            _fire = true;
        }
        this.transform.position += this.transform.forward * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, this.transform.forward);

        if (Physics.Raycast(ray, out hit, 1f))
        {
            if (hit.collider.transform.CompareTag("Enemy"))
            {                
                hit.transform.gameObject.GetComponent<Health>().health -= damage;
                if (hit.transform.gameObject.GetComponent<Health>().health <= 0)
                {
                    hit.transform.gameObject.GetComponent<Health>().EnemyDead();
                }
                GameObject blood = PollObjects.Instance.GetObject(bloods);
                blood.transform.position = this.transform.position;
            }
            else
            {
                GameObject wallBoom = PollObjects.Instance.GetObject(wallBooms);
                wallBoom.transform.position = this.transform.position;
            }
            PollObjects.Instance.DestroyGameObject(this.gameObject);            
        }
    }

    IEnumerator Destroer()
    {
        yield return new WaitForSeconds(timeToDestroy);
        _fire = false;
        PollObjects.Instance.DestroyGameObject(this.gameObject);        
    }


}
