using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Steuerung der Spielfigur.
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// Laufgeschwindigkeit der Figur
    /// </summary>
    public float speed = 0.05f;

    // Update is called once per frame
    private void Update()
    {
        transform.position += Input.GetAxis("Horizontal")   
             * speed * transform.forward;
    }
}
