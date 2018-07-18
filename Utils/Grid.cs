using GameLibrary.Objects;

namespace GameLibrary.Utils {
    public class Grid {

        public int width;
        public int height;

        public GameObject[,] objects;

        public Grid(int width, int height) {
            this.width = width;
            this.height = height;

            objects = new GameObject[width, height];
        }

        public void addObject(GameObject obj) {
            objects[(int) obj.rect.X, (int) obj.rect.Y] = obj;
        }

        public GameObject getObject(int x, int y) {
            return objects[x, y];
        }

    }
}
