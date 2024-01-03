using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Play
{
    public partial class Form1 : Form
    {
        string[] paths, files;
        public Form1()
        {
            InitializeComponent();

            track_volume.Value = 50;
            lbl_volume.Text = "50%";
        }

        private void track_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            player.URL = paths[track_list.SelectedIndex];
            player.Ctlcontrols.play();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.stop();
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.play();
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.pause();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if(track_list.SelectedIndex<= track_list.Items.Count -2)
                track_list.SelectedIndex =track_list.SelectedIndex+1;
            else
                track_list.SelectedIndex =0;
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            if(track_list.SelectedIndex>=1)
                track_list.SelectedIndex = track_list.SelectedIndex -1;
            else
                track_list.SelectedIndex =track_list.Items.Count -1;

        }


        private void track_volume_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = track_volume.Value;
            lbl_volume.Text = track_volume.Value.ToString() + "%";
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog(); 
            od.Multiselect= true;
            if(od.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = od.FileNames;
                paths= od.FileNames;
                for (int x = 0; x < files.Length; x++)
                {
                    files[x] = files[x].Split('\\')[files[x].Split('\\').Length - 1];
                    track_list.Items.Add(files[x]);
                }
            }
        }
    }
}
