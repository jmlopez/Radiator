using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.Practices.ServiceLocation;
using Radiator.Core.Infrastructure;
using Radiator.Core.Services.Settings;

namespace Radiator.Core.Services
{
    public class EntityQuery<TEntity>
    {
        private readonly UrlSettings _settings;
        private readonly StringBuilder _builder;
        private Type _returnType;
        public EntityQuery(UrlSettings settings)
        {
            _settings = settings;
            _builder = new StringBuilder();
            _returnType = typeof (TEntity);

            AddBaseUrl();
        }

        public Type ReturnType
        {
            get
            {
                return _returnType;
            }
        }

        private void AddBaseUrl()
        {
            var baseUrl = _settings.BaseUrl;
            if(baseUrl.EndsWith("/"))
            {
                baseUrl.Substring(0, baseUrl.Length - 1);
            }

            _builder.Append(baseUrl);
            Append(typeof (TEntity).Name + "s"); // TODO -- Plurals?
        }

        private EntityQuery<TEntity> Append(string pattern)
        {
            _builder.Append("/");
            _builder.Append(BreakUpCamelCase(pattern));
            return this;
        }

        public EntityQuery<TEntity> FindAll()
        {
            return this;
        }

        public EntityQuery<TEntity> FindById(string id)
        {
            Append("id:" + id);
            return this;
        }

        public EntityQuery<TEntity> GetProperty<T>(string id, Expression<Func<TEntity, T>> propertyExpression) // dsl closer
        {
            FindById(id);
            var property = (PropertyInfo)propertyExpression.FindProperty();
            _returnType = property.PropertyType;

            if(_returnType.IsGenericType)
            {
                _returnType = _returnType.GetGenericArguments()[0];
            }

            Append(property.Name);
            return this;
        }

        public string BuildUrl()
        {
            return _builder.ToString();
        }

        public static EntityQuery<TEntity> New()
        {
            return ServiceLocator
                .Current
                .GetInstance<EntityQuery<TEntity>>();
        }

        private static string BreakUpCamelCase(string input)
        {
            return input.Substring(0, 1).ToLower() + input.Substring(1);
        }
    }
}