using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.VelibWS;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private VelibWSClient client;
        public Form1()
        {
            InitializeComponent();
            this.client = new VelibWSClient();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string response = await this.client.GetCitiesAsync();
            string[] cities = Regex.Split(response, @"\n+");
            foreach (string s in cities)
            {
                if (s != "")
                {
                    cityListBox.Items.Add(s);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void cityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cityListBox.SelectedIndices.Count != 0)
            {
                string[] res =  Regex.Split(await client.DisplayStationsAsync(cityListBox.Items[cityListBox.SelectedIndices[0]].Text), @"\n");
                foreach (string s in res)
                {
                    if (s != "")
                    {
                        stationsListView.Items.Add(s);
                    }
                }
            }
            else
            {
                stationsListView.Items.Clear();
                detailListView.Items.Clear();
            }

        }

        private async void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stationsListView.SelectedIndices.Count != 0)
            {
                string[] res = Regex.Split(await client.GetStationAsync(stationsListView.Items[stationsListView.SelectedIndices[0]].Text, cityListBox.Items[cityListBox.SelectedIndices[0]].Text), @"\n");
                foreach (string s in res)
                {
                    if (s != "")
                    {
                        detailListView.Items.Add(s);
                    }
                }
            }
            else
            {
                detailListView.Items.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void detailListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            cityListBox.Items.Clear();
            string[] cities = Regex.Split(await this.client.GetCitiesAsync(), @"\n+");
            foreach (string s in cities)
            {
                if (s != "")
                {
                    cityListBox.Items.Add(s);
                }
            }
        }
    }
}
