using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Automatically adjust box collider to screen size
// TODO: Rather use rigid body to move?
public class ScreenBounds : MonoBehaviour
{
    public static event Action<GameObject> OnBulletOutOfBounds;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            OnBulletOutOfBounds?.Invoke(collision.gameObject);
        }
        else
        {
            collision.transform.position = new Vector2(-(collision.transform.position.x), -(collision.transform.position.y));
        }
    }

}
