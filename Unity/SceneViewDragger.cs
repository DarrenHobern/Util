using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

/// <summary>
/// Add To Editor folder somewhere:
/// * select the tool (Shift+W)
/// * Select the object from the scene you want
/// * Hold alt + drag to the field
/// </summary>

[EditorTool("Scene View Dragger")]
public class SceneViewDragger : EditorTool
{
    static Texture2D _toolIcon;

    readonly GUIContent _iconContent = new GUIContent
    {
        image = _toolIcon,
        text = "Scene View Dragger",
        tooltip = "Scene View Dragger"
    };

    public override GUIContent toolbarIcon => _iconContent;

    // Surely theres a way to make a hotkey without making a menu item...
    [MenuItem("Tools/Scene View Dragger #W", false)]
    public static void Activate()
    {
        ToolManager.SetActiveTool(typeof(SceneViewDragger));
    }

    public override void OnToolGUI(EditorWindow window)
    {
        Event evt = Event.current;
        if (Selection.activeGameObject && evt.type == EventType.MouseDown && evt.button == 0 && evt.alt)
        {
            GUIUtility.hotControl = 0;
            DragAndDrop.PrepareStartDrag();
            DragAndDrop.objectReferences = new Object[] { Selection.activeGameObject };
            DragAndDrop.StartDrag("SceneDrag");
            evt.Use();
        }
    }
}
