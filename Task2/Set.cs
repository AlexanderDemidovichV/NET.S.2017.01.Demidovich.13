using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Set<T> : Task2.ISet<T>, IEnumerable<T>, IEnumerable, IEquatable<T> where T : class
    {
        private T[] array;

        private readonly IEqualityComparer<T> equalityComparer;

        public int Count { get; }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds an element to the current set and returns a value to indicate if the element was successfully added.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        /// <returns>true if the element is added to the set; false if the element is already in the set.</returns>
        public bool Add(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifies the current set so that it contains all elements that are present in the current set, in the specified collection, or in both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public void UnionWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are also in a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public void IntersectWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current set.
        /// </summary>
        /// <param name="other">The collection of items to remove from the set.</param>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are present either in the current set or in the specified collection, but not both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether a set is a subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>
        ///   <c>true</c> if the current set is a subset of other; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the current set is a superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>
        ///   <c>true</c> if the current set is a superset of other; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the current set is a proper (strict) superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>
        ///   <c>true</c> if the current set is a proper superset of other; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether a set is a subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>
        ///   <c>true</c> if the current set is a subset of other; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the current set overlaps with the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>
        ///     <c>true</c> if the current set and other share at least one common element; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the current set and the specified collection contain the same elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>
        /// <c>true</c> if the current set is equal to other; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public bool SetEquals(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes all items.
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the set contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate.</param>
        /// <returns>
        ///   <c>true</c> if item is found in the ICollection<T>; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the Set.
        /// </summary>
        /// <param name="item">The object to remove.</param>
        /// <returns>
        /// true if item was successfully removed from the Set; otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">item is null.</exception>
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public bool Equals(T other)
        {
            throw new NotImplementedException();
        }
    }
}
