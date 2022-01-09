using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;


namespace Easy_Wheel_Replace
{
    public partial class EasyWheelReplace : Form
    {
        public EasyWheelReplace()
        {
            InitializeComponent();
        }
        string GamePath;
        bool PathCorrect = false;
        string[] WantedWheelsList;
        string[] TargetWheelsList;
        int wantedwheelsindex = 69420;
        int targetedwheelsindex  = 69420;
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (PathCorrect==false)
            {
                OpenFH5Folder.ShowDialog();
                GamePath = new FileInfo(OpenFH5Folder.FileName).DirectoryName;
                if (File.Exists(GamePath + "\\ForzaHorizon5.exe"))
                {
                    TXT_Gamepath.Text = new FileInfo(OpenFH5Folder.FileName).DirectoryName;
                    PathCorrect = true;
                    PopulateDropdown();
                }
                else
                {
                    PathCorrect = false;
                    MessageBox.Show("Folder selected does not contain the ForzaHorizon5.exe file \nTry again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
                MessageBox.Show("Game Folder already selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void PopulateDropdown()
        {
            WantedWheelsList = Directory.GetFiles(GamePath + "\\media\\cars");
            for (int i = 0;i < WantedWheelsList.Length;i++)
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

        private void BTN_ReplaceWheels_Click(object sender, EventArgs e)
        {
            if (targetedwheelsindex != 69420 && wantedwheelsindex != 69420)
            {
                if(Directory.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\EasyWheelSwapper\Temp"))
                {
                    BTN_ReplaceWheels.Enabled = false;
                    swapwheels();
                }
                else
                {
                    Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\EasyWheelSwapper");
                    Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\EasyWheelSwapper\Temp");
                    Directory.CreateDirectory(@"C:\Users\" + Environment.UserName + @"\Documents\EasyWheelSwapper\OriginalWheelBackup");
                    BTN_ReplaceWheels.Enabled=false;
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
            
            var wantedwheelpath = WantedWheelsList[wantedwheelsindex];
            var targetwheelpath = TargetWheelsList[targetedwheelsindex];
            var targetmedianame = LST_TargetWheels.SelectedItem.ToString();
            var wantedmedianame = LST_WantedWheels.SelectedItem.ToString();
            string tempfolder = @"C:\Users\" + Environment.UserName + @"\Documents\EasyWheelSwapper\Temp\";
            //TXT_Progress.Items.Add("Replacing wheel: " + LST_TargetWheels.SelectedItem + " with wheel: " + LST_WantedWheels.SelectedItem);
            //TXT_Progress.Items.Add("Backing up original wheel zip to: " + @"C:\Users\" + Environment.UserName + @"\Documents\EasyWheelSwapper\OriginalWheelBackup\" + LST_TargetWheels.SelectedItem);
            if (!File.Exists(@"C:\Users\" + Environment.UserName + @"\Documents\EasyWheelSwapper\OriginalWheelBackup\" + LST_TargetWheels.SelectedItem))
                File.Copy(targetwheelpath, @"C:\Users\" + Environment.UserName + @"\Documents\EasyWheelSwapper\OriginalWheelBackup\" + LST_TargetWheels.SelectedItem);
            //TXT_Progress.Items.Add("Moving wheels to " + tempfolder);
            File.Copy(wantedwheelpath, tempfolder + LST_WantedWheels.SelectedItem);
            File.Move(targetwheelpath, tempfolder + LST_TargetWheels.SelectedItem);
            //TXT_Progress.Items.Add("Extracting Wheel zips to: " + tempfolder);
            ZipFile.ExtractToDirectory(tempfolder + LST_WantedWheels.SelectedItem, tempfolder + @"\W\");
            ZipFile.ExtractToDirectory(tempfolder + LST_TargetWheels.SelectedItem, tempfolder + @"\T\");
            Directory.CreateDirectory(tempfolder + @"\N\");
            Directory.CreateDirectory(tempfolder + @"\N\Textures");
            Directory.CreateDirectory(tempfolder + @"\N\Textures\AO\");
            //TXT_Progress.Items.Add("Renaming and replacing wheel files");
            File.Move(tempfolder + @"\W\scene\_library\scene\Wheels\" + wantedmedianame.Substring(0, wantedmedianame.Length - 4) + "_wheelLF.modelbin", tempfolder + @"\N\" + targetmedianame.Substring(0, targetmedianame.Length - 4) + "_wheelLF.modelbin");

            if (File.Exists(tempfolder + @"\W\Textures\AO\" + wantedmedianame.Substring(0, wantedmedianame.Length - 4) + "_wheelLF_AO.swatchbin"))
            {
                File.Move(tempfolder + @"\W\Textures\AO\" + wantedmedianame.Substring(0, wantedmedianame.Length - 4) + "_wheelLF_AO.swatchbin", tempfolder + @"\N\Textures\AO\" + targetmedianame.Substring(0, targetmedianame.Length - 4) + "_wheelLF_AO.swatchbin");
            }
            else
            {
                var found = false;
                //TXT_Progress.Items.Add("Texture not present in car zip. Searching Textures.zip");
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
                    //TXT_Progress.Items.Add("Texture not present in Textures.zip. Searching Textures_pri_45.zip");
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
            //TXT_Progress.Items.Add("Creating new zip to replace: " + targetwheelpath);
            ZipFile.CreateFromDirectory(tempfolder + @"\N\", targetwheelpath);


            //TXT_Progress.Items.Add("Deleting contents of: " + tempfolder);
            Directory.Delete(tempfolder, true);
            Directory.CreateDirectory(tempfolder);
            BTN_ReplaceWheels.Enabled = true;
        }
    }
}
