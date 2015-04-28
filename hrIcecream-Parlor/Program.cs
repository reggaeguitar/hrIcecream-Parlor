using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class Solution
{
    static void Main()
    {
        Console.WriteLine(Solve(Console.In));
    }

    public static string Solve(TextReader reader)
    {
        var sb = new StringBuilder();
        var numCases = Int32.Parse(reader.ReadLine());
        while (numCases-- > 0)
        {
            var target = Int32.Parse(reader.ReadLine());
            reader.ReadLine();
            var nums = reader.ReadLine()
                .Split(' ')
                .Select((s, i) => new KeyValuePair<int, int>(Int32.Parse(s), i))
                .OrderBy(x => x.Key)
                .ToArray();
            bool done = false;
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (done) break;
                var curNum = nums[i].Key;
                for (int j = i + 1; j < nums.Length; ++j)
                {
                    if (curNum + nums[j].Key == target)
                    {
                        var firstIndex = Math.Min(nums[i].Value, nums[j].Value) + 1;
                        var secondIndex = Math.Max(nums[i].Value, nums[j].Value) + 1;
                        sb.AppendFormat("{0} {1}{2}", firstIndex, secondIndex, Environment.NewLine);
                        done = true;
                        break;
                    }
                }
            }
        }
        return sb.ToString();
    }
}
