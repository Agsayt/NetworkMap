using NetworkMap.Logic;
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

namespace NetworkMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _editorMode = EditorMode.Create;
            _mode = NodeMode.Transporter;

            EditorModeCB.Items.AddRange(Enum.GetNames(typeof(EditorMode)));
            EditorModeCB.SelectedIndex = 0;
            canvas.MouseWheel += canvas_MouseWheel;

            saveFileDialog.Filter = "Text files(*.txt)|*.txt";
            openFileDialog.Filter = "Text files(*.txt)|*.txt";

            canvas.Invalidate();
        }

        // Change radius of the node signal
        void canvas_MouseWheel(object sender, MouseEventArgs e)
        {            
            foreach (Node node in nodeList)
            {
                node.IsSelected = false;
                float dx = node.posX - e.X;
                float dy = node.posY - e.Y;
                if (dx * dx + dy * dy <= node.rNode * node.rNode)
                {
                    node.IsSelected = true;
                    node.rSignal += e.Delta > 0 ? 1: -1 ;
                    break;
                }

            }
            canvas.Invalidate();
        }

        #region enums

        public enum EditorMode
        {
            Create,
            Select,
            Edit    
        }

        public enum NodeMode
        {
            Sender,
            Transporter,
            Receiver      
        }

        #endregion
        #region vars

        NodeMode _mode;
        List<Node> nodeList = new List<Node> ();
        EditorMode _editorMode;
        Node selectedNode;
        int nextId = 0;
        #endregion

        private void canvas_Paint(object sender, PaintEventArgs e)
        {            
            foreach (var node in nodeList)
            {
                node.Draw (e.Graphics);
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                foreach (var node in nodeList)
                {
                    if (node.IsSelected)
                    {
                        node.ChangePosition (e.X, e.Y);
                        canvas.Invalidate();
                    }
                }
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (_editorMode == EditorMode.Create && e.Button == MouseButtons.Left)
            {
                Node node = new Node (nextId, e.X, e.Y, 100, _mode);
                nodeList.Add (node);
                nextId++;
                canvas.Invalidate ();    
            }

            
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            selectedNode = null;
            foreach (Node node in nodeList)
            {
                node.IsSelected = false;
                float dx = node.posX - e.X;
                float dy = node.posY - e.Y;
                if (dx * dx + dy * dy <= node.rNode * node.rNode)
                {
                    selectedNode = node;
                    node.IsSelected = true;
                    break;
                }

            }
            canvas.Invalidate();
        }

        private void EditorModeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var combo = sender as ToolStripComboBox;

            if (combo == null)
                return;

            EditorMode mode;

            var selectedItem = combo.SelectedItem.ToString();

            switch (selectedItem)
            {
                case "Create": mode = EditorMode.Create; break;
                case "Select": mode = EditorMode.Select; break;
                case "Edit": mode = EditorMode.Edit; break;
                default: return;
            }

            _editorMode = mode;
            canvas.Focus();
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (selectedNode == null)
                e.Cancel = true;
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = (sender as ToolStripMenuItem);

            switch (item.Name)
            {
                case "senderMode":
                    selectedNode.mode = NodeMode.Sender;
                    break;
                case "TransporterMode":
                    selectedNode.mode = NodeMode.Transporter;
                    break;
                case "ReceiverMode":
                    selectedNode.mode = NodeMode.Receiver;
                    break;
                case "EditName":
                    var name = Microsoft.VisualBasic.Interaction.InputBox("Введите название для нода", "Наименование нода", selectedNode.Name, this.Width / 2, this.Height / 2);
                    if (name == null)
                        return;

                    selectedNode.SetName(name);
                    canvas.Invalidate();
                    break;
                case "EditDesc":
                    var desc = Microsoft.VisualBasic.Interaction.InputBox("Введите описание для нода", "Описание нода", selectedNode.Description, this.Width / 2, this.Height / 2);
                    if (desc == null)
                        return;

                    selectedNode.SetDescription(desc);
                    break;
                case "EditLoc": 
                    var location = Microsoft.VisualBasic.Interaction.InputBox("Введите расположение нода", "Расположение нода", selectedNode.Location, this.Width/2, this.Height/2);
                    if (location == null)
                        return;

                    selectedNode.SetLocation(location);
                    break;
            }
        }

        #region nodeColors
        private void ColorSelectorClick(object sender, EventArgs e)
        {
            var item  = (sender as ToolStripButton);

            colorDialog.ShowDialog();
            if (DialogResult == System.Windows.Forms.DialogResult.Cancel)
                return;

            var selectedColor = colorDialog.Color;
            item.BackColor = selectedColor;
            NodeMode modeToChange = 0;

            switch (item.Name)
            {
                case "SenderColor": 
                    modeToChange = NodeMode.Sender;
                    break;
                case "TransporterColor":
                    modeToChange = NodeMode.Transporter;
                    break;
                case "ReceiverColor":
                    modeToChange = NodeMode.Receiver;
                    break;
            }
            ChangeNodesColor(selectedColor, modeToChange);
        }

        private void ChangeNodesColor(Color selectedColor, NodeMode modeToChange)
        {
            foreach (var node in nodeList)
            {
                if (node.mode == modeToChange)
                    node.penColor = new Pen(new SolidBrush(Color.FromArgb(selectedColor.A, selectedColor.R, selectedColor.G, selectedColor.B)));
            }
            canvas.Invalidate();
        }
        #endregion

        private void SavePreferences_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog.FileName;
                        
            using (FileStream fs = File.Create(filename))
            {
                Byte[] nextIndex = new UTF8Encoding(true).GetBytes(nextId.ToString() + "\n");

                var senderN = nodeList.Where(x => x.mode == NodeMode.Sender).FirstOrDefault();
                var receiverN = nodeList.Where(x => x.mode == NodeMode.Receiver).FirstOrDefault();

                var senderIndex = senderN == null ? -1 : senderN.index;
                var receiverIndex = receiverN == null ? -1 : receiverN.index;

                Byte[] srIndex = new UTF8Encoding(true).GetBytes(senderIndex.ToString() + " " +
                    receiverIndex.ToString() + "\n");

                fs.Write(nextIndex, 0, nextIndex.Length);
                fs.Write(srIndex, 0, srIndex.Length);

                foreach (var item in nodeList)
                {
                    var name = item.Name != null ? $"{item.Name.Replace(" ", "%")}" : "null";
                    var description = item.Description != null ? $"{item.Description.Replace(" ", "%")}" : "null";
                    var location = item.Location != null ? $"{item.Location.Replace(" ", "%")}" : "null";

                    Byte[] node = new UTF8Encoding(true).GetBytes
                        (
                            item.posX.ToString() + " " +
                            item.posY.ToString() + " " +
                            item.rSignal.ToString() + " " +
                            item.index.ToString() + " " +
                            name + " " +
                            description + " " +
                            location + " " +
                            item.mode.ToString() + "\n"
                        );

                    fs.Write(node,0, node.Length);
                }
            }
        }

        private void LoadPreferences_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            nodeList.Clear();
            string filename = openFileDialog.FileName;

            foreach(var line in File.ReadLines(filename))
            {
                List<string> vars = line.Split(' ').ToList();
                var flagToApped = false;

                for (int i = 0; i < vars.Count; i++)
                {
                    if (vars[i].Contains('%'))
                        vars[i] = vars[i].Replace('%', ' ');

                    #region 1st solution
                    //if (vars[i] == "'")
                    //{
                    //    flagToApped = !flagToApped;
                    //    vars.RemoveAt(i);
                    //    continue;
                    //}

                    //if (flagToApped)
                    //{
                    //    vars[i - 1] = vars[i-1] + " " + vars[i];
                    //    vars.RemoveAt(i);
                    //}
                    #endregion
                }

                switch (vars.Count)
                {
                    case 1:
                        nextId = int.Parse(vars[0]);
                        break;
                    case 2:

                        break;
                    case 8:
                                                
                        switch (vars[7])
                        {
                            case "Sender":
                                _mode = NodeMode.Sender;
                                break;
                            case "Transporter":
                                _mode = NodeMode.Transporter;
                                break;
                            case "Receiver":
                                _mode = NodeMode.Receiver;
                                break;
                        }

                        var node = new Node(int.Parse(vars[3]), int.Parse(vars[0]), int.Parse(vars[1]), int.Parse(vars[2]), _mode);

                        if (vars[4] != "null")
                            node.Name = vars[4];

                        if (vars[5] != "null")
                            node.Description = vars[5];

                        if (vars[6] != "null")
                            node.Location = vars[6];

                        nodeList.Add(node);
                        canvas.Invalidate();
                        break;
                       
                }
            }

        }

    }
}
