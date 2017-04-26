using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Set<T> : IEnumerable<T>, IEnumerable, IEquatable<Set<T>> where T : class
    {
        #region Private fields

        private List<T> collection;

        private readonly IEqualityComparer<T> equalityComparer;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of elements that are contained in a set.
        /// </summary>
        public int Count => collection.Count;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Set class that is empty and uses the default equality comparer for the set type.
        /// </summary>
        public Set() : this(new List<T>(), EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Set class that uses the default equality comparer for the set type, contains elements copied from the spesified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new set.</param>
        public Set(IEnumerable<T> collection) : this(collection, EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Set class that is empty and uses the specified equality comparer for the set type.
        /// </summary>
        /// <param name="equalityComparer">The IEqualityComparer implementation to use when comparing values in the set, or null to use default EqualityComparer.</param>
        public Set(IEqualityComparer<T> equalityComparer) : this(new List<T>(), equalityComparer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Set class that uses the specified equality comparer for the set type, contains elements copied from the spesified collection.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new set.</param>
        /// <param name="equalityComparer">The IEqualityComparer implementation to use when comparing values in the set, or null to use default EqualityComparer.</param>
        public Set(IEnumerable<T> collection, IEqualityComparer<T> equalityComparer)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException();

            if (ReferenceEquals(equalityComparer, null))
                this.equalityComparer = EqualityComparer<T>.Default;
            else
                this.equalityComparer = equalityComparer;

            this.collection = new List<T>(collection);

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an element to the current set and returns a value to indicate if the element was successfully added.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        /// <returns>true if the element is added to the set; false if the element is already in the set.</returns>
        public bool Add(T item)
        {
            if (collection.Contains(item))
                return false;

            collection.Add(item);
            return true;
        }

        /// <summary>
        /// Modifies the current set so that it contains all elements that are present in the current set, in the specified collection, or in both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public void UnionWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            foreach (var item in other)
            {
                if (!Contains(item))
                    collection.Add(item);
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are also in a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            var newSet = Intersect(this.collection, other);

            collection = newSet.collection;
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current set.
        /// </summary>
        /// <param name="other">The collection of items to remove from the set.</param>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            foreach (var item in other)
            {
                if (Contains(item))
                    collection.Remove(item);
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are present either in the current set or in the specified collection, but not both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            foreach (var item in other)
            {
                if (!Contains(item))
                    collection.Remove(item);
            }
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
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            foreach (var item in this)
            {
                if (!other.Contains(item))
                    return false;
            }
            return true;
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
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            foreach (var item in other)
                if (!this.Contains(item))
                    return false;

            return true;
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
            return this.IsSupersetOf(other) && !this.SetEquals(other);
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
            return this.IsSubsetOf(other) && !this.SetEquals(other);
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
            if (ReferenceEquals(other, null))
                throw new ArgumentNullException(nameof(other));

            if (!this.Any() || !other.Any())
                return true;

            foreach (var item in other)
                if (this.Contains(item))
                    return true;

            return false;
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
            return this.IsSubsetOf(other) && this.IsSupersetOf(other);
        }

        /// <summary>
        /// Removes all items.
        /// </summary>
        public void Clear() => collection.Clear();

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
            return collection.Contains(item, equalityComparer);
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
            return collection.Remove(item);
        }

        /// <summary>
        /// Determines whether the current set and the specified collection contain the same elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>
        /// <c>true</c> if the current set is equal to other; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">other is null.</exception>
        public bool Equals(Set<T> other)
        {
            return this.SetEquals(other);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a Set object.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collection)
                yield return item;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a Set object.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            Set<T> set = obj as Set<T>;

            return Equals(set);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 13;
            foreach (var item in collection)
            {
                hash = hash * 11 + item.GetHashCode();
            }

            return hash;
        }

        #endregion

        #region Public Static

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="lhs">The first set to compare.</param>
        /// <param name="rhs">The second set to compare.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Set<T> lhs, Set<T> rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                return false;

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="lhs">The first set to compare.</param>
        /// <param name="rhs">The second set to compare.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Set<T> lhs, Set<T> rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        /// Returns the collection wich contain all elements that are present in first collection, second collection, or both.
        /// </summary>
        /// <param name="firstSet">The first collection to compare to the other.</param>
        /// <param name="secondSet">The second collection to compare to the other.</param>
        /// <returns></returns>
        public static Set<T> Union(IEnumerable<T> firstSet, IEnumerable<T> secondSet)
        {
            if (firstSet == null)
                throw new ArgumentNullException(nameof(firstSet));
            if (secondSet == null)
                throw new ArgumentNullException(nameof(secondSet));
            if (firstSet == secondSet)
                return new Set<T>(firstSet);

            var newSet = new Set<T>(firstSet);
            newSet.UnionWith(secondSet);

            return newSet;
        }

        /// <summary>
        /// Returns the collection wich contain all elements that are present in first collection, but not in second collection.
        /// </summary>
        /// <param name="firstSet">The collection to compare to the other.</param>
        /// <param name="secondSet">The collection of items to remove from the other.</param>
        /// <returns></returns>
        public static Set<T> Except(IEnumerable<T> firstSet, IEnumerable<T> secondSet)
        {
            if (firstSet == null)
                throw new ArgumentNullException(nameof(firstSet));
            if (secondSet == null)
                throw new ArgumentNullException(nameof(secondSet));
            if (firstSet == secondSet)
                return new Set<T>();

            var newSet = new Set<T>(firstSet);
            newSet.ExceptWith(secondSet);

            return newSet;
        }

        /// <summary>
        /// Returns the collection wich contain only elements that are present in both collections.
        /// </summary>
        /// <param name="firstSet">The first collection to compare to the other.</param>
        /// <param name="secondSet">The second collection to compare to the other.</param>
        /// <returns></returns>
        public static Set<T> Intersect(IEnumerable<T> firstSet, IEnumerable<T> secondSet)
        {
            if (firstSet == null)
                throw new ArgumentNullException(nameof(firstSet));
            if (secondSet == null)
                throw new ArgumentNullException(nameof(secondSet));
            if (firstSet == secondSet)
                return new Set<T>(firstSet);

            var newSet = new Set<T>();
            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                    newSet.Add(item);
            }

            return newSet;
        }

        #endregion

    }
}
