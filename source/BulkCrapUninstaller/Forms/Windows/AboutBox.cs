using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BulkCrapUninstaller.Properties;
using Klocman.Extensions;
using Klocman.Forms.Tools;
using Klocman.Tools;

namespace BulkCrapUninstaller.Forms
{
    sealed partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            labelVersion.Text += AssemblyVersion;
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            labelis64.Text += ProcessTools.Is64BitProcess.ToYesNo();
            Assembly.GetExecutingAssembly().Modules.First().GetPEKind(out var pekind, out var ifmachine);
            string machine;
            if (Enum.IsDefined<ImageFileMachine>(ifmachine))
            {
                machine = Enum.GetName<ImageFileMachine>(ifmachine);
            } else // Work around .NET 6 not having WoA64 definitions in GetPEKind

            {
                machine = "ARM64";
            }
                labelArchitecture.Text += machine;
            labelPortable.Text += Program.IsInstalled.ToYesNo();

            groupBox4.Visible = false;
        }

        public static string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static Version AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version;

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PremadeDialogs.StartProcessSafely(@"http://objectlistview.sourceforge.net");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PremadeDialogs.StartProcessSafely(
                @"http://www.codeproject.com/Articles/20917/Creating-a-Custom-Settings-Provider");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PremadeDialogs.StartProcessSafely(@"https://github.com/Templarian/WindowsIcons/");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PremadeDialogs.StartProcessSafely(Resources.HomepageUrl);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PremadeDialogs.StartProcessSafely(@"https://nbug.codeplex.com/");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PremadeDialogs.StartProcessSafely(@"http://dotnetzip.codeplex.com/");
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PremadeDialogs.StartProcessSafely(@"http://taskscheduler.codeplex.com/");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PremadeDialogs.StartProcessSafely(@"https://github.com/TestStack/White");
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PremadeDialogs.StartProcessSafely(@"https://www.voidtools.com/");
        }
    }
}

