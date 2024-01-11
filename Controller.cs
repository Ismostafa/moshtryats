using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Security.Cryptography;
using System.IO;

namespace Moshtarayat
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

        /// <summary>
        /// ///////////////////////////////////////Views///////////////////////////////////////////
        /// </summary>
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        public DataTable SelectAllOrders()
        {

            string StoredProcedureName = StoredProcedures.RetrieveOrders;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable SelectAllBonusPointsClients()
        {

            string StoredProcedureName = StoredProcedures.RetrieveBonusPoints;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable SelectProblems()
        {

            string StoredProcedureName = StoredProcedures.RetrieveProblems;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable SelectAllPOH()
        {

            string StoredProcedureName = StoredProcedures.RetrievePOH;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable SelectAllClients()
        {

            string StoredProcedureName = StoredProcedures.RetrieveClients;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable SelectAllVendors()
        {

            string StoredProcedureName = StoredProcedures.RetrieveVendors;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable SelectAllDA()
        {

            string StoredProcedureName = StoredProcedures.RetrieveDelieveryAgents;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable GetallSPH()
        {

            string StoredProcedureName = StoredProcedures.GetallSPH;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
         
        public DataTable OngoingOrders()
        {

            string StoredProcedureName = StoredProcedures.OngoingOrders;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable Assignments()
        {
            string StoredProcedureName = StoredProcedures.Assignments;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

       public int  SavePH(int ida,int ido,int idph,int idc)
        {
            string StoredProcedureName = StoredProcedures.SavePH;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IDA", ida);
            Parameters.Add("@IDO", ido);
            Parameters.Add("@IDPH", idph);
            Parameters.Add("@IDC", idc);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable getclientwhoorder(int ido,int idc)
        {
            string StoredProcedureName = StoredProcedures.getclientwhoorder;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@IDO", ido);
            Parameters.Add("@IDC", idc);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable getassignOrderandPH(int ido,int idph)
        {
            string StoredProcedureName = StoredProcedures.getassignOrderandPH;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ID", ido);
            Parameters.Add("@ID2", idph);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public int AddPOH(string Cl_ID , string Or_state  , int Or_ID , string Adm_ID )
        {

            string StoredProcedureName = StoredProcedures.AddPurchaseHistory;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Clx_ID", Cl_ID);
            Parameters.Add("@Orx_state",Or_state);
            Parameters.Add("@Orx_ID", Or_ID);
            Parameters.Add("@Admx_ID", Adm_ID);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }



        /// <summary>
        /// /////////////////////////////////Admin/////////////////////////////////////////////////////////////
        /// </summary>
        /// 
        public int Redeemed(int Cl_ID, int R_ID)
        {
            String StoredProcedureName = StoredProcedures.Redeemed;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Cl_ID", Cl_ID);
            Parameters.Add("@R_ID", R_ID);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

            public DataTable LoadPasswordA(string username, string Password)
        {
            String StoredProcedureName = StoredProcedures.LoadpasswordA;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@username",username);
            Parameters.Add("@Password_out", Password);
            return dbMan.ExecuteReader(StoredProcedureName,Parameters);
        }
        public int ChangePasswordA(string Username , string OrigPassword , string NewPassword )
        {
            String StoredProcedureName = StoredProcedures.ChangePasswordA;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Username", Username);
            Parameters.Add("@OrigPassword", OrigPassword);
            Parameters.Add("@NewPassword", NewPassword);
            return dbMan.ExecuteNonQuery1(StoredProcedureName, Parameters,"@a");
        }
        public int CheckClienthasBonusPoints(string Cl_ID)
        {
            String StoredProcedureName = StoredProcedures.CheckClienthasBonusP;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Cl_ID", Cl_ID);
           
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public int SolveClientProblem(int P_num)
        {
            String StoredProcedureName = StoredProcedures.SolveClientProblem;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Pnumber", P_num);

            return dbMan.ExecuteNonQuery1(StoredProcedureName, Parameters, "@a");
        }
        public int DAisbusy(int daid)
        {
            String StoredProcedureName = StoredProcedures.DAisbusy;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ID", daid);
            return dbMan.ExecuteNonQuery1(StoredProcedureName, Parameters, "@a");
        }
        public int Assignordertoda(int idd,int ida,int ido)
        {
            String StoredProcedureName = StoredProcedures.Assignordertoda;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@DAID",idd);
            Parameters.Add("@AdmID", ida);
            Parameters.Add("@ORID ", ido);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable getAdmin(string role, int id)
        {
            String StoredProcedureName = StoredProcedures.getAdmin;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Role", role);
            Parameters.Add("@ID", id);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        
            public DataTable getorderongoing( int id)
        {
            String StoredProcedureName = StoredProcedures.getorderongoing;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ID", id);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
       public DataTable CheckUsernameAdmin(string username)
        {
            string StoredProcedureName = StoredProcedures.CheckUsernameAdmin;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Username", username);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        /// <summary>
        /// /////////////////////////////////Vendor/////////////////////////////////////////////////////////////
        /// </summary>

        /*  public DataTable Select_it()
          {

              string StoredProcedureName = StoredProcedures.RetrieveProblems;
              return dbMan.ExecuteReader(StoredProcedureName, null);
          }*/



        public DataTable LoadPasswordV(string username, string Password)
        {
            String StoredProcedureName = StoredProcedures.LoadpasswordV;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@username", username);
            Parameters.Add("@Password_out", Password);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        /* public DataTable S()
         {

             string StoredProcedureName = StoredProcedures.Retrieve_v_id;
             return dbMan.ExecuteReader(StoredProcedureName, null);
         }*/


        public DataTable getvendor_id(string name4, int id4)
        {
            string StoredProcedureName = StoredProcedures.getv_id;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@name2", name4);
            Parameters.Add("@ID", id4);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }



        public DataTable SelectAllitems(int id)
        {

            string StoredProcedureName = StoredProcedures.Retrieve_items;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@VendorID", id);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);

        }
        //ShowVendorItems_invendor_id
        public DataTable SelectAllitems1(int id)
        {

            string StoredProcedureName = StoredProcedures.Retrieve_items1;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@VendorID", id);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);

        }

        //CREATE PROCEDURE [addnewitem] @VendorID int, @It_Name1 varchar(50), @Quantity1 int, @Cost_Item1 float

        public int Additem(int v_ID, string It_Name11, int q, float cost)
        {

            string StoredProcedureName = StoredProcedures.addnewitem1;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@VendorID", v_ID);
            Parameters.Add("@It_Name1", It_Name11);
            Parameters.Add("@Quantity1", q);
            Parameters.Add("@Cost_Item1", cost);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        //CREATE PROCEDURE [UpdateItem] @cost float, @itemID1 int, @nameitem varchar(50), @q int

        public int Updateitem(float cost, int itemid, string nameitem1, int q)
        {

            string StoredProcedureName = StoredProcedures.updateitem1;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@cost", cost);
            Parameters.Add("@itemID1", itemid);
            Parameters.Add("@nameitem", nameitem1);
            Parameters.Add("@q", q);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }




        /*      CREATE PROCEDURE[dbo].[Deleteitem] @itemID int
      AS
      DELETE
      FROM Items
      Where Item_ID=@itemID
      GO*/


        public int deleteitem(int itemid)
        {

            string StoredProcedureName = StoredProcedures.deleteitem1;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@itemID", itemid);

            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }


        ////////////////////////////////
        ///
        public DataTable GetVendorlocations1(int V_ID)
        {

            string StoredProcedureName = StoredProcedures.GetVendorlocations1;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@V_id", V_ID);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public int insertVendorlocations1(int V_ID, string V_loc)
        {

            string StoredProcedureName = StoredProcedures.insertVendorlocations1;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@V_id", V_ID);
            Parameters.Add("@V_loc", V_loc);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public int DeleteVendorlocations1(int V_ID, string V_loc)
        {

            string StoredProcedureName = StoredProcedures.DeleteVendorlocations1;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@V_id", V_ID);
            Parameters.Add("@V_loc", V_loc);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public int UpdateVendorlocations1(int V_ID, string V_loc, string nV_loc)
        {

            string StoredProcedureName = StoredProcedures.UpdateVendorlocations1;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@V_id", V_ID);
            Parameters.Add("@V_loc", V_loc);
            Parameters.Add("@V_locnew", nV_loc);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        /// <summary>
        /// /////////////////////////////////Delievery Agent/////////////////////////////////////////////////////////////
        /// </summary>
        public DataTable LoadPassDA(string username, string Password)
        {
            String StoredProcedureName = StoredProcedures.LoadPassDA;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@username", username);
            Parameters.Add("@Password_out", Password);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public int ChangePassDA(string Username, string OrigPassword, string NewPassword)
        {
            String StoredProcedureName = StoredProcedures.ChangePassDA;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Username", Username);
            Parameters.Add("@OrigPassword", OrigPassword);
            Parameters.Add("@NewPassword", NewPassword);
            return dbMan.ExecuteNonQuery1(StoredProcedureName, Parameters, "@a");
        }

        public DataTable RetrieveDA_ID(string username, string password, int DA_ID)
        {
            String StoredProcedureName = StoredProcedures.RetrieveDA_ID;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Username", username);
            Parameters.Add("@Password", password);
            Parameters.Add("@ID", DA_ID);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable GetAssignedOrdersDA(int id)
        {
            string StoredProcedureName = StoredProcedures.GetAssignedOrdersDA;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@DA_id", id);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int OrderCollected(int or_id)
        {
            String StoredProcedureName = StoredProcedures.OrderCollected;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@orderID ", or_id);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int PHistoryCollected(int or_id)
        {
            String StoredProcedureName = StoredProcedures.OrderCollected;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@orderID ", or_id);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int SetBusyDA(int da_id)
        {
            String StoredProcedureName = StoredProcedures.SetBusyDA;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@DAid", da_id);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int ClearBusyDA(int da_id)
        {
            String StoredProcedureName = StoredProcedures.ClearBusyDA;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@DAid", da_id);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int OrderDelivered(int or_id)
        {
            String StoredProcedureName = StoredProcedures.OrderDelivered;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@orderID ", or_id);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int PHistoryDelivered(int or_id)
        {
            String StoredProcedureName = StoredProcedures.PHistoryDelivered;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@orderID ", or_id);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int InsertOrderDelivered(int or_id, int da_id)
        {
            String StoredProcedureName = StoredProcedures.InsertOrderDelivered;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Orid ", or_id);
            Parameters.Add("@DAid ", da_id);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable GetClientID(int orderid, int clientid)
        {
            String StoredProcedureName = StoredProcedures.GetClientID;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@or_id", orderid);
            Parameters.Add("@cl_ID", clientid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int InsertBonusPointsDA(int clientid)
        {
            String StoredProcedureName = StoredProcedures.InsertBonusPointsDA;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@cl_id ", clientid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        /// <summary>
        /// /////////////////////////////////Client/////////////////////////////////////////////////////////////
        /// </summary>
        /// 

        public int AddClient(string fname, string lname, string password)
        {
            string StoredProcedureName = StoredProcedures.AddClient;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@fname", fname);
            Parameters.Add("@lname", lname);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable CheckUsernameClient(string username)
        {
            String StoredProcedureName = StoredProcedures.CheckUsernameClient;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Username", username);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable LoadPasswordClient(string username, string passwordout)
        {
            String StoredProcedureName = StoredProcedures.LoadPasswordClient;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Username", username);
            Parameters.Add("@Password_OUT", passwordout);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable CheckPasswordClient(string username, string password)
        {
            String StoredProcedureName = StoredProcedures.CheckPasswordClient;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Username", username);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable LoadClientUsername(string fname, string lname, string password)
        {
            String StoredProcedureName = StoredProcedures.LoadClientUsername;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Fname", fname);
            Parameters.Add("@Lname", lname);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable ChangePasswordClient(string username, string origpassword, string newpassword)
        {
            String StoredProcedureName = StoredProcedures.ChangePasswordClient;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Username", username);
            Parameters.Add("@OrigPassword", origpassword);
            Parameters.Add("@NewPassword", newpassword);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int AddBonusPoints(int clientid, int gainedpoints)
        {
            String StoredProcedureName = StoredProcedures.AddBonusPoints;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ClientID", clientid);
            Parameters.Add("@GainedPoints", gainedpoints);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable GetallVendors()
        {
            String StoredProcedureName = StoredProcedures.GetallVendors;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable SelectAllVendorCuisines()
        {
            String StoredProcedureName = StoredProcedures.SelectAllVendorCuisines;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable SelectCuisineVendors(string cuisine)
        {
            String StoredProcedureName = StoredProcedures.SelectCuisineVendors;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Cuisine", cuisine);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable ShowVendorItems(int vendorid)
        {
            String StoredProcedureName = StoredProcedures.ShowVendorItems;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@VendorID", vendorid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int InitiateOrder(int clientid)
        {
            String StoredProcedureName = StoredProcedures.InitiateOrder;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ClientID", clientid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable SelectClientIDFromUsername(string username)
        {
            String StoredProcedureName = StoredProcedures.SelectClientIDFromUsername;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Username", username);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int ClientAddItems(int orderid, int itemid)
        {
            String StoredProcedureName = StoredProcedures.ClientAddItems;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@OrderID", orderid);
            Parameters.Add("@ItemID", itemid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable GetonGoingOrderID(int clientid)
        {
            String StoredProcedureName = StoredProcedures.GetonGoingOrderID;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ClientID", clientid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable ViewOrderItems(int orderid)
        {
            String StoredProcedureName = StoredProcedures.ViewOrderItems;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@OrderID", orderid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable SelectClientStreets(int clientid)
        {
            String StoredProcedureName = StoredProcedures.SelectClientStreets;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ClientID", clientid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable SelectCityBasedOnStreet(string street)
        {
            String StoredProcedureName = StoredProcedures.SelectCityBasedOnStreet;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Street", street);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable GetOrderTotalCost(int orderid)
        {
            String StoredProcedureName = StoredProcedures.GetOrderTotalCost;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@OrderID", orderid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int UpdatePaymentInfo(string method, int clientid)
        {
            String StoredProcedureName = StoredProcedures.UpdatePaymentInfo;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Info", method);
            Parameters.Add("@ClientID", clientid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int InsertNewAddress(string city, string street, int clientid)
        {
            String StoredProcedureName = StoredProcedures.InsertNewAddress;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@City", city);
            Parameters.Add("@Street", street);
            Parameters.Add("@ClientID", clientid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int DeleteAddress(string street, int clientid)
        {
            String StoredProcedureName = StoredProcedures.DeleteAddress;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Street", street);
            Parameters.Add("@ClientID", clientid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable GetAllClientAddresses(int clientid)
        {
            String StoredProcedureName = StoredProcedures.GetAllClientAddresses;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ClientID", clientid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable GetallRewards()
        {
            String StoredProcedureName = StoredProcedures.GetallRewards;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable GetClientTotalBonusPoints(int clientid)
        {
            String StoredProcedureName = StoredProcedures.GetClientTotalBonusPoints;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ClientID", clientid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable GetRewardEquivalentPoints(int rewardid)
        {
            String StoredProcedureName = StoredProcedures.GetRewardEquivalentPoints;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@RewardID", rewardid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable CheckRewardPoints_AgainstClientTotalBP(int clientid, int rewardid)
        {
            String StoredProcedureName = StoredProcedures.CheckRewardPoints_AgainstClientTotalBP;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ClientID", clientid);
            Parameters.Add("@RewardID", rewardid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int ConfirmOrderIntoCO(int clientid, int orderid)
        {
            String StoredProcedureName = StoredProcedures.ConfirmOrderIntoCO;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ClientID", clientid);
            Parameters.Add("@OrderID", orderid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int ConfirmOrderIntoPH(int orderid, int adminid, float ordercost)
        {
            String StoredProcedureName = StoredProcedures.ConfirmOrderIntoPH;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@OrderID", orderid);
            Parameters.Add("@AdminID", adminid);
            Parameters.Add("@OrderCost", ordercost);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int UpdateOrderTime(int orderid)
        {
            String StoredProcedureName = StoredProcedures.UpdateOrderTime;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@OrderID", orderid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int UpdateOrderStatus(int clientid)
        {
            String StoredProcedureName = StoredProcedures.UpdateOrderStatus;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ClientID", clientid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int ReturnOrder(int orderid, int clientid)
        {
            String StoredProcedureName = StoredProcedures.ReturnOrder;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ord_ID", orderid);
            Parameters.Add("@Cl_ID", clientid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int ReportProblem(string comment, int orderid, int clientid)
        {
            String StoredProcedureName = StoredProcedures.ReportProblem;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@comment", comment);
            Parameters.Add("@Or_ID", orderid);
            Parameters.Add("@Cl_ID", clientid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public int Give_NRx(int rating, int orderid, int clientid)
        {
            String StoredProcedureName = StoredProcedures.Give_NRx;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@comment", rating);
            Parameters.Add("@Or_ID", orderid);
            Parameters.Add("@Cl_ID", clientid);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public DataTable ordersdelievertoclient(int cl_ID)
        {
            String StoredProcedureName = StoredProcedures.ordersdelievertoclient;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Cl_ID", cl_ID);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable VandI()
        {
            String StoredProcedureName = StoredProcedures.Vendorsanditems;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }
        public DataTable IDfromfname (string fname)
        {
            String StoredProcedureName = StoredProcedures.IDfromfname;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@fname", fname);
            return dbMan.ExecuteReader(StoredProcedureName,Parameters);
        }
        public int ChangePasswordV(string Username, string OrigPassword, string NewPassword)
        {
            String StoredProcedureName = StoredProcedures.ChangePasswordV;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Username", Username);
            Parameters.Add("@OrigPassword", OrigPassword);
            Parameters.Add("@NewPassword", NewPassword);
            return dbMan.ExecuteNonQuery1(StoredProcedureName, Parameters, "@a");
        }
    }
}
