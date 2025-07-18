using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.ValueResolvers;
using Sirenix.Utilities.Editor;
using UnityEngine;
using Yuumix.OdinToolkits.Core;

namespace Yuumix.OdinToolkits.Editor.Core
{
    public class MultiLanguageBoxGroupAttributeDrawer : OdinGroupDrawer<MultiLanguageBoxGroupAttribute>
    {
        ValueResolver<string> _labelGetter;

        protected override void Initialize()
        {
            _labelGetter = ValueResolver.GetForString(Property, Attribute.LanguageData);
            InspectorMultiLanguageSetting.OnLanguageChange -= ReloadResolver;
            InspectorMultiLanguageSetting.OnLanguageChange += ReloadResolver;
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            _labelGetter.DrawError();
            string label1 = null;
            if (Attribute.ShowLabel)
            {
                label1 = _labelGetter.GetValue();
                if (string.IsNullOrEmpty(label1))
                {
                    label1 = "Null";
                }
            }

            SirenixEditorGUI.BeginBox(label1, Attribute.CenterLabel);
            for (var index = 0; index < Property.Children.Count; index++)
            {
                InspectorProperty child = Property.Children[index];
                child.Draw(child.Label);
            }

            SirenixEditorGUI.EndBox();
        }

        void ReloadResolver()
        {
            _labelGetter = ValueResolver.GetForString(Property, Attribute.LanguageData);
        }
    }
}
