using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{

    public GameManager gameManager;
    // public Spawn spawn;
    public static Locator i;
    void Awake()
    {
        i = this;
    }
}
