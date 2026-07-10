using System;
using System.Drawing;
using System.Windows.Forms;
using UninstallTools.Junk.WindowsCleaner;

namespace BulkCrapUninstaller.Forms
{
    public class WindowsCleanerWindow : Form
    {
        private CheckBox cbTempFiles;
        private CheckBox cbPrefetch;
        private CheckBox cbUpdateCache;
        private CheckBox cbTelemetry;
        private Button btnClean;
        private Button btnCancel;
        private Label lblDescription;

        public WindowsCleanerWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.cbTempFiles = new CheckBox();
            this.cbPrefetch = new CheckBox();
            this.cbUpdateCache = new CheckBox();
            this.cbTelemetry = new CheckBox();
            this.btnClean = new Button();
            this.btnCancel = new Button();
            this.lblDescription = new Label();
            this.SuspendLayout();

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new Point(12, 15);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(250, 15);
            this.lblDescription.Text = "Select the Windows components you want to clean:";

            // cbTempFiles
            this.cbTempFiles.AutoSize = true;
            this.cbTempFiles.Checked = true;
            this.cbTempFiles.Location = new Point(15, 45);
            this.cbTempFiles.Name = "cbTempFiles";
            this.cbTempFiles.Size = new Size(150, 19);
            this.cbTempFiles.Text = "Temporary Files (%TEMP%, Windows Temp)";

            // cbPrefetch
            this.cbPrefetch.AutoSize = true;
            this.cbPrefetch.Location = new Point(15, 70);
            this.cbPrefetch.Name = "cbPrefetch";
            this.cbPrefetch.Size = new Size(150, 19);
            this.cbPrefetch.Text = "Windows Prefetch Cache";

            // cbUpdateCache
            this.cbUpdateCache.AutoSize = true;
            this.cbUpdateCache.Location = new Point(15, 95);
            this.cbUpdateCache.Name = "cbUpdateCache";
            this.cbUpdateCache.Size = new Size(150, 19);
            this.cbUpdateCache.Text = "Windows Update Cache (SoftwareDistribution)";

            // cbTelemetry
            this.cbTelemetry.AutoSize = true;
            this.cbTelemetry.Location = new Point(15, 120);
            this.cbTelemetry.Name = "cbTelemetry";
            this.cbTelemetry.Size = new Size(150, 19);
            this.cbTelemetry.Text = "Disable Windows Telemetry (DiagTrack)";

            // btnClean
            this.btnClean.Location = new Point(130, 160);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new Size(75, 23);
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new EventHandler(this.btnClean_Click);

            // btnCancel
            this.btnCancel.Location = new Point(220, 160);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // WindowsCleanerWindow
            this.ClientSize = new Size(330, 200);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cbTempFiles);
            this.Controls.Add(this.cbPrefetch);
            this.Controls.Add(this.cbUpdateCache);
            this.Controls.Add(this.cbTelemetry);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WindowsCleanerWindow";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Windows Cleaner & Debloater";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            btnClean.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                if (cbTempFiles.Checked) SystemCleaner.CleanTempFiles();
                if (cbPrefetch.Checked) SystemCleaner.CleanPrefetch();
                if (cbUpdateCache.Checked) SystemCleaner.CleanUpdateCache();
                if (cbTelemetry.Checked) TelemetryDisabler.DisableTelemetry();

                MessageBox.Show(this, "Cleaning completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"An error occurred during cleaning:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
