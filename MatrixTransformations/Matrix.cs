using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransformations
{
    public class Matrix
    {
        public float[,] mat = new float[4, 4];

        public Matrix()
        {
            mat[0, 0] = 1;
            mat[0, 1] = 0;
            mat[0, 2] = 0;
            mat[0, 3] = 0;
            mat[1, 0] = 0;
            mat[1, 1] = 1;
            mat[1, 2] = 0;
            mat[1, 3] = 0;
            mat[2, 0] = 0;
            mat[2, 1] = 0;
            mat[2, 2] = 1;
            mat[2, 3] = 0;
            mat[3, 0] = 0;
            mat[3, 1] = 0;
            mat[3, 2] = 0;
            mat[3, 3] = 1;
        }

        public Matrix(float m11, float m12, float m13, float m14,
                      float m21, float m22, float m23, float m24,
                      float m31, float m32, float m33, float m34,
                      float m41, float m42, float m43, float m44)
        {
            mat[0, 0] = m11;
            mat[0, 1] = m12;
            mat[0, 2] = m13;
            mat[0, 3] = m14;
            mat[1, 0] = m21;
            mat[1, 1] = m22;
            mat[1, 2] = m23;
            mat[1, 3] = m24;
            mat[2, 0] = m31;
            mat[2, 1] = m32;
            mat[2, 2] = m33;
            mat[2, 3] = m34;
            mat[3, 0] = m41;
            mat[3, 1] = m42;
            mat[3, 2] = m43;
            mat[3, 3] = m44;
        }

        public Matrix(Vector v)
        {
            mat[0, 0] = v.x;
            mat[0, 1] = 0;
            mat[0, 2] = 0;
            mat[0, 3] = 0;
            mat[1, 0] = v.y;
            mat[1, 1] = 0;
            mat[1, 2] = 0;
            mat[1, 3] = 0;
            mat[2, 0] = v.z;
            mat[2, 1] = 0;
            mat[2, 2] = 0;
            mat[2, 3] = 0;
            mat[3, 0] = 1;
            mat[3, 1] = 0;
            mat[3, 2] = 0;
            mat[3, 3] = 1;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix newMat = new Matrix();
            for (int i = 0; i < m1.mat.GetLength(0); i++)
            {
                for (int j = 0; j < m1.mat.GetLength(1); j++)
                {
                    newMat.mat[i, j] = m1.mat[i, j] + m2.mat[i, j];
                }
            }
            return newMat;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix newMat = new Matrix();
            for (int i = 0; i < m1.mat.GetLength(0); i++)
            {
                for (int j = 0; j < m1.mat.GetLength(1); j++)
                {
                    newMat.mat[i, j] = m1.mat[i, j] - m2.mat[i, j];
                }
            }
            return newMat;
        }
        public static Matrix operator *(Matrix m1, float f)
        {
            for (int i = 0; i < m1.mat.GetLength(0); i++)
            {
                for (int j = 0; j < m1.mat.GetLength(1); j++)
                {
                    m1.mat[i, j] = m1.mat[i, j] * f;
                }
            }
            return m1;
        }

        public static Matrix operator *(float f, Matrix m1)
        {
            for (int row = 0; row < m1.mat.GetLength(0); row++)
            {
                for (int column = 0; column < m1.mat.GetLength(1); column++)
                {
                    m1.mat[row, column] = f * m1.mat[row, column];
                }
            }
            return m1;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix newMatrix = new Matrix();

            if (m1.mat.GetLength(0) != m2.mat.GetLength(1))
            {
                throw new Exception("matrixes not equal size");
            }

            for (int row = 0; row < m1.mat.GetLength(0); row++)
            {
                for (int column = 0; column < m1.mat.GetLength(1); column++)
                {
                    float val = 0;
                    for (int index = 0; index < m1.mat.GetLength(0); index++)
                    {
                        val = val + (m1.mat[row, index] * m2.mat[index, column]);
                    }
                    newMatrix.mat[row, column] = val;
                }
            }
            return newMatrix;
        }

        public static Vector operator *(Matrix m1, Vector v)
        {
            Vector newVector = new Vector();

            Matrix vector = new Matrix(v);

            Matrix solution = m1 * vector;

            newVector.x = solution.mat[0, 0];
            newVector.y = solution.mat[1, 0];
            newVector.z = solution.mat[2, 0];

            return newVector;
        }

        public static Matrix Identity()
        {
            return new Matrix();
        }

        public static Matrix Scale(float s)
        {
            return new Matrix(s, 0, 0, 0,
                              0, s, 0, 0,
                              0, 0, s, 0,
                              0, 0, 0, 1);
        }


        public static Matrix RotationZ(double alpha)
        {
            return new Matrix(
                (float)Math.Cos(alpha), (float)-Math.Sin(alpha), 0, 0,
                (float)Math.Sin(alpha), (float)Math.Cos(alpha), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
                );
        }


        public static Matrix RotationX(double alpha)
        {
            return new Matrix(
                1, 0, 0, 0,
                0, (float)Math.Cos(alpha), (float)-Math.Sin(alpha), 0,
                0, (float)Math.Sin(alpha), (float)Math.Cos(alpha), 0,
                0, 0, 0, 1
                );
        }

        public static Matrix RotationY(double alpha)
        {
            return new Matrix(
                (float)Math.Cos(alpha), 0, (float)Math.Sin(alpha), 0,
                0, 1, 0, 0,
                (float)-Math.Sin(alpha), 0, (float)Math.Cos(alpha), 0,
                0, 0, 0, 1
                );
        }

        public static Matrix Translate(Vector t)
        {
            return new Matrix(1, 0, 0, t.x,
                              0, 1, 0, t.y,
                              0, 0, 1, t.z,
                              0, 0, 0, 1);
        }

        public static Matrix View(float theta, float phi, float r)
        {

            double thetarad = (Math.PI / 180) * theta;
            double phirad = (Math.PI / 180) * phi;


            //Klopt het dat de cos van phi hetzelfde is als sin theta maar dan negatief?
            //cos theta en sin phi zijn hetzelfde bij de standaardwaarden
            float sinth = (float)Math.Sin(thetarad);
            float costh = (float)Math.Cos(thetarad);
            float sinph = (float)Math.Sin(phirad);
            float cosph = (float)Math.Cos(phirad);

            return new Matrix(
                    -sinth, costh, 0, 0,
                    -costh * cosph, -cosph * sinth, sinph, 0,
                    costh * sinph, sinth * sinph, cosph, -r,
                    0, 0, 0, 1
            );
        }

        public static Matrix Projection(float d, float z)
        {
            float p = -(d / z);

            return new Matrix(
                p, 0, 0, 0,
                0, p, 0, 0,
                0, 0, 0, 0,
                0, 0, 0, 0
            );
        }

        public override string ToString()
        {
            string toReturn = "";
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    toReturn += string.Format("{0} ", mat[i, j]);
                }
                toReturn += "\n";
            }
            return toReturn;
        }
    }
}
