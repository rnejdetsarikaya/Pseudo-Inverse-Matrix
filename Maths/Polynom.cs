using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoInverse.Maths
{
    class Polynom
    {
        public int Degree { get; private set; }
        public double[] Coefficients { get; private set; }
        public Polynom(int Degree)
        {
            this.Degree = Degree;
            Coefficients = new double[Degree+1];

        }

        //polinom toplaması
        public static Polynom PolynomSum (Polynom a, Polynom b)
        {
            Polynom result = new Polynom(Math.Max(a.Degree, b.Degree));
            Polynom max;

            if (a.Degree > b.Degree)
                max = a;
            else
                max = b;
                     
            for (int i = 0; i < result.Coefficients.Length; i++)
            {
                if (i <= Math.Min(a.Degree, b.Degree))
                    result.Coefficients[i] = a.Coefficients[i] + b.Coefficients[i];
                else
                    result.Coefficients[i] = max.Coefficients[i];
            }

            return result;
        }
        // polinom çıkartması
        public static Polynom PolynomSub(Polynom a, Polynom b)
        {
            Polynom result = new Polynom(Math.Max(a.Degree, b.Degree));
            Polynom max;

            if (a.Degree > b.Degree)
                max = a;
            else
                max = b;

            for (int i = 0; i < result.Coefficients.Length; i++)
            {
                if (i <= Math.Min(a.Degree, b.Degree))
                    result.Coefficients[i] = a.Coefficients[i] - b.Coefficients[i];
                else if (max.Equals(b))
                    result.Coefficients[i] = -max.Coefficients[i];
                else
                    result.Coefficients[i] = max.Coefficients[i];
            }

            return result;
        }
        // polinom çarpması 
        public static Polynom MultiplyPolynomials(Polynom a, Polynom b)
        {
            Polynom result = new Polynom(a.Degree + b.Degree);
            Polynom temp = new Polynom(result.Degree);

            for (int i = 0; i < a.Coefficients.Length; i++)
            {
                for (int j = 0; j < b.Coefficients.Length; j++)
                {
                    temp.Coefficients[i+j] =  a.Coefficients[i] * b.Coefficients[j];
                }
                result = PolynomSum(result, temp);
                temp = new Polynom(result.Degree);
            }

            return result;
        }
        //türev
        public static Polynom Derivative(Polynom a)
        {
            if(a.Degree == 0)
            {
                return new Polynom(0);
            }
            Polynom result = new Polynom(a.Degree - 1);

            for (int i = 1; i < a.Coefficients.Length; i++)
            {
                result.Coefficients[i - 1] = i * a.Coefficients[i];
            }
            return result;
        }
        // fonksiyonda yerine koyma
        private static double f(Polynom equation,double input)
        {
            double output = 0;

            if (equation.Degree == 0)
                return equation.Coefficients[0];

            for (int i = 1; i < equation.Coefficients.Length; i++)
            {
                output += equation.Coefficients[i] * Math.Pow(input, i);
            }
            output += equation.Coefficients[0];

            return output;
        }

        private static double negate(double number)
        {
            return -number;
        }
        //öz degerler
        public static List<double> eigenValues(double[,] matrix)
        {
            var polyMatrix = Matrix.ToPolynom(matrix);
            Polynom result = Matrix.Determinant(polyMatrix);

            for (int i = 0; i < result.Coefficients.Length; i++)
            {
                if (Math.Abs(result.Coefficients[i]) < 0.00000001)
                {
                    result.Coefficients[i] = 0;
                }
            }

            int count = 0;
            double root = 0;
            List<double> roots = new List<double>();
            int deegre = result.Degree;
            while (deegre > count)
            {
                if (result.Degree == 1)
                {
                    root = Math.Round(-result.Coefficients[0] / (result.Coefficients[1]), 4);
                    roots.Add(root);
                    break;
                }
                else
                {
                    root = NewtonRaphson(result);
                    root = Math.Round(root, 4);
                    roots.Add(root);
                    result = DivideToRoot(result, root);
                    count++;
                }
            }

            return roots;
        }
        //öz vektörler
        private static double[] findEigenVector(double[,] matrix)
        {
            int a = matrix.GetLength(1);
            double[] systemsRoots = new double[a];
            if (a == 1)
            {
                systemsRoots[0] = 1;
                return systemsRoots;
            }

            int row = -1;
            for (int i = 0; i < a; i++)
            {
                if (matrix[i, a - 1] != 0)
                {
                    row = i;
                    break;
                }
            }
            if (row == -1)
            {
                throw new Exception("Denklem Çözümü YOK!");
            }

            for (int i = 0; i < a; i++)
            {
                if (row == i)
                    continue;

                double rowLastElement = matrix[row, a - 1];
                double currentRowLastElement = matrix[i, a - 1];

                if (currentRowLastElement == 0)
                    continue;

                for (int j = 0; j < a; j++)
                {
                    matrix[i, j] = rowLastElement * matrix[i, j] / currentRowLastElement - matrix[row, j];
                }
            }

            double[,] minor = new double[a - 1, a - 1];
            for (int i = 0; i < a; i++)
            {
                if (row == i)
                    continue;
                for (int j = 0; j < minor.GetLength(0); j++)
                {
                    minor[i - (i > row ? 1 : 0), j] = matrix[i, j];
                }
            }

            double[] minorsRoots = findEigenVector(minor);

            for (int i = 0; i < minorsRoots.Length; i++)
            {
                systemsRoots[i] = minorsRoots[i];
            }

            double sum = 0;
            for (int j = 0; j < a - 1; j++)
            {
                sum += matrix[row,j] * systemsRoots[j];
            }
            systemsRoots[a-1] = -sum /matrix[row,a-1];


            return systemsRoots;
        }

        public static List<double[]> eigenVectorMatrix(double[,] matrix, List<double> roots)
        {
            List<double[,]> matrices = new List<double[,]>();
            List<double[]> eigenVectors = new List<double[]>();
            double[,] clone = (double[,])matrix.Clone();

            foreach (var root in roots)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (i == j)
                        {
                            clone[i,j] = matrix[i, j] - root;
                        }
                    }
                }
                if(root != 0)//root 0 olduğu durumlarda özvektör yoktur.
                matrices.Add(clone);
                clone = (double[,])matrix.Clone();
            }

            foreach (var aMatrix in matrices)
            {
                eigenVectors.Add(findEigenVector(aMatrix));
            }
            
            return eigenVectors;
        }
      
        // newton raphson yöntemi
        private static double NewtonRaphson(Polynom equation)
        {
            Polynom derivate = Derivative(equation);
            //10^-16
            double epsilon = 0.00000000000000001;
            double difference = 1D;
            int count = 0;
            double lastResult = 0;
            double result = 0;
            double iteratePoint = 0;
            // xi - f(xi)/f'(xi)
            while (f(Derivative(derivate), iteratePoint) * f(equation, iteratePoint) <= 0)//Newton Raphson teoremi yakınsaklık şartı f''(x0).f(x0) > 0 olmalı
            {
                //0 dan başlayarak 0.1 artırım ile + ve - değerlerini dene
                if (iteratePoint >= 0) 
                    iteratePoint += 0.1;
                iteratePoint = negate(iteratePoint);
            }


            lastResult = result;
            count++;

            while (difference > epsilon)// |Xk+1-Xk| < epsilon olduğunda son bulduğumuz değer bir köktür.
            {
                result = result - f(equation, result) / f(derivate, result);
                difference = Math.Abs(result - lastResult);
                lastResult = result;

                if (count++ == 5000000)
                    throw new Exception("Kök Bulunamadı");
            }

            return lastResult;
        }

        private static Polynom ReducedDegreeClone(Polynom polynom)
        {
            Polynom poly = new Polynom(polynom.Degree - 1);

            for (int i = 0; i < poly.Coefficients.Length; i++)
            {
                poly.Coefficients[i] = polynom.Coefficients[i];
            }

            return poly;
        }
        // köke bölme
        private static Polynom DivideToRoot(Polynom equation, double root)
        {
            Polynom quotient = new Polynom(equation.Degree - 1);
            Polynom divisor = new Polynom(1);
            Polynom temp = new Polynom(equation.Degree - 1);
            divisor.Coefficients[0] = -root;
            divisor.Coefficients[1] = 1;

            while(equation.Degree != 0)
            {
                quotient.Coefficients[equation.Degree - divisor.Degree] = equation.Coefficients[equation.Degree] / divisor.Coefficients[divisor.Degree];
                equation = PolynomSub(equation, MultiplyPolynomials(quotient, divisor));
                temp = PolynomSum(temp, quotient);
                quotient = ReducedDegreeClone(quotient);
                equation = ReducedDegreeClone(equation);
            }

            return temp;
        }

    }
}
