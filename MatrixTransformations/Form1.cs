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

        int phase = 0;
        bool phase1finished = false;
        bool phase2finished = false;
        bool phase3finished = false;
        bool animationstarted = false;
        bool rotatebackx = false;
        bool scaleback = false;
        bool rotatebacky = false;
        double currentscale = 0;
        double currentrotatex = 0;
        double currentrotatey = 0;


        double tx = 0;
        double ty = 0;
        double tz = 0;

        double rx = 0;
        double ry = 0;
        double rz = 0;

        double scale = 1;

        float d = 800;
        float r = 10;
        float theta = -100;
        float phi = -10;

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

            Matrix S = Matrix.Scale((float)scale);

            Matrix T = Matrix.Translate(new Vector((float)tx, (float)ty, (float)tz));

            Matrix R = Matrix.RotationX(rx) * Matrix.RotationY(ry) * Matrix.RotationZ(rz);

            Matrix total = S * R * T;

            foreach (Vector v in cube1.vertexbuffer)
            {
                Vector vp = total * v;
                vb.Add(vp);
            }

            vb = ViewingPipeline(vb);
            cube1.Draw(e.Graphics, vb);

            vb = ViewingPipeline(x.vb);

            x.Draw(e.Graphics, vb);

            vb = ViewingPipeline(y.vb);

            y.Draw(e.Graphics, vb);

            vb = ViewingPipeline(z.vb);

            z.Draw(e.Graphics, vb);
        }

        public List<Vector> ViewingPipeline(List<Vector> vb)
        {
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
                Vector v2 = new Vector(v.x + dx, dy - v.y, 0);
                result.Add(v2);
            }

            return result;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                tx -= 0.1;
            }
            if (e.KeyCode == Keys.Right)
            {
                tx += 0.1;
            }

            if (e.KeyCode == Keys.Up)
            {
                ty += 0.1;
            }

            if (e.KeyCode == Keys.Down)
            {
                ty -= 0.1;
            }

            if (e.KeyCode == Keys.PageUp)
            {
                tz += 0.1;
            }

            if (e.KeyCode == Keys.PageDown)
            {
                tz -= 0.1;
            }

            if (e.KeyCode == Keys.X)
            {
                if (e.Shift)
                {
                    rx -= 0.1;
                }
                else
                {
                    rx += 0.1;
                }
            }

            if (e.KeyCode == Keys.Y)
            {
                if (e.Shift)
                {
                    ry -= 0.1;
                }
                else
                {
                    ry += 0.1;
                }
            }


            if (e.KeyCode == Keys.Z)
            {
                if (e.Shift)
                {
                    rz -= 0.1;
                }
                else
                {
                    rz += 0.1;
                }
            }
            if (e.KeyCode == Keys.S)
            {
                if (e.Shift)
                {
                    scale -= 0.1;
                }
                else
                {
                    scale += 0.1;
                }
            }

            if (e.KeyCode == Keys.A)
            {
                animationstarted = true;


            }

            if (e.KeyCode == Keys.C)
            {
                tx = 0;
                ty = 0;
                tz = 0;

                rx = 0;
                ry = 0;
                rz = 0;

                scale = 1;

                d = 800;
                r = 10;
                theta = -100;
                phi = -10;
            }


            this.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (animationstarted)
            {
                if (!phase1finished)
                {
                    if (scale >= 1.4999)
                    {
                        scaleback = true;
                    }
                    if (scale < 1.5 && !scaleback)
                    {
                        scale += 0.01;
                    }

                    if (scaleback)
                    {
                        scale -= 0.01;
                        if(scale <= 1)
                        {
                            phase1finished = true;
                        }
                    }
                }

                if (phase1finished && !phase2finished)
                {
                    //TODO: de rotatie wordt in radialen meegegeven, dit moet omgezet worden naar graden.
                    Console.WriteLine(currentrotatex);
                    if (currentrotatex >= 45)
                    {
                        rotatebackx = true;
                    }

                    if (rotatebackx)
                    {
                        rx -= 0.01;
                        currentrotatex -= -.01;
                        if (currentrotatex <= 0)
                        {
                            phase2finished = true;
                        }
                    }
                    else
                    {
                        rx += 0.01;
                        currentrotatex += 0.01;
                    }
                }

                if (phase1finished && phase2finished && !phase3finished)
                {
                    if (currentrotatey == 45)
                    {
                        rotatebacky = true;
                    }

                    if (rotatebacky)
                    {
                        ry -= 1;
                        currentrotatey--;
                        if (currentrotatey == 0)
                        {
                            phase3finished = true;
                        }
                    }
                    else
                    {
                        ry += 1;
                        currentrotatey++;
                    }
                }

                this.Invalidate(true);
            }
        }
    }
}
