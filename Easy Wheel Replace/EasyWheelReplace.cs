using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using IniParser.Model;
using IniParser;
using System.Linq;
using System.Diagnostics;

namespace Easy_Wheel_Replace
{
    public partial class EasyWheelReplace : Form
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
        #region vars
        string GamePath;
        bool PathCorrect = false;
        private string[] WantedWheelsList;
        string[] TargetWheelsList;
        string targetwheelpath;
        int wantedwheelsindex = 69420;
        int targetedwheelsindex = 69420;
        string BaseDir;
        string targerwheelrc0path;
        #endregion

        public EasyWheelReplace()
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            InitializeComponent();

            #region settings
            var settingsParser = new FileIniDataParser();
            IniData settingsData = new IniData();

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EasyWheelSwapper"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EasyWheelSwapper");

            BaseDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EasyWheelSwapper";

            if (!File.Exists(BaseDir + @"\Settings.ini"))
            {
                using (File.Create(BaseDir + @"\Settings.ini")) { }
                var SettingsFile = BaseDir + @"\Settings.ini";

                settingsData["Settings"]["Path"] = "Not selected";
                settingsParser.WriteFile(SettingsFile, settingsData);
            }

            IniData Settings = settingsParser.ReadFile(BaseDir + @"\Settings.ini");
            string pathvalue = Settings["Settings"]["Path"];
            Globalvars.basegamedir = Settings["Settings"]["Path"];

            if (File.Exists(BaseDir + @"\Settings.ini") && pathvalue != "Not selected")
            {
                GamePath = pathvalue;
                TXT_Gamepath.Text = GamePath;
                LST_TargetWheels.Enabled = true;
                LST_WantedWheels.Enabled = true;
                BTN_ReplaceWheels.Enabled = true;
                PopulateDropdown();
            }
            else
            {
                LST_TargetWheels.Enabled = false;
                LST_WantedWheels.Enabled = false;
                BTN_ReplaceWheels.Enabled = false;
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            GamePath = dialog.SelectedPath;

            if (result == DialogResult.OK)
            {
                if (File.Exists(GamePath + @"\ForzaHorizon5.exe"))
                {
                    TXT_Gamepath.Text = new FileInfo(GamePath + @"\ForzaHorizon5.exe").DirectoryName;
                    if (File.Exists(BaseDir + @"\Settings.ini"))
                    {
                        var SettingsFile = BaseDir + @"\Settings.ini";
                        var SettingsParser = new FileIniDataParser();
                        IniData Settings = new IniData();
                        Settings["Settings"]["Path"] = GamePath;
                        Globalvars.basegamedir = GamePath;
                        SettingsParser.WriteFile(SettingsFile, Settings);
                    }
                    PathCorrect = true;
                    LST_TargetWheels.Enabled = true;
                    LST_WantedWheels.Enabled = true;
                    BTN_ReplaceWheels.Enabled = true;
                    PopulateDropdown();
                }
                else
                {
                    PathCorrect = false;
                    MessageBox.Show("Select a correct path");
                }
            }
            else
            {
                PathCorrect = false;
                MessageBox.Show("No location selected");
            }
        }

        private void PopulateDropdown()
        {
            WantedWheelsList = GetFilteredFileNames(GamePath + @"\media\cars");

            for (int i = 0; i < WantedWheelsList.Length; i++)
            {
                var sections = (WantedWheelsList[i].Split('\\'));
                var fileName = sections[sections.Length - 1];
                LST_WantedWheels.Items.Add(fileName);
            }
            TargetWheelsList = Directory.GetFiles(GamePath + "\\media\\cars\\_library\\scene\\wheels");
            for (int i = 0; i < TargetWheelsList.Length; i++)
            {
                var sections = (TargetWheelsList[i].Split('\\'));
                var fileName = sections[sections.Length - 1];
                LST_TargetWheels.Items.Add(fileName);
            }
        }

        //filter all cars but the welcome pack ones
        private string[] GetFilteredFileNames(string folderPath)
        {
            string[] allFileNames = Directory.GetFiles(folderPath);
            string[] filteredFileNames = allFileNames.Where(fileName => !fileName.Contains("WP_")).ToArray();
            return filteredFileNames;
        }

        private void BTN_ReplaceWheels_Click(object sender, EventArgs e)
        {
            if (targetedwheelsindex != 69420 && wantedwheelsindex != 69420)
            {
                if (Directory.Exists(BaseDir + @"\Temp") && Directory.Exists(BaseDir + @"\OriginalWheelBackup") && Directory.Exists(BaseDir + @"\Logs"))
                {
                    BTN_ReplaceWheels.Enabled = false;
                    swapwheels();
                }
                else
                {
                    Directory.CreateDirectory(BaseDir);
                    Directory.CreateDirectory(BaseDir + @"\Temp");
                    Directory.CreateDirectory(BaseDir + @"\OriginalWheelBackup");
                    Directory.CreateDirectory(BaseDir + @"\Logs");
                    BTN_ReplaceWheels.Enabled = false;
                    swapwheels();
                }
            }
            else
                MessageBox.Show("Options not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LST_WantedWheels_SelectedIndexChanged(object sender, EventArgs e)
        {
            wantedwheelsindex = LST_WantedWheels.SelectedIndex;
        }

        private void LST_TargetWheels_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetedwheelsindex = LST_TargetWheels.SelectedIndex;
        }
        void swapwheels()
        {
            StatusBar.Enabled = true;
            StatusBar.Value = 0;
            var wantedwheelpath = WantedWheelsList[wantedwheelsindex];
            targetwheelpath = TargetWheelsList[targetedwheelsindex];
            var targetmedianame = LST_TargetWheels.SelectedItem.ToString();
            var wantedmedianame = LST_WantedWheels.SelectedItem.ToString();
            targerwheelrc0path = GamePath + @"\media\stripped\mediaoverride\rc0\cars\_library\scene\wheels";
            if (!File.Exists(targerwheelrc0path))
                Directory.CreateDirectory(targerwheelrc0path);
            var logfile = BaseDir + @"\Logs" + @"\" + targetmedianame + "." + DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm") + ".log";
            using (File.Create(logfile)) { };
            Logger logger = new Logger(logfile);
            string tempfolder = BaseDir + @"\Temp\";
            StatusBar.Value = 15;
            logger.Log("Replacing wheel: " + LST_TargetWheels.SelectedItem + " with wheel: " + LST_WantedWheels.SelectedItem);
            logger.Log("Backing up original wheel zip to: " + BaseDir + @"\OriginalWheelBackup\" + LST_TargetWheels.SelectedItem);

            if (!File.Exists(BaseDir + @"\OriginalWheelBackup\" + LST_TargetWheels.SelectedItem))
                File.Copy(targetwheelpath, BaseDir + @"\OriginalWheelBackup\" + LST_TargetWheels.SelectedItem);
            logger.Log("Moving wheels to " + tempfolder);
            StatusBar.Value = 30;
            try
            {
                File.Copy(wantedwheelpath, tempfolder + LST_WantedWheels.SelectedItem);
                File.Move(targetwheelpath, tempfolder + LST_TargetWheels.SelectedItem);
                logger.Log("Extracting Wheel zips to: " + tempfolder);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); logger.Log("Failed at:" + ex.Message); revert(); }
            StatusBar.Value = 45;
            try
            {
                ZipFile.ExtractToDirectory(tempfolder + LST_WantedWheels.SelectedItem, tempfolder + @"\W\");
                ZipFile.ExtractToDirectory(tempfolder + LST_TargetWheels.SelectedItem, tempfolder + @"\T\");
                Directory.CreateDirectory(tempfolder + @"\N\");
                Directory.CreateDirectory(tempfolder + @"\N\Textures");
                Directory.CreateDirectory(tempfolder + @"\N\Textures\AO\");
                logger.Log("Renaming and replacing wheel files");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); logger.Log("Failed at:" + ex.Message); revert(); }

            StatusBar.Value = 60;
            try
            {
                File.Move(tempfolder + @"\W\scene\_library\scene\Wheels\" + wantedmedianame.Substring(0, wantedmedianame.Length - 4) + "_wheelLF.modelbin", tempfolder + @"\N\" + targetmedianame.Substring(0, targetmedianame.Length - 4) + "_wheelLF.modelbin");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); revert(); }

            if (File.Exists(tempfolder + @"\W\Textures\AO\" + wantedmedianame.Substring(0, wantedmedianame.Length - 4) + "_wheelLF_AO.swatchbin"))
            {
                try
                {
                    logger.Log("Moving wheel files");
                    File.Move(tempfolder + @"\W\Textures\AO\" + wantedmedianame.Substring(0, wantedmedianame.Length - 4) + "_wheelLF_AO.swatchbin", tempfolder + @"\N\Textures\AO\" + targetmedianame.Substring(0, targetmedianame.Length - 4) + "_wheelLF_AO.swatchbin");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); logger.Log("Failed at:" + ex.Message); revert(); }
            }
            else
            {
                try
                {
                    StatusBar.Value = 70;
                    var found = false;
                    logger.Log("Texture not present in car zip. Searching Textures.zip");
                    using (ZipArchive archive = ZipFile.OpenRead(GamePath + @"\media\cars\_library\Textures.zip"))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (entry.FullName.Contains(wantedmedianame.Substring(0, wantedmedianame.Length - 4) + "_wheellf", StringComparison.OrdinalIgnoreCase))
                            {
                                archive.GetEntry(entry.FullName).ExtractToFile(tempfolder + @"\N\Textures\AO\" + targetmedianame.Substring(0, targetmedianame.Length - 4) + "_wheelLF_AO.swatchbin");
                                found = true;
                                break;
                            }
                        }
                    }
                    if (!found)
                    {
                        logger.Log("Texture not present in Textures.zip. Searching Textures_pri_45.zip");
                        using (ZipArchive archive = ZipFile.OpenRead(GamePath + @"\media\cars\_library\Textures_pri_45.zip"))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                if (entry.FullName.Contains(wantedmedianame.Substring(0, wantedmedianame.Length - 4) + "_wheellf", StringComparison.OrdinalIgnoreCase))
                                {
                                    archive.GetEntry(entry.FullName).ExtractToFile(tempfolder + @"\N\Textures\AO\" + targetmedianame.Substring(0, targetmedianame.Length - 4) + "_wheelLF_AO.swatchbin");
                                    break;
                                }
                            }
                        }
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); logger.Log("Failed at:" + ex.Message); revert(); }
            }
            StatusBar.Value = 85;
            logger.Log("Creating new zip in: " + targerwheelrc0path + @"\" + LST_TargetWheels.SelectedItem);
            ZipFile.CreateFromDirectory(tempfolder + @"\N\", targerwheelrc0path + @"\" + LST_TargetWheels.SelectedItem);

            logger.Log("Deleting contents of: " + tempfolder);
            Directory.Delete(tempfolder, true);
            Directory.CreateDirectory(tempfolder);
            BTN_ReplaceWheels.Enabled = true;
            StatusBar.Value = 100;
            StatusBar.Enabled = false;

            DialogResult dialogResult = MessageBox.Show("Do you wanna see the log file of the swapped wheel?", "Logging", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start(new ProcessStartInfo(logfile) { UseShellExecute = true });
            }
        }

        private void revert()
        {
            File.Delete(targerwheelrc0path + @"\" + LST_TargetWheels.SelectedItem);
        }

        private void RevertWheels_Click(object sender, EventArgs e)
        {
            SwappedWheelReplacer swappedWheelReplacer = new SwappedWheelReplacer();
            if (!Globalvars.IsOpen)
            {
                Globalvars.IsOpen = true;
                Globalvars.TimesOpened++;
                swappedWheelReplacer.Show();
            }

            // Funne little easter egg from me
            if (Globalvars.IsOpen)
                Globalvars.TimesOpened++;

            if (Globalvars.TimesOpened >= 5)
                MessageBox.Show("stop spamming this button you fucking retard");
        }
    }
}
