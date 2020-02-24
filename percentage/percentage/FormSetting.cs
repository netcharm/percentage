using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace percentage
{
    public partial class FormSetting : Form
    {
        internal string FontName { get; set; } = "Segoe UI";
        internal FontStyle FontStyle { get; set; } = FontStyle.Bold;
        internal float FontSize { get; set; } = 22.0F;
        internal Color TextColor { get; set; } = SystemColors.HighlightText;
        internal Color BackgroundColor { get; set; } = Color.Transparent;

        internal void DrawSample()
        {
            lblFont.Text = "0.123456789";
            lblFont.Font = new Font(FontName, FontSize, FontStyle, GraphicsUnit.Point);
            lblFont.ForeColor = TextColor;
            lblFont.BackColor = BackgroundColor;
        }

        public FormSetting()
        {
            InitializeComponent();
            DrawSample();
        }

        private void btnFGDefault_Click(object sender, EventArgs e)
        {
            TextColor = SystemColors.HighlightText;
            DrawSample();
        }

        private void btnBGDefault_Click(object sender, EventArgs e)
        {
            BackgroundColor = Color.Transparent;
            DrawSample();
        }

        private void btnFontDefault_Click(object sender, EventArgs e)
        {
            FontName = "Segoe UI";
            FontStyle = FontStyle.Bold;
            FontSize = 32.0F;
            DrawSample();
        }

        private void btnFG_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = TextColor;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                TextColor = dlg.Color;
                DrawSample();
            }
        }

        private void btnBG_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = BackgroundColor;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                BackgroundColor = dlg.Color;
                DrawSample();
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog() {
                ShowColor = true,
                ShowEffects = true,
                Color = TextColor,
                Font = new Font(FontName, FontSize, FontStyle, GraphicsUnit.Point)
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FontName = string.IsNullOrEmpty(dlg.Font.Name) ? FontName : dlg.Font.Name;
                    FontSize = dlg.Font.Size;
                    FontStyle = dlg.Font.Style;
                    DrawSample();
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
