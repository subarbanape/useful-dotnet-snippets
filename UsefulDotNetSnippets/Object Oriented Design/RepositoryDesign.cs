using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvinun.UsefulDotNetSnippets.RepositoryDesign
{
    // Abstraction and Encapsulation
    public class Demo
    {
        public static void Run()
        {
            // In this example, we abstract the methods save and retreive 
            // inside the Repository interface. Define SQL and SharePoint classes 
            // and implement the concrete methods to implement the respective behavior.
            // This achieves Inheritance

            // SQL way
            IRepositoryConnection connection = new SQLRepositoryConnection();
            IRepository repository = new SQLRepository(connection);
            // private retrieve method is encapsulated and hidden from the public
            // this achieves Encapsulation
            AppData data = repository.Retrieve(1);
            // modify the data... and call save
            repository.Save(data);

            // SharePoint way
            connection = new SharePointRepositoryConnection();
            repository = new SharePointRepository(connection);
            data = repository.Retrieve(1);
            repository.Save(data);
        }
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
        private SPListItem  itemToFind;

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
