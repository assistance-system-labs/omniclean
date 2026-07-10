using System;
using System.Windows.Forms;
using BulkCrapUninstaller.Functions;
using BulkCrapUninstaller.Properties;

namespace BulkCrapUninstaller.Forms
{
    public partial class NewsPopup : Form
    {
        private NewsPopup()
        {
            InitializeComponent();

            if (DesignMode) return;

            var version = Program.AssemblyVersion;
            labelTitle.Text = string.Format(Program.IsAfterUpgrade ? Localisable.NewsPopup_UpdatedTitle : Localisable.NewsPopup_FirstStartTitle,
                version.Major + "." + version.Minor + (version.Build > 0 ? "." + version.Build : string.Empty));

            Settings.Default.SettingBinder.BindControl(checkBoxNeverShow, settings => settings.MiscFeedbackNagNeverShow, this);
            Settings.Default.SettingBinder.SendUpdates(this);
        }

        public static void ShowPopup(Form owner)
        {
            if (Settings.Default.MiscFeedbackNagNeverShow) return;

            using (var news = new NewsPopup())
            {
                news.StartPosition = FormStartPosition.CenterParent;
                news.ShowDialog(owner);
            }
        }

        private void Close(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainWindow.OpenUrls(new[] { new Uri(Resources.GithubReleasesLink) });
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBoxes.DisplayHelp();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FeedbackBox.ShowFeedbackBox(this, false);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainWindow.OpenUrls(new[] { new Uri(Resources.GithubLink) });
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainWindow.OpenUrls(new[] { new Uri(Resources.DonateLink) });
        }
    }
}

