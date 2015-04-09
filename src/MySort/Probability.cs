using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySort
{
    public class Probability
    {
        private Random _rand;
        private Dictionary<int, Prize> _prizeList;
        public Probability()
        {
            _rand = new Random();
            _prizeList = new Dictionary<int, Prize>();

            _prizeList.Add(0, new Prize { Name = "下次没准就能中哦", Probability = 50 });
            _prizeList.Add(1, new Prize { Name = "平板电脑", Probability = 1 });
            _prizeList.Add(2, new Prize { Name = "数码相机", Probability = 5 });
            _prizeList.Add(3, new Prize { Name = "音箱设备", Probability = 10 });
            _prizeList.Add(4, new Prize { Name = "4G优盘", Probability = 12 });
            _prizeList.Add(5, new Prize { Name = "10Q币", Probability = 22 });
        }

        public int? GetRand(int[] arr)
        {
            var arrSum = arr.Sum();
            for (int i = 0; i < arr.Length; ++i)
            {
                var randNum = _rand.Next(1, arrSum);
                if (randNum <= arr[i])
                    return i;
                else
                    arrSum -= arr[i];
            }
            return null;
        }

        public void Test()
        {
            var probability = new int[_prizeList.Count()];
            foreach (var item in _prizeList)
            {
                probability[item.Key] = item.Value.Probability;
            }
            var res = GetRand(probability);
            Console.WriteLine(_prizeList[res.Value].Name);
        }
    }

    struct Prize
    {
        public string Name { get; set; }
        public int Probability { get; set; }
    }
}
