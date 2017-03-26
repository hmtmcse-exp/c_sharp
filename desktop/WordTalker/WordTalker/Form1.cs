using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordTalker
{


    public partial class Form1 : Form
    {

        List<Dictionary<string, string>> words = new List<Dictionary<string, string>>();
        SpeechSynthesizer synth = new SpeechSynthesizer();
        Thread thread;
        int lastIndex = 0;
        Boolean isStartTalking = false;
        int sleepTime = 0;

       
        

        private string pullValue(string key,int index)
        {
            Dictionary<string, string> data = words[index];
            return data[key];
        }


        private void loadData()
        {
            if(words.Count() == 0)
            {
                using (TextFieldParser parser = new TextFieldParser(@"ielts_official_1_8.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    listView1.View = View.Details;
                    listView1.GridLines = true;
                    listView1.FullRowSelect = true;
                    listView1.Columns.Add("SL", 100);
                    listView1.Columns.Add("English Word", 100);
                    listView1.Columns.Add("Bangla Meaning", 100);
                    listView1.Columns.Add("Parts of Speech", 100);
                    listView1.Columns.Add("Synonym", 100);
                    Dictionary<string, string> row = new Dictionary<string, string>();
                    int numberOfWord = 0;
                    while (!parser.EndOfData)
                    {
                        row = new Dictionary<string, string>();
                        string[] tmp = parser.ReadFields();
                        string[] fields = new string[tmp.Length + 1];
                        fields[0] = numberOfWord + "";
                        tmp.CopyTo(fields, 1);

                        row.Add("english", fields[1]);
                        row.Add("bangla", fields[2]);
                        words.Add(row);
                        listView1.Items.Add(new ListViewItem(fields));
                        numberOfWord++;
                    }
                }

            }

        }

        delegate void SetTextCallback(List<Dictionary<string, string>> words, int index);
        private void SetText(List<Dictionary<string, string>> words, int index)
        {
            if (this.englishWord.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { words, index });
            }
            else
            {
                this.englishWord.Text = pullValue("english", index);
                lastIndex = index;
                startLine.Text = lastIndex + "";
            }

            if (this.banglaMeaning.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { words, index });
            }
            else
            {
                this.banglaMeaning.Text = pullValue("bangla", index);
                lastIndex = index;
            }


            if (this.listView1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { words, index });
            }
            else
            {
                if (index != 0)
                {
                    listView1.Items[index - 1].Selected = false;
                }
                listView1.Items[index].Selected = true;
                listView1.Items[index].Focused = true;
                listView1.TopItem = listView1.Items[index];
                listView1.Select();

            }
        }

        public void updateLabel()
        {
            synth.SetOutputToDefaultAudioDevice();
            for (int i = lastIndex; i < words.Count(); i++)
            {
                this.SetText(words, i);
                synth.Speak(pullValue("english",i));
                Thread.Sleep(1000 * sleepTime);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!startLine.Text.Equals(0))
            {
                lastIndex = int.Parse(startLine.Text);
            }
            loadData();
            if (isStartTalking)
            {
                isStartTalking = false;
                button1.Text = "Start Talking";
                thread.Abort();
                comboBox1.Enabled = true;
            }
            else
            {
                thread = new Thread(updateLabel);
                thread.Start();
                isStartTalking = true;
                button1.Text = "Stop Talking";
                comboBox1.Enabled = false;
            }
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sleepTime = int.Parse(comboBox1.SelectedItem.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
