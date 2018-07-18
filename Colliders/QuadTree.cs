using GameLibrary.Objects;
using System.Collections.Generic;

namespace GameLibrary.Colliders {
    public class QuadTree {

        public int MAX_OBJECTS = 10;
        public int MAX_LEVELS = 5;

        private int level;
        private List<GameObject> objects;
        private Rectanglef bounds;
        private QuadTree[] nodes;

        public QuadTree(int level, Rectanglef bounds) {
            this.level = level;
            this.bounds = bounds;
            objects = new List<GameObject>();
            nodes = new QuadTree[4];
        }

        public void CollisionDetection() {
            if (nodes == null) {

            } else {
                foreach (QuadTree node in nodes) {
                    node.CollisionDetection();
                }
            }
        }

        /// <summary>
        /// Clears the quadtree.
        /// </summary>
        public void Clear() {
            objects.Clear();

            for (int i = 0; i < nodes.Length; i++) {
                if (nodes[i] != null) {
                    nodes[i].Clear();
                    nodes[i] = null;
                }
            }
        }

        /// <summary>
        /// Splits the node into 4 subnodes.
        /// </summary>
        private void Split() {
            float subWidth = bounds.Width / 2;
            float subHeight = bounds.Height / 2;
            float x = bounds.X;
            float y = bounds.Y;

            nodes[0] = new QuadTree(level + 1, new Rectanglef(x + subWidth, y, subWidth, subHeight));
            nodes[1] = new QuadTree(level + 1, new Rectanglef(x, y, subWidth, subHeight));
            nodes[2] = new QuadTree(level + 1, new Rectanglef(x, y + subHeight, subWidth, subHeight));
            nodes[3] = new QuadTree(level + 1, new Rectanglef(x + subWidth, y + subHeight, subWidth, subHeight));
        }

        /// <summary>
        /// Determine which node the object belongs to. -1 means
        /// object cannot completely fit within a child node and is part
        /// of the parent node.
        /// </summary>
        private int GetIndex(GameObject obj) {
            int index = -1;
            double verticalMidpoint = bounds.X + (bounds.Width / 2);
            double horizontalMidpoint = bounds.Y + (bounds.Height / 2);

            // Object can completely fit within the top quadrants.
            bool topQuadrant = (obj.rect.Y < horizontalMidpoint && obj.rect.Y + obj.rect.Height < horizontalMidpoint);
            // Object can completely fit within the bottom quadrants.
            bool bottomQuadrants = (obj.rect.Y > horizontalMidpoint);

            // Object can completely fit within the left quadrants.
            if (obj.rect.X < verticalMidpoint && obj.rect.X + obj.rect.Width < verticalMidpoint) {
                if (topQuadrant) {
                    index = 1;
                } else if (bottomQuadrants) {
                    index = 2;
                }
            } else if (obj.rect.X > verticalMidpoint) { // Object can completely fit within the right quadrants.
                if (topQuadrant) {
                    index = 0;
                } else if (bottomQuadrants) {
                    index = 3;
                }
            }

            return index;
        }

        public void Insert(GameObject obj) {
            if (nodes[0] != null) {
                int index = GetIndex(obj);

                if (index != -1) {
                    nodes[index].Insert(obj);

                    return;
                }
            }

            objects.Add(obj);

            int i = 0;
            while (i < objects.Count) {
                int index = GetIndex(objects[i]);

                if (index != -1) {
                    objects.RemoveAt(i);
                    //nodes[index].insert(objects.RemoveAt(i));
                } else {
                    i++;
                }
            }
        }

        /// <summary>
        /// Return all objects that could collide with the given object.
        /// </summary>
        public List<GameObject> Retrieve(List<GameObject> returnObjects, GameObject obj) {
            int index = GetIndex(obj);
            if (index != -1 && nodes[0] != null) {
                nodes[index].Retrieve(returnObjects, obj);
            }

            returnObjects.AddRange(objects);

            return returnObjects;
        }

    }
}
