using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    // TODO: Automatically adjust box collider to screen size
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.position = new Vector2(-(collision.transform.position.x), -(collision.transform.position.y));
    }

}
