using BingoX;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CostControlWebApplication.Application.AD
{
    public class ActiveDirectoryOption
    {
        public string LDAPService { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }
    }
    public class ActiveDirectoryService
    {
        private readonly ActiveDirectoryOption option;

        public ActiveDirectoryService(ActiveDirectoryOption option)
        {
            this.option = option;
            this.uid = option.Uid;
            this.pwd = option.Pwd;
        }
        string uid;
        string pwd;
        public bool Login(string uid, string pwd)
        {
            this.uid = uid;
            this.pwd = pwd;
            try
            {
                GetDirectoryObject().RefreshCache();
                return true;
            }
            catch (DirectoryServicesCOMException ex)
            {
                if (ex.ExtendedErrorMessage == "SASL:[GSS-SPNEGO]: NT_STATUS_LOGON_FAILURE") return false;
                throw new LogicException("登录失败", ex);
            }
            catch (Exception ex)
            {

                throw new LogicException("登录失败", ex);
            }


        }
        //"LDAP://huarchi.tooo.top:12648", "dason", "Dason16659716",
        private DirectoryEntry GetDirectoryObject()
        {
            DirectoryEntry entry = null;
            try
            {
                entry = new DirectoryEntry(option.LDAPService, uid, pwd, AuthenticationTypes.Secure);

            }
            catch (Exception ex)
            {
            }
            return entry;
        }

        DirectoryEntry GetDirectoryEntry(string path)
        {
            DirectoryEntry entry = new DirectoryEntry(option.LDAPService + "/" + path, uid, pwd, AuthenticationTypes.Secure);
            return entry;
        }
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public bool UserExists(string UserName)
        {
            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=user) (cn=" + UserName + "))";
            SearchResultCollection results = deSearch.FindAll();
            if (results.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 根据用户公共名称取得用户的 对象
        /// </summary>
        /// <param name="commonName">用户公共名称</param>
        /// <returns>如果找到该用户则返回用户的对象,否则返回 null</returns>
        public System.Security.Claims.ClaimsIdentity GetUserInfoDirectoryEntry(string commonName)
        {
            var de = GetDirectoryObject();
            var deSearch = new DirectorySearcher(de);
            deSearch.Filter = "(&(&(objectCategory=person)(objectClass=user))(cn=" + commonName.Replace("\\", "") + "))";
            deSearch.SearchScope = SearchScope.Subtree;
            try
            {

                var result = deSearch.FindOne();
                de = result.GetDirectoryEntry();

                var memberof = GetProperty(de, "memberof");
                var displayname = GetProperty(de, "Displayname").ToString();
                var description = GetProperty(de, "description").ToString();
                var id = de.Guid;
                //     var claims = de.Properties.Cast<PropertyValueCollection>().Select(n => new System.Security.Claims.Claim(n.PropertyName, GetProperty(n).ToString())).ToList();
                ClaimsIdentity identity = new ClaimsIdentity("Basic", "Name", "Role");
                identity.AddClaim(new Claim("Name", de.Username));
                identity.AddClaim(new Claim("Displayname", displayname?? description));
                identity.AddClaim(new Claim("ID", de.Guid.ToString()));
                identity.AddClaim(new Claim("Role", memberof.ToString().Contains("costmanager") ? "Admin" : "Staffer"));
                //memberOf 所在用户组
                de.Close();
                return identity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 根据用户公共名称取得用户的 对象
        /// </summary>
        /// <param name="commonName">用户公共名称</param>
        /// <returns>如果找到该用户则返回用户的对象,否则返回 null</returns>
        public DataTable GetGroupUser(string commonName)
        {
            var de = GetDirectoryObject();
            DirectoryEntry group = null;
            var deSearch = new DirectorySearcher(de);
            deSearch.Filter = "(&(objectClass=group)(cn=" + commonName.Replace("\\", "") + "))";
            deSearch.PropertiesToLoad.Add("memberof");

            try
            {
                var result = deSearch.FindOne();
                group = result.GetDirectoryEntry();
                group.RefreshCache();
                var pcoll = group.Properties;
                var n = pcoll["member"];
                if (n.Count == 0) return null;
                DataTable tbUser = new DataTable("Users");
                tbUser.Columns.Add("ID", typeof(Guid));
                tbUser.Columns.Add("GroupName");
                tbUser.Columns.Add("samaccountname");
                tbUser.Columns.Add("UserName");
                tbUser.Columns.Add("DisplayName");
                tbUser.Columns.Add("EMailAddress");
                tbUser.Columns.Add("primaryGroupID");
                tbUser.Columns.Add("description");
                foreach (string property in pcoll["member"])
                {
                    var deUser = GetDirectoryEntry(property);
                    deUser.RefreshCache();
                    DataRow rwUser = tbUser.NewRow();
                    rwUser["ID"] = deUser.Guid;
                    rwUser["GroupName"] = commonName;
                    rwUser["samaccountname"] = GetProperty(deUser, "samaccountname");
                    rwUser["UserName"] = GetProperty(deUser, "cn");
                    rwUser["DisplayName"] = GetProperty(deUser, "DisplayName");
                    rwUser["EMailAddress"] = GetProperty(deUser, "mail");
                    rwUser["primaryGroupID"] = GetProperty(deUser, "primaryGroupID");
                    rwUser["description"] = GetProperty(deUser, "description");
                    tbUser.Rows.Add(rwUser);
                    deUser.Close();

                }
                //}

                return tbUser;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (group != null) group.Close();
                if (de != null) de.Close();
            }
        }
        object GetProperty(DirectoryEntry entry, string propertyName)
        {
            if (!entry.Properties.Contains(propertyName)) return null;
            return GetProperty(entry.Properties[propertyName]);


        }
        object GetProperty(PropertyValueCollection property)
        {
            if (property == null) return string.Empty;

            if (property.Value is string)
            {
                return property.Value.ToString();
            }
            if (property.Value is DateTime)
            {
                return property.Value.ToString();
            }
            else if (property.Value is object[])
            {
                var value = property.Value as object[];
                return string.Join(" ", value);
            }

            return property.Value;

        }
    }
}
