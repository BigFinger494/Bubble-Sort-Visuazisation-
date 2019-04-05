using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
namespace SFMLTESTPROJECT
{
    class Program
    {
       static RenderWindow window ;
        static void Main(string[] args)
        {
            Random rand = new Random();
            window = new RenderWindow(new SFML.Window.VideoMode(800,600),"Demo");
            window.SetVerticalSyncEnabled(true);
            CircleShape circle = new CircleShape(50.0f);
            circle.SetPointCount(20);

            int Count = 25;

            RectangleShape[] mas = new RectangleShape[Count];
            int[] arr = new int[Count];
            Text Copyright = new Text();
          
            int X = 50;
            Font font = new Font(@"C:\Windows\Fonts\Arial.ttf");
            window.Closed += Window_Closed;
            void init()
            {
                Copyright.Font = font;
                Copyright.CharacterSize = 30;
                for (int i = 0; i < Count; i++)
                {
                    arr[i] = rand.Next(1, 200);
                    
                }

                for (int i = 0; i < Count; i++)
                {
                    mas[i] = new RectangleShape(new Vector2f(10, arr[i] * (-2)));
                    // mas[i].Size = new Vector2f(10, 20);
                    mas[i].Position = new SFML.System.Vector2f(X, 500);
                    mas[i].FillColor = new Color(Color.Green);
                    mas[i].OutlineColor = new Color(Color.Black);
                    mas[i].OutlineThickness = 1;
                    X += 20;
                }

                for (int i = 0; i < mas.Length; i++)
                    window.Draw(mas[i]);
            }

            int percent=0,count_i=0,count_j=0;

            int x = arr.Length * (arr.Length - 1);
          void BubbleSort()
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    count_i++;
                    for (int j = 0; j < arr.Length-1; j++)
                    {
                        count_j++;
                        int y  =
                        percent = 100* count_i*count_j /(x * Count) ;
                        window.Clear(Color.Black);
                        Copyright.DisplayedString = "progress: "+ percent.ToString() + "%";
                        window.Draw(Copyright);
                        mas[j].FillColor = new Color(Color.Blue);
                        mas[j+1].FillColor = new Color(Color.Blue);
                        if (arr[j] > arr[j+1])
                        {
                            var temp = arr[j+1];
                            var coords = mas[j + 1].Size.Y;
                            arr[j+1] = arr[j];
                            arr[j] = temp;
                            mas[j+1].Size = new Vector2f(mas[j].Size.X, mas[j].Size.Y);
                            mas[j].Size = new Vector2f(mas[j].Size.X, coords);
                        }
                        for (int z = 0; z < mas.Length; z++)
                        {
                            if (j > 0 && z != j+1 && z!=j)
                                mas[z].FillColor = new Color(Color.Red);

                            window.Draw(mas[z]);
                        }
                        window.Display();
                        System.Threading.Thread.Sleep(10);
                    }
                    
                }
                mas[mas.Length-2].FillColor = new Color(Color.Red);
                mas[mas.Length-1].FillColor = new Color(Color.Red);
            }

            if (window.IsOpen)
            {

                init();
                BubbleSort();

            }
           
           
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Black);
                window.Draw(Copyright);
                for (int i = 0; i < mas.Length; i++)
                {
                    window.Draw(mas[i]);
                }
                window.Display();
            }
        }
        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
