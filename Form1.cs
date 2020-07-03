using PseudoInverse.Maths;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoInverse
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        TextBox[][] tbMatrix = new TextBox[5][];
        Random random = new Random();
        Boolean flag = false;
        int X = 0, Y = 0;
        double[,] matrix;
        Size size;
        Variables singleObject = Variables.Instance;
        Steps steps = new Steps();

        public Form1()
        {
            InitializeComponent();
            createMatrix();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            steps.Visible = false;
            Controls.Add(steps);
            singleObject.Additions = 0;
            singleObject.Multiplactions = 0;
            singleObject.Loops = 0;
            // Matrix matrix = new Matrix(3,4);


        }

        public double createRandomValue()
        {
            double a = random.NextDouble();
            double value = 0;
            while (value == 0)
            {
                value = Math.Round(a, 1) + random.Next(9);
                if (value > 9)
                    value = 9;
            }


            return value;
        }

        public void createMatrix()
        {
            TextBox textBox;
            for (int i = 0; i < 25; i++)
            {
                textBox = new TextBox();
                textBox.TextChanged += textBox1_TextChanged;
                textBox.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
                textBox.Location = new Point(14 + 36 * (i % 5), 60 + 33 * (i / 5));
                textBox.Font = new Font("Microsoft Sans Serif", 15F);
                textBox.Size = new Size(33, 30);
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Visible = false;
               // textBox.Enabled = false;
                if (i % 5 == 0)
                    tbMatrix[i / 5] = new TextBox[5];
                tbMatrix[i / 5][i % 5] = textBox;
                Controls.Add(textBox);

            }
        }
        
        public void createMatrix(int X, int Y)
        {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    tbMatrix[i][j].Visible = true;
                    if (flag)
                        tbMatrix[i][j].Enabled = false;
                    else
                    {
                        tbMatrix[i][j].Enabled = true;
                        tbMatrix[i][j].Text = string.Empty;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = ((TextBox)sender).Text;
            double value = 0;
            if (!double.TryParse(text, out value) || text.Equals("0"))
            {
                ((TextBox)sender).Text = "";
            }
            if (text.Length > 1 && text[1] != ',')
                ((TextBox)sender).Text = text.Substring(0,1);
            else if (text.Length > 3 && text[1] == ',')
                ((TextBox)sender).Text = text.Substring(0, 3);


        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void randomMatrix_Click(object sender, EventArgs e)
        {
            //double presudoInverse;
            flag = true;
            X = random.Next(1, 5);
            Y = random.Next(1, 5);
            while(X == Y)
            {
                Y = random.Next(1, 5);
            }
            

            for (int i = 0; i < 25; i++)
            {
                tbMatrix[i / 5][i % 5].Visible = false;
            }
            createMatrix(X, Y);
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    tbMatrix[i][j].Text = createRandomValue().ToString();
                }
            }

        }

        public double[,] SingularValueDecomposition(double[,] matrix1)
        {
            var eigenValues = Polynom.eigenValues(matrix1);
            var eigenVectors = Polynom.eigenVectorMatrix(matrix1, eigenValues);
            double vectorMagnitude = 0;//sqrt(a^2+b^2)
            foreach (var eigenvector in eigenVectors)
            {
                double sums = 0;
                for (int i = 0; i < eigenvector.Length; i++)
                {
                    sums += eigenvector[i] * eigenvector[i];
                }
                vectorMagnitude = Math.Sqrt(sums);
                for (int i = 0; i < eigenvector.Length; i++)
                {
                    eigenvector[i] /= vectorMagnitude;
                }
                vectorMagnitude = 0;
            }
            double[,] V = new double[eigenVectors[0].Length, eigenVectors.Count];///V matrisinin konumlarını kontrol et ters gelebiliyor

            int k = 0;
            for (int i = 0; i < V.GetLength(0); i++)
            {
                int j = 0;
                    foreach (var eigenvector in eigenVectors)
                    {
                        V[i, j] = eigenvector[k];
                        j++;
                    }
                k++;
            }
            double[,] S = new double[eigenValues.Count, eigenValues.Count];//S matrisinin karekökünü almayabilebilirzi belki sonra bi bak
            for (int i = 0; i < S.GetLength(0); i++)
            {
                for (int j = 0; j < S.GetLength(1); j++)
                {
                    if (i == j)
                        S[i, j] = Math.Sqrt(eigenValues[i]);
                }
            }

            
            double[,] U = Matrix.multiplyMatrix(Matrix.multiplyMatrix(matrix, V),Matrix.getInverse((double[,])S.Clone()));
            double[,] pseudo = Matrix.multiplyMatrix(Matrix.multiplyMatrix(V,getPinv((double[,])S.Clone())),Matrix.getTranspose(U));

            return pseudo;
        }

        public double[,] getPinv(double [,] matrix1)
        { 
            int a = matrix1.GetLength(0);
            int b = matrix1.GetLength(1);
            double [,] pinv = new double[Y, X];

            //if (a == b)
            //{
            //    return Matrix.getInverse(matrix1);
            //}
            if (a < b)
            {
                singleObject.RowOrColumn = "row";
                steps.loadImage(); // hangi formülü kullanacaksak onun resmi yüklendi
                singleObject.ATranspose = Matrix.getTranspose(matrix1);//Transpose yazdırılmak üzere atandı
                singleObject.Multiply = Matrix.multiplyMatrix(matrix1, singleObject.ATranspose);//Ana matris ile transpose çarpımı yazdırılmak üzere atandı
                singleObject.det = Matrix.Determinant(singleObject.Multiply);//Det yazdırılmak üzere atandı
                singleObject.MultiplyInverse = Matrix.getInverse((double[,])singleObject.Multiply.Clone());//matris çarpımlarının oluşan kare matrisin tersi yazdırılmak üzere atandı
                if (Matrix.isFullRank(matrix1) && singleObject.det != 0)
                {
                    MessageBox.Show("Moore Penrose for row: ");
                    singleObject.PseudoInverse = Matrix.multiplyMatrix(singleObject.ATranspose, singleObject.MultiplyInverse);//pseudo inverse yazdırılmak üzere atandı
                    return singleObject.PseudoInverse;
                }
                else
                {
                    MessageBox.Show("Determinant is 0!");
                    // SingularValueDecomposition(Matrix.multiplyMatrix(Matrix.getTranspose(matrix), matrix));
                }
            }
            else if (b < a)
            {
                singleObject.RowOrColumn = "column";
                steps.loadImage(); // hangi formülü kullanacaksak onun resmi yüklendi
                singleObject.ATranspose = Matrix.getTranspose(matrix1);//Transpose yazdırılmak üzere atandı
                singleObject.Multiply = Matrix.multiplyMatrix(singleObject.ATranspose, matrix1);//Ana matris ile transpose çarpımı yazdırılmak üzere atandı
                singleObject.det = Matrix.Determinant(singleObject.Multiply);//Det yazdırılmak üzere atandı
                singleObject.MultiplyInverse = Matrix.getInverse((double[,])singleObject.Multiply.Clone());//matris çarpımlarının oluşan kare matrisin tersi yazdırılmak üzere atandı
                if (Matrix.isFullRank(singleObject.ATranspose) && singleObject.det != 0)
                {
                    MessageBox.Show("Moore Penrose for column: ");
                    singleObject.PseudoInverse = Matrix.multiplyMatrix(singleObject.MultiplyInverse, singleObject.ATranspose);
                    return singleObject.PseudoInverse;
                }
                else
                {
                    MessageBox.Show("Determinant is 0!");
                   // SingularValueDecomposition(Matrix.multiplyMatrix(Matrix.getTranspose(matrix), matrix));
                }
            }
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    pinv[i, j] = double.NaN;
                }
            }

            MessageBox.Show("Something went wrong!!");
            return pinv;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            matrix = new double[X, Y];
            double[,] pseudoInverseMatrix;

            if (X == 0 || Y == 0)
            {
                MessageBox.Show("Must create a matrix first");
                return;
            }
            try
            {
                for (int i = 0; i < X; i++)
                {
                    for (int j = 0; j < Y; j++)
                    {
                        matrix[i, j] = double.Parse(tbMatrix[i][j].Text);
                    }
                }
                singleObject.A = matrix;//Ana matris yazdırılmak üzere variables olarak atandı
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill out all fields");
                return;
            }

            pseudoInverseMatrix = getPinv(matrix);

            steps.tab = 0;
            steps.Dock = DockStyle.Fill;
            steps.writeMatrix(singleObject.A);
            steps.Visible = true;
            Size = new Size(440, 440);
            steps.BringToFront();
            

        }

 

        private void button2_Click(object sender, EventArgs e)
        {
            matrix = new double[X, Y];
            try
            {
                for (int i = 0; i < X; i++)
                {
                    for (int j = 0; j < Y; j++)
                    {
                        matrix[i, j] = double.Parse(tbMatrix[i][j].Text);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill out all fields");
            }
            //SingularValueDecomposition(Matrix.multiplyMatrix(Matrix.getTranspose(matrix), matrix));

  
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Size = new Size(367, 441);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            size = this.Size;
        }

        private void setMatrix_Click(object sender, EventArgs e)
        {
            flag = false;
            X = (int)numericM.Value;
            Y = (int)numericN.Value;

            if (X == Y)
            {
                MessageBox.Show("M value, must be diffrent from N value!!");
            }
            else
            {
                for (int i = 0; i < 25; i++)
            {
                tbMatrix[i / 5][i % 5].Visible = false;
            }
            createMatrix(X, Y);
            }
        }

    }
}
