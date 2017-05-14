using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaffoldGenerator
{
    public partial class Form1 : Form
    {

        int listView1SelectedIndex = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Display Name");
            listView1.Columns.Add("Error Message");
            listView1.Columns.Add("Data Type");
            listView1.Columns.Add("Name");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(listView1SelectedIndex == -1)
            {
                addItem();
            }
            else
            {
                updateItem();
            }
            clearAllText();
        }

        private void addItem()
        {
            string[] row = { name.Text, displayName.Text, errorMessage.Text, dataType.Text };
            var listViewItem = new ListViewItem(row);
            listView1.Items.Add(listViewItem);
        }

        private void updateItem()
        {
            ListViewItem item = listView1.Items[listView1SelectedIndex];
            item.SubItems[0].Text = name.Text;
            item.SubItems[1].Text = displayName.Text;
            item.SubItems[2].Text = errorMessage.Text;
            item.SubItems[3].Text = dataType.Text;
        }

        private void clearAllText()
        {
            listView1SelectedIndex = -1;
            name.Text = "";
            displayName.Text = "";
            errorMessage.Text = "";
            dataType.Text = "";
            AddUpdateButton.Text = "Add";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.SelectedItems[0];
            listView1SelectedIndex =item.Index;
            name.Text = item.SubItems[0].Text;
            displayName.Text = item.SubItems[1].Text;
            errorMessage.Text = item.SubItems[2].Text;
            dataType.Text = item.SubItems[3].Text;
            AddUpdateButton.Text = "Update";
        }

        private void Clearr(object sender, EventArgs e)
        {

        }

        private void Clear(object sender, EventArgs e)
        {
            clearAllText();
        }
    }
}
