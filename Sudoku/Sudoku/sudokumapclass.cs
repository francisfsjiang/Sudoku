using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class sudokumap
    {
        private const int MAXSIZE=20;
        private const int MINSIZE=2;
        private int  sudokusize;
        private int edgelength;
        private int[,]  map;
        private int[,] solvedmap;
        //private int[,] ablenum;
        private bool[,] rowused;
        private bool[,] columnused;
        private bool[,] nineused;
        private bool created;
        private  Random rander = new Random();
        public List<string> errorlog=new List<string>();
        public sudokumap(){}
        public sudokumap(int size)
        {
            try
            {
                if (size < MINSIZE || size > MAXSIZE) return;
                sudokusize = size;
                edgelength = size * size;
                solvedmap = new int[edgelength + 1, edgelength + 1];
                map = new int[edgelength + 1, edgelength + 1];
                //ablenum = new int[edgelength + 1, edgelength + 1];
                rowused = new bool[edgelength + 1, edgelength + 1];
                columnused = new bool[edgelength + 1, edgelength + 1];
                nineused = new bool[edgelength + 1, edgelength + 1];
                for (int i = 1; i <= edgelength; i++) for (int j = 1; j <= edgelength; j++)
                    {
                        solvedmap[i, j] = 0;
                        map[i, j] = 0;
                        rowused[i, j] = false;
                        columnused[i, j] = false;
                        nineused[i, j] = false;
                    }
                created = false;
            }
            catch
            {
            }
        }
        public void clear()
        {
            for(int i=1;i<=edgelength;i++)for(int j=1;j<=edgelength;j++)
            {
                map[i,j]=0;
                rowused[i, j] = false;
                columnused[i,j]=false;
                nineused[i,j]=false;
            }
        }
        public int size
        {
            get
            {
                return sudokusize;
            }
            set
            {
            }
        }
        public int nine(int x,int y)
        {
            try
            {
                return ((x - 1) / sudokusize) * sudokusize + (y - 1) / sudokusize + 1;
            }
            catch { return 0; }
        }
        public bool issetted(int x,int y)
        {
            if(map[x,y]!=0)return true;
            else return false;
        }
        public bool checknum(int x,int y,int num)
        {
            try
            {
                if(!rowused[x,num]&&!columnused[y,num]&&!nineused[nine(x,y),num])return true;
                else return false;
            }
            catch
            {
                    return false;
            }
        }
        public int numofabletoset(int x,int y)
        {
            try
            {
                int[] list = new int[edgelength + 1];
                int listlen = 0;
                for (int i = 1; i <= edgelength; i++)
                {
                    if (checknum(x, y, i))
                    {
                        list[listlen] = i;
                        listlen++;
                    }
                }
                if (listlen <= 1) return 0;
                else
                {
                    int rd = rander.Next(0, listlen);
                    return list[rd];
                }
            }
            catch
            {
                return 0;
            }
        }
        public bool setnumber(int x, int y, int num)
        {
            if (!this.issetted(x, y))
            {
                rowused[x,num]=true;
                columnused[y,num]=true;
                nineused[nine(x, y), num] = true;
                map[x, y] = num;
                return true;
            }
            else return false;
        }
        public int getnumber(int x, int y)
        {
            return map[x, y];
        }
        public int getsolvednumber(int x, int y)
        {
            return solvedmap[x, y];
        }
        //creat process
        public bool creat(int level,bool isonesol)
        {
            try
            {
                int insertnumber = edgelength*level/5+edgelength*sudokusize;
                int randx, randy,number;
                while (true)
                {
                    for (int i = insertnumber; i > 0; )
                    {
                        randx = rander.Next(1, edgelength + 1);
                        randy = rander.Next(1, edgelength + 1);
                        number =numofabletoset(randx,randy);
                        if (number != 0)
                        {
                            setnumber(randx, randy, number);
                            i--;
                        }
                    }
                    bool sign = this.solve();
                    if (sign)
                    {
                        for (int i = 0; i < edgelength * edgelength; i++)
                        {
                            solvedmap[lists[ans[i]].x, lists[ans[i]].y] = lists[ans[i]].num;
                        }
                        break;
                    }
                    else
                    {
                        clear();
                    }
                }
                if (created) return true;
                else return false;
            }
            catch
            {
                return false;
            }
        }
        //solve process
        public bool solve()
        {
            try
            {
                lists = new point[4*edgelength * edgelength * edgelength + edgelength * sudokusize];
                ans = new int[4 * edgelength * edgelength];
                makeup();
                if (dance(0) == 1)
                {
                    for (int i = 0; i < edgelength * edgelength; i++)
                    {
                        solvedmap[lists[ans[i]].x, lists[ans[i]].y] = lists[ans[i]].num;
                    }
                    return true;
                }
                return false;
                //d = lists[2].up;

            }
            catch
            {
                return false;
            }
        }
        private point[] lists;
        private struct point
        {
            public int up, down, right, left, column, sum;
            public int x,y,num;
        };
        private int[] ans;
        private void insert(int sign ,int x,int y,int num)
        {
            int[] col = new int[4]{(x-1)*edgelength+y,
            edgelength*edgelength+(x-1)*edgelength+num,
            2*edgelength*edgelength+(y-1)*edgelength+num,
            3*edgelength*edgelength+(nine(x,y)-1)*edgelength+num};
            lists[sign].up = col[0];
            lists[sign].down = col[1];
            lists[sign].left = col[2];
            lists[sign].right = col[3];
            for (int i = 0; i <= 3; i++)
            {
                lists[sign + i].left = sign + i - 1;
                lists[sign + i].right = sign + i + 1;
                lists[lists[col[i]].up].down = sign + i;
                lists[sign + i].up = lists[col[i]].up;
                lists[col[i]].up = sign + i;
                lists[sign + i].down = col[i];
                lists[sign + i].column = col[i];
                lists[col[i]].sum++;
                lists[sign + i].num = num;
                lists[sign + i].x = x;
                lists[sign + i].y = y;
            }
            lists[sign].left = sign + 3;
            lists[sign + 3].right = sign;
        }
        private void makeup()
        {
            int len = 4 *edgelength* edgelength;
            for(int i=1;i<=len;i++)
            {
                lists[i].left=i-1;
                lists[i].right= i + 1;
                lists[i].up = i;
                lists[i].down= i;
                lists[i].column = i;
            }
            lists[0].left=len;
            lists[0].right = 1;
            lists[len].right = 0;
            lists[len].sum = len;
            int sign = len+1;
            //int lastcolumn = 1;
            for(int i=1;i<=edgelength;i++)for(int j=1;j<=edgelength;j++)
            {
                if(map[i,j]==0)
                {
                    for(int k=1;k<=edgelength;k++)
                    {
                        insert(sign,i,j,k);
                        sign += 4;
                    }
                }
                else
                {
                    insert(sign,i,j,map[i,j]);
                    sign += 4;
                }
            }
        }
        private void removec(int x)
        {
            //errorlog.Add("remove"+x.ToString());
            int i, j;
            lists[0].sum--;
            lists[lists[x].left].right= lists[x].right;
            lists[lists[x].right].left = lists[x].left;
            for (i = lists[x].down; i != x; i = lists[i].down) for (j = lists[i].right; j != i; j = lists[j].right)
                {
                    lists[lists[j].down].up = lists[j].up;
                    lists[lists[j].up].down = lists[j].down;
                    lists[lists[j].column].sum--;
                }
        }
        private void resumec(int x)
        {
            //errorlog.Add("resume" + x.ToString());
            int i, j;
            lists[0].sum++;
            for (i = lists[x].up; i != x; i = lists[i].up) for (j = lists[i].left; j != i; j = lists[j].left)
                {
                    lists[lists[j].down].up = j;
                    lists[lists[j].up].down = j;
                    lists[lists[j].column].sum++;
                }
            lists[lists[x].left].right = x;
            lists[lists[x].right].left = x;
        }
        private int dance(int x)
        {
            //errorlog.Add("dance" + x.ToString());
            if (lists[0].right == 0)
            {
                return 1;
            }
            else
            {
                int min = 999999, minn = 1 ;
                for (int i = lists[0].right; i != 0; i = lists[i].right) if (lists[i].sum< min)
                    {
                        min = lists[i].sum;
                        minn = i;
                    }
                removec(minn);
                for (int i = lists[minn].down; i != minn; i = lists[i].down)
                {
                    ans[x] = i;
                    for (int j = lists[i].right; j != i; j = lists[j].right) removec(lists[j].column);
                    if (dance(x + 1)==1) return 1;
                    for (int j = lists[i].left; j != i; j = lists[j].left) resumec(lists[j].column);
                }
                resumec(minn);
                return 0;
            }
        }
  }
}
