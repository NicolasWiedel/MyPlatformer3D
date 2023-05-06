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

    /// <summary>
    /// Verweis auf das graphische Model.
    /// Dient u.A. der Drehung der Laufrichtung.
    /// </summary>
    public GameObject model;

    /// <summary>
    /// Der Winkel zu dem sich die Figur um die eigene Achse
    /// (=Y) drehen soll
    /// </summary>
    private float towardsY = 0f;

    // Update is called once per frame
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");

        transform.position += h * speed * transform.forward;

        if(h > 0)
        {
            towardsY = 0f;
        }
        
        else if(h < 0)
        {
            towardsY = -180f;
        }

        /// <summary>
        /// Die Lerp-Methode sorgt für eine sanfte und
        /// flüssige Drehung der Spielfigur
        /// </summary>
        model.transform.rotation = Quaternion.Lerp(
            model.transform.rotation,
            Quaternion.Euler(0f, towardsY, 0f),
            Time.deltaTime * 10f);
    }
}
