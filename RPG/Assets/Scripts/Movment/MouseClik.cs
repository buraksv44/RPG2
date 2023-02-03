using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;
using Cursor = UnityEngine.Cursor;

public class MouseClik : MonoBehaviour
{
    [SerializeField] Texture2D cursor, cursor2;
    private void OnMouseDown()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(cursor2, Vector2.zero, CursorMode.Auto);
    }







}
