using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorImg; //�ٲ� Ŀ�� �̹���
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware); //cursorImg �ؽ��ķ� Ŀ�� ����
    }
}
