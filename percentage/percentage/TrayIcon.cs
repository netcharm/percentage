using System;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace percentage
{
    class TrayIcon
    {
        private static string APPPATH = Application.ExecutablePath;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool DestroyIcon(IntPtr handle);

        private string iconFontName = "Segoe UI";
        private float iconFontSize = 24.0F;
        private FontStyle iconFontStyle = FontStyle.Regular;
        private Font iconFont = null;
        private Color iconForeColor = SystemColors.HighlightText;
        private Color iconBackColor = Color.Transparent;

        private string batteryPercentage;
        private NotifyIcon notifyIcon;

        private Image DrawText(string text, Font font, Color textColor, Color backColor)
        {
            var textSize = GetImageSize(text, font);
            int ox = (int)Math.Floor(textSize.Width * 0.07);
            int oy = (int)Math.Floor(textSize.Height * 0.07);
            Image image = new Bitmap((int) textSize.Width-(ox*2), (int) textSize.Height-(ox*2), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                // paint the background
                graphics.Clear(backColor);

                // create a brush for the text
                using (Brush textBrush = new SolidBrush(textColor))
                {
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    graphics.DrawString(text, font, textBrush, -ox, -oy);
                    graphics.Save();
                }
            }
            return image;
        }

        private SizeF GetImageSize(string text, Font font)
        {
            SizeF size = new SizeF(16, 16);
            using (Image image = new Bitmap(48, 48))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    size = graphics.MeasureString(text, font);
                }
            }
            return (size);
        }

        private void LoadSetting()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration( Application.ExecutablePath );
            AppSettingsSection appSection = config.AppSettings;
            //appSection.File = config.FilePath.ToLowerInvariant();

            if (appSection.Settings["FontName"] != null)
            {
                iconFontName = appSection.Settings["FontName"].Value;
            }
            if (appSection.Settings["FontSize"] != null)
            {
                iconFontSize = Convert.ToSingle(appSection.Settings["FontSize"].Value);
            }
            if (appSection.Settings["FontStyle"] != null)
            {
                iconFontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), appSection.Settings["FontStyle"].Value);
            }

            if (appSection.Settings["TextColor"] != null)
            {
                iconForeColor = ColorTranslator.FromHtml(appSection.Settings["TextColor"].Value);
            }
            if (appSection.Settings["BackColor"] != null)
            {
                iconBackColor = ColorTranslator.FromHtml(appSection.Settings["BackColor"].Value);
            }
        }

        private void SaveSetting()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration( Application.ExecutablePath );
            AppSettingsSection appSection = config.AppSettings;
            //appSection.File = config.FilePath.ToLowerInvariant();

            if (appSection.Settings["FontName"] != null)
            {
                appSection.Settings["FontName"].Value = iconFontName;
            }
            else
            {
                appSection.Settings.Add("FontName", iconFontName);
            }
            if (appSection.Settings["FontSize"] != null)
            {
                appSection.Settings["FontSize"].Value = iconFontSize.ToString();
            }
            else
            {
                appSection.Settings.Add("FontSize", iconFontSize.ToString());
            }
            if (appSection.Settings["FontStyle"] != null)
            {
                appSection.Settings["FontStyle"].Value = iconFontStyle.ToString();
            }
            else
            {
                appSection.Settings.Add("FontStyle", iconFontStyle.ToString());
            }

            if (appSection.Settings["TextColor"] != null)
            {
                appSection.Settings["TextColor"].Value = ColorTranslator.ToHtml(iconForeColor);
            }
            else
            {
                appSection.Settings.Add("TextColor", ColorTranslator.ToHtml(iconForeColor));
            }
            if (appSection.Settings["BackColor"] != null)
            {
                appSection.Settings["BackColor"].Value = ColorTranslator.ToHtml(iconBackColor);
            }
            else
            {
                appSection.Settings.Add("BackColor", ColorTranslator.ToHtml(iconBackColor));
            }

            config.Save(ConfigurationSaveMode.Full);
        }

        public TrayIcon()
        {
            LoadSetting();

            iconFont = new Font(iconFontName, iconFontSize, iconFontStyle, GraphicsUnit.Point);

            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItemExit = new MenuItem();
            MenuItem menuItemSetting = new MenuItem();
            MenuItem menuItemSep = new MenuItem("-");

            notifyIcon = new NotifyIcon();

            // initialize contextMenu
            contextMenu.MenuItems.AddRange(new MenuItem[] { menuItemSetting, menuItemSep, menuItemExit });

            // initialize menuItem
            menuItemExit.Index = 2;
            menuItemExit.Text = "E&xit";
            menuItemExit.Click += new EventHandler(menuItemExit_Click);

            menuItemSetting.Index = 0;
            menuItemSetting.Text = "&Setting";
            menuItemSetting.Click += new EventHandler(menuItemSetting_Click);

            notifyIcon.ContextMenu = contextMenu;

            batteryPercentage = "?";

            notifyIcon.Visible = true;

            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000; // in miliseconds
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PowerStatus powerStatus = SystemInformation.PowerStatus;
            batteryPercentage = (powerStatus.BatteryLifePercent * 100).ToString();

            //using (Bitmap bitmap = new Bitmap(DrawText(batteryPercentage, new Font(iconFont, iconFontSize), Color.White, Color.Black)))
            if (!(iconFont is Font)) iconFont = new Font(iconFontName, iconFontSize);
            using (Bitmap bitmap = new Bitmap(DrawText(batteryPercentage, iconFont, iconForeColor, iconBackColor)))
            {
                IntPtr intPtr = bitmap.GetHicon();
                try
                {
                    using (Icon icon = Icon.FromHandle(intPtr))
                    {
                        notifyIcon.Icon = icon;
                        notifyIcon.Text = batteryPercentage + "%";
                    }
                }
                finally
                {
                    DestroyIcon(intPtr);
                }
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void menuItemSetting_Click(object sender, EventArgs e)
        {
            FormSetting dlg = new FormSetting() {
                TextColor = iconForeColor,
                BackColor = iconBackColor,
                FontName = iconFontName,
                FontSize = iconFontSize,
                FontStyle = iconFontStyle
            };
            dlg.DrawSample();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    iconFont = new Font(dlg.FontName, dlg.FontSize, dlg.FontStyle, GraphicsUnit.Point);
                    iconFontName = dlg.FontName;
                    iconFontSize = dlg.FontSize;
                    iconFontStyle = dlg.FontStyle;
                    iconForeColor = dlg.TextColor;
                    iconBackColor = dlg.BackColor;
                    SaveSetting();
                }
                catch(Exception)
                {

                }
            }
            dlg.Dispose();
        }
    }
}
