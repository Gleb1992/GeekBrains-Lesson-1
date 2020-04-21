using System;
using System.Drawing;

namespace AsteroidGame
{
    class Rock : BaseObject
    {
        public Rock(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y, pos.X + size.Width/2, pos.Y + size.Height/2);
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width/2, pos.Y + size.Height / 2, pos.X, pos.Y + size.Height);
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y, pos.X, pos.Y + size.Height);
        }

        public override void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X < 0) dir.X = -dir.X;
            if (pos.X > Game.Width) dir.X = -dir.X;
            if (pos.Y < 0) dir.Y = -dir.Y;
            if (pos.Y > Game.Height) dir.Y = -dir.Y;
        }



    }
}
