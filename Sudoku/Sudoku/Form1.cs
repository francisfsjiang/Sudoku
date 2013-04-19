using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sudokumap sudoku=new sudokumap(3);
        sudoku.creat(1, true);
        for (int i = 1; i <= sudoku.size*sudoku.size; i++)
        {
            for (int j = 1; j <= sudoku.size * sudoku.size; j++)
                richTextBox1.Text += sudoku.getnumber(i,j)+" ";
            richTextBox1.Text += Environment.NewLine;
        }
        richTextBox1.Text += Environment.NewLine;
//        int[,] data=new int[10,10]{
//            {0,8,5,4,3,9,6,1,2,7,},
//            {0,1,4,3,6,2,8,5,7,9,},
//{0,5,7,2,1,3,9,4,6,8,},
//{0,9,8,6,7,5,4,2,3,1,},
//{0,3,9,1,5,4,2,7,8,6,},
//{0,4,6,8,9,1,7,3,5,2,},
//{0,7,2,5,8,6,3,9,1,4,},
//{0,2,3,7,4,8,1,6,9,5,},
//{0,6,1,9,2,7,5,8,4,3,},
//{0,8,5,4,3,9,6,1,2,7,},
//        };
//        for (int i = 1; i <= 9; i++)
//        {
//            for (int j = 1; j <= 9; j++)
//                sudoku.setnumber(i, j,data[i,j]);
////textBox1.Text += Environment.NewLine;
//        }
        for (int i = 1; i <= sudoku.size * sudoku.size; i++)
        {
            for (int j = 1; j <= sudoku.size * sudoku.size; j++)
                richTextBox2.Text += sudoku.getsolvednumber(i, j) + " ";
            richTextBox2.Text += Environment.NewLine;
        }
        richTextBox2.Text += Environment.NewLine;
        //textBox1.Text += Environment.NewLine;
        //sudoku.solve();
        //for (int i = 1; i <= sudoku.size * sudoku.size; i++)
        //{
        //    for (int j = 1; j <= sudoku.size * sudoku.size; j++)
        //        textBox1.Text += sudoku.getsolvednumber(i, j) + " ";
        //    textBox1.Text += Environment.NewLine;
        //}

        //for (int i = 0; i <= 80; i++)
        //{
        //    try
        //    {
        //        this.richTextBox1.Text += i + " " + sudoku.ans[i] +" "+ sudoku.lists[sudoku.ans[i]].x+" "+sudoku.lists[sudoku.ans[i]].y+" "+sudoku.lists[sudoku.ans[i]].num+" "+ Environment.NewLine;
        //    }
        //    catch
        //    {
        //        break;
        //    }
        //}
    }


  }
}
