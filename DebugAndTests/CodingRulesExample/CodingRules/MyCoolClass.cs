using System;

namespace CodingRulesExample.CodingRules
{
    public class MyCoolClass
    {
        private readonly string name;
        private readonly IDataAccess dataAccess;


        public MyCoolClass(string name, IDataAccess dataAccessRead)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (dataAccessRead == null)
                throw new ArgumentNullException(nameof(dataAccessRead));

            this.name = name;
            this.dataAccess = dataAccessRead;
        }
    }
}
