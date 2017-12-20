using IBatisNet.DataMapper;
using SOAFramework.Library;
using SOAFramework.Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace XinLuClub.Forum.BLL
{
    public class Common
    {
        const string mapperKey = "__mapper";
        const string beginTransKey = "__begintrans";
        public static ISqlMapper GetMapper()
        {
            if (!ContextFactory.Current.ContainsKey(mapperKey)) ContextFactory.Current[mapperKey] = null;
            ISqlMapper mapper = ContextFactory.Current[mapperKey] as ISqlMapper;
            if (mapper == null) mapper = Mapper.Instance();
            return mapper;
        }

        public static ISqlMapper StoreMapper()
        {
            var mapper = Mapper.Instance();
            ContextFactory.Current[mapperKey] = mapper;
            return mapper;
        }

        public static void BeginTrans()
        {
            //开启事务
            ISqlMapper mapper = GetMapper();
            mapper.BeginTransaction();
            ContextFactory.Current[beginTransKey] = true;
        }

        public static void CommitTrans()
        {
            ISqlMapper mapper = GetMapper();
            bool beginTrans = false;
            if (ContextFactory.Current.ContainsKey(beginTransKey)) beginTrans = (bool)ContextFactory.Current[beginTransKey];
            if (mapper != null && beginTrans) mapper.CommitTransaction();
            ContextFactory.Current[beginTransKey] = false;
        }

        public static void RollBackTrans()
        {
            ISqlMapper mapper = GetMapper();
            bool beginTrans = false;
            if (ContextFactory.Current.ContainsKey(beginTransKey)) beginTrans = (bool)ContextFactory.Current[beginTransKey];
            if (mapper != null && beginTrans) mapper.RollBackTransaction();
            ContextFactory.Current[beginTransKey] = false;
        }

        public static T CreateDao<T, TEntity, TQueryForm, TUpdateForm>() where T: IDao<TEntity, TQueryForm, TUpdateForm>
            where TEntity: IEntity
            where TQueryForm: IQueryForm
            where TUpdateForm: IUpdateForm
        {
            var mapper = GetMapper();
            T t = (T)Activator.CreateInstance(typeof(T), mapper);
            return t;
        }

        public static string GetToken()
        {
            string token = HttpContext.Current.Request.Cookies.Get("__xinluclub_form_token")?.Value;
            //if (string.IsNullOrEmpty(token)) token = HttpContext.Current.Request.Form["token"];
            if (string.IsNullOrEmpty(token)) throw new XinLuClubException(100, "cookie中没有token");
            return token;
        }
    }
}
