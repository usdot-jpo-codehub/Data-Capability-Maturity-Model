using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Data_CMM
{
    public class CMMData
    {
        public List<string> UseCase = new List<string>();
        public List<string> BarrierTitle = new List<string>();
        public List<ulong> BarrierScore = new List<ulong>();
        public short DimensionCount = 0;
        public short ChecklistItemCount = 0;
        public float MaturityScore = 0;
        public float ResponseRate = 0;
        public short NumResponses = 0;
        public string SelectedUseCase = "Generic Use Case";
        public string UserNotes = "";
        public bool ShowBarriers = false;
        public short ConfigFileVersionNumber;
        public List<DimensionData> Dimension = new List<DimensionData>();
        public class DimensionData
        {
            public string Title = "";
            public float MaturityScore = 0;
            public float ResponseRate = 0;
            public short NumResponses = 0;
            public List<ulong> BarrierScore = new List<ulong>();
            public short SubdimensionCount = 0;
            public short ChecklistItemCount = 0;
            public string UserNotes = "";
            public List<SubdimensionData> Subdimension = new List<SubdimensionData>();
            public class SubdimensionData
            {
                public string Title = "";
                public float MaturityScore = 0;
                public float ResponseRate = 0;
                public short NumResponses = 0;
                public List<ulong> BarrierScore = new List<ulong>();
                public short ChecklistItemCount = 0;
                public string UserNotes = "";
                public List<ChecklistItemData> ChecklistItem = new List<ChecklistItemData>();
                public class ChecklistItemData
                {
                    public short MaturityScore = 0;
                    public string LongText = "";
                    public string UserNotes = "";
                    public List<bool> BarrierApplicable = new List<bool>();
                }
            }
        }
    }
    static class MainProgram
    {
        public static bool ObfuscatedProgram = false;
        public static bool StartProgram = true;
        public static bool AbortProgram = false;
        public static bool NewFileMode = false;
        public static bool OpenFileMode = false;
        public static string CMMFileName = "Assessment1";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            do
            {
                CMMData DataCMM1 = new CMMData();
                ReadCMMConfigFile(DataCMM1);
                if (AbortProgram) return;
                if (OpenFileMode) ReadXMLDataFile(DataCMM1);
                if (AbortProgram) return;
                StartProgram = false;
                NewFileMode = false;
                Application.Run(new MainForm(DataCMM1));
            } while (StartProgram);
        }
        private static string ReadXMLElementNodeString(XmlElement root, string TargetNode)
        { // this function provides backwards compatibility by allowing the use of default values for data items (XML tags) that are not present within the XML file
            XmlNode nodeToFind;
            nodeToFind = root.SelectSingleNode(TargetNode);
            if (nodeToFind != null)
            {
                return root.SelectSingleNode(TargetNode).InnerText;
            }
            else 
            {
                return "";
            }
        }
        private static string ReadXMLNodeNodeString(XmlNode node, string TargetNode)
        { // this function provides backwards compatibility by allowing the use of default values for data items (XML tags) that are not present within the XML file
            XmlNode nodeToFind;
            nodeToFind = node.SelectSingleNode(TargetNode);
            if (nodeToFind != null)
            {
                return node.SelectSingleNode(TargetNode).InnerText;
            }
            else
            {
                return "";
            }
        }
        private static bool ReadShowBarriers(XmlElement root)
        { // this function provides backwards compatibility by allowing the use of default values for data items (XML tags) that are not present within the XML file
            XmlNode nodeToFind;
            bool InternalValue = false;
            nodeToFind = root.SelectSingleNode("ShowBarriers");
            if (nodeToFind != null)
            {
                if (root.SelectSingleNode("ShowBarriers").InnerText == "True") InternalValue = true;
            }
            return InternalValue;
        }
        private static Int16 ReadXMLElementNodeInt16(XmlElement root, string TargetNode)
        { // this function provides backwards compatibility by allowing the use of default values for data items (XML tags) that are not present within the XML file
            XmlNode nodeToFind;
            nodeToFind = root.SelectSingleNode(TargetNode);
            if (nodeToFind != null)
            {
                return Convert.ToInt16(root.SelectSingleNode(TargetNode).InnerText);
            }
            else
            {
                return 0;
            }
        }
        private static Int16 ReadXMLNodeNodeInt16(XmlNode node, string TargetNode)
        { // this function provides backwards compatibility by allowing the use of default values for data items (XML tags) that are not present within the XML file
            XmlNode nodeToFind;
            nodeToFind = node.SelectSingleNode(TargetNode);
            if (nodeToFind != null)
            {
                return Convert.ToInt16(node.SelectSingleNode(TargetNode).InnerText);
            }
            else
            {
                return 0;
            }
        }
        private static Single ReadXMLElementNodeSingle(XmlElement root, string TargetNode)
        { // this function provides backwards compatibility by allowing the use of default values for data items (XML tags) that are not present within the XML file
            XmlNode nodeToFind;
            nodeToFind = root.SelectSingleNode(TargetNode);
            if (nodeToFind != null)
            {
                return Convert.ToSingle(root.SelectSingleNode(TargetNode).InnerText);
            }
            else
            {
                return 0;
            }
        }
        private static Single ReadXMLNodeNodeSingle(XmlNode node, string TargetNode)
        { // this function provides backwards compatibility by allowing the use of default values for data items (XML tags) that are not present within the XML file
            XmlNode nodeToFind;
            nodeToFind = node.SelectSingleNode(TargetNode);
            if (nodeToFind != null)
            {
                return Convert.ToSingle(node.SelectSingleNode(TargetNode).InnerText);
            }
            else
            {
                return 0;
            }
        }
        public static void ReadXMLDataFile(CMMData DataCMM1)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Data CMM XML files (*.xml)|*.xml";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    short DimensionNumber = 0;
                    short SubdimensionNumber = 0;
                    short ChecklistItemNumber = 0;
                    Int16 TempFileVersionNumber = 0;
                    XmlDocument doc = new XmlDocument();
                    doc.Load(openFileDialog.FileName);
                    CMMFileName = Path.GetFileName(openFileDialog.FileName);
                    XmlElement root = doc.DocumentElement; //get the root element.
                    DataCMM1.UserNotes = ReadXMLElementNodeString(root, "UserNotes");
                    DataCMM1.SelectedUseCase = ReadXMLElementNodeString(root, "SelectedUseCase");
                    DataCMM1.ShowBarriers = ReadShowBarriers(root);
                    DataCMM1.NumResponses = ReadXMLElementNodeInt16(root, "NumResponses");
                    DataCMM1.ResponseRate = ReadXMLElementNodeSingle(root, "ResponseRate");
                    DataCMM1.MaturityScore = ReadXMLElementNodeSingle(root, "MaturityScore");
                    DataCMM1.NumResponses = ReadXMLElementNodeInt16(root, "DimensionCount");
                    TempFileVersionNumber = ReadXMLElementNodeInt16(root, "ConfigFileVersionNumber");
                    if (DataCMM1.ConfigFileVersionNumber != TempFileVersionNumber)
                    {
                        string caption = "Data file may be from an older version of the tool";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;
                        string message = "Warning: The data file version number (" + TempFileVersionNumber.ToString() + ") does not match the program version number (" + DataCMM1.ConfigFileVersionNumber.ToString() + "). This may indicate that the program has changed since the data file was originally created.";
                        result = MessageBox.Show(message, caption, buttons);
                        //AbortProgram = true;
                    }
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        if (node.Name == "Dimension") 
                        {
                            DimensionNumber += 1;
                            SubdimensionNumber = 0;
                            DataCMM1.Dimension[DimensionNumber - 1].UserNotes = ReadXMLNodeNodeString(node, "UserNotes");
                            DataCMM1.Dimension[DimensionNumber - 1].NumResponses = ReadXMLNodeNodeInt16(node, "NumResponses");
                            DataCMM1.Dimension[DimensionNumber - 1].ResponseRate = ReadXMLNodeNodeSingle(node, "ResponseRate");
                            DataCMM1.Dimension[DimensionNumber - 1].MaturityScore = ReadXMLNodeNodeSingle(node, "MaturityScore");
                            DataCMM1.Dimension[DimensionNumber - 1].SubdimensionCount = ReadXMLNodeNodeInt16(node, "SubdimensionCount");
                            foreach (XmlNode cnode in node.ChildNodes)
                            {
                                if (cnode.Name == "Subdimension")
                                {
                                    SubdimensionNumber += 1;
                                    ChecklistItemNumber = 0;
                                    DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].UserNotes = ReadXMLNodeNodeString(cnode, "UserNotes");
                                    DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].NumResponses = ReadXMLNodeNodeInt16(cnode, "NumResponses");
                                    DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].ResponseRate = ReadXMLNodeNodeSingle(cnode, "ResponseRate");
                                    DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].MaturityScore = ReadXMLNodeNodeSingle(cnode, "MaturityScore");
                                    DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].ChecklistItemCount = ReadXMLNodeNodeInt16(cnode, "ChecklistItemCount");
                                    foreach (XmlNode ccnode in cnode.ChildNodes)
                                    {
                                        if (ccnode.Name == "Checklist")
                                        {
                                            ChecklistItemNumber += 1;
                                            DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].ChecklistItem[ChecklistItemNumber - 1].MaturityScore = ReadXMLNodeNodeInt16(ccnode, "MaturityScore");
                                            DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].ChecklistItem[ChecklistItemNumber - 1].UserNotes = ReadXMLNodeNodeString(ccnode, "UserNotes");
                                            foreach (XmlNode cccnode in ccnode.ChildNodes) 
                                            {
                                                if (cccnode.Name == "Barrier") 
                                                {
                                                    for (short i = 0; i <= DataCMM1.BarrierTitle.Count - 1; i++)
                                                    {
                                                        if (DataCMM1.BarrierTitle[i].ToString() == cccnode.Attributes["Title"]?.InnerText)
                                                        {
                                                            if (cccnode.Attributes["Applicable"]?.InnerText == "True") 
                                                            {
                                                                DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].ChecklistItem[ChecklistItemNumber - 1].BarrierApplicable[i] = true;
                                                            }
                                                            else
                                                            {
                                                                DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].ChecklistItem[ChecklistItemNumber - 1].BarrierApplicable[i] = false;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else if (ccnode.Name == "Barrier")
                                        {
                                            for (short i = 0; i <= DataCMM1.BarrierTitle.Count - 1; i++)
                                            {
                                                if (DataCMM1.BarrierTitle[i].ToString() == ccnode.Attributes["Title"]?.InnerText)
                                                {
                                                    DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].BarrierScore[i] = (ulong)Convert.ToInt16(ccnode.Attributes["Score"]?.InnerText);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (cnode.Name == "Barrier")
                                {
                                    for (short i = 0; i <= DataCMM1.BarrierTitle.Count - 1; i++)
                                    {
                                        if (DataCMM1.BarrierTitle[i].ToString() == cnode.Attributes["Title"]?.InnerText)
                                        {
                                            DataCMM1.Dimension[DimensionNumber - 1].BarrierScore[i] = (ulong)Convert.ToInt16(cnode.Attributes["Score"]?.InnerText);
                                        }
                                    }
                                }
                            }
                        }
                        else if (node.Name == "Barrier")
                        {
                            for (short i = 0; i <= DataCMM1.BarrierTitle.Count - 1; i++)
                            {
                                if (DataCMM1.BarrierTitle[i].ToString() == node.Attributes["Title"]?.InnerText)
                                {
                                    DataCMM1.BarrierScore[i] = (ulong)Convert.ToInt16(node.Attributes["Score"]?.InnerText);
                                }
                            }
                        }
                    }
                }
            }
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
        public static void ReadCMMConfigFile(CMMData DataCMM1)
        {
            String MyConfigFile;
            String ConfigFileLine;
            String ApplicationPath = Application.StartupPath;
            DataCMM1.BarrierTitle.Clear();
            short DimensionNumber = 0;
            short SubdimensionNumber = 0;
            short ChecklistItemNumber = 0;
            string caption = "";
            short number1 = 0;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            const int CCaesarCipherKey = -54347; // negative value specifies decryption, must be equal to negative value of encryption value
            try
            {
                MyConfigFile = ApplicationPath + "\\CMM config.txt";
                if (ObfuscatedProgram) MyConfigFile = ApplicationPath + "\\CMM config.bnr";
                StreamReader sr = new StreamReader(MyConfigFile);
                ConfigFileLine = sr.ReadLine();
                if (ObfuscatedProgram && ConfigFileLine != null) ConfigFileLine = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                if (ConfigFileLine != "Config File Version Number") 
                {
                    string message = "Error reading CMM configuration file.";
                    result = MessageBox.Show(message, caption, buttons);
                    AbortProgram = true;
                    return;
                }
                ConfigFileLine = sr.ReadLine();
                if (ObfuscatedProgram && ConfigFileLine != null) ConfigFileLine = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                bool canConvert = short.TryParse(ConfigFileLine, out number1);
                if (canConvert == false)
                {
                    string message = "Error reading CMM configuration file version number.";
                    result = MessageBox.Show(message, caption, buttons);
                    AbortProgram = true;
                    return;
                }
                DataCMM1.ConfigFileVersionNumber = number1;
                while (ConfigFileLine != null)
                {
                    ConfigFileLine = sr.ReadLine();
                    if (ObfuscatedProgram && ConfigFileLine != null) ConfigFileLine = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                    if (ConfigFileLine == "Start Usecases")
                    {
                        ConfigFileLine = sr.ReadLine();
                        if (ObfuscatedProgram && ConfigFileLine != null) ConfigFileLine = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                        while (ConfigFileLine != "End Usecases")
                        {
                            DataCMM1.UseCase.Add(ConfigFileLine);
                            ConfigFileLine = sr.ReadLine();
                            if (ObfuscatedProgram && ConfigFileLine != null) ConfigFileLine = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                        }
                    }
                    else if (ConfigFileLine == "Start Barriers")
                    {
                        ConfigFileLine = sr.ReadLine();
                        if (ObfuscatedProgram && ConfigFileLine != null) ConfigFileLine = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                        while (ConfigFileLine != "End Barriers")
                        {
                            DataCMM1.BarrierTitle.Add(ConfigFileLine);
                            DataCMM1.BarrierScore.Add(0);
                            ConfigFileLine = sr.ReadLine();
                            if (ObfuscatedProgram && ConfigFileLine != null) ConfigFileLine = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                        }
                    }
                    else if (ConfigFileLine == "Start Dimension")
                    {
                        DimensionNumber += 1;
                        SubdimensionNumber = 0;
                        DataCMM1.Dimension.Add(new CMMData.DimensionData());
                        DataCMM1.Dimension[DimensionNumber - 1].SubdimensionCount = 0;
                        ConfigFileLine = sr.ReadLine();
                        if (ObfuscatedProgram && ConfigFileLine != null) ConfigFileLine = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                        DataCMM1.Dimension[DimensionNumber - 1].Title = ConfigFileLine;
                        for (short i = 0; i <= DataCMM1.BarrierScore.Count - 1; i++) 
                        {
                            DataCMM1.Dimension[DimensionNumber - 1].BarrierScore.Add(0);
                        }
                    }
                    else if (ConfigFileLine == "Start Subdimension")
                    {
                        DataCMM1.Dimension[DimensionNumber - 1].Subdimension.Add(new CMMData.DimensionData.SubdimensionData());
                        SubdimensionNumber += 1;
                        DataCMM1.Dimension[DimensionNumber - 1].SubdimensionCount += 1;
                        ChecklistItemNumber = 0;
                        ConfigFileLine = sr.ReadLine();
                        if (ObfuscatedProgram && ConfigFileLine != null) ConfigFileLine = CaesarCipher(ConfigFileLine, CCaesarCipherKey);
                        DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].Title = ConfigFileLine;
                        for (short i = 0; i <= DataCMM1.BarrierScore.Count - 1; i++)
                        {
                            DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].BarrierScore.Add(0);
                        }
                    }
                    else if (ConfigFileLine != null)
                    {
                        ChecklistItemNumber += 1;
                        DataCMM1.ChecklistItemCount += 1;
                        DataCMM1.Dimension[DimensionNumber - 1].ChecklistItemCount += 1;
                        DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].ChecklistItem.Add(new CMMData.DimensionData.SubdimensionData.ChecklistItemData());
                        DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].ChecklistItemCount += 1;
                        DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].ChecklistItem[ChecklistItemNumber - 1].LongText = ConfigFileLine;
                        for (int i = 0; i <= DataCMM1.BarrierTitle.Count - 1; i++)
                        {
                            DataCMM1.Dimension[DimensionNumber - 1].Subdimension[SubdimensionNumber - 1].ChecklistItem[ChecklistItemNumber - 1].BarrierApplicable.Add(false);
                        }
                    }
                }
                DataCMM1.DimensionCount = DimensionNumber;
                sr.Close();
            }
            catch
            {
                string message = "Error reading CMM configuration file.";
                //string caption = "";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");
            //}
        }
    }
}
