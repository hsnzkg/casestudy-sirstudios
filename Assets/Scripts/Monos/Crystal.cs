using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField]private CrystalSettings setting;
    [SerializeField] private GameObject vfxEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ParticleSystem vfx =  Instantiate(vfxEffect, transform.position, transform.rotation, null).GetComponent<ParticleSystem>();
            vfx.Play();
            ScoreManager.Instance.IncrementScore(setting.score);
            PoolManager.Instance.AddObject(this.gameObject);
        }
    }
}
