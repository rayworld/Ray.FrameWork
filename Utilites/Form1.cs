using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ray.Framework.Utilities
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                string text = "\n sb.Append(\" ";
                string text2 = " \");\r";
                if (this.tbxSb.TextLength != 0)
                {
                    string text3 = this.tbxSb.Text.ToString().Trim();
                    text = text.Replace("sb", text3);
                }
                string text4 = this.tbxSource.Text.ToString();
                string text5 = this.tbxTarget.Text.ToString();
                try
                {
                    text5 = text4.Replace("\"\"", "\"");
                    text5 = text5.Replace("\"", "\\\"");
                    text5 = text5.Replace("\r", text2);
                    text5 = text5.Replace("\n", text);
                    this.tbxTarget.Text = (text + text5 + text2);
                    tbxTarget.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else  //翻转生成
            {
                string text = tbxSource.Text.Replace(tbxSb.Text.Trim() + @".AppendLine(" + '"', "");
                text = text.Replace(tbxSb.Text.Trim() + @".Append(" + '"', "");
                text = text.Replace('"' + ");", "");
                tbxTarget.Text = text;

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(tbxTarget.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
