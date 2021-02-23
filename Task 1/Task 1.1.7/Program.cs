using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._7
{
    class Program
    {
          static void Main(string[] args)
          {
              int[] arr = new int[10];
              Random rnd = new Random();
              for (int i = 0; i < arr.Length;i++)
              {
                  arr[i] = rnd.Next(-100,100);
                  Console.WriteLine($"{i} = {arr[i]}");
              }
              Console.WriteLine($"Max point = {Max(arr)}");
              Console.WriteLine($"Min point = {Min(arr)}");
              Sort(arr);
              for (int i = 0; i < arr.Length; i++)
              {
                  Console.WriteLine($"{i} = {arr[i]}");
              }
          }
          public static int Max(int[] arr)
          {
              int m = arr[0];
              for (int i = 0; i < arr.Length; i++)
              {
                  if (arr[i] > m)
                  {
                      m = arr[i];
                  }
              }
            return m;
          }
          public static int Min(int[] arr)
          {
              int m = arr[0];
              for (int i = 0; i < arr.Length; i++)
              {
                  if (arr[i] < m)
                  {
                      m = arr[i];
                  }
              }
              return m;
          }
          public static int[] Sort(int[] arr)
          {
              int m;
              for (int i = 0; i < arr.Length; i++)
              {
                  for (int j = i + 1; j < arr.Length; j++)
                  {
                      if (arr[i] > arr[j])
                      {
                          m = arr[i];
                          arr[i] = arr[j];
                          arr[j] = m;
                      }
                  }
              }
              return arr;
          }
    }
}
