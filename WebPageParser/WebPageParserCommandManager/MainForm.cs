using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebPageParserCommandManager.Models;

namespace WebPageParserCommandManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonParseOnClick(object sender, EventArgs e)
        {
            ParseCommand cmd = new ParseCommand();
            cmd.Url = textBoxUrlParse.Text;
            cmd.WithExternalLinks = checkBoxUseExternalParse.Checked;
            cmd.Depth = (int)numericUpDownDepthParse.Value;
            cmd.ThreadsCount = (int)numericUpDownThreadsCountParse.Value;
            using (var context = new WebPageParserCommandContext())
            {
                context.Commands.Add(cmd);
                context.SaveChanges();
            }
        }

        private void buttonBuildTree_Click(object sender, EventArgs e)
        {
            BuildTreeCommand cmd = new BuildTreeCommand();
            cmd.Url = textBoxUrlBuild.Text;
            cmd.WithExternalLinks = checkBoxUseExternalBuild.Checked;
            cmd.FilePath = textBoxPathBuildTree.Text;
            using (var context = new WebPageParserCommandContext())
            {
                context.Commands.Add(cmd);
                context.SaveChanges();
            }
        }
    }
}
