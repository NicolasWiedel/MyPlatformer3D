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
    /// Die Kraft mit der nach oben gespringen wird.
    /// </summary>
    public float jumpPush = 1f;

    /// <summary>
    /// Verstärkung der Gravitation, damit die Figur schneller fällt.
    /// </summary>
    public float extraGravity = 20f;

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

    /// <summary>
    /// Zeiger auf die Physics-Komponente
    /// </summary>
    private Rigidbody rigid;

    /// <summary>
    /// True bedeutet, dass die Figur auf dem Boden ist.
    /// </summary>
    private bool onGround;

    // Wird zur Initialisierung ausgeführt.
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Eingabesingnal fürs Laufen
        float h = Input.GetAxis("Horizontal");

        // vorwärts bewegen
        transform.position += h * speed * transform.forward;

        // Drehung
        if(h > 0)
        {
            towardsY = 0f;
        }
        
        else if(h < 0)
        {
            towardsY = -180f;
        }

        // Die Lerp-Methode sorgt für eine sanfte und
        // flüssige Drehung der Spielfigur
        model.transform.rotation = Quaternion.Lerp(
            model.transform.rotation,
            Quaternion.Euler(0f, towardsY, 0f),
            Time.deltaTime * 10f);

        // Springen
        RaycastHit hitinfo;
        onGround = Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitinfo, 0.12f);
        if (Input.GetAxis("Jump") > 0 && onGround)
        {
            Vector3 power = rigid.velocity;
            power.y = jumpPush;
            rigid.velocity = power;
        }
        rigid.AddForce(new Vector3(0f, extraGravity, 0f));
    }

    private void OnDrawGizmos()
    {
        if(onGround)
            Gizmos.color = Color.magenta;
        else
            Gizmos.color = Color.yellow;
        Vector3 rayStartPosition = transform.position + (Vector3.up * 0.1f);
        Gizmos.DrawLine(rayStartPosition, rayStartPosition + (Vector3.down * 0.12f));
    }
}
