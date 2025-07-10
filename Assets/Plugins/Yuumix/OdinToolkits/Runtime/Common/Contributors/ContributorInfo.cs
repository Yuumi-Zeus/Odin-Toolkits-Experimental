using Sirenix.OdinInspector;
using System;
using UnityEngine;
using Yuumix.OdinToolkits.Common;

namespace Yuumix.OdinToolkits.Common
{
    [Serializable]
    public class ContributorInfo
    {
        [BoxGroup("1", false)]
        [HorizontalGroup("1/1")]
        [GUIColor("green")]
        [DisplayAsString(EnableRichText = true, FontSize = 15)]
        [EnableGUI]
        [HideLabel]
        [ShowInInspector]
        [HideIf("TimeIsNull")]
        public string Time { get; set; }

        bool TimeIsNull => Time.IsNullOrWhiteSpace();

        [BoxGroup("1")]
        [ShowInInspector]
        [DisplayAsString(EnableRichText = true, FontSize = 15)]
        [HorizontalGroup("1/1")]
        [HideLabel]
        [EnableGUI]
        [HideIf("NameIsNull")]
        public string Name { get; set; }

        bool NameIsNull => Name.IsNullOrWhiteSpace();

        [BoxGroup("1")]
        [ShowInInspector]
        [HorizontalGroup("1/1")]
        [HideLabel]
        [EnableGUI]
        [DisplayAsString(EnableRichText = true, FontSize = 15)]
        [HideIf("EmailIsNull")]
        public string Email { get; set; }

        bool EmailIsNull => Email.IsNullOrWhiteSpace();

        [BoxGroup("1")]
        [DisplayAsString(EnableRichText = true, FontSize = 15)]
        [HorizontalGroup("1/2")]
        [HideLabel]
        [EnableGUI]
        [ShowInInspector]
        [HideIf("LinkIsNull")]
        public string Link { get; set; }

        bool LinkIsNull => Link.IsNullOrWhiteSpace();

        [BoxGroup("1")]
        [ShowIfChinese]
        [HorizontalGroup("1/2", 0.3f)]
        [Button("打开链接", 25)]
        [HideIf("LinkIsNull")]
        public void OpenLink()
        {
            Application.OpenURL(Link);
        }

        [BoxGroup("1")]
        [ShowIfEnglish]
        [HorizontalGroup("1/2", 0.3f)]
        [Button("Open Link", 25)]
        [HideIf("LinkIsNull")]
        public void OpenLink2()
        {
            Application.OpenURL(Link);
        }

        /// <summary>
        /// 全参数构造函数
        /// </summary>
        /// <param name="time">使用 2025/06/15 的样式</param>
        /// <param name="name">贡献者名称</param>
        /// <param name="email">邮箱</param>
        /// <param name="link">自定义的链接（与作者有关）</param>
        public ContributorInfo(string time, string name, string email,
            string link)
        {
            Time = time;
            Name = name;
            Email = email;
            Link = link;
        }

        public ContributorInfo(string name, string email, string link)
        {
            Name = name;
            Email = email;
            Link = link;
        }

        public ContributorInfo(string name)
        {
            Name = name;
            Email = "";
            Link = "";
        }

        public ContributorInfo(string name, string email)
        {
            Name = name;
            Email = email;
            Link = "";
        }

        public override string ToString() => $"{Time} - {Name} - {Email} - {Link}";
    }
}
