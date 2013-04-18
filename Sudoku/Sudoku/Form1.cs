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
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
                textBox1.Text += sudoku.getnumber(i,j);
            textBox1.Text += Environment.NewLine;
        }
        textBox1.Text += Environment.NewLine;
        bool sign=sudoku.solve();
        if (!sign) textBox1.Text += "error" + Environment.NewLine;
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 9; j++)
                //textBox1.Text += sudoku.getsolvednumber(i, j) + " ";
                textBox1.Text += sudoku.solvedmap[i,j] + " ";
            textBox1.Text += Environment.NewLine;
        }
        //for (int i = 0; i <= 2500; i++)
        //{
        //    try
        //    {
        //        this.richTextBox1.Text += i + " " + sudoku.ans[i] + Environment.NewLine;
        //    }
        //    catch
        //    {
        //        break;
        //    }
        //}
        for (int i = 0; i <= 2600; i++)
        {
            try
            {
                this.richTextBox1.Text += i + " " + sudoku.lists[i].up + " " + sudoku.lists[i].down + " " + sudoku.lists[i].left + " " + sudoku.lists[i].right + " " + Environment.NewLine;
                this.richTextBox1.Text += sudoku.lists[i].x + " " + sudoku.lists[i].y + " " + sudoku.lists[i].num + " " + Environment.NewLine;
            }
            catch
            {
                break;
            }
        }
    }

  }
}
