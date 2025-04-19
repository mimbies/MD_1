using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTarget : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform player;
    [SerializeField] float spielraum;



    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (player.position + mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -spielraum + player.position.x, spielraum + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -spielraum + player.position.y, spielraum + player.position.y);

        this.transform.position = targetPos;
    }
}
