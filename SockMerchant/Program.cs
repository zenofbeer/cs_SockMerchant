using System;
using System.Collections.Generic;

namespace SockMerchant
{
    class Program
    {
        static void Main(string[] args)
        {
            SockInventory inventory = new SockInventory();
            var socks = new int[]{1, 2, 1, 2, 1, 3, 2};
            // sort the socks
            var buckets = inventory.OrganizeSocks(socks);
            
            // print the results
            foreach (var key in buckets.Keys)
            {
                Console.WriteLine("Color " + key + " has " + buckets[key][0] + " pairs and " + buckets[key][1] +
                                  " singles.");
            }
        }
    }

    internal class SockInventory
    {
        public Dictionary<int, int[]> OrganizeSocks(int[] socks)
        {
            var sockBuckets = new Dictionary<int, int[]>();

            foreach (var sock in socks)
            {
                if (sockBuckets.ContainsKey(sock))
                {
                    sockBuckets[sock][0]++;
                }
                else
                {
                    sockBuckets.Add(sock, new int[]{1, 0});
                }
            }

            foreach (var key in sockBuckets.Keys)
            {
                var pairs = sockBuckets[key][0] / 2;
                var singles = ((sockBuckets[key][0] % 2) != 0) ? 1 : 0;
                sockBuckets[key][0] = pairs;
                sockBuckets[key][1] = singles;
            }
            
            return sockBuckets;
        }
    }
}