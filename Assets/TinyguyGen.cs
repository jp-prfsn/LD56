using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyguyGen : MonoBehaviour
{
    public static TinyguyGen tg;
    public GameObject tinyGuyPrefab;
    
    void Start()
    {
        tg = this;
    }
    public void Create(Vector3 position)
    {
        GameObject tinyGuy = Instantiate(tinyGuyPrefab);
        tinyGuy.transform.position = position;
    }


}
