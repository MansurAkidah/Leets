using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leets
{
    public class InsertIntervals
    {
        
            public int[][] Insert(int[][] intervals, int[] newInterval)
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                int[][] finka;
                int left = 0;
                int right = 0;
                bool flag = false;
                if (intervals.Length == 0)
                {
                    finka = new int[1][];
                    finka[0] = newInterval;
                    return finka;
                }
                if (newInterval[1] < intervals[0][0])
                {
                    int[][] fin = new int[intervals.Length + 1][];
                    fin[0] = new int[2];
                    fin[0][0] = newInterval[0];
                    fin[0][1] = newInterval[1];
                    for (int i = 1; i < fin.Length; i++)
                    {
                        fin[i] = new int[2];
                        fin[i][0] = intervals[i - 1][0];
                        fin[i][1] = intervals[i - 1][1];
                    }
                    return fin;
                }
                else if (newInterval[1] == intervals[0][0])
                {
                    intervals[0][0] = newInterval[0];
                    return intervals;
                }
                else if (newInterval[0] > intervals[intervals.Length - 1][1])
                {
                    int[][] fin = new int[intervals.Length + 1][];
                    fin[fin.Length - 1] = new int[2];
                    fin[fin.Length - 1][0] = newInterval[0];
                    fin[fin.Length - 1][1] = newInterval[1];
                    for (int i = 0; i < fin.Length - 1; i++)
                    {
                        fin[i] = new int[2];
                        fin[i][0] = intervals[i][0];
                        fin[i][1] = intervals[i][1];
                    }
                    return fin;
                }
                else if (newInterval[0] == intervals[intervals.Length - 1][1])
                {
                    intervals[intervals.Length - 1][1] = newInterval[1];
                    return intervals;
                }
                for (int i = 0; i < intervals.Length; i++)
                {
                    if (newInterval[0] >= intervals[i][0] && newInterval[0] <= intervals[i][1])
                    {
                        left = intervals[i][0];
                        for (int j = i + 1; j < intervals.Length; j++)
                        {
                            if (newInterval[1] < intervals[j][0])
                            {
                                right = newInterval[1];
                                finishMethod();
                                return finka;
                                //Console.WriteLine(left + " " + right);
                            }
                            else if (newInterval[1] >= intervals[j][0] && newInterval[1] <= intervals[j][1])
                            {
                                right = intervals[j][1];
                                finishMethod();
                                return finka;
                                //Console.WriteLine(left + " " + right);
                            }
                        }
                        right = newInterval[1];
                        finishMethod();
                        return finka;
                    }
                    else if (newInterval[0] < intervals[i][0])
                    {
                        left = newInterval[0];
                        for (int j = i; j < intervals.Length; j++)
                        {
                            if (newInterval[1] < intervals[j][0])
                            {
                                right = newInterval[1];
                                finishMethod();
                                return finka;
                                //Console.WriteLine(left + " " + right);
                            }
                            else if (newInterval[1] >= intervals[j][0] && newInterval[1] <= intervals[j][1])
                            {
                                right = intervals[j][1];
                                finishMethod();
                                return finka;
                                //Console.WriteLine(left + " " + right);
                            }
                        }
                        right = newInterval[1];
                        finishMethod();
                        return finka;
                    }
                }
                void finishMethod()
                {
                    for (int i = 0; i < intervals.Length; i++)
                    {
                        if (intervals[i][1] < left) //все что меньше левого конца нового интервала
                        {
                            dict.Add(intervals[i][0], intervals[i][1]);
                        }
                        if (intervals[i][0] > right) //всеЮ, что больше правого конца нового интерваал
                        {
                            dict.Add(intervals[i][0], intervals[i][1]);
                        }
                        else if (intervals[i][0] <= left && intervals[i][1] >= left) //левая часть нового интервала внутри одного из старых
                        {
                            left = intervals[i][0];
                            for (int j = i; j < intervals.Length; j++)
                            {
                                if (intervals[j][0] <= right && intervals[j][1] >= right) //правая часть нового интервала внутри одного из старых
                                {
                                    right = intervals[j][1];
                                    i = j;
                                    dict.Add(left, right);
                                    flag = true;
                                    break;
                                }
                                else if (right < intervals[j][0]) // правая часть нового интервала не входящая внутрь одного из старых
                                {
                                    dict.Add(left, right);
                                    i = j - 1;
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag == true)
                            {
                                flag = false;
                                continue;

                            }
                            dict.Add(left, right); //если правый конец нового интервала является крайним
                            break;
                        }
                        else if (intervals[i][1] < left && i + 1 < intervals.Length && right < intervals[i + 1][0])//когда новый интервал не пересекается с другимим
                        {
                            //dict.Add(intervals[i][0], intervals[i][1]);
                            dict.Add(left, right);
                        }
                        else if (intervals[i][0] > left)
                        {
                            for (int j = 0; j < intervals.Length; j++)
                            {
                                if (intervals[j][0] <= right && intervals[j][1] >= right) //правая часть нового интервала внутри одного из старых
                                {
                                    right = intervals[j][1];
                                    i = j;
                                    dict.Add(left, right);
                                    flag = true;
                                    break;
                                }
                                else if (right < intervals[j][0]) // правая часть нового интервала не входящая внутрь одного из старых
                                {
                                    dict.Add(left, right);
                                    i = j - 1;
                                    flag = true;
                                    break;
                                }
                            }
                            if (flag == true)
                            {
                                flag = false;
                                continue;

                            }
                            dict.Add(left, right); //если правый конец нового интервала является крайним
                            break;
                        }

                    }
                    finka = new int[dict.Count][];
                    int index = 0;
                    foreach (var item in dict)
                    {
                        finka[index] = new int[2];
                        finka[index][0] = item.Key;
                        finka[index++][1] = item.Value;
                        Console.WriteLine(item.Key + " " + item.Value);
                    }
                }
                return intervals;
            }
        
    }
}
