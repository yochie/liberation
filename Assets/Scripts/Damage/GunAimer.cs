using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAimer : MonoBehaviour
{
    [SerializeField]
    private Transform rotationCenter;

    [SerializeField]
    private SpriteRenderer gunSprite;

    public Vector3 Orientation { get {
            return this.transform.position - this.rotationCenter.position;

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0;
        Vector3 currentlyPointingAt = this.Orientation;
        float angleToMouse = Vector3.SignedAngle(currentlyPointingAt, mouseWorldPos - this.rotationCenter.position, Vector3.forward);
        float smoothedAngleToMouse = Mathf.LerpAngle(0, angleToMouse, 0.2f);

        this.transform.RotateAround(this.rotationCenter.position, Vector3.forward, smoothedAngleToMouse);

        this.gunSprite.flipY = this.transform.localPosition.x > 0;
    }
}
