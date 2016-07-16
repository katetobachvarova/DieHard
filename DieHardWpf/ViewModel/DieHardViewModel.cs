using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using DieHardWpf.Commands;
using System.Data;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace DieHardWpf
{
    public class DieHardViewModel : BindableBase
    {

        public TickCommand TickCommand { get; set; }

        //protected int[,] current = new int[40, 40];
        int[,] next;

        private int[,] current = new int[40, 30];

        public int[,] Current
        {
            get { return current; }
            set {
                current = value;
                MyArrayData = CreateDataTable();
            }
        }

        public DieHardViewModel()
        {
            current[20, 17] = 1;
            current[21, 11] = 1;
            current[21, 12] = 1;
            current[22, 12] = 1;
            current[22, 16] = 1;
            current[22, 17] = 1;
            current[22, 18] = 1;
            bla.Add(new Customer() { ID = 3, Name="Kateto" });
            bla.Add(new Customer() { ID = 4, Name = "pe6o" });
            TickCommand = new TickCommand(this);
            MyArrayData = CreateDataTable();
            PointsToDraw.Add(new Rectangle() { Height = 5, Width = 5, Top = (20 * 10) + 10, Left = (17 * 10) + 10, Color = new SolidColorBrush(Colors.Coral) });
            PointsToDraw.Add(new Rectangle() { Height = 5, Width = 5, Top = (21 * 10) + 10, Left = (11 * 10) + 10, Color = new SolidColorBrush(Colors.Coral) });
            PointsToDraw.Add(new Rectangle() { Height = 5, Width = 5, Top = (21 * 10) + 10, Left = (12 * 10) + 10, Color = new SolidColorBrush(Colors.Coral) });
            PointsToDraw.Add(new Rectangle() { Height = 5, Width = 5, Top = (22 * 10) + 10, Left = (12 * 10) + 10, Color = new SolidColorBrush(Colors.Coral) });
            PointsToDraw.Add(new Rectangle() { Height = 5, Width = 5, Top = (22 * 10) + 10, Left = (16 * 10) + 10, Color = new SolidColorBrush(Colors.Coral) });
            PointsToDraw.Add(new Rectangle() { Height = 5, Width = 5, Top = (22 * 10) + 10, Left = (17 * 10) + 10, Color = new SolidColorBrush(Colors.Coral) });
            PointsToDraw.Add(new Rectangle() { Height = 5, Width = 5, Top = (22 * 10) + 10, Left = (18 * 10) + 10, Color = new SolidColorBrush(Colors.Coral) });

        }

        private ObservableCollection<Customer> bla = new ObservableCollection<Customer>();

        public  ObservableCollection<Customer> Bla
        {
            get { return bla; }
            set { bla = value; }
        }

        private ObservableCollection<Rectangle> pointsToDraw = new ObservableCollection<Rectangle>();

        public ObservableCollection<Rectangle> PointsToDraw
        {
            get { return pointsToDraw ; }
            set { pointsToDraw = value; }
        }

        private Canvas canvasToDraw;

        public Canvas CanvasToDraw
        {
            get { return canvasToDraw; }
            set { canvasToDraw = value; }
        }



        private DataView myArrayData;

        public DataView MyArrayData
        {
            get { return myArrayData; }
            set { SetProperty(ref myArrayData, value); }
        }

        protected DataView CreateDataTable()
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < current.GetLength(1); i++)
            {
                dt.Columns.Add();
            }
            for (int i = 0; i < current.GetLength(0); i++)
            {
                DataRow dr = dt.NewRow();
                for (int col = 0; col < current.GetLength(1); col++)
                {
                    dr[col] = current[i,col];
                    
                }
                dt.Rows.Add(dr);
            }
            return dt.DefaultView;
        }
       
        public async void Tick()
        {
            for (int i = 0; i < 130; i++)
            {
                next = Tick(Current);
                Current = next;
                await Task.Delay(2000);

            }

        }

        //public void DrawCanvas()
        //{
        //    foreach (var rect in PointsToDraw)
        //    {
        //        System.Windows.Shapes.Rectangle r = new System.Windows.Shapes.Rectangle();
        //        r.Width = rect.Width;
        //        r.Height = rect.Height;
        //        r.Fill = rect.Color;

        //        // ... Set canvas position based on Rect object.
        //        Canvas.SetLeft(r, rect.Left);
        //        Canvas.SetTop(r, rect.Top);

        //        // ... Add to canvas.
        //        CanvasToDraw.Children.Add(r);
        //    }
        //}
        private  int[,] Tick(int[,] bla)
        {
            PointsToDraw.Clear();
            int x = bla.GetLength(0);
            int y = bla.GetLength(1);

            int[,] next = new int[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    next[i, j] = ComputeState(i, j, bla, bla[i, j]);
                    if (next[i,j] == 1)
                    {
                        //PointsToDraw.Add(new Point(i,j));
                        Rectangle r = new Rectangle() { Height = 5, Width = 5, Top = (i * 10) + 10, Left = (j * 10) + 10, Color = new SolidColorBrush(Colors.Coral)};

                        PointsToDraw.Add(r);

                    }
                }
            }


            return next;
        }

        private  int ComputeState(int i, int j, int[,] bla, int currentState)
        {
            int state;
            int sum = -1;
            int x = bla.GetLength(0);
            int y = bla.GetLength(1);

            if (i > 0 && j > 0 && i <= x - 2 && j <= y - 2)
            {
                sum = bla[i - 1, j - 1] + bla[i - 1, j] + bla[i - 1, j + 1] +
                      bla[i, j - 1] + bla[i, j] + bla[i, j + 1] +
                      bla[i + 1, j - 1] + bla[i + 1, j] + bla[i + 1, j + 1];
            }
            else
            {
                if (i < 1 && j < 1)
                {
                    sum = bla[x - 1, y - 1] + bla[x - 1, j] + bla[x - 1, j + 1] +
                      bla[i, y - 1] + bla[i, j] + bla[i, j + 1] +
                      bla[i + 1, y - 1] + bla[i + 1, j] + bla[i + 1, j + 1];
                }
                else if (i > x - 1 - 1 && j > y - 1 - 1)
                {
                    sum = bla[i - 1, j - 1] + bla[i - 1, j] + bla[i - 1, 0] +
                      bla[i, j - 1] + bla[i, j] + bla[i, 0] +
                      bla[0, j - 1] + bla[0, j] + bla[0, 0];
                }
                else if (i < 1 && j > y - 1 - 1)
                {
                    sum = bla[x - 1, j - 1] + bla[x - 1, j] + bla[x - 1, 0] +
                      bla[i, j - 1] + bla[i, j] + bla[i, 0] +
                      bla[i + 1, j - 1] + bla[i + 1, j] + bla[i + 1, 0];
                }
                else if (j < 1 && i > 0 && i > x - 2 && j < y - 2)
                {
                    sum = bla[i - 1, y - 1] + bla[i - 1, j] + bla[i - 1, j + 1] +
                     bla[i, y - 1] + bla[i, j] + bla[i, j + 1] +
                     bla[0, y - 1] + bla[0, j] + bla[0, j + 1];
                }

                else if (i < 1 && j > 0 && i < x - 2 && j <= y - 2)
                {
                    sum = bla[x - 1, j - 1] + bla[x - 1, j] + bla[x - 1, j + 1] +
                          bla[i, j - 1] + bla[i, j] + bla[i, j + 1] +
                          bla[i + 1, j - 1] + bla[i + 1, j] + bla[i + 1, j + 1];
                }

                else if (j < 1 && i > 0 && i <= x - 2 && j < y - 2)
                {
                    sum = bla[i - 1, y - 1] + bla[i - 1, j] + bla[i - 1, j + 1] +
                      bla[i, y - 1] + bla[i, j] + bla[i, j + 1] +
                      bla[i + 1, y - 1] + bla[i + 1, j] + bla[i + 1, j + 1];
                }

                else if (i > 0 && j > 0 && i <= x - 2 && j > y - 1 - 1)
                {
                    sum = bla[i - 1, j - 1] + bla[i - 1, j] + bla[i - 1, 0] +
                     bla[i, j - 1] + bla[i, j] + bla[i, 0] +
                     bla[i + 1, j - 1] + bla[i + 1, j] + bla[i + 1, 0];
                }
                else if (i > 0 && j > 0 && j <= y - 2 && i > x - 1 - 1)
                {
                    sum = bla[i - 1, j - 1] + bla[i - 1, j] + bla[i - 1, j + 1] +
                      bla[i, j - 1] + bla[i, j] + bla[i, j + 1] +
                      bla[0, j - 1] + bla[0, j] + bla[0, j + 1];
                }



            }


            if (sum == 3)
            {
                return state = 1;
            }
            else if (sum == 4)
            {
                return state = currentState;
            }
            else
            {
                return state = 0;
            }
        }

    }

    public class Customer : BindableBase
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

    }

    public class Point : BindableBase
    {
        private int i;

        public int I
        {
            get { return i; }
            set { SetProperty(ref i, value); }
        }

        private int j;

        public int J
        {
            get { return j; }
            set { SetProperty(ref j , value); }
        }

        public Point(int i, int j)
        {
            I = i;
            J = j;
        }

    }

    public class Rectangle : BindableBase
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public SolidColorBrush Color { get; set; }

    }
}
