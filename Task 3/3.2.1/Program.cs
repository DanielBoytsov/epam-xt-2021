using System;
using System.Collections.Generic;

namespace _3._2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new DynamicArray<int>(3) { 1, 5, 7 };
            List<int> abc = new List<int>(3) { 1, 5, 9 };
            var testList = new DynamicArray<int>(abc);

            //test.ChangeCapacity(0);
            test.RemoveAt(13);
            foreach (var item in test)
            {

                Console.Write(item);
            }
            foreach (var item in testList)
            {
                Console.Write(item);
            }
            

           
            var testCDA = new CycledDynamicArray<int>(test);
            //foreach (var item in testCDA)
            //{
            //    Console.Write(item);
            //}
            var a = (DynamicArray<int>)testList.Clone();
           

            var bv = testList.ToArray();
            var asdsa = new DynamicArray<int>(bv);

            foreach (var item in bv)
            {
                
                Console.Write(item);
            }


            //test.Insert(0, 5);
            //test.Insert(1, 8);
            //test.Insert(1, 9);
            //test.Insert(3, 9);
            //foreach (var item in test)
            //{
            //    Console.WriteLine("after insert" + item);
            //}
            //test.RemoveAt(0);
            //test.Remove(9);
            //foreach (var item in test)
            //{
            //    Console.WriteLine("after removing" + item);
            //}


            //foreach (var item in abc)
            //{
            //    abc.Add(2);
            //}
            //foreach (var item in abc)
            //{
            //    Console.Write(item);
            //}
            //Console.WriteLine("-index" + test[-4]);

        }
        
    }
    
}
