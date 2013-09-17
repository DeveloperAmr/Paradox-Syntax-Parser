using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SyntaxParser
{
    public partial class mainform : Form
    {
        string filelocation;
        List<List<string>> items = new List<List<string>>();

        public mainform()
        {
            InitializeComponent();
        }

        int ReadSyntax(int linenum, string[] file) //used to read from curly bracket to curly bracket, returns the line number of the closing bracket, if end of file then returns 0
        {
            for (; linenum < file.Length; linenum++)
            {
                string line = file[linenum];
                if (line.Contains('}') && !line.Contains('{'))
                {
                    return linenum;
                }
                else
                {
                    if (line.Contains('{') && !line.Contains('}'))
                    {
                        linenum = ReadSyntax(linenum + 1, file);
                    }
                }
            }

            return 0;
        }

        string[] SplitComments(string rawline) //splits the line from the comment, returns the line on 0 and the comment on 1
        {
            string[] split = { "", "" };

            if (rawline.Split('#').Length > 1)
            {
                split[0] = rawline.Split('#')[0];
                split[1] = "#" + rawline.Split('#')[1];
            }
            else
            {
                split[0] = rawline;
            }

            return split;
        }

        List<string> LoadSyntaxFirstLevel(string[] file) //parse the items in the first level of code blocks, returns null on syntax error
        {
            List<string> items = new List<string>();

            for (int i = 0; i < file.Length; i++)
            {
                string line = SplitComments(file[i])[0];
                string comment = SplitComments(file[i])[1];

                if (line == "")
                {
                    continue;
                }

                if (line.Contains("{"))
                {
                    items.Add(line.Split('=')[0].Trim());
                    i = ReadSyntax(i + 1, file);
                    if (i == 0)
                    {
                        return null;
                    }
                }
            }

            return items;
        }

        List<List<string>> LoadSyntaxSecondLevel(string[] file) //parse the items in the second level of code blocks. this will return of list of lists that contains the second level item. the order of the list is the same as the file. returns null on syntax error
        {
            List<List<string>> items = new List<List<string>>();

            for (int i = 0; i < file.Length; i++)
            {
                string line = SplitComments(file[i])[0];
                if (line.Contains('{'))
                {
                    List<string> blockitems = new List<string>();
                    i++;
                    for (; i < file.Length ; i++)
                    {
                        line = SplitComments(file[i])[0];
                        if (line.Contains("}") && !line.Contains("\t"))
                        {
                            break;
                        }

                        if (line.Contains("{"))
                        {
                            blockitems.Add(line.Split('=')[0].Trim(' ', '\t'));
                            if (!line.Contains("}")) //check if there is a opening and closing statement on the same line. in that case there is no need for a readsyntax call
                            {
                                i = ReadSyntax(i + 1, file);
                                if (i == 0)
                                {
                                    MessageBox.Show("Syntax Error", "GODVERDOMME");
                                    return null;
                                }
                            }

                        }
                    }
                    items.Add(blockitems);
                }
            }

            return items;
        }

        List<string> LoadSyntaxSecondLevel(string[] file, string name) //this will load the second level items of a block with specified name, returns null on syntax error
        {
            List<string> items = new List<string>();

            for (int i = 0; i < file.Length; i++)
            {
                string line = SplitComments(file[i])[0];
                string comment = SplitComments(file[i])[1];

                if (line == "")
                {
                    continue;
                }

                if (line.Contains(name) && line.Contains('{'))
                {
                    for (int z = i; z < file.Length; z++)
                    {
                        line = file[z];
                        if (line.Contains('{') && line.Contains('\t'))
                        {
                            string[] parts = line.Split(' ');
                            string item = parts[0].TrimStart('\t');

                            items.Add(item);

                            if (!line.Contains("}")) //check if the block is not closed at the same line
                            {
                                z = ReadSyntax(z + 1, file);
                                if (z == 0)
                                {
                                    return null;
                                }
                            }
                        }
                        else
                        {
                            if (line.Contains('}') && !line.Contains('\t'))
                            {
                                i = z;
                                break;
                            }
                        }
                    }
                    break;
                }
            }

            return items;
        }

        void LoadCombobox(ComboBox cmb, List<string> items) //loads a list into combobox items
        {
            cmb.Items.Clear();
            foreach (string item in items)
            {
                cmb.Items.Add(item);
            }
        }

        private void bt_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Please select file to parse";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filelocation = ofd.FileName;
                txt_search.Enabled = true;
                bt_load_1.Enabled = true;
                bt_load_2.Enabled = true;
            }
        }

        private void bt_load_2_Click(object sender, EventArgs e)
        {
            cmb_first.Items.Clear();
            cmb_second.Items.Clear();
            cmb_first.Text = "";
            cmb_second.Text = "";
            items.Clear();
            LoadCombobox(cmb_first, LoadSyntaxFirstLevel(File.ReadAllLines(filelocation)));
            items = LoadSyntaxSecondLevel(File.ReadAllLines(filelocation));
            //MessageBox.Show(items[0][0]);
        }

        private void bt_load_1_Click(object sender, EventArgs e)
        {
            cmb_first.Items.Clear();
            cmb_second.Items.Clear();
            cmb_first.Text = "";
            cmb_second.Text = "";
            cmb_first.Items.Clear();
            cmb_second.Items.Clear();
            cmb_first.Text = "";
            cmb_second.Text = "";
            items.Clear();
            LoadCombobox(cmb_first, LoadSyntaxSecondLevel(File.ReadAllLines(filelocation), txt_search.Text.Trim()));
        }

        private void cmb_first_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (items.Count > 0)
            {
                LoadCombobox(cmb_second, items[cmb_first.SelectedIndex]);
            }
        }
    }
}
