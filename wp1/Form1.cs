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

namespace wp1
{
    public partial class Form1 : Form
    {
        int counter;
        Stack<string> st = new Stack<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DirectoryInfo di = new DirectoryInfo(@"C:\");
            DirectoryInfo[] x = di.GetDirectories();
            for (int i = 0; i < x.Length; ++i)
            {
                listView1.Items.Add(x[i].FullName);
                
            }
            
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar==(char)Keys.Back)
            {
                st.Pop();
                int count = listView1.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    listView1.Items[0].Remove();
                }
                if (st.Count==0)
                {
                    st.Push(@"C:\");
                }
                DirectoryInfo di = new DirectoryInfo(@"" + st.Peek());
                DirectoryInfo[] x = di.GetDirectories();
                for (int i = 0; i < x.Length; ++i)
                {
                    listView1.Items.Add(x[i].FullName);

                }

            }
            if (e.KeyChar==(char)Keys.Enter)
            {
                 int count = listView1.Items.Count;
                for (int i=0; i<listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected==true)
                    {
                        counter = i;
                    }
                }
                string path = listView1.Items[counter].Text;
                st.Push(path);
                for (int i=0; i<count; i++)
                {
                    listView1.Items[0].Remove();
                }
                DirectoryInfo di = new DirectoryInfo(@""+path);
                DirectoryInfo[] x = di.GetDirectories();
                for (int i = 0; i < x.Length; ++i)
                {
                    listView1.Items.Add(x[i].FullName);
                   

                }
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }
    }
}
