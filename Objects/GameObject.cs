using GameLibrary.Colliders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameLibrary.Objects {
    public class GameObject {

        public GraphicsDeviceManager graphics;
        public Texture2D texture;
        public bool Collided = false;
        public Rectanglef rect;

        public Vector2 velocity;

        public GameObject(GraphicsDeviceManager graphics, Rectanglef rect, Texture2D texture) {
            this.graphics = graphics;
            this.rect = rect;
            this.texture = texture;
        }

        public virtual void Update() {

        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Rectanglef(rect.Position, rect.Size).toRectangle(), Color.White);
        }

        #region Collision

        protected bool IsTouchingLeft(GameObject other) {
            return rect.Right + velocity.X > other.rect.Left &&
                   rect.Left < other.rect.Left &&
                   rect.Bottom > other.rect.Top &&
                   rect.Top < other.rect.Bottom;
        }

        protected bool IsTouchingRight(GameObject other) {
            return rect.Left + velocity.X < other.rect.Right &&
                   rect.Right > other.rect.Right &&
                   rect.Bottom > other.rect.Top &&
                   rect.Top < other.rect.Bottom;
        }

        protected bool IsTouchingTop(GameObject other) {
            return rect.Bottom + velocity.Y > other.rect.Top &&
                   rect.Top < other.rect.Top &&
                   rect.Right > other.rect.Left &&
                   rect.Left < other.rect.Right;
        }

        protected bool IsTouchingBottom(GameObject other) {
            return rect.Top + velocity.Y < other.rect.Bottom &&
                   rect.Bottom > other.rect.Bottom &&
                   rect.Right > other.rect.Left &&
                   rect.Left < other.rect.Right;
        }

        #endregion

        /**public bool Collision(GameObject target) {
            bool intersects = rect.Intersects(target.rect) && PerPixelCollision(target);

            Collided = intersects;
            target.Collided = intersects;
            return intersects;
        }

        /**public bool PerPixelCollision(GameObject target) {
            Color[] sourceColors = new Color[texture.Width * texture.Height];
            texture.GetData(sourceColors);

            Color[] targetColors = new Color[target.texture.Width * target.texture.Height];
            target.texture.GetData(targetColors);

            int left = Math.Max(rect.Left, target.rect.Left);

            Rectanglef intersectingRectangle = new Rectangle();
        }*/


        protected enum FACING {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }
    }
}
