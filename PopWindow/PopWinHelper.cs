using System;
using System.Collections.Generic;
using System.Text;
using DevComponents.DotNetBar;
using System.Drawing;
using System.Windows.Forms;

namespace Ray.Framework.PopWindow
{
    public sealed class PopWinHelper
    {
        /// <summary>
        /// 在屏幕右下显示一个POP提示窗口
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Text">内容</param>
        public static void ShowAlert(string Title, string Text)
        {
            Balloon dd = new Balloon();
            dd.Style = eBallonStyle.Office2007Alert;
            dd.AlertAnimation = eAlertAnimation.BottomToTop;
            dd.AlertAnimationDuration = 100;
            Rectangle r = SystemInformation.VirtualScreen;
            dd.Height = 120;
            dd.Location = new Point(r.Width - dd.Width, r.Bottom - dd.Height - 40);
            dd.AutoClose = true;
            dd.AutoCloseTimeOut = 15;
            dd.AlertAnimation = eAlertAnimation.BottomToTop;
            dd.Text = Text;
            dd.CaptionText = Title;
            dd.Show(false);
        }
    }
}
