using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject[] minos;
    // Start is called before the first frame update
    void Start()
    {
        NewMino();
    }

   public void NewMino()
    {
        Instantiate(minos[Random.Range(0, minos.Length)], transform.position, Quaternion.identity);
    }
}
