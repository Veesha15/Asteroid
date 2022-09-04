using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Automatically adjust box collider to screen size.
// TODO: Rather use RigidBody.MovePosition to move?
// TODO: Remove hard coded numbers.
// TODO: Catch stragglers.
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
            ScreenWrap(collision);
        }
    }

    private void ScreenWrap(Collider2D _collider)
    {
        if (Mathf.Abs(_collider.transform.position.y) >= 5)
        {
            _collider.transform.position = new Vector2((_collider.transform.position.x), -(_collider.transform.position.y));
        }
       
        if (Mathf.Abs(_collider.transform.position.x) >= 9)
        {
            _collider.transform.position = new Vector2(-(_collider.transform.position.x), (_collider.transform.position.y));
        }
    }

}
