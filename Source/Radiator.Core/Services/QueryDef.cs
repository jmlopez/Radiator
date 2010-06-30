using System;

namespace Radiator.Core.Services
{
    public class QueryDef
    {
        public QueryDef(Type entityType, string url)
        {
            
        }

        public Type EntityType { get; private set; }
        public string Url { get; private set; }
    }
}