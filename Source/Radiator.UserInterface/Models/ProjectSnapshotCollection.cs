using System.Collections;
using System.Collections.Generic;

namespace Radiator.UserInterface.Models
{
    public class ProjectSnapshotCollection : IEnumerable<ProjectSnapshot>
    {
        private readonly IList<ProjectSnapshot> _innerList;

        public ProjectSnapshotCollection()
            : this(new List<ProjectSnapshot>())
        {   
        }

        public ProjectSnapshotCollection(IList<ProjectSnapshot> innerList)
        {
            _innerList = innerList;
        }

        public void Add(ProjectSnapshot snapshot)
        {
            _innerList.Add(snapshot);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<ProjectSnapshot> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}