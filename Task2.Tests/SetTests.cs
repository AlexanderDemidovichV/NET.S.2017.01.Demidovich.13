using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2.Tests
{
    public class SetTests
    {

        [TestCase(new[] {"1", "2", "3"}, "4")]
        public void Add(string[] array, string element)
        {
            Set<string> set = new Set<string>(array);
            set.Add(element);
            Assert.AreEqual(set, new Set<string>(new[] {"1", "2", "3", "4"}));
        }

        [TestCase(new[] { "1", "2", "3", "4", "5" }, "4")]
        public void Remove(string[] array, string element)
        {
            Set<string> set = new Set<string>(array);
            set.Remove(element);
            Assert.AreEqual(set, new Set<string>(new[] { "1", "2", "3", "5" }));
        }

        [TestCase(new[] { "1", "2", "3", "4", "5" }, new[] { "3", "4", "5", "6" })]
        public void Intersect(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            var result = set1.Intersect(set2);
            Assert.AreEqual(result, new Set<string>(new[] { "3", "4", "5" }));
        }

        [TestCase(new[] { "1", "2", "3", "4", "5" }, new[] { "3", "4", "5", "6" })]
        public void Union(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            var result = set1.Union(set2);
            Assert.AreEqual(result, new Set<string>(new[] { "1", "2", "3", "4", "5", "6" }));
        }

    }
}