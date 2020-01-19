using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using EPICCentralDL.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class UniquenessTest
    {
        /// <summary>
        /// Satisfies requirement 4.7.2.1
        /// Satisfies requirement 4.7.2.2
        /// </summary>
        [TestMethod]
        public void Ids_Are_Unique()
        {
            var uniqueIds = new LinqMetaData().Device.Select(x => x.UniqueIdentifier).ToList().Concat(
                new LinqMetaData().Location.Select(x => x.UniqueIdentifier).ToList().Concat(
                    new LinqMetaData().Organization.Select(x => x.UniqueIdentifier).ToList()
                    )
                );
            var idsGrouped = uniqueIds.GroupBy(x => x, (Id, enumerable) => new {Id, Count = enumerable.Count()});
            Assert.IsTrue(!idsGrouped.Any(x => x.Count > 1));
        }
    }
}
