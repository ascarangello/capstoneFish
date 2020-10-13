using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// Script adapted from https://dev.to/matthewodle/simple-ui-element-dragging-script-in-unity-c-450p
// Added offset to make dragging non central
public class Dragger : EventTrigger
{
    private float offset;
    private bool dragging;

    private void Start()
    {
        offset = GetComponent<RectTransform>().rect.height / 2;
    }

    public void DragObject()
    {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
