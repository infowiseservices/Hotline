using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Net;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Threading;

namespace IW_Hotline
{
    public partial class ThisAddIn
    {
        public static string username = "";
        public static string password = "";
        public static string loginText = "";
        public static string baseUrlString = "https://support.infowise.dk/";
        public static string accountId = "";
        public static string accountKey = "";
        public static string orgId = "";
        public static string customerId = "";
        public static string customerName = "";
        public static string issueText = "";
        public static string issueId = "";
        public static string issueKey = "";
        public static bool restResult = false;
        public static string resultText = "";
        public static hotlineForm HLF;
        public static loginForm LF;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }
        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new HotlineRibbon();
        }
        public static void runCreation(string accId, string accKey, string custId, string description) {
            try
            {
                accountId = accId.ToString();
                accountKey = accKey.ToString();
                issueText = description.ToString();

                if (accountId != "" || accountKey != "")
                {
                    if (issueText != "")
                    {
                        if (restResult)
                        {
                            resultText = "Opretter Opgaven!";
                            HLF.resultLbl.Text = resultText;
                            getOrganizationKey(custId);
                            if (restResult)
                            {
                                getCustomerKey(customerName);
                                if (restResult)
                                {
                                    createIssue();
                                    if (restResult)
                                    {
                                        createTimesheet();
                                        if (restResult)
                                        {
                                            Thread.Sleep(3000);
                                            closeIssue();
                                            if (restResult)
                                            {
                                                resultText = "Success!";
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        resultText = "Der er ikke skrevet en tekst!";
                        HLF.resultLbl.Text = resultText;
                    }
                }
                else
                {
                    resultText = "Der er ikke valgt en Account!";
                    HLF.resultLbl.Text = resultText;
                }
            }
            catch(Exception e) {
                resultText = e.Message;
                HLF.resultLbl.Text = resultText;
            }

                
        }
        public static void getPopup(string text = "")
        {
            try
            {
                if (username != "" || password != "")
                {
                    HLF = new hotlineForm();
                    HLF.Show();
                }
                else
                {
                    loginText = text;
                    LF = new loginForm();
                    LF.Show();
                }
            }
            catch { 
            
            }
        }

        public static string RunQuery(string resource, JObject data = null, string method = "GET", bool exp = false)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                Uri baseUrl = new Uri(baseUrlString);
                var client = new RestClient(baseUrl);

                Method theMethod = Method.GET;

                switch (method)
                {
                    case "GET":
                        theMethod = Method.GET;
                        break;
                    case "POST":
                        theMethod = Method.POST;
                        break;
                    case "PUT":
                        theMethod = Method.PUT;
                        break;
                    case "DELETE":
                        theMethod = Method.DELETE;
                        break;
                }
                IRestRequest request = new RestRequest(new Uri($"{client.BaseUrl}{resource}"), theMethod);
                string creds = GetEncodedCredentials();
                if (creds != "")
                {
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("Authorization", "Basic " + creds);
                    if (exp)
                    {
                        request.AddHeader("X-ExperimentalApi", "opt-in");
                    }
                    if (data != null)
                    {
                        request.AddParameter("application/json", data, ParameterType.RequestBody);

                    }
                    IRestResponse response = client.Execute(request);

                    string result = "";
                    if (response.IsSuccessful)
                    {
                        result = response.Content;
                        restResult = true;
                        return result;
                    }
                    else
                    {
                        restResult = false;
                        return "";
                    }
                }
                else {
                    restResult = false;
                    return "";
                }
                
            }
            catch (Exception e)
            {
                resultText = e.Message;
                HLF.resultLbl.Text = resultText;

            }
            restResult = false;
            return "";

        }
        public static List<projectData> GetProjectsSearch(string query)
        {
            List<projectData> pData = new List<projectData>();
            try
            {
                query = HttpUtility.UrlEncode(query);
                string result = RunQuery("rest/tempo-accounts/1/account/search?limit=500&query=" + query, null, "GET", true);
                TempoAccountSearch dataObj = new TempoAccountSearch();
                
                if (restResult)
                {
                    dataObj = JsonConvert.DeserializeObject<TempoAccountSearch>(result);
                    foreach (TempoAccount account in dataObj.accounts)
                    {
                        pData.Add(new projectData() { name = account.name, accountId = account.id, accountKey = account.key, customerId = Int32.Parse(account.customer.key) });
                    }
                    return pData;
                }
                else
                {
                    return pData;
                }
            }
            catch (Exception e)
            {
                resultText = e.Message;
                HLF.resultLbl.Text = resultText;
                restResult = false;

            }
            return pData;
        }
        public static void createIssue()
        {
            try
            {
                if (customerId != "")
                {
                    JObject jObjectbody = new JObject();
                    string jString = @"{""fields"":
                                    {""project"":
                                        {""id"": ""10000""},
                                         ""summary"": ""HOTLINE - " + customerName + @""",
                                         ""description"": """ + issueText + @""",
                                         ""issuetype"": {""id"": ""10001""},
                                         ""reporter"":{""name"": """ + username + @"""},
                                         ""assignee"":{""name"": """ + username + @"""},
                                         ""customfield_10221"": """ + accountId + @""",
                                         ""customfield_10002"": [" + orgId + @"],
                                         ""customfield_10300"": [{""key"":""" + customerId + @"""}]
                                    }
                                }";
                    jObjectbody = JObject.Parse(jString);

                    string result = RunQuery("rest/api/2/issue", jObjectbody, "POST", true);
                    if (restResult)
                    {
                        createIssueRespons dataObj = new createIssueRespons();
                        dataObj = JsonConvert.DeserializeObject<createIssueRespons>(result);

                        issueId = dataObj.id.ToString();
                        issueKey = dataObj.key.ToString();
                    }
                    else
                    {
                        resultText = "Kunne ikke oprette opgaven!";
                    }
                }
                else
                {
                    resultText = "Mangler Kunde Id!";
                    restResult = false;
                }
            }
            catch (Exception e)
            {
                resultText = e.Message;
                HLF.resultLbl.Text = resultText;
                restResult = false;
            }

        }
        public static void createTimesheet() {
            try
            {
                if (issueId != "")
                {
                    DateTime dateTime = DateTime.Today;
                    string date = dateTime.ToString("yyyy-MM-dd");
                    string jString = @"{""attributes"": 
                                    {""_Account_"": 
                                        {""name"": ""Account"",
                                         ""workAttributeId"": 1,
                                         ""value"": """ + accountKey + @"""},
                                     ""_Art_"": 
                                        {""name"": ""Art"", 
                                         ""workAttributeId"": 2,
                                         ""value"": ""23""}},
                                ""billableSeconds"": 900,
                                ""worker"": """ + username + @""",
                                ""comment"": """ + issueText + @""",
                                ""started"": """ + date + @""",
                                ""timeSpentSeconds"": 900,
                                ""originTaskId"": """ + issueId + @""",  
                                ""remainingEstimate"": null,  
                                ""endDate"": null}";
                    JObject jObjectbody = new JObject();
                    jObjectbody = JObject.Parse(jString);

                    string result = RunQuery("rest/tempo-timesheets/4/worklogs/", jObjectbody, "POST", true);
                    if (!restResult)
                    {
                        resultText = "Kunne ikke registrer tid";
                    }
                }
                else
                {
                    resultText = "Mangler opgave Id!";
                    restResult = false;
                }
            }
            catch (Exception e)
            {
                resultText = e.Message;
                HLF.resultLbl.Text = resultText;
                restResult = false;
            }
        }
        public static void getOrganizationKey(string query) {
            try
            {
                var startValue = 0;
                bool dataPresent = true;
                if (query != "")
                {
                    while (orgId == "" && dataPresent)
                    {
                        string result = RunQuery("rest/servicedeskapi/organization?start=" + startValue, null, "GET", true);
                        ServicediskOrganizations dataObj = new ServicediskOrganizations();
                        dataObj = JsonConvert.DeserializeObject<ServicediskOrganizations>(result);
                        if (dataObj.values.Count() == 0)
                        {
                            dataPresent = false;
                        }
                        foreach (ServicediskOrganizationsValues values in dataObj.values)
                        {
                            if (values.name.Substring(0, 4) == query)
                            {
                                orgId = values.id.ToString();
                                customerName = values.name.Substring(7);
                            }
                        }
                        if (orgId == "")
                        {
                            startValue += 50;
                        }
                    }
                    if (orgId == "" && dataPresent)
                    {
                        resultText = "Kunne ikke finde Organisation";
                        restResult = false;
                    }
                }
                else
                {
                    resultText = "Mangler Kunde ID";
                    restResult = false;
                }
            }
            catch (Exception e)
            {
                resultText = e.Message;
                HLF.resultLbl.Text = resultText;
            }
        }
        public static void closeIssue() {
            try
            {
                if (issueKey != "")
                {
                    string jString = @"{""id"": ""761"",""additionalComment"": { ""body"":""" + issueText + @"""}}";
                    JObject jObjectbody = new JObject();
                    jObjectbody = JObject.Parse(jString);
                    string result = RunQuery("rest/servicedeskapi/request/" + issueKey + "/transition", jObjectbody, "POST", true);
                    if (!restResult)
                    {
                        resultText = "Kunne ikke lukke Opgaven";
                    }
                }
                else
                {
                    resultText = "Mangler Opgave Nøgle!";
                    restResult = false;
                }
            }
            catch (Exception e)
            {
                resultText = e.Message;
                HLF.resultLbl.Text = resultText;
                restResult = false;
            }

        }
        public static void getCustomerKey(string query) {
            try
            {
                if (query != "")
                {
                    string jString = @"{""query"": """ + query + @""",""currentProject"": ""10000"",""currentReporter"": """ + username + @"""}";
                    JObject jObjectbody = new JObject();
                    jObjectbody = JObject.Parse(jString);
                    string result = RunQuery("rest/insight/1.0/customfield/default/10500/objects", jObjectbody, "POST", true);
                    if (restResult)
                    {
                        InsightCustomer dataObj = new InsightCustomer();
                        dataObj = JsonConvert.DeserializeObject<InsightCustomer>(result);
                        customerId = dataObj.objects[0].objectkey.ToString();
                    }
                    else
                    {
                        resultText = "Kunne ikke finde Kunden";
                    }
                }
                else
                {
                    resultText = "Mangler Kunde Navn!";
                    restResult = false;
                }
            }
            catch (Exception e)
            {
                resultText = e.Message;
                HLF.resultLbl.Text = resultText;
                restResult = false;
            }


        }
        public static void ResetGlobals() {
            accountId = "";
            accountKey = "";
            orgId = "";
            customerId = "";
            customerName = "";
            issueText = "";
            issueId = "";
            issueKey = "";
            restResult = false;
            resultText = "";
    }
        private static string GetEncodedCredentials()
        {
            string cred = "";
            try
            {
                string mergedCredentials = string.Format("{0}:{1}", username, password);
                byte[] byteCredentials = UTF8Encoding.UTF8.GetBytes(mergedCredentials);
                cred = Convert.ToBase64String(byteCredentials);
            }
            catch (Exception e)
            {
                resultText = e.Message;
                HLF.resultLbl.Text = resultText;
                restResult = false;
            }
            return cred;
          
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
    public class projectData
    {
        public string name { get; set; }
        public int accountId { get; set; }
        public string accountKey { get; set; }
        public int customerId { get; set; }
    }
    public class TempoAccount
    {
        public int id { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public TempoCustomer customer { get; set; }
    }
    public class TempoAccountSearch
    {
        public int pageSize { get; set; }
        public int currentPage { get; set; }
        public int totalRecords { get; set; }
        public int totalPages { get; set; }
        public string tqlQuery { get; set; }
        public string query { get; set; }
        public List<TempoAccount> accounts { get; set; }
    }

    public class TempoCustomer
    {
        public int id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
    }
    public class ServicediskOrganizations
    {
        public List<ServicediskOrganizationsValues> values { get; set; }
    }
    public class ServicediskOrganizationsValues
    {
        public int id { get; set; }
        public string name { get; set; }
        public string links { get; set; }
    }
    public class InsightCustomer
    {
        public List<InsightCustomerId> objects { get; set; }
    }
    public class InsightCustomerId
    {
        public int id { get; set; }
        public string objectkey { get; set; }
    }    
    public class createIssueRespons
    {
        public int id { get; set; }
        public string key { get; set; }
    }
}
