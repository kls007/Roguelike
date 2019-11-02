using Shuai;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LuaGenerateHelper
{
    public class OutStruct
    {
        public Transform transform;
        public OutStruct parent;
        public int level = 0;
        public readonly List<Transform> Items = new List<Transform>();
        public readonly List<OutStruct> Childs = new List<OutStruct>();

        private void exportItem(Transform item, int level)
        {
            // print(item.name);
            // if(item.name.StartsWith("-"))
            // exportGameObject(item.gameObject);
            bool ishaveComponent = false;
            //if (item.name.Contains("Rect"))
            //{ 
            //    exportReatTransform(item.GetComponent<RectTransform>(), level > 0);
            //    ishaveComponent = true;
            //}
            if (item.GetComponent<Button>())
            {
                exportButton(item.GetComponent<Button>(), level > 0);
                ishaveComponent = true;
            }
            if (item.GetComponent<Text>())
            {
                exportText(item.GetComponent<Text>(), level > 0);
                ishaveComponent = true;
            }
            if (item.GetComponent<Image>())
            {
                exportImage(item.GetComponent<Image>(), level > 0);
                ishaveComponent = true;
            }
            if (item.GetComponent<SpriteRes>())
            {
                exportSpriteRes(item.GetComponent<SpriteRes>(), level > 0);
                ishaveComponent = true;
            }
            if (item.GetComponent<Animator>())
            {
                exportAnimator(item.GetComponent<Animator>(), level > 0);
                ishaveComponent = true;
            }
            if (item.GetComponent<Toggle>())
            {
                exportToggle(item.GetComponent<Toggle>(), level > 0);
                ishaveComponent = true;
            }
            if (item.GetComponent<ToggleGroup>())
            {
                exportToggleGroup(item.GetComponent<ToggleGroup>(), level > 0);
                ishaveComponent = true;
            }
            if (item.GetComponent<InputField>())
            {
                exportInput(item.GetComponent<InputField>(), level > 0);
                ishaveComponent = true;
            }
            if (item.GetComponent<Dropdown>())
            {
                exportDropdown(item.GetComponent<Dropdown>(), level > 0);
                ishaveComponent = true;
            }

            if (!ishaveComponent)
            {
                exportGameObject(item);
            }
              
        }

        //private void exportItem(Transform item, int level)
        //{
        //    // print(item.name);
        //    // if(item.name.StartsWith("-"))
        //    // exportGameObject(item.gameObject);
        //    if (item.name.Contains("Rect"))
        //        exportReatTransform(item.GetComponent<RectTransform>(), level > 0);
        //    else if (item.name.Contains("Button"))
        //        exportButton(item.GetComponent<Button>(), level > 0);
        //    else if (item.name.Contains("Text"))
        //        exportText(item.GetComponent<Text>(), level > 0);
        //    else if (item.name.Contains("Image"))
        //        exportImage(item.GetComponent<Image>(), level > 0);
        //    else if (item.name.Contains("ToggleGroup"))
        //        exportToggleGroup(item.GetComponent<ToggleGroup>(), level > 0);
        //    else if (item.name.Contains("Toggle"))
        //        exportToggle(item.GetComponent<Toggle>(), level > 0);
        //    else if (item.name.Contains("Input"))
        //        exportInput(item.GetComponent<InputField>(), level > 0);
        //    else if (item.name.Contains("Dropdown"))
        //        exportDropdown(item.GetComponent<Dropdown>(), level > 0);
        //    //else if (item.name.Contains("Spine"))
        //    //    exportSpineUI(item.GetComponent<Spine.Unity.SkeletonGraphic>(), level > 0);
        //    else
        //        exportGameObject(item);
        //}

        string GameObjectTypeString = "";

        public void export()
        {
            if (level == 1)
            {
                // ExportConstStringBuilder.AppendLine(transform.name.Substring(1) + ":{");
                // ExportConstStringBuilder.AppendLine("gameObject : UnityEngine.GameObject,");

                var name = transform.name.StartsWith("-$") ? transform.name.Substring(2) : transform.name.Substring(1);
                ConstStringBuilder.AppendLine("self." + name + "= {");
                ConstStringBuilder.AppendLine(GameObjectTypeString + string.Format("gameObject = transform:Find(\"{0}\").gameObject,", GetFullPath(transform)));
                if (transform.name.StartsWith("-$"))
                    exportItem(transform, level);
            }
            else if (level > 1)
            {
                // ExportConstStringBuilder.AppendLine(transform.name.Substring(1) + ":{");
                // ExportConstStringBuilder.AppendLine("gameObject : UnityEngine.GameObject,");


                var name = transform.name.StartsWith("-$") ? transform.name.Substring(2) : transform.name.Substring(1);
                ConstStringBuilder.AppendLine(name + "= {");
                ConstStringBuilder.AppendLine(GameObjectTypeString + string.Format("gameObject = transform:Find(\"{0}\").gameObject,", GetFullPath(transform)));
                if (transform.name.StartsWith("-$"))
                    exportItem(transform, level);
            }

            foreach (var item in Items)
            {
                exportItem(item, level);
            }

            foreach (var child in Childs)
            {
                child.export();
            }

            if (level > 0)
            {
                // ExportConstStringBuilder.AppendLine("}");
                ConstStringBuilder.AppendLine("}");
                if (level > 1)
                    ConstStringBuilder.AppendLine(",");
            }
            // print(outStruct.ExportConstStringBuilder + "\n" + outStruct.ConstStringBuilder);
        }

        // private void exportGameObject(GameObject gameobject, bool inside = false){
        //     var name = gameobject.name.Substring(1);

        //     var ExportFormatString = inside ? "{0}: UnityEngine.GameObject," : " {0}: UnityEngine.GameObject;";
        //     ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

        //     var FormatString = inside ?
        //      "{0} = transform:Find(\"{1}\").gameObject," :
        //      "self.{0} = transform:Find(\"{1}\").gameObject;";
        //     ConstStringBuilder.AppendLine(string.Format(FormatString, name, GetFullPath(gameobject.transform)));
        // }


        private void exportReatTransform(RectTransform rect, bool inside = false)
        {
            var name = rect.name.Substring(rect.name.IndexOf('$') + 1);

            var ExportFormatString = inside ? "{0}: UnityEngine.UI.RectTransform," : " {0}: UnityEngine.UI.RectTransform;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var typeString = "";

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\"):GetComponent(\"RectTransform\")," :
             "self.{0} = transform:Find(\"{1}\"):GetComponent(\"RectTransform\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(rect.transform)));
        }

        private void exportButton(Button button, bool inside = false)
        {
            var name = button.name.Substring(button.name.IndexOf('$') + 1);
            // if (button.name[0] == '-')
            // Debug.Log(button.name + " " + button.name.IndexOf('$') + " " + button.name.Substring(button.name.IndexOf('$') + 1));

            var typeString = "";

            var ExportFormatString = inside ? "{0}: UnityEngine.UI.Button," : " {0}: UnityEngine.UI.Button;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\"):GetComponent(\"Button\")," :
             "self.{0} = transform:Find(\"{1}\"):GetComponent(\"Button\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(button.transform)));
        }

        private void exportText(Text text, bool inside = false)
        {
            // export var Text_time: UnityEngine.UI.Text;
            // Text_time = transform:Find("Texts/Text_time"):GetComponent("Button");
            var name = "Text_" + text.name.Substring(text.name.IndexOf('$') + 1);

            var typeString = "";

            var ExportFormatString = inside ? "{0}: UnityEngine.UI.Text," : " {0}: UnityEngine.UI.Text;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\"):GetComponent(\"Text\")," :
             "self.{0} = transform:Find(\"{1}\"):GetComponent(\"Text\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(text.transform)));
        }

        private void exportImage(Image image, bool inside = false)
        {
            var name = "Image_" + image.name.Substring(image.name.IndexOf('$') + 1);

            var typeString = "";

            var ExportFormatString = inside ? "{0}: UnityEngine.UI.Image," : " {0}: UnityEngine.UI.Image;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\"):GetComponent(\"Image\")," :
             "self.{0} = transform:Find(\"{1}\"):GetComponent(\"Image\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(image.transform)));
        }
        
        private void exportSpriteRes(SpriteRes image, bool inside = false)
        {
            var name = "SpriteRes_" + image.name.Substring(image.name.IndexOf('$') + 1);

            var typeString = "";

            var ExportFormatString = inside ? "{0}: UnityEngine.UI.Image," : " {0}: UnityEngine.UI.Image;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\"):GetComponent(\"SpriteRes\")," :
             "self.{0} = transform:Find(\"{1}\"):GetComponent(\"SpriteRes\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(image.transform)));
        }

        private void exportAnimator(Animator image, bool inside = false)
        {
            var name = "Animator_" + image.name.Substring(image.name.IndexOf('$') + 1);

            var typeString = "";

            var ExportFormatString = inside ? "{0}: UnityEngine.UI.Image," : " {0}: UnityEngine.UI.Image;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\"):GetComponent(\"Animator\")," :
             "self.{0} = transform:Find(\"{1}\"):GetComponent(\"Animator\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(image.transform)));
        }

        private void exportToggleGroup(ToggleGroup toggle, bool inside = false)
        {
            var name = toggle.name.Substring(toggle.name.IndexOf('$') + 1);

            var typeString = "";

            var ExportFormatString = inside ? "{0}: UnityEngine.UI.ToggleGroup," : " {0}: UnityEngine.UI.ToggleGroup;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\"):GetComponent(\"ToggleGroup\")," :
             "self.{0} = transform:Find(\"{1}\"):GetComponent(\"ToggleGroup\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(toggle.transform)));
        }

        private void exportToggle(Toggle toggle, bool inside = false)
        {
            var name = toggle.name.Substring(toggle.name.IndexOf('$') + 1);

            var typeString = "";

            var ExportFormatString = inside ? "{0}: UnityEngine.UI.Toggle," : " {0}: UnityEngine.UI.Toggle;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\"):GetComponent(\"Toggle\")," :
             "self.{0} = transform:Find(\"{1}\"):GetComponent(\"Toggle\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(toggle.transform)));
        }

        private void exportInput(InputField input, bool inside = false)
        {
            var name = input.name.Substring(input.name.IndexOf('$') + 1);

            var typeString = "";

            var ExportFormatString = inside ? "{0}: UnityEngine.UI.InputField," : " {0}: UnityEngine.UI.InputField;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\"):GetComponent(\"InputField\")," :
             "self.{0} = transform:Find(\"{1}\"):GetComponent(\"InputField\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(input.transform)));
        }

        private void exportDropdown(Dropdown dropdown, bool inside = false)
        {
            var name = dropdown.name.Substring(dropdown.name.IndexOf('$') + 1);

            var typeString = "";

            var ExportFormatString = inside ? "{0}: UnityEngine.UI.Dropdown," : " {0}: UnityEngine.UI.Dropdown;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\"):GetComponent(\"Dropdown\")," :
             "self.{0} = transform:Find(\"{1}\"):GetComponent(\"Dropdown\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(dropdown.transform)));
        }

        //private void exportSpineUI(Spine.Unity.SkeletonGraphic skeletonGraphic, bool inside = false)
        //{
        //    var name = skeletonGraphic.name.Substring(skeletonGraphic.name.IndexOf('$') + 1);

        //    var typeString = "";

        //    var ExportFormatString = inside ? "{0}: Spine.Unity.SkeletonGraphic," : " {0}: Spine.Unity.SkeletonGraphic;";
        //    ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

        //    var FormatString = inside ?
        //     "{0} = transform:Find(\"{1}\"):GetComponent(\"SkeletonGraphic\")," :
        //     "self.{0} = transform:Find(\"{1}\"):GetComponent(\"SkeletonGraphic\");";
        //    ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(skeletonGraphic.transform)));
        //}

        private void exportGameObject(Transform item, bool inside = false)
        {
            var name = item.name.Substring(item.name.IndexOf('$') + 1);

            var typeString = "";

            var ExportFormatString = inside ? "{0}: UnityEngine.Transform," : " {0}: UnityEngine.Transform;";
            ExportConstStringBuilder.AppendLine(string.Format(ExportFormatString, name));

            var FormatString = inside ?
             "{0} = transform:Find(\"{1}\")," :
             "self.{0} = transform:Find(\"{1}\");";
            ConstStringBuilder.AppendLine(string.Format(typeString + FormatString, name, GetFullPath(item.transform)));
        }
    }

    //  TODO: public class

    public static Transform Root;
    public readonly static StringBuilder ExportConstStringBuilder = new StringBuilder();
    public readonly static StringBuilder ConstStringBuilder = new StringBuilder();

    public static void Generate(GameObject root)
    {
        Root = root.transform;
        ExportConstStringBuilder.Length = 0;
        ConstStringBuilder.Length = 0;

        var outRoot = new OutStruct();
        outRoot.transform = root.transform;
        internalGenerate(outRoot, root.transform);
        outRoot.export();

        // 
        // Debug.Log(ExportConstStringBuilder + "\n" + ConstStringBuilder);
        Debug.Log(ConstStringBuilder);
        // 复制到剪切板
        TextEditor textEditor = new TextEditor();
        textEditor.text = ConstStringBuilder.ToString();
        textEditor.SelectAll();
        textEditor.Copy();
    }

    // public void InternalGenerate(OutStruct outStruct)
    // {
    //     internalGenerate(outStruct, outStruct.transform);
    // }

    private static void internalGenerate(OutStruct outStruct, Transform transform)
    {
        // 排除特殊目录
        // if (outStruct.transform != transform && transform:GetComponent<TsGenerateHelper>() != null)
        // {
        //     return;
        // }

        // 处理子目录
        if (outStruct.transform != transform && transform.name.StartsWith("-"))
        {
            var childStruct = new OutStruct();
            childStruct.parent = outStruct;
            childStruct.transform = transform;
            childStruct.level = outStruct.level + 1;
            outStruct.Childs.Add(childStruct);
            internalGenerate(childStruct, transform);
            return;
        }
        // 普通元素
        if (transform.name.StartsWith("$"))
        {
            outStruct.Items.Add(transform);
        }
        // 遍历子元素
        foreach (Transform child in transform)
        {
            internalGenerate(outStruct, child);
        }
    }

    static string GetFullPath(Transform child, string splitStr = "/", Func<string, string> paction = null)
    {
        var root = Root;
        // 特殊处理
        if (child == root)
            return string.Empty;

        //
        var path = child.gameObject.name;
        if (child != root)
            child = child.parent;
        while (child != null && child != root /*&& tempParent:GetComponent<LuaViewGenerater>() != null*/)
        {
            path = string.Format("{0}{2}{1}", (object)child.gameObject.name, (object)path, splitStr);
            if (paction != null) path = paction(path);
            child = child.parent;
        }
        return path;
    }

    [MenuItem("GameObject/- Out Lua View", false, -1)]
    private static void OutLuaView(MenuCommand data)
    {
        Generate(data.context as GameObject);
    }
}