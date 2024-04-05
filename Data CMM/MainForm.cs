using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Data_CMM
{
    public partial class MainForm : Form
    {
        //public string CMMFileName = "Assessment1";
        public bool FileSavedAtLeastOnce = false;
        public bool DataModified = false;
        public short SelectedDimensionNumber = 0;
        public short SelectedSubdimensionNumber = 0;
        public short SelectedChecklistItemNumber = 0;
        public short SelectedTreeLevel = 0;
        public bool FormLoaded = false;
        public CMMData DataCMM2 = new CMMData();
        public MainForm(CMMData DataCMM1)
        {
            string TempStr;
            string TempStr1;
            short TempVal1;
            short TempVal2;
            InitializeComponent();
            UseCaseToolStripComboBox.Items.Clear();
            UseCaseToolStripComboBox.Items.Add("Generic Use Case");
            BarriersComboBox.Text = "Notes";
            for (short i = 0; i <= DataCMM1.UseCase.Count - 1; i++)
            {
                UseCaseToolStripComboBox.Items.Add(DataCMM1.UseCase[i].ToString());
            }
            UseCaseToolStripComboBox.SelectedIndex = 0;
            for (short i = 0; i <= DataCMM1.BarrierTitle.Count - 1; i++)
            {
                dataGridViewBarriers.Rows.Add();
                dataGridViewBarriers[1, i].Value = DataCMM1.BarrierTitle[i].ToString();
                TempStr = DataCMM1.BarrierScore[i].ToString();
                dataGridViewBarriers[1, i].Value += " (" + TempStr + "%)";
            }
            groupBoxBarriers.Enabled = true;
            if (MainProgram.OpenFileMode)
            {
                TempVal1 = (short)Math.Round(DataCMM1.ResponseRate, 0);
                TempStr1 = TempVal1.ToString();
                TempVal2 = DataCMM1.NumResponses;
                TempStr = TempVal2.ToString();
                textBoxResponseRate.Text = TempStr1 + "% (" + TempStr + " out of " + DataCMM1.ChecklistItemCount.ToString() + " readiness checklist items)";
                TempStr = DataCMM1.MaturityScore.ToString();
                if (TempStr.Length == 1) TempStr += ".00";
                else if (TempStr.Length == 3) TempStr += "0";
                if (DataCMM1.MaturityScore < 1) TempStr = "none";
                treeView1.Nodes.Add("Data CMM (maturity score: " + TempStr + ")");
                for (short i = 0; i <= DataCMM1.DimensionCount - 1; i++)
                {
                    TempStr = DataCMM1.Dimension[i].MaturityScore.ToString();
                    if (TempStr.Length == 1) TempStr += ".00";
                    else if (TempStr.Length == 3) TempStr += "0";
                    if (DataCMM1.Dimension[i].MaturityScore < 1) TempStr = "none";
                    treeView1.Nodes[0].Nodes.Add(DataCMM1.Dimension[i].Title + " (maturity score: " + TempStr + ")");
                    for (short j = 0; j <= DataCMM1.Dimension[i].SubdimensionCount - 1; j++)
                    {
                        TempStr = DataCMM1.Dimension[i].Subdimension[j].MaturityScore.ToString();
                        if (TempStr.Length == 1) TempStr += ".00";
                        else if (TempStr.Length == 3) TempStr += "0";
                        if (DataCMM1.Dimension[i].Subdimension[j].MaturityScore < 1) TempStr = "none";
                        treeView1.Nodes[0].Nodes[i].Nodes.Add(DataCMM1.Dimension[i].Subdimension[j].Title + " (maturity score: " + TempStr + ")");
                        for (short k = 0; k <= DataCMM1.Dimension[i].Subdimension[j].ChecklistItemCount - 1; k++)
                        {
                            TempStr = DataCMM1.Dimension[i].Subdimension[j].ChecklistItem[k].MaturityScore.ToString();
                            if (DataCMM1.Dimension[i].Subdimension[j].ChecklistItem[k].MaturityScore < 1) TempStr = "none";
                            TempStr1 = (k + 1).ToString().Trim();
                            treeView1.Nodes[0].Nodes[i].Nodes[j].Nodes.Add("Checklist Item #" + TempStr1 + " (maturity score: " + TempStr + ")");
                        }
                    }
                }
                this.Text = MainProgram.CMMFileName + " | Saved to this PC";
                FileSavedAtLeastOnce = true;
                DataModified = false;
                MainProgram.OpenFileMode = false;
            }
            else 
            {
                treeView1.Nodes.Add("Data CMM (maturity score: none)");
                for (short i = 0; i <= DataCMM1.DimensionCount - 1; i++)
                {
                    treeView1.Nodes[0].Nodes.Add(DataCMM1.Dimension[i].Title + " (maturity score: none)");
                    for (short j = 0; j <= DataCMM1.Dimension[i].SubdimensionCount - 1; j++)
                    {
                        treeView1.Nodes[0].Nodes[i].Nodes.Add(DataCMM1.Dimension[i].Subdimension[j].Title + " (maturity score: none)");
                        for (short k = 0; k <= DataCMM1.Dimension[i].Subdimension[j].ChecklistItemCount - 1; k++)
                        {
                            TempStr = (k + 1).ToString().Trim();
                            treeView1.Nodes[0].Nodes[i].Nodes[j].Nodes.Add("Checklist Item #" + TempStr + " (maturity score: none)");
                        }
                    }
                }
            }
            treeView1.Nodes[0].Expand();
            DataCMM2 = DataCMM1;
            FormLoaded = true;
        }
        public void HandleKeyDown(object sender, KeyEventArgs e) 
        {
            if (!FormLoaded) return;
            if (e.KeyCode == Keys.D1 && groupBoxMaturity.Enabled && !textBoxNotes.Focused)
            {
                e.SuppressKeyPress = true; // suppress the 'ding' https://stackoverflow.com/questions/6290967/stop-the-ding-when-pressing-enter
                rdb1.Checked = true;
            }
            else if (e.KeyCode == Keys.D2 && groupBoxMaturity.Enabled && !textBoxNotes.Focused)
            {
                e.SuppressKeyPress = true; // suppress the 'ding'
                rdb2.Checked = true;
            }
            else if (e.KeyCode == Keys.D3 && groupBoxMaturity.Enabled && !textBoxNotes.Focused)
            {
                e.SuppressKeyPress = true; // suppress the 'ding'
                rdb3.Checked = true;
            }
            else if (e.KeyCode == Keys.D4 && groupBoxMaturity.Enabled && !textBoxNotes.Focused)
            {
                e.SuppressKeyPress = true; // suppress the 'ding'
                rdb4.Checked = true;
            }
            else if (e.KeyCode == Keys.D0 && groupBoxMaturity.Enabled && !textBoxNotes.Focused)
            {
                e.SuppressKeyPress = true; // suppress the 'ding'
                rdbUnknown.Checked = true;
            }
            else if (e.KeyCode == Keys.F12)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F1)
            {
                AboutBox1 a = new AboutBox1(DataCMM2);
                a.Show();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N)
            {
                BrandNewToolStripButton_Click(sender, e);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.O)
            {
                OpenToolStripButton_Click(sender, e);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                SaveToolStripButton_Click(sender, e);
            }
        }
        private void BrandNewToolStripButton_Click(object sender, EventArgs e)
        {
            MainProgram.StartProgram = true;
            MainProgram.NewFileMode = true;
            this.Close();
        }
        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            MainProgram.StartProgram = true;
            MainProgram.OpenFileMode = true;
            this.Close();
        }
        /// <summary>
        /// Method to perform a very simple (and classical) encryption for a string. This is NOT at 
        /// all secure, it is only intended to make the string value non-obvious at a first glance.
        ///
        /// The shiftOrUnshift argument is an arbitrary "key value", and must be a non-zero integer 
        /// between -65535 and 65535 (inclusive). To decrypt the encrypted string you use the negative 
        /// value. For example, if you encrypt with -42, then you decrypt with +42, or vice-versa.
        ///
        /// This is inspired by, and largely based on, this:
        /// https://stackoverflow.com/a/13026595/253938
        /// </summary>
        /// <param name="inputString">string to be encrypted or decrypted, must not be null</param>
        /// <param name="shiftOrUnshift">see above</param>
        /// <returns>encrypted or decrypted string</returns>
        private static string CaesarCipher(string inputString, int shiftOrUnshift)
        {
            // Check C# is still C#
            //Debug.Assert(char.MinValue == 0 && char.MaxValue == UInt16.MaxValue);
            const int C64K = UInt16.MaxValue + 1;
            // Check the arguments
            if (inputString == null)
                throw new ArgumentException("Must not be null.", "inputString");
            if (shiftOrUnshift == 0)
                throw new ArgumentException("Must not be zero.", "shiftOrUnshift");
            if (shiftOrUnshift <= -C64K || shiftOrUnshift >= C64K)
                throw new ArgumentException("Out of range.", "shiftOrUnshift");
            // Perform the Caesar cipher shifting, using modulo operator to provide wrap-around
            char[] charArray = new char[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                charArray[i] = Convert.ToChar((Convert.ToInt32(inputString[i]) + shiftOrUnshift + C64K) % C64K);
            }
            // Return the result as a new string
            return new string(charArray);
        }
        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Data CMM XML Document|*.xml";
            saveFileDialog1.Title = "Save Data CMM Input Data";
            saveFileDialog1.FileName = MainProgram.CMMFileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            if (saveFileDialog1.FileName == "") return;
            if (MainProgram.ObfuscatedProgram == false)
            { // https://stackoverflow.com/questions/13025949/simple-obfuscation-of-string-in-net
                String ApplicationPath = Application.StartupPath;
                String ConfigFileLine;
                string caption = "";
                string caesarCiphered = "";
                const int CCaesarCipherKey = 54347; // positive value specifies encryption, must be equal to positive value of decryption value
                short number1 = 0;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                try
                {
                    StreamReader sr = new StreamReader(ApplicationPath + "\\CMM config.txt");
                    StreamWriter sw = new StreamWriter(ApplicationPath + "\\CMM config.bnr");
                    ConfigFileLine = sr.ReadLine();
                    if (ConfigFileLine != "Config File Version Number")
                    {
                        string message = "Error reading CMM configuration file.";
                        result = MessageBox.Show(message, caption, buttons);
                        MainProgram.AbortProgram = true;
                        return;
                    }
                    caesarCiphered = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                    sw.WriteLine(caesarCiphered);
                    ConfigFileLine = sr.ReadLine();
                    bool canConvert = short.TryParse(ConfigFileLine, out number1);
                    if (canConvert == false)
                    {
                        string message = "Error reading CMM configuration file version number.";
                        result = MessageBox.Show(message, caption, buttons);
                        MainProgram.AbortProgram = true;
                        return;
                    }
                    caesarCiphered = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                    sw.WriteLine(caesarCiphered);
                    while (ConfigFileLine != null)
                    {
                        ConfigFileLine = sr.ReadLine();
                        if (ConfigFileLine != null) 
                        {
                            caesarCiphered = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                            sw.WriteLine(caesarCiphered);
                        }
                    }
                    sr.Close();
                    sw.Close();
                }
                catch
                {
                    string message = "Error reading CMM configuration file.";
                    //string caption = "";
                    //MessageBoxButtons buttons = MessageBoxButtons.OK;
                    //DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                }
            }
            XmlWriter writer = null;
            writer = XmlWriter.Create(saveFileDialog1.FileName);
            writer.WriteStartElement("DataCMM");
            writer.WriteElementString("DimensionCount", DataCMM2.DimensionCount.ToString());
            writer.WriteElementString("ChecklistItemCount", DataCMM2.ChecklistItemCount.ToString());
            writer.WriteElementString("MaturityScore", DataCMM2.MaturityScore.ToString());
            writer.WriteElementString("ResponseRate", DataCMM2.ResponseRate.ToString());
            writer.WriteElementString("NumResponses", DataCMM2.NumResponses.ToString());
            writer.WriteElementString("ConfigFileVersionNumber", DataCMM2.ConfigFileVersionNumber.ToString());
            writer.WriteElementString("SelectedUseCase", DataCMM2.SelectedUseCase);
            writer.WriteElementString("ShowBarriers", DataCMM2.ShowBarriers.ToString());
            writer.WriteElementString("UserNotes", DataCMM2.UserNotes);
            for (int i = 0; i <= DataCMM2.BarrierTitle.Count - 1; i++)
            {
                writer.WriteStartElement("Barrier");
                writer.WriteAttributeString("Title", DataCMM2.BarrierTitle[i]);
                writer.WriteAttributeString("Score", DataCMM2.BarrierScore[i].ToString());
                writer.WriteEndElement();
            }
            for (int i = 0; i <= DataCMM2.DimensionCount - 1; i++)
            {
                writer.WriteStartElement("Dimension");
                writer.WriteAttributeString("Title", DataCMM2.Dimension[i].Title);
                writer.WriteElementString("UserNotes", DataCMM2.Dimension[i].UserNotes);
                writer.WriteElementString("ChecklistItemCount", DataCMM2.Dimension[i].ChecklistItemCount.ToString());
                writer.WriteElementString("MaturityScore", DataCMM2.Dimension[i].MaturityScore.ToString());
                writer.WriteElementString("ResponseRate", DataCMM2.Dimension[i].ResponseRate.ToString());
                writer.WriteElementString("NumResponses", DataCMM2.Dimension[i].NumResponses.ToString());
                writer.WriteElementString("SubdimensionCount", DataCMM2.Dimension[i].SubdimensionCount.ToString());
                for (int j = 0; j <= DataCMM2.BarrierTitle.Count - 1; j++)
                {
                    writer.WriteStartElement("Barrier");
                    writer.WriteAttributeString("Title", DataCMM2.BarrierTitle[j]);
                    writer.WriteAttributeString("Score", DataCMM2.Dimension[i].BarrierScore[j].ToString());
                    writer.WriteEndElement();
                }
                for (int j = 0; j <= DataCMM2.Dimension[i].SubdimensionCount - 1; j++)
                {
                    writer.WriteStartElement("Subdimension");
                    writer.WriteAttributeString("Title", DataCMM2.Dimension[i].Subdimension[j].Title);
                    writer.WriteElementString("UserNotes", DataCMM2.Dimension[i].Subdimension[j].UserNotes);
                    writer.WriteElementString("ChecklistItemCount", DataCMM2.Dimension[i].Subdimension[j].ChecklistItemCount.ToString());
                    writer.WriteElementString("MaturityScore", DataCMM2.Dimension[i].Subdimension[j].MaturityScore.ToString());
                    writer.WriteElementString("ResponseRate", DataCMM2.Dimension[i].Subdimension[j].ResponseRate.ToString());
                    writer.WriteElementString("NumResponses", DataCMM2.Dimension[i].Subdimension[j].NumResponses.ToString());
                    for (int k = 0; k <= DataCMM2.BarrierTitle.Count - 1; k++)
                    {
                        writer.WriteStartElement("Barrier");
                        writer.WriteAttributeString("Title", DataCMM2.BarrierTitle[k]);
                        writer.WriteAttributeString("Score", DataCMM2.Dimension[i].Subdimension[j].BarrierScore[k].ToString());
                        writer.WriteEndElement();
                    }
                    for (int k = 0; k <= DataCMM2.Dimension[i].Subdimension[j].ChecklistItemCount - 1; k++)
                    {
                        writer.WriteStartElement("Checklist");
                        writer.WriteAttributeString("Item", DataCMM2.Dimension[i].Subdimension[j].ChecklistItem[k].LongText);
                        writer.WriteElementString("MaturityScore", DataCMM2.Dimension[i].Subdimension[j].ChecklistItem[k].MaturityScore.ToString());
                        writer.WriteElementString("UserNotes", DataCMM2.Dimension[i].Subdimension[j].ChecklistItem[k].UserNotes);
                        for (int kk = 0; kk <= DataCMM2.BarrierTitle.Count - 1; kk++)
                        {
                            writer.WriteStartElement("Barrier");
                            writer.WriteAttributeString("Title", DataCMM2.BarrierTitle[kk]);
                            writer.WriteAttributeString("Applicable", DataCMM2.Dimension[i].Subdimension[j].ChecklistItem[k].BarrierApplicable[kk].ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Flush();
            writer.Close();
            MainProgram.CMMFileName = Path.GetFileName(saveFileDialog1.FileName);
            this.Text = MainProgram.CMMFileName + " | Saved to this PC";
            FileSavedAtLeastOnce = true;
            DataModified = false;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            HandleTreeChange(sender, e);
        }
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            HandleTreeChange(sender, e);
        }
        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(sender, e);
        }
        private void rdb1_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(sender, e);
        }
        private void rdb2_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(sender, e);
        }
        private void rdb3_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(sender, e);
        }
        private void rdb4_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(sender, e);
        }
        private void textBoxChecklistItem_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(sender, e);
        }
        private void dataGridViewBarriers_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(sender, e);
        }
        private void textBoxNotes_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(sender, e);
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(sender, e);
        }
        private void rdbUnknown_CheckedChanged(object sender, EventArgs e)
        {
            if (!FormLoaded) return;
            if (SelectedTreeLevel == 3 && rdbUnknown.Checked)
            {
                DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].MaturityScore = 0;
                string TempStr = (SelectedChecklistItemNumber + 1).ToString().Trim();
                treeView1.Nodes[0].Nodes[SelectedDimensionNumber].Nodes[SelectedSubdimensionNumber].Nodes[SelectedChecklistItemNumber].Text = "Checklist Item #" + TempStr + " (maturity score: none)";
                DataModified = true;
                RecalculateMaturityScores();
            }
        }
        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            if (!FormLoaded) return;
            if (SelectedTreeLevel == 3 && rdb1.Checked)
            {
                DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].MaturityScore = 1;
                string TempStr = (SelectedChecklistItemNumber + 1).ToString().Trim();
                treeView1.Nodes[0].Nodes[SelectedDimensionNumber].Nodes[SelectedSubdimensionNumber].Nodes[SelectedChecklistItemNumber].Text = "Checklist Item #" + TempStr + " (maturity score: 1)";
                DataModified = true;
                RecalculateMaturityScores();
            }
        }
        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            if (!FormLoaded) return;
            if (SelectedTreeLevel == 3 && rdb2.Checked)
            {
                DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].MaturityScore = 2;
                string TempStr = (SelectedChecklistItemNumber + 1).ToString().Trim();
                treeView1.Nodes[0].Nodes[SelectedDimensionNumber].Nodes[SelectedSubdimensionNumber].Nodes[SelectedChecklistItemNumber].Text = "Checklist Item #" + TempStr + " (maturity score: 2)";
                DataModified = true;
                RecalculateMaturityScores();
            }
        }
        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            if (!FormLoaded) return;
            if (SelectedTreeLevel == 3 && rdb3.Checked)
            {
                DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].MaturityScore = 3;
                string TempStr = (SelectedChecklistItemNumber + 1).ToString().Trim();
                treeView1.Nodes[0].Nodes[SelectedDimensionNumber].Nodes[SelectedSubdimensionNumber].Nodes[SelectedChecklistItemNumber].Text = "Checklist Item #" + TempStr + " (maturity score: 3)";
                DataModified = true;
                RecalculateMaturityScores();
            }
        }
        private void rdb4_CheckedChanged(object sender, EventArgs e)
        {
            if (!FormLoaded) return;
            if (SelectedTreeLevel == 3 && rdb4.Checked)
            {
                DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].MaturityScore = 4;
                string TempStr = (SelectedChecklistItemNumber + 1).ToString().Trim();
                treeView1.Nodes[0].Nodes[SelectedDimensionNumber].Nodes[SelectedSubdimensionNumber].Nodes[SelectedChecklistItemNumber].Text = "Checklist Item #" + TempStr + " (maturity score: 4)";
                DataModified = true;
                RecalculateMaturityScores();
            }
        }

        //public void DisplayMaturityScores() 
        //{
        //    string TempStr = DataCMM2.MaturityScore.ToString();
        //    if (TempStr.Length == 1) TempStr += ".00";
        //    else if (TempStr.Length == 3) TempStr += "0";
        //    // display average maturity score for the overall CMM on the tree view
        //    treeView1.Nodes[0].Text = "Data CMM (maturity score: " + TempStr + ")";
        //}
        public void RecalculateMaturityScores()
        {
            float CMMScore = 0;
            float DimensionScore = 0;
            float SubdimensionScore = 0;
            float TempBarrierScore = 0;
            string TempStr = "";
            short TempCount = 0;
            short ResponseCount = 0;
            short TotalPossibleResponses = 0;
            string TempStr1;
            short TempVal1;
            string TempStr2;
            short TempVal2;
            // all calls to RecalculateMaturityScores now require FormLoaded = true
            FormLoaded = false; // prevent recursive calls to RecalculateMaturityScores
            if (FileSavedAtLeastOnce && DataModified) this.Text = MainProgram.CMMFileName;
            // first, update the displays that don't require much recalculation
            if (DataCMM2.SelectedUseCase.Length > 0)
            {
                for (short i = 0; i <= UseCaseToolStripComboBox.Items.Count - 1; i++)
                {
                    if (DataCMM2.SelectedUseCase.ToString() == UseCaseToolStripComboBox.Items[i].ToString())
                    {
                        UseCaseToolStripComboBox.SelectedIndex = i;
                    }
                }
            }
            if (DataCMM2.ShowBarriers) 
            { 
                BarriersComboBox.Text = "Barriers";
                textBoxNotes.Visible = false;
            }
            else
            {
                BarriersComboBox.Text = "Notes";
                textBoxNotes.Visible = true;
                groupBoxBarriers.Enabled = true; // regardless of which tree item has focus
            }
            if (groupBoxBarriers.Enabled) dataGridViewBarriers.Enabled = true;
            if (!groupBoxBarriers.Enabled) dataGridViewBarriers.Enabled = false;
            if (SelectedTreeLevel == 3) // checklist item selected
            {
                groupBoxMaturity.Enabled = true;
                groupBoxBarriers.Enabled = true;
                dataGridViewBarriers.Enabled = true;
                textBoxChecklistItem.ForeColor = Color.Black;
                textBoxChecklistItem.Text = DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].LongText;
                if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].MaturityScore == 0) 
                {
                    rdbUnknown.Checked = true;
                    dataGridViewBarriers.Enabled = false; // disallow coding of barriers to advancement
                }
                else if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].MaturityScore == 1)
                {
                    rdb1.Checked = true;
                }
                else if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].MaturityScore == 2)
                {
                    rdb2.Checked = true;
                }
                else if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].MaturityScore == 3)
                {
                    rdb3.Checked = true;
                }
                else if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].MaturityScore == 4)
                {
                    rdb4.Checked = true;
                }
                for (short i = 0; i < DataCMM2.BarrierTitle.Count; i++)
                {
                    dataGridViewBarriers[0, i].Value = DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].BarrierApplicable[i];
                    DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].BarrierScore[i] = 0; // reinitialize barrier scores of the selected subdimension
                }
            }
            else
            {
                if (BarriersComboBox.Text == "Barriers") groupBoxBarriers.Enabled = false;
                textBoxChecklistItem.Text = "";
                groupBoxMaturity.Enabled = false;
                for (short i = 0; i < DataCMM2.BarrierTitle.Count; i++)
                {
                    dataGridViewBarriers[0, i].Value = false;
                }
                rdb1.Checked = false;
                rdb2.Checked = false;
                rdb3.Checked = false;
                rdb4.Checked = false;
                rdbUnknown.Checked = false;
            }
            // next, recalculate, display, and store the updated maturity score, response rate, and barriers to improvement of the selected subdimension
            TempStr = "none";
            if (SelectedTreeLevel == 3) // checklist item selected, so the subdimension score may have changed
            {
                if (BarriersComboBox.Text == "Notes") groupBoxBarriers.Text = "Notes for Checklist Item";
                if (BarriersComboBox.Text == "Barriers") groupBoxBarriers.Text = "Barriers for Checklist Item, Percentages for Subdimension";
                textBoxNotes.Text = DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].UserNotes;
                for (short i = 0; i <= DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItemCount - 1; i++)
                { // tabulate the summations of maturity scores and barrier scores for each readiness checklist item within the selected subdimension
                    if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[i].MaturityScore >= 1)
                    {
                        SubdimensionScore += DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[i].MaturityScore;
                        TempCount += 1;
                    }
                    for (short j = 0; j <= DataCMM2.BarrierTitle.Count - 1; j++)
                    {
                        if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[i].BarrierApplicable[j])
                        {
                            DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].BarrierScore[j]++;
                        }
                    }
                }
                if (SubdimensionScore > 0)
                { // compute average maturity score for the selected subdimension by dividing by the number of scored checklist items inside the subdimension
                    SubdimensionScore /= TempCount;
                    TempStr = Math.Round(SubdimensionScore, 2).ToString();
                    if (TempStr.Length == 1) TempStr += ".00";
                    else if (TempStr.Length == 3) TempStr += "0";
                }
                // store the subdimension maturity score, response rate, and number of scored checklist items into memory
                DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].MaturityScore = (float)Math.Round(SubdimensionScore, 2);
                DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ResponseRate = (float)Math.Round((float)TempCount * 100 / DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItemCount, 2);
                DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].NumResponses = TempCount;
            }
            else if (SelectedTreeLevel == 2)
            { // display the stored value
                if (BarriersComboBox.SelectedIndex == 0) groupBoxBarriers.Text = "Notes for Subdimension";
                if (BarriersComboBox.SelectedIndex == 1) groupBoxBarriers.Text = "Barrier to Improvement Percentages for Subdimension";
                textBoxNotes.Text = DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].UserNotes;
                if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].MaturityScore >= 1) 
                {
                    TempStr = DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].MaturityScore.ToString();
                    if (TempStr.Length == 1) TempStr += ".00";
                    else if (TempStr.Length == 3) TempStr += "0";
                }
            }
            if (SelectedTreeLevel >= 2) // one of the subdimensions is selected
            { // update subdimension displays on screen
                // display average maturity score for the selected subdimension on the tree view
                treeView1.Nodes[0].Nodes[SelectedDimensionNumber].Nodes[SelectedSubdimensionNumber].Text = DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].Title + " (maturity score: " + TempStr + ")";
                // display response rate on screen for the selected subdimension
                TempVal1 = (short)Math.Round(DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ResponseRate, 0);
                TempStr1 = TempVal1.ToString();
                TempVal2 = DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].NumResponses;
                TempStr2 = TempVal2.ToString();
                textBoxResponseRate.Text = TempStr1 + "% (" + TempStr2 + " out of " + DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItemCount.ToString() + " readiness checklist items)";
            }
            if (SelectedTreeLevel == 3) // checklist item selected, so the subdimension score may have changed
            { // compute and store subdimension barrier scores
                for (short i = 0; i <= DataCMM2.BarrierTitle.Count - 1; i++)
                {
                    // compute average barrier score for the selected subdimension by dividing by the number of scored checklist items inside the subdimension
                    TempBarrierScore = 0;
                    if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].NumResponses > 0) 
                    {
                        TempBarrierScore = (float)100 * DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].BarrierScore[i] / DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].NumResponses;
                    }
                    // store average barrier score for the selected subdimension into memory
                    DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].BarrierScore[i] = (ulong)TempBarrierScore;
                }
            }
            if (SelectedTreeLevel >= 2) // checklist item or subdimension selected
            { // display subdimension barrier scores in the grid view
                //groupBoxResponseRate.Text = "Response Rate for " + DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].Title.ToLower();
                groupBoxResponseRate.Text = "Response Rate for Subdimension";
                for (short i = 0; i <= DataCMM2.BarrierTitle.Count - 1; i++)
                {
                    TempStr = DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].BarrierScore[i].ToString();
                    dataGridViewBarriers[1, i].Value = DataCMM2.BarrierTitle[i];
                    dataGridViewBarriers[1, i].Value += " (" + TempStr + "%)";
                }
            }
            // next, recalculate, display, and store the updated maturity score, response rate, and barriers to improvement of the selected major dimension
            TempStr = "none";
            if (SelectedTreeLevel == 3) // checklist item selected, so the major dimension score may have changed
            {
                TempCount = 0;
                ResponseCount = 0;
                TotalPossibleResponses = 0;
                for (short k = 0; k <= DataCMM2.Dimension[SelectedDimensionNumber].SubdimensionCount - 1; k++)
                { // tabulate the summations of maturity scores for each subdimension within the selected major dimension
                    TotalPossibleResponses += DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[k].ChecklistItemCount;
                    if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[k].MaturityScore > 0)
                    {
                        DimensionScore += DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[k].MaturityScore;
                        TempCount += 1;
                        ResponseCount += DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[k].NumResponses;
                    }
                }
                if (DimensionScore > 0)
                { // compute average maturity score for the selected major dimension by dividing by the number of scored subdimensions inside the major dimension
                    DimensionScore /= TempCount;
                    TempStr = Math.Round(DimensionScore, 2).ToString();
                    if (TempStr.Length == 1) TempStr += ".00";
                    else if (TempStr.Length == 3) TempStr += "0";
                }
                // store the major dimension maturity score, response rate, and number of scored checklist items into memory
                DataCMM2.Dimension[SelectedDimensionNumber].MaturityScore = (float)Math.Round(DimensionScore, 2);
                DataCMM2.Dimension[SelectedDimensionNumber].ResponseRate = (float)Math.Round((float)ResponseCount * 100 / TotalPossibleResponses, 2);
                DataCMM2.Dimension[SelectedDimensionNumber].NumResponses = ResponseCount;
            }
            else if (SelectedTreeLevel >= 1)
            { // display the stored value
                if (DataCMM2.Dimension[SelectedDimensionNumber].MaturityScore >= 1)
                {
                    TempStr = DataCMM2.Dimension[SelectedDimensionNumber].MaturityScore.ToString();
                    if (TempStr.Length == 1) TempStr += ".00";
                    else if (TempStr.Length == 3) TempStr += "0";
                }
            }
            if (SelectedTreeLevel >= 1) // one of the major dimensions is selected
            { // update major dimension displays on screen
                // display average maturity score for the selected major dimension on the tree view
                treeView1.Nodes[0].Nodes[SelectedDimensionNumber].Text = DataCMM2.Dimension[SelectedDimensionNumber].Title + " (maturity score: " + TempStr + ")";
                if (SelectedTreeLevel == 1) // one of the major dimensions has focus
                { // display response rate on screen for the selected major dimension
                    TempVal1 = (short)Math.Round(DataCMM2.Dimension[SelectedDimensionNumber].ResponseRate, 0);
                    TempStr1 = TempVal1.ToString();
                    TempVal2 = DataCMM2.Dimension[SelectedDimensionNumber].NumResponses;
                    TempStr2 = TempVal2.ToString();
                    textBoxResponseRate.Text = TempStr1 + "% (" + TempStr2 + " out of " + DataCMM2.Dimension[SelectedDimensionNumber].ChecklistItemCount.ToString() + " readiness checklist items)";
                }
            }
            if (SelectedTreeLevel == 3) // checklist item selected, so the major dimension score may have changed
            { // compute and store major dimension barrier scores
                for (short i = 0; i <= DataCMM2.BarrierTitle.Count - 1; i++)
                {
                    TempBarrierScore = 0;
                    TempCount = 0;
                    // compute average barrier score for the selected major dimension by dividing by the number of scored subdimensions inside the major dimension
                    for (short j = 0; j <= DataCMM2.Dimension[SelectedDimensionNumber].SubdimensionCount - 1; j++)
                    {
                        if (DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[j].MaturityScore > 0)
                        {
                            TempCount += 1;
                            TempBarrierScore += DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[j].BarrierScore[i];
                        }
                    }
                    if (TempCount >= 2) TempBarrierScore /= TempCount;
                    // store average barrier score for the selected major dimension into memory
                    DataCMM2.Dimension[SelectedDimensionNumber].BarrierScore[i] = (ulong)TempBarrierScore;
                }
            }
            if (SelectedTreeLevel == 1) // major dimension selected
            { // display major dimension barrier scores in the grid view
                //groupBoxResponseRate.Text = "Response Rate for Dimension " + DataCMM2.Dimension[SelectedDimensionNumber].Title;
                groupBoxResponseRate.Text = "Response Rate for Dimension";
                if (BarriersComboBox.Text == "Notes") groupBoxBarriers.Text = "Notes for Dimension";
                if (BarriersComboBox.Text == "Barriers") groupBoxBarriers.Text = "Barrier to Improvement Percentages for Dimension";
                textBoxNotes.Text = DataCMM2.Dimension[SelectedDimensionNumber].UserNotes;
                for (short i = 0; i <= DataCMM2.BarrierTitle.Count - 1; i++)
                {
                    TempStr = DataCMM2.Dimension[SelectedDimensionNumber].BarrierScore[i].ToString();
                    dataGridViewBarriers[1, i].Value = DataCMM2.BarrierTitle[i];
                    dataGridViewBarriers[1, i].Value += " (" + TempStr + "%)";
                }
            }
            // finally, recalculate, display, and store the updated maturity score, response rate, and barriers to improvement of the overall Data CMM
            TempStr = "none";
            if (SelectedTreeLevel == 3) // checklist item selected, so the major dimension score may have changed
            {
                TempCount = 0;
                ResponseCount = 0;
                TotalPossibleResponses = 0;
                for (short k = 0; k <= DataCMM2.DimensionCount - 1; k++)
                { // tabulate the summations of maturity scores for each major dimension
                    TotalPossibleResponses += DataCMM2.Dimension[k].ChecklistItemCount;
                    if (DataCMM2.Dimension[k].MaturityScore > 0)
                    {
                        CMMScore += DataCMM2.Dimension[k].MaturityScore;
                        TempCount += 1;
                        ResponseCount += DataCMM2.Dimension[k].NumResponses;
                    }
                }
                if (TempCount > 0)
                { // compute average maturity score for the overall CMM by dividing by the number of scored major dimensions
                    CMMScore /= TempCount;
                    TempStr = Math.Round(CMMScore, 2).ToString();
                    if (TempStr.Length == 1) TempStr += ".00";
                    else if (TempStr.Length == 3) TempStr += "0";
                }
                // store the overall CMM maturity score, response rate, and number of scored checklist items into memory
                DataCMM2.MaturityScore = (float)Math.Round(CMMScore, 2);
                DataCMM2.ResponseRate = (float)Math.Round((float)ResponseCount * 100 / TotalPossibleResponses, 2);
                DataCMM2.NumResponses = ResponseCount;
            }
            else if (DataCMM2.MaturityScore >= 1)
            { // display the stored value
                TempStr = DataCMM2.MaturityScore.ToString();
                if (TempStr.Length == 1) TempStr += ".00";
                else if (TempStr.Length == 3) TempStr += "0";
            }
            // display average maturity score for the overall CMM on the tree view
            treeView1.Nodes[0].Text = "Data CMM (maturity score: " + TempStr + ")";
            if (SelectedTreeLevel == 0) 
            { // display response rate on screen for the overall CMM
                TempVal1 = (short)Math.Round(DataCMM2.ResponseRate, 0);
                TempStr1 = TempVal1.ToString();
                TempVal2 = DataCMM2.NumResponses;
                TempStr2 = TempVal2.ToString();
                textBoxResponseRate.Text = TempStr1 + "% (" + TempStr2 + " out of " + DataCMM2.ChecklistItemCount.ToString() + " readiness checklist items)";
            }
            if (SelectedTreeLevel == 3) // checklist item selected, so the overall CMM score may have changed
            { // compute and store overall CMM barrier scores
                for (short i = 0; i <= DataCMM2.BarrierTitle.Count - 1; i++)
                {
                    TempBarrierScore = 0;
                    TempCount = 0;
                    // compute average barrier score for the selected major dimension by dividing by the number of scored subdimensions inside the major dimension
                    for (short j = 0; j <= DataCMM2.DimensionCount - 1; j++)
                    {
                        if (DataCMM2.Dimension[j].MaturityScore > 0)
                        {
                            TempCount += 1;
                            TempBarrierScore += DataCMM2.Dimension[j].BarrierScore[i];
                        }
                    }
                    if (TempCount >= 2) TempBarrierScore /= TempCount;
                    // store average barrier score for the overall CMM into memory
                    DataCMM2.BarrierScore[i] = (ulong)TempBarrierScore;
                }
            }
            if (SelectedTreeLevel == 0) // overall CMM has focus
            { // display major dimension barrier scores in the grid view
                groupBoxResponseRate.Text = "Response Rate for Overall CMM";
                if (BarriersComboBox.Text == "Notes") groupBoxBarriers.Text = "Notes for Overall CMM";
                if (BarriersComboBox.Text == "Barriers") groupBoxBarriers.Text = "Barrier to Improvement Percentages for Overall CMM";
                textBoxNotes.Text = DataCMM2.UserNotes;
                for (short i = 0; i <= DataCMM2.BarrierTitle.Count - 1; i++)
                {
                    TempStr = DataCMM2.BarrierScore[i].ToString();
                    dataGridViewBarriers[1, i].Value = DataCMM2.BarrierTitle[i];
                    dataGridViewBarriers[1, i].Value += " (" + TempStr + "%)";
                }
            }
            FormLoaded = true; // give control back to the end-user
        }
        private void dataGridViewBarriers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!FormLoaded) return;
            DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].BarrierApplicable[e.RowIndex] = (bool)dataGridViewBarriers[0, e.RowIndex].EditedFormattedValue;
            DataModified = true;
        }
        public void HandleTreeChange(object sender, TreeViewEventArgs e) 
        {
            if (!FormLoaded) return;
            // reset the "currently selected items" (e.g., SelectedDimensionNumber) and then call RecalculateMaturityScores to update the displays
            if (e.Node.Level == 3) // checklist item selected
            {
                SelectedTreeLevel = 3;
                SelectedDimensionNumber = ((short)e.Node.Parent.Parent.Index);
                SelectedSubdimensionNumber = ((short)e.Node.Parent.Index);
                SelectedChecklistItemNumber = ((short)e.Node.Index);
                groupBoxChecklists.Text = "Readiness Checklist Item #" + (SelectedChecklistItemNumber + 1).ToString();
            }
            else
            {
                if (e.Node.Level == 1) // major dimension selected
                {
                    SelectedTreeLevel = 1;
                    SelectedDimensionNumber = ((short)e.Node.Index);
                }
                else if (e.Node.Level == 2) // subdimension selected
                {
                    SelectedTreeLevel = 2;
                    SelectedDimensionNumber = ((short)e.Node.Parent.Index);
                    SelectedSubdimensionNumber = ((short)e.Node.Index);
                }
                else // overall CMM selected
                {
                    SelectedTreeLevel = 0;
                }
                groupBoxChecklists.Text = "Readiness Checklist Items";
            }
            RecalculateMaturityScores();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DataModified)
            {
                string message = "Exit program without saving?";
                if (MainProgram.OpenFileMode) message = "Open data file without saving?";
                if (MainProgram.NewFileMode) message = "Start new file without saving?";
                string caption = "Recent edits not yet saved";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    MainProgram.NewFileMode = false;
                    MainProgram.OpenFileMode = false;
                    MainProgram.StartProgram = false;
                    e.Cancel = true;
                }
                else if (MainProgram.StartProgram && message == "Exit program without saving?")
                {
                    MainProgram.StartProgram = false;
                }
            }
        }

        private void UseCaseToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormLoaded)
            {
                DataCMM2.SelectedUseCase = UseCaseToolStripComboBox.Text;
                string caption = "Use case information";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                if (UseCaseToolStripComboBox.Text == "Regional System Management")
                {
                    string message = "Note: The Federal policy subdimension may not be a high priority for use cases external to USDOT.";
                    result = MessageBox.Show(message, caption, buttons);
                }
                else if (UseCaseToolStripComboBox.Text == "Offline Analysis Support")
                {
                    string message = "Note: The Federal policy subdimension may not be a high priority for use cases external to USDOT.";
                    result = MessageBox.Show(message, caption, buttons);
                }
                else if (UseCaseToolStripComboBox.Text == "University TRC")
                {
                    string message = "Note: The Federal policy subdimension may not be a high priority for use cases external to USDOT.";
                    result = MessageBox.Show(message, caption, buttons);
                }
                else if (UseCaseToolStripComboBox.Text == "USDOT Single-Source Data")
                {
                    string message = "Note: The Create dimension may not be a high priority for the USDOT Single-Source Data use case.";
                    result = MessageBox.Show(message, caption, buttons);
                }
                else if (UseCaseToolStripComboBox.Text == "USDOT Research Program")
                {
                    string message = "Note: All dimensions and subdimensions are potentially high priorities for the USDOT Research Program use case.";
                    result = MessageBox.Show(message, caption, buttons);
                }
            }
        }

        private void BarriersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormLoaded)
            {
                if (BarriersComboBox.Text == "Notes")
                {
                    DataCMM2.ShowBarriers = false;
                }
                else if (BarriersComboBox.Text == "Barriers")
                {
                    DataCMM2.ShowBarriers = true;
                }
                DataModified = true;
                RecalculateMaturityScores();
            }
        }

        private void textBoxNotes_Leave(object sender, EventArgs e)
        {
            if (!FormLoaded || BarriersComboBox.Text != "Notes") return;
            if (SelectedTreeLevel == 3)
            {
                DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].ChecklistItem[SelectedChecklistItemNumber].UserNotes = textBoxNotes.Text;
            }
            else if (SelectedTreeLevel == 2)
            {
                DataCMM2.Dimension[SelectedDimensionNumber].Subdimension[SelectedSubdimensionNumber].UserNotes = textBoxNotes.Text;
            }
            else if (SelectedTreeLevel == 1)
            {
                DataCMM2.Dimension[SelectedDimensionNumber].UserNotes = textBoxNotes.Text;
            }
            else if (SelectedTreeLevel == 0)
            {
                DataCMM2.UserNotes = textBoxNotes.Text;
            }
            DataModified = true;
            RecalculateMaturityScores();
        }

        private void AboutToolStripButton(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1(DataCMM2);
            a.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

    }
}
