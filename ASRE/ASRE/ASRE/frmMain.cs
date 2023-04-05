using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ASRE
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            RefreshFileList();
        }

        private void activeScripts_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            MessageBox.Show(activeScripts.Items[e.Index].ToString());
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "NewValue", e.NewValue);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "CurrentValue", e.CurrentValue);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "ItemCheck Event");
        }
      
        private void RefreshFileList()
        {
            activeScripts.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(Properties.Settings.Default.scriptPath.ToString());
            FileInfo[] scriptFiles = di.GetFiles("*.xml");

            foreach (FileInfo fi in scriptFiles)
            {
                activeScripts.Items.Add(fi.Name.ToString());
            }
        }

        private void RefreshActiveScripts()
        {
            XmlTextReader xmlReader = new XmlTextReader("activeScripts.xml");
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    string val;
                    switch (xmlReader.Name)
                    {
                        case "scriptName":
                        val = xmlReader.ReadElementString();
                        MessageBox.Show(val);
                        break;
                        default: break;
                    }
                }
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            RefreshFileList();
            RefreshActiveScripts();
        }

        private void ScriptMonitor_Changed(object sender, FileSystemEventArgs e)
        {
            RefreshFileList();
        }
        private void ScriptMonitor_Created(object sender, FileSystemEventArgs e)
        {
            RefreshFileList();
        }
        private void ScriptMonitor_Deleted(object sender, FileSystemEventArgs e)
        {
            RefreshFileList();
        }
        private void ScriptMonitor_Renamed(object sender, FileSystemEventArgs e)
        {
            RefreshFileList();
        }
    }
}