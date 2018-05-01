using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForcefield : MonoBehaviour {

    public GameObject forcefield;


    public void Deactivate()
    {
        Destroy(forcefield);
        Destroy(gameObject);
    }

}
