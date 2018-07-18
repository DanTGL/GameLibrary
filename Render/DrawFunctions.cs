using GameLibrary.Colliders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameLibrary.Render {
    public class DrawFunctions {

        public static void DrawRect(SpriteBatch spriteBatch, Texture2D texture, Rectanglef rect, Color color, float scale) {
            //spriteBatch.Draw(texture, rect.Position, null, Color.White, 0f, new Vector2(rect.X - (rect.Width / 2), rect.Y - (rect.Height / 2)), 1.0f, SpriteEffects.None, 0f);
            //spriteBatch.Draw(texture, new Vector2(rect.X, rect.Y), null, color, 0f, new Vector2(rect.X + (rect.Width / 2), rect.Y + (rect.Height / 2)), 1.0f, SpriteEffects.None, 0f);
            //spriteBatch.Draw(texture, new Vector2(rect.X, rect.Y), color);
            spriteBatch.Draw(texture, new Vector2(rect.X, rect.Y), null, color, 0f, new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0f);
        }

    }
}
