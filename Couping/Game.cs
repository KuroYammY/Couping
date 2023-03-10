using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Drawing.Imaging;

namespace Couping
{
    public class Game : Control
    {
        protected int _sizeS;
        protected int _size;
        public int minSize;
        public int maxSize;

        protected int _x;// расположение X
        protected int _y;// расположение Y

        public int _imSize = 150;//ширина фото высота фото

        bool flagClick = false;

        protected bool _gameStatus = false;
        public bool GameStatus
        {
            get { return _gameStatus; }
        }


        protected void Update(Object source, ElapsedEventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                Invoke((Action)(() =>
                {
                    if (1== 0)
                    {
                        
                    }
                }));
            });
            thread.Start();
        }

        private int _level;
        public int gameLevel
        {
            get => _level;
            set { 
                if (value > 0 && value < 10)
                    _level = value;
            }
        }

        protected int X
        {
            get => _x;
            set { if (_x != 0) { _x = 0; } }
        }
        protected int Y
        {
            get => _y;
            set { if (_y != 0) { _y = 0; } }
        }

        protected System.Timers.Timer _timer;

        //Метод вызывающийся при запуске игры
        public void StarProcess()
        {

            //_timer.Enabled = true;
            //this.Focus();
            if (_gameStatus)
            {
             //   _gameStatus = false;
                gameLevel = 1; 
                formList();
            }

            Invalidate();
        }
        //Метод вызывающийся при завершении игры
        public void EndProcess()
        {
            //_timer.Stop();

            //_gameStatus = true;
            Invalidate();
        }

        List<string> cards1 = new List<string>();
        List<string> cards2 = new List<string>();
        
        //генерация наименований картинок
        public void formList()
        {
            bool flag = true;
            bool flag2 = true;
            int cc = gameLevel + 1;
            while (cards1.Count != cc)
            {
                Random r = new Random();
                int value = r.Next(0, 7);
                string val = value.ToString();
                flag = cards1.Contains(val);
                if (flag == false)
                {
                    cards1.Add(val);
                }
            }
            while (cards2.Count != cards1.Count)
            {
                Random d = new Random();
                int value = d.Next(0, 7);
                string val = value.ToString();
                flag = cards1.Contains(val);
                flag2 = cards2.Contains(val);
                if (flag)
                {
                    if (flag2 == false)
                    {
                        cards2.Add(val);
                    }
                }
            }
        }
        string ss1;
        string ss2;
        bool flagc = false;
        int i2;
        int i1;
        //Метод отвечающий за прорисовку уровня
        protected override void OnPaint(PaintEventArgs e)
        {
            if (cards1.Count == 0) 
            {
                formList();
            }
            int countcards = gameLevel + 1;
            Rectangle[] rct1 = new Rectangle[countcards];
            Rectangle[] rct2 = new Rectangle[countcards];
            Bitmap[] img1x = new Bitmap[countcards];
            Bitmap[] img2x = new Bitmap[countcards];
            bool flagc1 = false;
            bool flagc2 = false;
            int xx = X;
            int yy = Y;
            Brush BonesBrushSelected = new SolidBrush(Color.Gray);
            Brush BonesBrush = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 25);

            for (int j = 0; j < countcards; j++)
            {
                rct1[j] = new Rectangle(xx + (j * _imSize) + j * 20, yy, _imSize, _imSize);
                rct2[j] = new Rectangle(xx + (j * _imSize) + j * 20, yy + (_imSize) + 20, _imSize, _imSize);
                Bitmap img1 = (Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cards1[j]}");
                Bitmap img2 = (Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cards2[j]}");
                string S1 = cards1[j].ToString();
                string S2 = cards2[j].ToString();
                //e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cards1[j]}"),rct1[j]);
                //e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"default"), new RectangleF(xx, yy + (j * _imSize) + j * 20, _imSize, _imSize));
                /* if (flagClick)
                {
                    e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cards1[j]}"), new RectangleF(xx, yy + (j * _imSize) + j * 20, _imSize, _imSize));
                }*/

                if (j != selectedBone)
                {                    
                    e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"default"), rct1[j]);
                    //e.Graphics.FillRectangle(BonesBrush, xx + (j * _imSize) + j * 20, yy, _imSize, _imSize);
                    //ss1 = cards1.ElementAt(j);
                    if (flagc) 
                    {
                        //cards1[i1] = "9";
                        e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cards1[i1]}"), rct1[i1]);
                    }                    
                }
                else
                {
                    //e.Graphics.FillRectangle(BonesBrushSelected, xx + (j * _imSize) + j * 20, yy, _imSize, _imSize);
                    e.Graphics.DrawImage(img1, rct1[j]);
                    e.Graphics.DrawString(S1, font, BonesBrush, xx + (j * _imSize) + j * 20, yy);
                    ss1 = S1;
                }                

                if (j != selectedBone1)
                {
                    e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"default"), rct2[j]);
                    //e.Graphics.FillRectangle(BonesBrush, xx + (j * _imSize) + j * 20, yy + ( _imSize) +  20, _imSize, _imSize);
                    //ss2 = cards2.ElementAt(j);
                    if (flagc)
                    {
                        //cards2[i2] = "9";
                        e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cards2[i2]}"), rct2[i2]);
                    }
                }
                else
                {
                    //e.Graphics.FillRectangle(BonesBrushSelected, xx + (j * _imSize) + j * 20, yy + ( _imSize) +  20, _imSize, _imSize);
                    e.Graphics.DrawImage(img2, rct2[j]);
                    e.Graphics.DrawString(S2, font, BonesBrush, xx + (j * _imSize) + j * 20, yy + (_imSize) + 20);
                    ss2 = S2;
                }
                //если выбранные карточки равны, закрасить
                if (flag && (ss1 == ss2))
                {
                        //int i1;
                        i1 = cards1.IndexOf(ss1);//получаем индекс cards1
                       //int i2;
                        i2 = cards2.IndexOf(ss2);//получаем индекс cards2
                        flagc = true;
                    //cards1.RemoveAt(i1);
                    //cards2.RemoveAt(i2);
                    //cards1[i1] = "9";
                    //cards2[i2] = "9";


                        //e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p0"), rct1[i1]);
                        //e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p0"), rct2[i2]);
                        //flag = false;
                }
            }
              


                /*                string ss = ("Couping/Resources/11.png");
                                //Image img = (Bitmap)Image.FromFile(ss, true);

                                _p2[j] = new PictureBox{
                                    Location = new Point(xx + 20 + iWidth, yy + (j * iHeight) + j * 20),
                                    Size = new Size(iWidth, iHeight),
                                    Image = Image.FromFile(ss)
                                };*/
                //rct2[j] = new Rectangle(xx + 20 + iWidth, yy + (j * iHeight) + j * 20, iWidth, iHeight);
                // e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cards2[j]}"), rct2[j]);

                //e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cards2[j]}"), new RectangleF(xx + 20 + iWidth, yy + (j * iHeight) + j * 20, iWidth, iHeight));
                //e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"default"), new RectangleF(xx + 20 + iWidth, yy + (j * iHeight) + j * 20, iWidth, iHeight));

            //e.Dispose();
        }

        public Game()
        {
            _size = 20;
            minSize = 200;
            maxSize = 800;
            _y = 20;
            _x = 20;
            //_timer = new System.Timers.Timer(150);
            //_timer.AutoReset = true;
            //_timer.Elapsed += Update;
            //_timer.Enabled = false;
        }   

        public int iSize
        {
            get
            {
                return _imSize;
            }
            set
            {
                if (_imSize == 0)
                {
                    _imSize = 100;
                }
                else
                {
                    _imSize = value;
                    Invalidate();
                }
            }
        }

        protected void GameLevel(int _level) 
        {
            for (int i = 1; i < _level; i++)
            {
                //imgCount += 2;
            }
            return;
        }

        int selectedBone = -1; 
        int selectedBone1 = -1;
        bool flag = false;
        int fl1 = 0; 
        int fl2 = 0;
        public void onMouseClick(MouseEventArgs e)
        {
            int bufi = 0;
            int bufj = 0;
            int bufW = 0;
            int bufH = 0;
            int zi = e.X / (_imSize + 20);
            int zj = e.Y / (_imSize + 20);

            if (e.Button == MouseButtons.Left)
            {
                if (zi < cards1.Count && zj == 0)
                {
                    selectedBone = zi;
                    fl1 = 1;
                }
                if (zi < cards2.Count && zj == 1)
                {
                    selectedBone1 = zi;
                    fl2 = 1;
                }
            }
            if (fl1 == 1 && fl2 == 1) 
            {
                flag = true;
                fl1 = 0;
                fl2 = 0;
            }

            
         /*
            if (i == bufi && j == bufj)
            {
                bufW = iWidth;
                bufH = iHeight;
                i = i + 100;
                iHeight = 0;
                new Rectangle(i,j,iWidth,iHeight);

            }*/

/*            if (i < bufi+iWidth && j<bufj+iHeight) 
            {                
                iWidth = 0;
                iHeight = 0;                
            }*/

        /*      int zi = 0;
                int zj = 0;
                for (int d = 0; d < 4; d++)
                {
                    for (int b = 0; b < 4; b++)
                    {
                        if (cartCount[d, b] == 0) { zi = d; zj = b; }
                    }
                }
                int i = e.Y / cellSize;
                int j = e.X / cellSize;
                int buf;
                if (j == zj && Math.Abs(zi - i) == 1)
                {
                    buf = cartCount[i, j];
                    cartCount[i, j] = cartCount[zi, j];
                    cartCount[zi, j] = buf;
                }
                if (i == zi && Math.Abs(zj - j) == 1)
                {
                    buf = cartCount[i, j];
                    cartCount[i, j] = cartCount[i, zj];
                    cartCount[i, zj] = buf;
                }*/
            Invalidate();
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
            Invalidate();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = 0x02000000;
                return cp;
            }
        }
    }
}




//////////////////////////////////////////////////////////////////////
/*protected override void OnPaint(PaintEventArgs e)
{
    Brush MainDice = new SolidBrush(Color.Black);


    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 2; j++)
        {

            *//*                    if (i[i, j] != 0)
                                {*//*

                                //e.Graphics.FillRectangle(MainDice, X, Y, iWidth+10, iHeight+10);
                                e.Graphics.DrawImage((Bitmap)Properties.Resources._0, new RectangleF(X, Y, iWidth, iHeight));

            e.Graphics.DrawImage((Bitmap)Properties.Resources._0, new RectangleF(X, Y + Between + iHeight, iWidth, iHeight));

                                e.Graphics.DrawImage((Bitmap)Properties.Resources._1, new RectangleF(X + Between + iWidth, Y, iWidth, iHeight));

                                e.Graphics.DrawImage((Bitmap)Properties.Resources._1, new RectangleF(X + Between + iWidth, Y + Between + iWidth, iWidth, iHeight));
            *//*                    Image b = new Bitmap(Couping.Properties.Resources._1);
                                e.Graphics.FillRectangle(MainDice, DiceX, DiceY, iWidth, iHeight);
                                e.Graphics.DrawImage(b, DiceX+ iWidth, 1, iWidth, iHeight);*/
/*                    }
                    else
                    {
                        e.Graphics.FillRectangle(Zero, DiceX + 2, DiceY + 2, 100, 150);
                    }*//*
//DiceX += cellSize;
}
// DiceX = X;
//DiceY += cellSize;
}
MainDice.Dispose();
}
        public void Randomizer()
        {
          /*  int zi = 0;
            int zj = 0;
            int i = 0;
            int j = 0;
            int buf = 0;
            Random randomI = new Random();
            Random randomJ = new Random();
            int bufI;
            int bufJ;
            int k = 1;
            while (k % 2 != 0)
            {
                k = 0;
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 2; j++)
                    {
                        bufI = randomI.Next(2);
                        bufJ = randomJ.Next(2);

                        buf = cartCount[i, j];
                        cartCount[i, j] = cartCount[bufI, bufJ];
                        cartCount[bufI, bufJ] = buf;
                    }
                }
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 2; j++)
                    {
                        if (cartCount[i, j] == 0)
                        {
                            zi = i;
                            zj = j;
                        }
                    }
                }
                buf = cartCount[zi, zj];
                cartCount[zi, zj] = cartCount[2, 2];
                cartCount[2, 2] = buf;
                zi = 2;
                zj = 2;
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < 2; j++)
                    {
                        for (int d = i; d < 2; d++)
                        {
                            for (int b = 0; b < 2; b++)
                            {
                                if (cartCount[d, b] != 0 && cartCount[i, j] > cartCount[d, b] && (i < d || j < b)) { ++k; }
                            }
                        }
                    }
                }
                k += zi + 1;
            }
            Invalidate();*
        }

        public void RandomPanels()
{
    var rnd = new Random();
    int i, j, buff, i1, j1;
    int count = 0;
    while (count != 44)
    {
        j = rnd.Next(0, 4);
        i = rnd.Next(0, 4);
        i1 = -1;
        j1 = -1;
        do
        {
            i1++;
            j1++;
        }
        while (cartCount[i1, j1] == 0);
        if (i == i1)
        {
            if (i1 >= 0 && i1 != 4) { i++; }
            else if (i1 == 4) { i--; }
        }
        if (j == j1)
        {
            if (j1 >= 0 && j1 != 4)
            {
                if (j1 >= 0) { j++; }
                else { j--; }
            }
            else if (j1 == 4) { j--; }
        }
        buff = cartCount[i, j];
        cartCount[i, j] = cartCount[i1, j1];
        cartCount[i1, j1] = buff;
        count++;
    }

    Invalidate();
}
        protected override void OnPaint(PaintEventArgs e) 
        {
            formList();
            int cc = ccc;
            Brush main = new SolidBrush(Color.Black);
            int xx = X;
            int yy = Y;

            for (int j = 0; j < gameLevel + 1; j++)
            {
                e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cards1[j]}"), new RectangleF(xx, yy + (j * iHeight) + j * 20, iWidth, iHeight));
                //e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"default"), new RectangleF(xx, yy + (j * iHeight) + j * 20, iWidth, iHeight));
                //e.Graphics.DrawImage((Bitmap)Properties.Resources._default, new RectangleF(xx, yy, iWidth, iHeight));
                //e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cc}"), new RectangleF(xx, yy, iWidth, iHeight));
                //e.Graphics.FillRectangle(main, xx, yy, iWidth, iHeight);
            }
            for (int j = 0; j < gameLevel + 1; j++)
            {
                e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cards2[j]}"), new RectangleF(xx + 20 + iWidth, yy + (j * iHeight) + j * 20, iWidth, iHeight));
                //e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"default"), new RectangleF(xx + 20 + iWidth, yy + (j * iHeight) + j * 20, iWidth, iHeight));
                //e.Graphics.DrawImage((Bitmap)Properties.Resources._default, new RectangleF(xx, yy, iWidth, iHeight));
                //e.Graphics.FillRectangle(main, xx, yy, iWidth, iHeight);
            }

            /*            for (int i = 0; i <2 ; i++)
                        {                
                            for (int j = 0; j < gameLevel + 1; j++) 
                            {



                                e.Graphics.DrawImage((Bitmap)Properties.Resources.ResourceManager.GetObject($"p{cc}"), new RectangleF(xx, yy, iWidth, iHeight));
                                //e.Graphics.DrawImage((Bitmap)Properties.Resources._default, new RectangleF(xx, yy, iWidth, iHeight));
                                //e.Graphics.FillRectangle(main, xx, yy, iWidth, iHeight);
                                Random r = new Random();
                                int value = r.Next(0, 1);
                                if (value == 0)
                                {
                                    cc++;
                                }
                                yy += iHeight + 10;                    
                            }
                            yy = Y;
                            xx += iWidth + 10;
                            cc =ccc;
                        }
e.Dispose();
Invalidate();
        }        public void onMouseClick(MouseEventArgs e)
{
    /*            int bufi = 0;
                int bufj = 0;
                int bufW = 0;
                int bufH = 0;
                int i = e.X / iWidth;
                int j = e.Y / iHeight;

                if (i == bufi && j == bufj)
                {
                    bufW = iWidth;
                    bufH = iHeight;
                    i = i + 100;
                    iHeight = 0;
                    new Rectangle(i,j,iWidth,iHeight);

                }*/

    /*            if (i < bufi+iWidth && j<bufj+iHeight) 
                {                
                    iWidth = 0;
                    iHeight = 0;                
                }*/
    /*            if (i != Bitmap(_x,_y,iWidth,iHeight)) 
                {
                    _x = 150;
                }*/

    /*                      int zi = 0;
                            int zj = 0;
                            for (int d = 0; d < 4; d++)
                            {
                                for (int b = 0; b < 4; b++)
                                {
                                    if (cartCount[d, b] == 0) { zi = d; zj = b; }
                                }
                            }
                            int i = e.Y / cellSize;
                            int j = e.X / cellSize;
                            int buf;
                            if (j == zj && Math.Abs(zi - i) == 1)
                            {
                                buf = cartCount[i, j];
                                cartCount[i, j] = cartCount[zi, j];
                                cartCount[zi, j] = buf;
                            }
                            if (i == zi && Math.Abs(zj - j) == 1)
                            {
                                buf = cartCount[i, j];
                                cartCount[i, j] = cartCount[i, zj];
                                cartCount[i, zj] = buf;
                            }
    Invalidate();
}
*/