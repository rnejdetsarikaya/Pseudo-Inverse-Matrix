using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoInverse.Maths
{
    class Matrix
    {
        public double[,] matrix { get; private set; }
        private int X, Y;
        static Variables singleObject = Variables.Instance;
        public Matrix(int X,int Y)
        {
            this.matrix = new double[X, Y];
            this.X = X;
            this.Y = Y;
        }

        public double[,] GetTranspose()
        {
            double[,] matrixTranspose = new double[Y, X];
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    matrixTranspose[i, j] = matrix[j, i];
                }
            }

            return matrixTranspose;
        }

        

        public static bool isFullRank(double[,] matrix1)
        {
            int X = matrix1.GetLength(0);
            int Y = matrix1.GetLength(1);
            if (X == 1)
                return true;
            double value = 0;
            int k = 0;
            for (int i = 0; i < X; i++)
            {
                singleObject.Loops++;
                for (int j = i + 1; j < X; j++)
                {
                    singleObject.Loops++;
                    for (k = 0; k < Y; k++)
                    {
                        singleObject.Loops++;
                        if (value == 0)
                        {
                            value = matrix1[i, k] / matrix1[j, k];
                            singleObject.Multiplactions++;
                        }
                        else if (value != matrix1[i, k] / matrix1[j, k])
                        {
                            singleObject.Multiplactions++;
                            break;
                        }
                        singleObject.Multiplactions++;
                    }
                    if (k == Y)
                        return false;
                    value = 0;
                }

            }

            return true;
        }

        public static void InitializePolynomMatrix(Polynom[,] polynoms)
        {
            for (int i = 0; i < polynoms.GetLength(0); i++)
            {
                for (int j = 0; j < polynoms.GetLength(0); j++)
                {
                    if (i == j)
                        polynoms[i, j] = new Polynom(1);
                    else
                        polynoms[i, j] = new Polynom(0);
                }
            }
        }

        public static double Determinant(double[,] matrix1)
        {
            int a = matrix1.GetLength(0);
            int b = matrix1.GetLength(1);
            if (a != b)
                throw new Exception("Kare matris değil!");

            if (a == 1)
                return matrix1[0, 0];

            if (a == 2)
            {
                singleObject.Multiplactions += 2;
                singleObject.Additions++;
                return matrix1[0, 0] * matrix1[1, 1] - matrix1[0, 1] * matrix1[1, 0];
            }
            double det = 0;
            for (int i = 0; i < a; i++)
            {
                singleObject.Loops++;
                double[,] minor = new double[a - 1, a - 1];
                for (int j = 0; j < a; j++)
                {
                    singleObject.Loops++;
                    for (int k = 0; k < a; k++)
                    {
                        singleObject.Loops++;
                        if (i == j || 0 == k)
                            continue;
                        minor[j - (j > i ? 1 : 0), k - (k > 0 ? 1 : 0)] = matrix1[j, k];
                    }
                }
                singleObject.Multiplactions += 2;
                det += ((i) % 2 == 0 ? 1 : -1) * matrix1[i, 0] * Determinant(minor);
            }

            return det;
        }

        public static Polynom Determinant(Polynom[,] matrix)
        {
            int a = matrix.GetLength(0);
            int b = matrix.GetLength(1);
            Polynom det = new Polynom(a);

            if (a != b)
            {
                throw new Exception("Kare matris değil!");
            }
            if (a == 1)
                return matrix[0,0];

            if (a == 2)
            {
                return Polynom.PolynomSub(Polynom.MultiplyPolynomials(matrix[0, 0], matrix[1, 1]), Polynom.MultiplyPolynomials(matrix[0, 1], matrix[1, 0]));
            }


            Polynom factor = new Polynom(0);
            Polynom temp;

            for (int i = 0; i < a; i++)
            {
                Polynom[,] minor = new Polynom[a - 1, a - 1];
                InitializePolynomMatrix(minor);
                for (int j = 0; j < a; j++)
                {
                    for (int k = 0; k < a; k++)
                    {
                        if (i == j || 0 == k)
                            continue;
                        minor[j - (j > i ? 1 : 0), k - (k > 0 ? 1 : 0)] = matrix[j, k];
                    }
                }
                factor.Coefficients[0] = ((i) % 2 == 0 ? 1 : -1);
                
                temp = Polynom.MultiplyPolynomials(factor, matrix[i, 0]);
                var deneme = Determinant(minor);
                temp = Polynom.MultiplyPolynomials(temp, Determinant(minor));
                det = Polynom.PolynomSum(det,temp);
            }

            return det;
        }

        public static Polynom[,] ToPolynom(double[,] matrix)
        {
            Polynom[,] polyMatrix = new Polynom[matrix.GetLength(0), matrix.GetLength(1)];
            InitializePolynomMatrix(polyMatrix);

            for (int i = 0; i < polyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < polyMatrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        polyMatrix[i, j].Coefficients[0] = matrix[i, j];
                        polyMatrix[i, j].Coefficients[1] = -1;
                    }
                    else
                        polyMatrix[i, j].Coefficients[0] = matrix[i, j];
                }
            }

            return polyMatrix;
        }

        public static double[,] multiplyMatrix(double[,] matrix1, double[,] matrix2)
        {
            double temp = 0;
            int matrix1M = matrix1.GetLength(0);
            int matrix1N = matrix1.GetLength(1);
            int matrix2M = matrix2.GetLength(0);
            int matrix2N = matrix2.GetLength(1);
            double[,] matrixMultiply = new double[matrix1M, matrix2N];
            for (int i = 0; i < matrix1M; i++)
            {
                // 1M
                singleObject.Loops++;
                for (int j = 0; j < matrix2N; j++)
                {
                    singleObject.Loops++;
                    for (int k = 0; k < matrix1N; k++)
                    {
                        singleObject.Loops++;
                        temp += matrix1[i, k] * matrix2[k, j];
                        singleObject.Additions++;
                        singleObject.Multiplactions++;
                    }
                    matrixMultiply[i, j] = temp;
                    temp = 0;
                }
            }
            return matrixMultiply;
        }

        public static double[,] getTranspose(double[,] matrix1)
        {
            int X = matrix1.GetLength(0);
            int Y = matrix1.GetLength(1);
            double[,] matrixTranspose = new double[Y, X];
            for (int i = 0; i < Y; i++)
            {
                singleObject.Loops++;
                for (int j = 0; j < X; j++)
                {
                    singleObject.Loops++;
                    matrixTranspose[i, j] = matrix1[j, i];
                }
            }

            return matrixTranspose;
        }

        public static double[,] getInverse(double[,] matrix1)
        {
            int a = matrix1.GetLength(0);
            int b = matrix1.GetLength(1);
            double[,] unitMatrix = new double[a, b];
            for (int i = 0; i < a; i++)
            {
                singleObject.Loops++;
                for (int j = 0; j < b; j++)
                {
                    singleObject.Loops++;
                    if (i == j)
                        unitMatrix[i, j] = 1;
                    else
                        unitMatrix[i, j] = 0;
                }
            }
            double[] temp = new double[a];
            double[] tempUnit = new double[a];
            for (int i = 0; i < a; i++)
            {
                singleObject.Loops++;
                tempUnit[i] = unitMatrix[0, i];
            }
            for (int i = 0; i < b; i++)
            {
                singleObject.Loops++;
                for (int j = 0; j < a; j++)
                {
                    singleObject.Loops++;
                    if (matrix1[i, i] != 1)
                    {
                        j = i;
                        for (int ii = 0; ii < a; ii++)
                        {
                            singleObject.Loops++;
                            temp[ii] = matrix1[i, ii];
                            tempUnit[ii] = unitMatrix[i, ii];
                        }
                        double value = temp[i];
                        for (int k = 0 + i; k < b; k++)
                        {
                            singleObject.Loops++;
                            matrix1[j, k] = matrix1[j, k] / value;
                            singleObject.Multiplactions++;
                            temp[k] = matrix1[j, k];
                        }
                        for (int k = 0; k < b; k++)
                        {
                            singleObject.Loops++;
                            unitMatrix[j, k] = unitMatrix[j, k] / value;
                            singleObject.Multiplactions++;
                            tempUnit[k] = unitMatrix[j, k];
                        }
                        j = 0;
                    }

                    if (i != j && matrix1[i, i] == 1)
                    {

                        double value = matrix1[j, i];
                        for (int k = 0 + i; k < b; k++)
                        {
                            singleObject.Loops++;
                            matrix1[j, k] = matrix1[j, k] - value * temp[k];
                            singleObject.Multiplactions++;
                            singleObject.Additions++;
                        }
                        for (int k = 0; k < b; k++)
                        {
                            singleObject.Loops++;
                            unitMatrix[j, k] = unitMatrix[j, k] - value * tempUnit[k];
                            singleObject.Multiplactions++;
                            singleObject.Additions++;
                        }
                    }
                }
            }
            return unitMatrix;
        }
    }
}
