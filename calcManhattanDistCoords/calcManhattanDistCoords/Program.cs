namespace calcManhattanDistCoords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (Tuple<int, int> combi in getCombiOfManhattan(2, 3, 3))
            {
                Console.WriteLine($"{combi.Item1} {combi.Item2}");
            }
        }

        /// <summary>
        /// 指定の座標から指定のマンハッタン距離の座標の一覧を取得する
        /// </summary>
        /// <param name="offsetY">Y座標</param>
        /// <param name="offsetX">X座標</param>
        /// <param name="dist">マンハッタン距離</param>
        /// <example>
        /// 入力：offsetY = 0, offsetX = 0, dist = 3 <br></br>
        /// 出力：(Y,X)=(0,3),(1,2),(2,1),(3,0),(0,-3),(1,-2),(2,-1),(-1,2),(-2,1),(-3,0),(0,-3),(-1,-2),(-2,-1)
        /// </example>
        /// <returns>指定の座標から指定のマンハッタン距離の座標の一覧</returns>
        static IEnumerable<Tuple<int, int>> getCombiOfManhattan(int offsetY, int offsetX, int dist)
        {
            List<Tuple<int, int>> combisFirstQuadrant = new List<Tuple<int, int>>();
            List<Tuple<int, int>> combis = new List<Tuple<int, int>>();

            // (0,0)を基準とする引数のマンハッタン距離の一覧を取得する
            // 第一象限（x, yともに正）の一覧を取得する
            for (int i = 0; i <= dist; i++)
            {
                Tuple<int, int> combi = new Tuple<int, int>(i, dist - i);
                combisFirstQuadrant.Add(combi);
                combis.Add(combi);
            }
            // x軸、y軸で反転し、マンハッタン距離の一覧を取得する
            foreach (Tuple<int, int> combi in combisFirstQuadrant)
            {
                bool isItem1Zero = combi.Item1 == 0;
                bool isItem2Zero = combi.Item2 == 0;

                if (!isItem1Zero)
                {
                    combis.Add(new Tuple<int, int>(-combi.Item1, combi.Item2));
                }
                if (!isItem2Zero)
                {
                    combis.Add(new Tuple<int, int>(combi.Item1, -combi.Item2));
                }
                if (!isItem1Zero && !isItem2Zero)
                {
                    combis.Add(new Tuple<int, int>(-combi.Item1, -combi.Item2));
                }
            }

            // 基準点でオフセットしてマンハッタン距離の一覧を返却する
            return combis.Select(_ => new Tuple<int, int>(_.Item1 + offsetY, _.Item2 + offsetX));
        }
    }
}