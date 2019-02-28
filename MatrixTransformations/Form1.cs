using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixTransformations
{
    public partial class Form1 : Form
    {
        AxisY y;
        AxisX x;
        AxisZ z;
        Cube cube1;

        public Form1()
        {
            InitializeComponent();

            this.Width = 800;
            this.Height = 600;

            x = new AxisX(3);
            y = new AxisY(3);
            z = new AxisZ(3);

            cube1 = new Cube(Color.Purple);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            List<Vector> vb;

            vb = new List<Vector>();

            vb = ViewingPipeline(cube1.vertexbuffer);
            cube1.Draw(e.Graphics, vb);

            vb = ViewingPipeline(x.vb);

            x.Draw(e.Graphics,vb);

            vb = ViewingPipeline(y.vb);

            y.Draw(e.Graphics,vb);

            vb = ViewingPipeline(z.vb);

            z.Draw(e.Graphics, vb);
        }

        public List<Vector> ViewingPipeline(List<Vector> vb)
        {
            float d = 800;
            float r = 10;
            float theta = -100;
            float phi = -10;

            List<Vector> res = new List<Vector>();
            Vector vp = new Vector();
            Matrix vMat = Matrix.View(theta, phi, r);

            foreach (Vector v in vb)
            {
                vp = vMat * v;

                Matrix p = Matrix.Projection(d, vp.z);

                vp = p * vp;

                res.Add(vp);
            }
            
            res = ViewportTransformation(Width, Height, res);

            return res;
        }

        public static List<Vector> ViewportTransformation(float width, float height, List<Vector> vectors)
        {
            List<Vector> result = new List<Vector>();
            float dx = width / 2;
            float dy = height / 2;
            foreach (Vector v in vectors)
            {
                Vector v2 = new Vector(v.x + dx, dy - v.y,0);
                result.Add(v2);
            }

            return result;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.X)
            {
                
            }
        }
    }
}
