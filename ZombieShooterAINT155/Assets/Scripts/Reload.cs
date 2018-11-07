using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Reload : MonoBehaviour {
    public float reloadTime = 1;
    public bool repeat = false;
    public UnityEvent onReload;

    // Use this for initialization
    void Start () {
            InvokeRepeating("OnReload", 0, reloadTime);

    }
    private void OnReload()
    {
        GameObject.Find("Hero").GetComponent<Weapon>().bulletMagazine = 10;
        GameObject.Find("Hero").GetComponent<Weapon>().emptyMagazine = false;
    }
}
