using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;

namespace GameLibrary.Tile {
    public class TileEngineReader {

        public int[,] pos;

        public readonly int width;
        public readonly int height;

        string[] separators = new string[] { "," };

        public TileEngineReader(int width, int height, string filePath) {
            this.width = width;
            this.height = height;

            var levelFile = TitleContainer.OpenStream(filePath);

            Debug.WriteLine(Directory.GetCurrentDirectory());
            string[] lines = new string[height];
            
            using (StreamReader reader = new StreamReader(levelFile)) {
                int i = 0;

                while ((lines[i] = reader.ReadLine()) != null) {
                    lines[i] = reader.ReadLine();
                    i++;
                }
            }
            pos = new int[width, height];

            int j;

            for (int i = 0; i < height; i++) {
                string line = lines[i];

                j = 0;

                foreach (string number in line.Split(separators, StringSplitOptions.RemoveEmptyEntries)) {
                    int num = int.Parse(number);
                    Debug.Write(num + " ");
                    pos[j, i] = num;
                    j++;
                }
                Debug.WriteLine("");
            }
        }
    }
}
