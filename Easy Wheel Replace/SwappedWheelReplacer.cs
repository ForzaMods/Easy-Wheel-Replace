using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Easy_Wheel_Replace
{
    public partial class SwappedWheelReplacer : Form
    {
        #region logger
        public class Logger
        {
            private string logFilePath;

            public Logger(string filePath)
            {
                logFilePath = filePath;
            }

            public void Log(string message)
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    string logEntry = $"{DateTime.Now} - {message}";
                    writer.WriteLine(logEntry);
                }
            }
        }
        #endregion

        int selected = 123;

        public SwappedWheelReplacer()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            InitializeComponent();
            List();
        }

        void List()
        {
            string[] wheels = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EasyWheelSwapper\OriginalWheelBackup", "*.zip");
            foreach (var wheel in wheels)
            {
                LST_BackedUpList.Items.Add(Path.GetFileName(wheel));
            }
        }

        private void BTN_RevetWheels_Click(object sender, EventArgs e)
        {
            var BaseDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EasyWheelSwapper";
            var logfile = BaseDir + @"\Logs" + @"\" + LST_BackedUpList.SelectedItem + "." + DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm") + "-Revert.log";
            using (File.Create(logfile)) { };
            Logger logger = new Logger(logfile);

            if (selected != 123)
            {
                logger.Log("Starting revert");
                try
                {
                    File.Delete(Globalvars.basegamedir + @"\media\cars\_library\scene\wheels" + @"\" + LST_BackedUpList.SelectedItem);
                    logger.Log("Delete swapped wheel");
                    File.Copy(BaseDir + @"\OriginalWheelBackup" + @"\" + LST_BackedUpList.SelectedItem, Globalvars.basegamedir + @"\media\cars\_library\scene\wheels" + @"\" + LST_BackedUpList.SelectedItem);
                    logger.Log("Copy original wheel");
                    File.Delete(BaseDir + @"\OriginalWheelBackup" + @"\" + LST_BackedUpList.SelectedItem);
                    logger.Log("Delete original wheel from the backups");
                    logger.Log("Successfully reverted");
                    LST_BackedUpList.Items.Clear();
                    List();
                    LST_BackedUpList.SelectedIndex = 0;
                catch(Exception ex) { MessageBox.Show(ex.Message); logger.Log(ex.Message); }

                DialogResult dialogResult = MessageBox.Show("Do you wanna see the log file of the swapped wheel?", "Logging", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo(logfile) { UseShellExecute = true });
                }
            }
        }
            else if (selected == 123)
                MessageBox.Show("Select a wheel first smh");
        }

        private void LST_BackedUpList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = LST_BackedUpList.SelectedIndex;
        }

        private void OriginalWheelReplacer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Globalvars.IsOpen = false;
            Globalvars.TimesOpened = 0;
        }
    }
}
