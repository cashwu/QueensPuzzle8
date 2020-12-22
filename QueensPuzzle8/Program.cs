using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensPuzzle8
{
    class Program
    {
        /// <summary>
        /// 主程式
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // 寫死了 0 ~ 7 如果今天需要修改的話怎麼辦 ? 
            var arr = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
            
            // 命名 arr
            var arrs = GetArrs(arr); 
            arrs = RemoveObliqueLine(arrs);
            foreach (var ans in arrs) {
                Console.WriteLine($"第{arrs.IndexOf(ans) + 1}個棋盤");
                foreach (var item in ans) {
                    var str = "........".Remove(item, 1).Insert(item, "Q");
                    Console.WriteLine(str);
                }
                Console.WriteLine($"");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 移除 斜角線的棋盤 
        /// </summary>
        /// <param name="arrs"></param>
        /// <returns></returns>
        private static List<List<int>> RemoveObliqueLine(List<List<int>> arrs)
        {
            var newArr = new List<List<int>>();

            foreach (var arr in arrs) 
            {
                if (!IsObliqueLine(0, arr)) 
                {
                    newArr.Add(arr);
                }
            }

            return newArr;
        }

        /// <summary>
        /// 判斷任兩個皇后 是否 在斜角線
        /// </summary>
        /// <param name="ind"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static bool IsObliqueLine(int ind, List<int> arr)
        {
            var res = false;

            for (var i = ind+1; i < arr.Count(); i++)
            {
                res = Math.Abs(arr[i] - arr[ind]) == Math.Abs(i - ind);
                if (res) 
                {
                    return res;
                }
            }

            if (arr.Count() - (ind + 1) > 1) 
            {
                return IsObliqueLine(ind + 1, arr);
            }

            return res;
        }

        /// <summary>
        /// 取得 八皇后 不同列不同行的解
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static List<List<int>> GetArrs(List<int> arr)
        {
            var rets = new List<List<int>>();
 
            for (var i = 0; i < arr.Count(); i++) 
            {
                // 命名
                var a2 = arr.ToList();
                a2.RemoveAt(i);
                if (a2.Count() < 1)
                {
                    rets.Add(arr);
                    break;
                }

                var arrs = GetArrs(a2);
                foreach (var item in arrs)
                {
                    item.Insert(0, arr[i]);
                    rets.Add(item);
                }
            }

            return rets;
        }
    }
}
