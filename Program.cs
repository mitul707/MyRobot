using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRobot
{

    /* This Robot class is used to assign task to process dynamically.
     * As a developer we don't have to take care of the functionality of the robot class.
     * This Robot class can be used as a Utility or Helper class where we give input to some function and expects its output.
     * We just bind tell the robot to insert chip and it will execute its output based on the inserted chip.
     */
    
    
    enum Chip
    {
        SORT,
        SUM
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyRobot obj = new MyRobot();
            obj.Install_Chip(Chip.SORT);
            int[] output = obj.Execute_chip(new int[] { 5, 7, 3, 8, 10, 15, 12 });

            for (int i = 0; i < output.Length; i++)
            {
                Console.Write(output[i] + " ");
            }

            Console.WriteLine();

            obj.Install_Chip(Chip.SUM);
            Console.WriteLine(obj.Execute_chip(new int[] { 5, 7, 3, 8, 10, 15, 12 }));
            Console.WriteLine(obj.Chip_Count);
            Console.Read();
        }
    }

    class MyRobot
    {
        Chip val;
        ArrayList objInsertChip;

        public MyRobot()
        {
            objInsertChip = new ArrayList();
        }

        public int Chip_Count
        {
            get
            {
                return objInsertChip.Count;
            }
        }

        public void Install_Chip(Chip item)
        {
            if(!objInsertChip.Contains(item))
            {
                objInsertChip.Add(item);
            }
            
            val = item;
        }

        public dynamic Execute_chip(int[] arr)
        {
            if (val == Chip.SORT)
            {
                Array.Sort(arr);
                return arr;
            }

            else
            {
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    sum = sum + arr[i];
                }
                return sum;
            }
        }
    }
}
