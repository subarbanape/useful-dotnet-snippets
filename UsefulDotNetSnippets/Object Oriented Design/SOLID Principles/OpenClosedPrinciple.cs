using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambdaDemo.Object_Oriented_Design.SOLID_Principles
{
    public class OpenClosedPrinciple
    {   
        public static void DemoRun()
        {
            // We have defined an interface IRepository
            // And we implement 2 classes SQL and SharePoint 
            // which does serve the common purpose to Save and Retrieve the recods.
            // Observe, with this design, we are making the classes
            // to be extendible but not modifiable. 
            // These classes can be further extended to add more features
            // but need not have to be modified.

            // SQL way
            IRepositoryConnection connection = new SQLRepositoryConnection();
            IRepository repository = new SQLRepository(connection);
            AppData data = repository.Retrieve(1);
            repository.Save(data);

            // SharePoint way
            connection = new SharePointRepositoryConnection();
            repository = new SharePointRepository(connection);
            data = repository.Retrieve(1);
            repository.Save(data);
        }

        public interface IRepositoryConnection
        {
        }

        public interface IRepository
        {
            bool Save(AppData data);
            AppData Retrieve(int key);
        }

        public class AppData
        {
        }

        internal class SharePointRepositoryConnection : IRepositoryConnection
        {
        }

        internal class SQLRepositoryConnection : IRepositoryConnection
        {
        }

        public class SQLRepository : IRepository
        {
            private IRepositoryConnection sqlConnection;

            public SQLRepository(IRepositoryConnection sqlConnection)
            {
                this.sqlConnection = sqlConnection;
            }

            public AppData Retrieve(int key)
            {
                // retrieve data from SQL DB based on the key
                return new AppData();
            }

            public bool Save(AppData data)
            {
                // save data back to SQL DB repository
                return true;
            }
        }

        public class SharePointRepository : IRepository
        {
            private IRepositoryConnection connection;
            private SPListItem itemToFind;

            public SharePointRepository(IRepositoryConnection connection)
            {
                this.connection = connection;
            }

            public AppData Retrieve(int key)
            {
                // retrieve data based from SharePoint Library/List based on the key
                return retrieve(key);
            }

            // retrieve method is encapsulated and hidden fromt the public
            private AppData retrieve(int key)
            {
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name=\"ID\"/><Value Type=\"Integer\">" + key + "</Value></Eq></Where>";
                query.ViewAttributes = "Scope=\"Recursive\"";
                SPListItemCollection items = itemToFind.ParentList.GetItems(query);
                if (items.Count > 0)
                {
                    //foreach (SPListItem item in items)
                    //{
                    //    SPItem result = item.Web.GetItem(item.Url);
                    //    return result;
                    //}
                }
                return new AppData();
            }

            public bool Save(AppData data)
            {
                // save data back to SharePoint Library/List repository
                return true;
            }
        }

        internal class SPListItem
        {
            public SPListItem ParentList { get; internal set; }

            internal SPListItemCollection GetItems(SPQuery query)
            {
                throw new NotImplementedException();
            }
        }

        internal class SPListItemCollection
        {
            public int Count { get; set; }
        }

        internal class SPQuery
        {
            public string Query { get; internal set; }
            public object Folder { get; internal set; }
            public string ViewAttributes { get; internal set; }
        }
    }
}
