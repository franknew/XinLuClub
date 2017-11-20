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
            if (!Session.Current.ContainsKey(mapperKey)) Session.Current[mapperKey] = null;
            ISqlMapper mapper = Session.Current[mapperKey] as ISqlMapper;
            if (mapper == null) mapper = Mapper.Instance();
            return mapper;
        }

        public static ISqlMapper StoreMapper()
        {
            var mapper = Mapper.Instance();
            Session.Current[mapperKey] = mapper;
            return mapper;
        }

        public static void BeginTrans()
        {
            //开启事务
            ISqlMapper mapper = GetMapper();
            mapper.BeginTransaction();
            Session.Current[beginTransKey] = true;
        }

        public static void CommitTrans()
        {
            ISqlMapper mapper = GetMapper();
            bool beginTrans = false;
            if (Session.Current.ContainsKey(beginTransKey)) beginTrans = (bool)Session.Current[beginTransKey];
            if (mapper != null && beginTrans) mapper.CommitTransaction();
            Session.Current[beginTransKey] = false;
        }

        public static void RollBackTrans()
        {
            ISqlMapper mapper = GetMapper();
            bool beginTrans = false;
            if (Session.Current.ContainsKey(beginTransKey)) beginTrans = (bool)Session.Current[beginTransKey];
            if (mapper != null && beginTrans) mapper.RollBackTransaction();
            Session.Current[beginTransKey] = false;
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
