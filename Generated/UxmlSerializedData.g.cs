// Hand-written equivalent of what Unity's UxmlElement source generator emits for the
// [UxmlElement] controls in Assets/OrbitalSurvey/Code/UI/Controls. Only needed when building
// with plain csc (build.sh); the Unity editor generates this itself. Mirrors the 0.9.7 release
// DLL (type and field names must match, the UI bundle's UXML references them by name). The
// editor-only Register() methods are omitted.
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace OrbitalSurvey.UI.Controls
{
    public partial class LegendKeyControl
    {
        [Serializable]
        public new class UxmlSerializedData : VisualElement.UxmlSerializedData
        {
            [SerializeField] private Color ColorValue;
            [SerializeField] private string TextValue;
            [SerializeField, UxmlIgnore, HideInInspector] private UxmlAttributeFlags ColorValue_UxmlAttributeFlags;
            [SerializeField, UxmlIgnore, HideInInspector] private UxmlAttributeFlags TextValue_UxmlAttributeFlags;

            public override object CreateInstance() => new LegendKeyControl();

            public override void Deserialize(object obj)
            {
                base.Deserialize(obj);
                var e = (LegendKeyControl)obj;
                if (ShouldWriteAttributeValue(ColorValue_UxmlAttributeFlags)) e.ColorValue = ColorValue;
                if (ShouldWriteAttributeValue(TextValue_UxmlAttributeFlags)) e.TextValue = TextValue;
            }
        }
    }

    public partial class MapMarkerControl
    {
        [Serializable]
        public new class UxmlSerializedData : VisualElement.UxmlSerializedData
        {
            [SerializeField] private string NameValue;
            [SerializeField] private double LatitudeValue;
            [SerializeField] private double LongitudeValue;
            [SerializeField, UxmlIgnore, HideInInspector] private UxmlAttributeFlags NameValue_UxmlAttributeFlags;
            [SerializeField, UxmlIgnore, HideInInspector] private UxmlAttributeFlags LatitudeValue_UxmlAttributeFlags;
            [SerializeField, UxmlIgnore, HideInInspector] private UxmlAttributeFlags LongitudeValue_UxmlAttributeFlags;

            public override object CreateInstance() => new MapMarkerControl();

            public override void Deserialize(object obj)
            {
                base.Deserialize(obj);
                var e = (MapMarkerControl)obj;
                if (ShouldWriteAttributeValue(NameValue_UxmlAttributeFlags)) e.NameValue = NameValue;
                if (ShouldWriteAttributeValue(LatitudeValue_UxmlAttributeFlags)) e.LatitudeValue = LatitudeValue;
                if (ShouldWriteAttributeValue(LongitudeValue_UxmlAttributeFlags)) e.LongitudeValue = LongitudeValue;
            }
        }
    }

    public partial class SideToggleControl
    {
        [Serializable]
        public new class UxmlSerializedData : Button.UxmlSerializedData
        {
            [SerializeField] private string TextValue;
            [SerializeField, UxmlIgnore, HideInInspector] private UxmlAttributeFlags TextValue_UxmlAttributeFlags;

            public override object CreateInstance() => new SideToggleControl();

            public override void Deserialize(object obj)
            {
                base.Deserialize(obj);
                var e = (SideToggleControl)obj;
                if (ShouldWriteAttributeValue(TextValue_UxmlAttributeFlags)) e.TextValue = TextValue;
            }
        }
    }
}
