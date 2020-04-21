using System;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame
{
    

    static class Game
    {
        static BaseObject[] objs;

        static BufferedGraphicsContext context;
        static public BufferedGraphics buffer;
        
        // Свойства
        // Ширина и высота игрового поля
        static public int Width { get; set; }
        static public int Height { get; set; }

        static Game()
        {
        }

        static public void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // предоставляет доступ к главному буферу графического контекста для текущего приложения
            context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();// Создаём объект - поверхность рисования и связываем его с формой
                                      // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
            // Связываем буфер в памяти с графическим объектом.
            // для того, чтобы рисовать в буфере
            buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        static public void Load()
        {

            objs = new BaseObject[30];
            for (int i = 0; i < 10; i++)
                objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            for (int i = 10; i < 20; i++)
                objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(5, 5));
            for (int i = 20; i < 30; i++)
                objs[i] = new Rock(new Point(600, i * 20), new Point(25 - i, 26 - i), new Size(20, 20));



                //            objs = new BaseObject[30];
                //            for (int i = 0; i < objs.Length; i++)
                //                objs[i] = new Star(new Point(600, i * 20), new Point(-i, 1), new Size(20, 20));

                //            objs = new BaseObject[30];
                //            for (int i = 0; i < objs.Length; i++)
                //                objs[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
        }

        static public void Draw()
        {
            buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in objs)
                obj.Draw();
            buffer.Render();
        }

        static public void Update()
        {
            foreach (BaseObject obj in objs)
                obj.Update();
        }

    }
}

