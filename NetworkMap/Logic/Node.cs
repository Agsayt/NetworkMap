using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMap.Logic
{
    class Node
    {

        private Guid id;
        public int posX;
        public int posY;
        private float rSignal;
        public float rNode;       
        private string Name { get; set; }
        private string Description { get; set; }
        private string Location { get; set; }

        public bool IsSelected { get; set; }
        
        public Node(int x, int y, int r, NetworkMap.Form1.NodeMode mode)
        {
            id = Guid.NewGuid();
            posX = x;
            posY = y;
            var noder = 10;

            if (r < 0)
                rSignal = Math.Abs(r);
            else
                rSignal = r;

            if (noder >= rSignal)
                rNode = rSignal - 0.1f;
            else
                rNode = noder;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetDescription(string desc)
        {
            Description = desc;
        }

        public void SetLocation (string location)
        {
            Location = location;
        }

        public void ChangePosition(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public void ChangeRadius(float r)
        {
            rSignal = r;
        }

        public void Draw(Graphics g)
        {
            float diameter = rSignal + rSignal;
            float nodeDiameter = rNode + rNode;
            float x0 = posX - rSignal;
            float y0 = posY - rSignal;
            float x0Node = posX - rNode;
            float y0Node = posY - rNode;
            Pen p = Pens.Black;

            if (IsSelected == true)
            {
                g.DrawEllipse(p, x0, y0, diameter, diameter);
                p = Pens.Red;
            }

            g.DrawEllipse(p, x0Node, y0Node, nodeDiameter, nodeDiameter);
        }



    }
}
