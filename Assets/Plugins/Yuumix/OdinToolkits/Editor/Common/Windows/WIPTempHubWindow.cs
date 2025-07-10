using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using Yuumix.OdinToolkits.Common;
using Yuumix.OdinToolkits.Editor.Core;

namespace Yuumix.OdinToolkits.Editor.Common
{
    public class WIPTempHubWindow : OdinEditorWindow
    {
        public MultiLanguageHeaderWidget header =
            new MultiLanguageHeaderWidget("临时调试窗口中心", "Temporary Hub");

        [MenuItem(OdinToolkitsWindowMenuItems.TempHubMenuItemName, false, OdinToolkitsWindowMenuItems.TempHubPriority)]
        public static void ShowWindow()
        {
            var window = GetWindow<WIPTempHubWindow>();
            window.titleContent = new GUIContent("临时调试窗口中心");
            window.position = GUIHelper.GetEditorWindowRect().AlignCenter(800, 600);
            window.Show();
        }
    }
}
