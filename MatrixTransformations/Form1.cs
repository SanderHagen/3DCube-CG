﻿using System;
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
        public class formTimer
        {
            public static System.Timers.Timer timer;
            public formTimer()
            {
                timer = new System.Timers.Timer();
                timer.Interval = 100;
            }
        }

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

            formTimer timer = new formTimer();
            formTimer.timer.Elapsed += onTimerElapsed;

            cube1 = new Cube(Color.Purple);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            ShowInfo();
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
                formTimer.timer.Start();

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

        private void onTimerElapsed(object sender, EventArgs e)
        {
            if (animationstarted)
            {
                if (!phase1finished)
                {
                    Phase1();
                }

                if (phase1finished && !phase2finished)
                {
                    Phase2();
                }

                if (phase1finished && phase2finished && !phase3finished)
                {
                    Phase3();
                }
                if (phase1finished && phase2finished && phase3finished)
                {
                    ResetPhase();
                }
                Console.WriteLine(phase);

                Invalidate();
            }
        }

        private void ResetPhase()
        {
            phase = 4;
            if (theta != -100)
            {
                theta++;
            }
            if (phi != -10)
            {
                phi--;
            }

            if (theta == -100 && phi == -10)
            {
                phase1finished = false;
                phase2finished = false;
                phase3finished = false;
                formTimer.timer.Stop();
            }
        }

        private void Phase3()
        {
            phase = 3;
            phi++;
            double degrees = (180 / Math.PI) * currentrotatey;

            if (degrees >= 45)
            {
                rotatebacky = true;
            }

            if (rotatebacky)
            {
                ry -= 0.1;
                currentrotatey -= 0.1;
                if (currentrotatey == 0)
                {
                    phase3finished = true;
                }
            }
            else
            {
                ry += 0.1;
                currentrotatey += 0.1;
            }
        }

        private void Phase2()
        {

            phase = 2;
            theta--;
            double degrees = (180 / Math.PI) * currentrotatex;
            if (degrees >= 45)
            {
                rotatebackx = true;
            }

            if (rotatebackx)
            {
                rx -= 0.1;
                currentrotatex -= 0.1;
                if (currentrotatex <= 0)
                {
                    phase2finished = true;
                }
            }
            else
            {
                rx += 0.1;
                currentrotatex += 0.1;
            }

        }

        private void Phase1()
        {

            phase = 1;
            theta--;
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
                if (scale <= 1)
                {
                    phase1finished = true;
                }
            }

        }

        private void ShowInfo()
        {
            double degreesrotate = (180 / Math.PI) * currentrotatex;

            transXVal.Text = tx.ToString();
            transYVal.Text = ty.ToString();
            transZVal.Text = tz.ToString();
            rotXVal.Text = rx.ToString();
            rotYVal.Text = ry.ToString();
            rotZVal.Text = rz.ToString();
            scaleVal.Text = scale.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
