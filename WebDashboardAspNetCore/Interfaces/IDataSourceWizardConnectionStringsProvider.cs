using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Json;
using DevExpress.DataAccess.Web;
using DevExpress.Xpo.DB;

public class MyDataSourceWizardConnectionStringsProvider : IDataSourceWizardConnectionStringsProvider
{
    public Dictionary<string, string> GetConnectionDescriptions()
    {
        Dictionary<string, string> connections = new Dictionary<string, string>();

        // Customize the loaded connections list.  
        connections.Add("jsonUrlConnection", "JSON URL Connection");
        connections.Add("pgSqlConnection", "Postgre SQL Connection");
        connections.Add("nwindConnection", "nwind");
        return connections;
    }

    public DataConnectionParametersBase GetDataConnectionParameters(string name)
    {
        // Return custom connection parameters for the custom connection.
        if (name == "jsonUrlConnection")
        {
            return new JsonSourceConnectionParameters()
            {
                JsonSource = new UriJsonSource(
                    new Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json"))
            };
        }
        else if (name == "pgSqlConnection")
        {
            PostgreSqlConnectionParameters postgreParams = new PostgreSqlConnectionParameters();
            postgreParams.ServerName = "localhost";
            postgreParams.PortNumber = 5432;
            postgreParams.DatabaseName = "devex";
            postgreParams.UserName = "postgres";
            postgreParams.Password = "sudosu";
            return postgreParams;
        } 
        else if (name == "nwindConnection") 
        {
            XmlFileConnectionParameters xmlParams = new XmlFileConnectionParameters();
            xmlParams.FileName = "nwind";
            return new XmlFileConnectionParameters();
        }
        throw new System.Exception("The connection string is undefined.");
    }
}