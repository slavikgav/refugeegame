﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collectable {


    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(this.gameObject);
    }

    void OnMouseDown()
    {
        // this object was clicked - do something
        FallingObjects.fallingObjectsInstance.collectFruits(this);
        Destroy(this.gameObject);
    }
}
