using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShopItemData))]
public class ShopItemDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ShopItemData shopItem = (ShopItemData)target;

        DrawDefaultInspector();

        GUILayout.Space(10);
        DrawUILine(Color.gray);
        GUILayout.Space(10);

        GUIStyle boldLabelStyle = new(GUI.skin.label)
        {
            fontStyle = FontStyle.Bold,
            fontSize = 17
        };

        if (shopItem.sprite != null)
        {
            GUILayout.Label("Sprite Preview:");
            Texture2D spriteTexture = shopItem.sprite.texture;
            Rect spriteRect = shopItem.sprite.rect;
            float aspect = spriteRect.width / spriteRect.height;
            GUILayout.Label(GUIContent.none, GUILayout.Width(300), GUILayout.Height(300 / aspect));
            Rect lastRect = GUILayoutUtility.GetLastRect();
            GUI.DrawTextureWithTexCoords(lastRect, spriteTexture, new Rect(spriteRect.x / spriteTexture.width, spriteRect.y / spriteTexture.height, spriteRect.width / spriteTexture.width, spriteRect.height / spriteTexture.height));
        }
        GUILayout.Space(20);
        GUIStyle nameStyle = new(GUI.skin.label)
        {
            wordWrap = true,
            fontSize = 17
        };
        EditorGUILayout.LabelField("Item Name: ", boldLabelStyle);
        EditorGUILayout.LabelField(shopItem.itemName, nameStyle);

        GUILayout.Space(10);
        GUIStyle descriptionStyle = new(GUI.skin.label)
        {
            wordWrap = true,
            fontSize = 17
        };
        EditorGUILayout.LabelField("Description: ", boldLabelStyle);
        EditorGUILayout.LabelField(shopItem.description, descriptionStyle);

        GUILayout.Space(10);
        GUIStyle priceStyle = new(GUI.skin.label)
        {
            wordWrap = true,
            fontSize = 20,
        };
        EditorGUILayout.LabelField("Price: ", boldLabelStyle);
        EditorGUILayout.LabelField(shopItem.price.ToString(), priceStyle);
    }

    private void DrawUILine(Color color, int thickness = 1, int padding = 10)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
        r.height = thickness;
        r.y += padding / 2;
        r.x -= 2;
        r.width += 6;
        EditorGUI.DrawRect(r, color);
    }
}
