using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 多线程_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string flag = "222222";




            Console.WriteLine("主线程！");
            Thread thread = new Thread(new ThreadStart(CallToChildThread));
            thread.Start();
            Thread.Sleep(3000);
            Console.WriteLine("准备终止子线程");
            thread.Abort();
            Console.ReadKey();
        }
        public static void CallToChildThread()
        {
            try
            {
                Console.WriteLine("子线程开启！");
                Console.WriteLine("子线程将进入休眠4s....");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(4000);
                    Console.WriteLine(i+1);
                }
                Console.WriteLine("子线程重新开启");
            }
            catch(ThreadAbortException e)
            {
                Console.WriteLine("线程终止，抛出异常");
            }
            finally
            {
                Console.WriteLine("中止信息在finally块中出现");
            }
        }
    }
}
