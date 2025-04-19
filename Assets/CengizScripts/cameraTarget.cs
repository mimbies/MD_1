using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTarget : MonoBehaviour
{
    [SerializeField] Camera cam;           // Die Kamera, die bewegt werden soll
    [SerializeField] Transform player;     // Der Spieler
    [SerializeField] float spielraum;      // Der Spielraum, in dem sich die Kamera bewegen darf
    [SerializeField] Vector3 offset;       // Der Offset, der den Spieler von der Mitte verschiebt

    private Vector3 lastTargetPos;         // Um die Zielposition zu speichern

    // Update is called once per frame
    void Update()
    {
        // Holen der Mausposition im Weltkoordinaten-System
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Berechnung des Zielpunkts (Mittelpunkt zwischen Spieler und Maus)
        Vector3 targetPos = (player.position + mousePos) / 2f;

        // Zielpunkt nur dann aktualisieren, wenn die Maus sich bewegt
        if (targetPos != lastTargetPos)
        {
            lastTargetPos = targetPos;
        }

        // Begrenzung der Zielposition innerhalb des Spielraums
        targetPos.x = Mathf.Clamp(lastTargetPos.x, -spielraum + player.position.x, spielraum + player.position.x);
        targetPos.y = Mathf.Clamp(lastTargetPos.y, -spielraum + player.position.y, spielraum + player.position.y);

        // Sicherstellen, dass die Z-Position der Kamera gleich bleibt
        targetPos.z = transform.position.z;

        // Berechne die Zielposition mit dem Offset (damit der Spieler nicht immer mittig ist)
        targetPos += offset;

        // Bewege die Kamera nur in X- und Y-Richtung, ohne die Rotation zu beeinflussen
        this.transform.position = targetPos;
    }
}
