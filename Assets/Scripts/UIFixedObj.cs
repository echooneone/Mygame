using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 此脚本用于跟随物体显示UI标签（如角色名、血条等）
/// 挂载到UI上即可
/// </summary>
public class UIFixedObj : MonoBehaviour
{
    public GameObject obj;    //跟随目标对象
    private RectTransform rect;
    private float scalerX;
    private float scalerY;
    // Use this for initialization
    void Start()
    {
        rect = (RectTransform)transform;
        CanvasScaler scaler = transform.root.GetComponent<CanvasScaler>();
        scalerX = scaler.referenceResolution.x;
        scalerY = scaler.referenceResolution.y;
    }

    void Update()
    {
        Vector2 pos;
        Canvas canvas = transform.root.GetComponent<Canvas>();
        if (Camera.main == null) return;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
            Camera.main.WorldToScreenPoint(obj.transform.position), canvas.worldCamera, out pos);
        {
            //此处限制在Game视图内部
            //if (pos.x + rect.rect.width > scalerX / 2)
            //    pos = new Vector2(scalerX / 2 - rect.rect.width, pos.y);
            //if (pos.x < -scalerX / 2)
            //    pos = new Vector2(-scalerX / 2, pos.y);
            //if (pos.y > scalerY / 2)
            //    pos = new Vector2(pos.x, scalerY / 2);
            //if (pos.y - rect.rect.height < -scalerY / 2)
            //    pos = new Vector2(pos.x, -scalerY / 2 + rect.rect.height);
            rect.localPosition = pos;
        }
    }
}