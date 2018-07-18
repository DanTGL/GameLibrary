using Microsoft.Xna.Framework;

namespace GameLibrary.Colliders {
    public class Rectanglef {

        public float X;
        public float Y;
        public float Width;
        public float Height;
        public float scale;

        public Rectanglef(float x, float y, float width, float height, float scale = 1.0f)  {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.scale = scale;
        }

        public Rectanglef(Vector2 pos, Vector2 size, float scale = 1.0f) : this(pos.X, pos.Y, size.X, size.Y, scale) {}

        public bool Intersects(Rectanglef other) {
            float otherX = other.X;
            float otherY = other.Y;
            float otherWidth = other.Width;
            float otherHeight = other.Height;
            
            //if (Contains(new Vector2(X, Y))) {
            //    return true;
            //}
            
            //return false;
            return !(X > otherWidth || Width < otherX || Y > otherHeight || Height < otherY);
        }

        public float Top {
            get { return Y; }
        }

        public float Bottom {
            get { return Y + Height; }
        }

        public float Left {
            get { return X; }
        }

        public float Right {
            get { return X + Width; }
        }

        public float verticalMidpoint {
            get { return X + Width / 2; }
        }

        public float horizontalMidpoint {
            get { return Y + Height / 2; }
        }

        public Vector2 Center {
            get { return new Vector2(verticalMidpoint, horizontalMidpoint); }
        }
        
        public Vector2 Position {
            get { return new Vector2(X, Y); }
        }

        public Vector2 Size {
            get { return new Vector2(Width, Height); }
        }

        public Rectangle toRectangle() {
            return new Rectangle((int) X, (int) Y, (int) Width, (int) Height);
        }
        
        public bool Contains(Vector2 pos) {
            if (pos == null) return false;

            return pos.X >= X && pos.X <= Width && pos.Y >= Y && pos.Y <= Height;

            /*for (int i = 0; i < Right; i++) {
                for (int j = 0; j < Bottom; j++) {
                    if (new Vector2(i, j) == pos)
                        return true;
                }
            }

            return false;*/
        }

    }
}
