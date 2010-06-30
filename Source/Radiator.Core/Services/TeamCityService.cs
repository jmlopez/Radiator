using System.Collections;
using System.Collections.Generic;
using Radiator.Infrastructure;

namespace Radiator.Core.Services
{
    public class TeamCityService : ITeamCityService
    {
        private readonly IJsonService _jsonService;
        private readonly IHttpService _httpService;
        public TeamCityService(IJsonService jsonService, IHttpService httpService)
        {
            _jsonService = jsonService;
            _httpService = httpService;
        }

        public TEntity GetEntity<TEntity>(EntityQuery<TEntity> query)
        {
            return _jsonService.Deserialize<TEntity>(GetResponse(query));
        }

        public IEnumerable GetList<TEntity>(EntityQuery<TEntity> query)
        {
            var returnType = typeof (List<>).MakeGenericType(query.ReturnType);
            var response = GetResponse(query);
            if(response.IndexOf("[") != -1)
            {
                response = response.Substring(response.IndexOf("["));
                response = response.TrimEnd('}');
            }

            return _jsonService.Deserialize(response, returnType) as IEnumerable;
        }

        private string GetResponse<TEntity>(EntityQuery<TEntity> query)
        {
            return _httpService.DownloadString(query.BuildUrl());
        }
    }
}