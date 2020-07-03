using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PseudoInverse.Maths;

namespace PseudoInverse
{
    public partial class Steps : UserControl
    {
        Variables singleObject = Variables.Instance;
        public int tab = 0;
        public Size centerSize;
        Size programSize;

        public Steps()
        {
            InitializeComponent();
            centerSize = Center.Size;
            Right.ReadOnly = true;
            Left.ReadOnly = true;
            Center.ReadOnly = true;
            MultiplactionLabel.Visible = false;
            AdditionsLabel.Visible = false;
            MultiplactionCount.Visible = false;
            AddtitionsCount.Visible = false;
            LoopsLabel.Visible = false;
            LoopsCount.Visible = false;
            Back.Visible = false;
        }

        public void write(RichTextBox richText,double[,] matrix)
        {
            richText.Text = "|";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    richText.Text += $"{Math.Round(matrix[i, j],4),3}" + " | ";
                }
                richText.Text += Environment.NewLine;
                richText.Text += "-------------------------";
                if(i != matrix.GetLength(0)-1)
                richText.Text += Environment.NewLine+"|";
            }
        }
        public void writeMatrix(double[,] matrix)
        {
            Center.Visible = true;
            Right.Visible = false;
            Left.Visible = false;
            sign.Visible = false;
            equal.Visible = false;
            Center.Size = new Size(180, 180);
            write(Center, matrix);
        }
        public void writeMatrix(double[,] matrix1, double[,] matrix2,double[,] matrix3)
        {
            Center.Size = centerSize;
            Left.Visible = true;
            Center.Visible = true;
            Right.Visible = true;
            sign.Visible = true;
            equal.Visible = true;
            write(Left, matrix1);
            write(Center, matrix2);
            write(Right, matrix3);
        }
        public void writeMatrix(double[,] matrix1, double det)
        {
            Center.Size = centerSize;
            Left.Visible = false;
            Center.Visible = true;
            Right.Visible = true;
            sign.Visible = false;
            equal.Visible = true;
            write(Center, matrix1);
            Right.Text = det + "";
        }


        private void Back_Click(object sender, EventArgs e)
        {
            if (tab != 0)
                tab--;
            switch (tab)
            {
                case 0:
                    Back.Visible = false;
                    writeMatrix(singleObject.A);
                    LeftLabel.Text = "";
                    RightLabel.Text = "";
                    CenterLabel.Text = "A";
                    break;
                case 1:
                    writeMatrix(singleObject.ATranspose);
                    LeftLabel.Text = "";
                    RightLabel.Text = "";
                    CenterLabel.Text = "Transpose of A";
                    break;
                case 2:
                    if (singleObject.RowOrColumn.Equals("row"))
                    {
                        writeMatrix(singleObject.A, singleObject.ATranspose, singleObject.Multiply);
                        LeftLabel.Text = "A";
                        CenterLabel.Text = "Transpose of A";
                        RightLabel.Text = "A*(Transpose of A)";
                    }
                    else
                    {
                        writeMatrix(singleObject.ATranspose, singleObject.A, singleObject.Multiply);
                        LeftLabel.Text = "Transpose of A";
                        CenterLabel.Text = "A";
                        RightLabel.Text = "(Transpose of A)*A";
                    }
                    break;
                case 3:
                    writeMatrix(singleObject.Multiply, singleObject.det);
                    LeftLabel.Text = "";
                    CenterLabel.Text = "[(Transpose of A)*A]";
                    RightLabel.Text = "Determinant";
                    break;
                case 4:
                    writeMatrix(singleObject.MultiplyInverse);
                    LeftLabel.Text = "";
                    RightLabel.Text = "";
                    CenterLabel.Text = "[(Transpose of A)*A]^(-1)";
                    break;
                case 5:
                    Next.Visible = true;
                    MultiplactionLabel.Visible = false;
                    AdditionsLabel.Visible = false;
                    AddtitionsCount.Visible = false;
                    MultiplactionCount.Visible = false;
                    LoopsLabel.Visible = false;
                    LoopsCount.Visible = false;

                    LoopsCount.Text = "";
                    MultiplactionCount.Text = "";
                    AddtitionsCount.Text = "";
                    if (singleObject.RowOrColumn.Equals("row"))
                    {
                        writeMatrix(singleObject.ATranspose, singleObject.MultiplyInverse, singleObject.PseudoInverse);
                        LeftLabel.Text = "Transpose of A";
                        CenterLabel.Text = "[(Transpose of A)*A]^(-1)";
                        RightLabel.Text = "Pseudo Inverse of A";
                    }
                    else
                    {
                        writeMatrix(singleObject.MultiplyInverse, singleObject.ATranspose, singleObject.PseudoInverse);
                        LeftLabel.Text = "[A*(Transpose of A)]^(-1)";
                        CenterLabel.Text = "Transpose of A";
                        RightLabel.Text = "Pseudo Inverse of A";
                    }
                    break;
                case 6:
                    writeMatrix(singleObject.PseudoInverse);
                    LeftLabel.Text = "";
                    CenterLabel.Text = "Pseudo Inverse of A";
                    RightLabel.Text = "";
                    break;
            }
        }
        private void Next_Click(object sender, EventArgs e)
        {
            if(tab !=6)
                tab++;
            switch (tab)
            {
                case 0:
                    writeMatrix(singleObject.A);
                    LeftLabel.Text = "";
                    RightLabel.Text = "";
                    CenterLabel.Text = "A";
                    break;
                case 1:
                    Back.Visible = true;
                    writeMatrix(singleObject.ATranspose);
                    LeftLabel.Text = "";
                    RightLabel.Text = "";
                    CenterLabel.Text = "Transpose of A";
                    break;
                case 2:
                    if (singleObject.RowOrColumn.Equals("row"))
                    {
                        writeMatrix(singleObject.A, singleObject.ATranspose, singleObject.Multiply);
                        LeftLabel.Text = "A";
                        CenterLabel.Text = "Transpose of A";
                        RightLabel.Text = "A*(Transpose of A)";
                    }
                    else
                    {
                        writeMatrix(singleObject.ATranspose, singleObject.A, singleObject.Multiply);
                        LeftLabel.Text = "Transpose of A";
                        CenterLabel.Text = "A";
                        RightLabel.Text = "(Transpose of A)*A";
                    }
                    break;
                case 3:
                    writeMatrix(singleObject.Multiply, singleObject.det);
                    LeftLabel.Text = "";
                    CenterLabel.Text = "[A*(Transpose of A)]";
                    RightLabel.Text = "Determinant";
                    break;
                case 4:
                    writeMatrix(singleObject.MultiplyInverse);
                    LeftLabel.Text = "";
                    RightLabel.Text = "";
                    CenterLabel.Text = "[A*(Transpose of A)]^(-1)";
                    break;
                case 5:
                    if (singleObject.RowOrColumn.Equals("row"))
                    {
                        writeMatrix(singleObject.ATranspose, singleObject.MultiplyInverse, singleObject.PseudoInverse);
                        LeftLabel.Text = "Transpose of A";
                        CenterLabel.Text = "[A*(Transpose of A)]^(-1)";
                        RightLabel.Text = "Pseudo Inverse of A";
                    }
                    else
                    {
                        writeMatrix(singleObject.MultiplyInverse, singleObject.ATranspose, singleObject.PseudoInverse);
                        LeftLabel.Text = "[A*(Transpose of A)]^(-1)";
                        CenterLabel.Text = "Transpose of A";
                        RightLabel.Text = "Pseudo Inverse of A";
                    }
                    break;
                case 6:
                    writeMatrix(singleObject.PseudoInverse);
                    MultiplactionLabel.Visible = true;
                    AdditionsLabel.Visible = true;
                    LoopsLabel.Visible = true;

                    AddtitionsCount.Text = singleObject.Additions +"";
                    AddtitionsCount.Visible = true;
                    MultiplactionCount.Text = singleObject.Multiplactions + "";
                    MultiplactionCount.Visible = true;
                    LoopsCount.Text = singleObject.Loops + "";
                    LoopsCount.Visible = true;



                    LeftLabel.Text = "";
                    CenterLabel.Text = "Pseudo Inverse of A";
                    RightLabel.Text = "";

                    Next.Visible = false;
                    break;
            }
        }

        public void loadImage()
        {
            if (singleObject.RowOrColumn.Equals("row"))
            {
                formulaPicture.Size = Properties.Resources.rowFormula.Size;
                formulaPicture.Image = Properties.Resources.rowFormula;
            }
            else if (singleObject.RowOrColumn.Equals("column"))
            {
                formulaPicture.Size = Properties.Resources.rowFormula.Size;
                formulaPicture.Image = Properties.Resources.columnFormula;
            }
                
        }

        private void Steps_Load(object sender, EventArgs e)
        {
            programSize = Program.form.Size;
            Program.form.Size = new Size(440, 440);
            CenterLabel.Text = "A";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            singleObject.Multiplactions = 0;
            singleObject.Additions = 0;
            singleObject.Loops = 0;

            LoopsCount.Visible = false;
            LoopsLabel.Visible = false;
            LoopsCount.Text = "";

            AdditionsLabel.Visible = false;
            AddtitionsCount.Visible = false;
            AddtitionsCount.Text = "";

            MultiplactionLabel.Visible = false;
            MultiplactionCount.Visible = false;
            MultiplactionCount.Text = "";

            Next.Visible = true;
            Back.Visible = false;
            
           
            CenterLabel.Text = "A";
            RightLabel.Text = "";
            LeftLabel.Text = "";
            Visible = false;
            Program.form.Size = programSize;
            SendToBack();
        }
    }
}
