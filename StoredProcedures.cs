using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;

namespace Moshtarayat
{
    public class StoredProcedures
    {
        public static string Redeemed = "Redeemed";
        public static string RetrieveOrders = "GetallOrders";
        public static string RetrieveBonusPoints = "GetBonusPointsClients";
        public static string RetrieveProblems = "GetallProblems";
        public static string RetrievePOH= "GetPOH";
        public static string RetrieveClients = "GetallClients";
        public static string RetrieveVendors = "GetallVendors";
        public static string RetrieveDelieveryAgents = "GetallDelieveryAgents";
        public static string LoadpasswordA = "LoadPasswordAdmin";
        public static string ChangePasswordA = "ChangePasswordAdmin";
        public static string SolveClientProblem = "SolveProblem";
        public static string SavePH="SavePurchaseHistory";
        public static string GetallSPH = "getallSPH";
        public static string AddPurchaseHistory= "PutPOH";
        public static string CheckClienthasBonusP = "CheckClienthasBonusPoints";
        public static string AddBonusPtoClient = "AddBonusPoints";
        public static string OngoingOrders = "getallongoingorders";
        public static string Assignments = "getallAssignments";
        public static string DAisbusy = "CheckDAisbusy";
        public static string Assignordertoda = "AddAssignment";
        public static string getAdmin = "GetAdminID";
        public static string getorderongoing = "GetOrderOngoihg_ID";
        public static string getclientwhoorder = "GetClientID";
        public static string getassignOrderandPH= "GetOrderAssignedtoDA_And_PurchaseHistory_IDs";
        public static string CheckUsernameAdmin = "CheckUsernameAdmin";
        public static string LoadpasswordV = "LoadPasswordvendor";
        public static string Retrieve_items = "ShowVendorItems_invendor";
        public static string getv_id = "GetVendorID";
        public static string addnewitem1 = "addnewitem";
        public static string updateitem1 = "UpdateItem";
        public static string Retrieve_items1 = "ShowVendorItems_invendor_id";
        public static string deleteitem1 = "Deleteitem";
        public static string GetVendorlocations1 = "GetVendorlocations";
        public static string insertVendorlocations1 = "insertVendorlocations";
        public static string UpdateVendorlocations1 = "UpdateVendorlocations";
        public static string DeleteVendorlocations1 = "DeleteVendorlocations";
        public static string CheckUserDA = "CheckUsernameDA";
        public static string LoadPassDA = "LoadPasswordDA";
        public static string CheckPassDA = "CheckPasswordDA";
        public static string ChangePassDA = "ChangePasswordDA";
        public static string RetrieveDA_ID = "GetDA_ID";
        public static string OrderCollected = "Order_OrderStateCollected";
        public static string PHistoryCollected = "PHistory_OrderStateCollected";
        public static string OrderDelivered = "Order_OrderStateDelivered";
        public static string PHistoryDelivered = "PHistory_OrderStateDelivered";
        public static string SetBusyDA = "SetBusyDA";
        public static string ClearBusyDA = "ClearBusyDA";
        public static string InsertOrderDelivered = "InsertOrderDelivered";
        public static string GetClientID = "GetClient_ID";
        public static string InsertBonusPointsDA = "InsertIntoBonusPoints_DA";
        public static string GetAssignedOrdersDA = "GetAssignedOrdersDA";
        public static string CheckUsernameClient = "CheckUsernameClient";//done
        public static string LoadPasswordClient = "LoadPasswordClient";//done
        public static string CheckPasswordClient = "CheckPasswordClient";//done
        public static string ChangePasswordClient = "ChangePasswordClient";
        public static string AddClient = "AddClient";//done
        public static string GetallRewards = "GetallRewards";//done
        public static string AddBonusPoints = "AddBonusPoints";
        public static string GetClientTotalBonusPoints = "GetClientTotalBonusPoints";//done
        public static string GetRewardEquivalentPoints = "GetRewardEquivalentPoints";//done
        public static string CheckRewardPoints_AgainstClientTotalBP = "CheckRewardPoints_AgainstClientTotalBP";//done
        public static string GetAllClientAddresses = "GetAllClientAddresses";//done
        public static string InsertNewAddress = "InsertNewAddress";//done
        public static string DeleteAddress = "DeleteAddress";//done
        public static string UpdatePaymentInfo = "UpdatePaymentInfo";//done
        public static string ViewPaymentInfo = "ViewPaymentInfo";//unused
        public static string SelectAllVendorCuisines = "SelectAllVendorCuisines";//done
        public static string SelectCuisineVendors = "SelectCuisineVendors";//done
        public static string ShowVendorItems = "ShowVendorItems";//done
        public static string InitiateOrder = "InitiateOrder";//done
        public static string ClientAddItems = "ClientAddItems";//done
        public static string ViewOrderItems = "ViewOrderItems";//done
        public static string SelectClientStreets = "SelectClientStreets";//done
        public static string SelectCityBasedOnStreet = "SelectCityBasedOnStreet";//done
        public static string ConfirmOrderIntoCO = "ConfirmOrderIntoCO";//done
        public static string ConfirmOrderIntoPH = "ConfirmOrderIntoPH";//done
        public static string GetOrderTotalCost = "GetOrderTotalCost";//done
        public static string UpdateOrderPrice = "UpdateOrderPrice";//not used
        public static string UpdateOrderTime = "UpdateOrderTime";//--
        public static string LoadClientUsername = "LoadClientUsername";//done
        public static string GetallVendors = "GetallVendors";//done
        public static string SelectClientIDFromUsername = "SelectClientIDFromUsername";//done
        public static string GetonGoingOrderID = "GetonGoingOrderID";//done
        public static string UpdateOrderStatus = "UpdateOrderStatus";
        public static string ReturnOrder = "ReturnOrder";
        public static string ReportProblem = "ReportProblem";
        public static string Give_NRx = "Give_NRx";
        public static string ordersdelievertoclient = "ordersdelievertoclient";
        public static string Vendorsanditems = "Vendorsanditems";
        public static String IDfromfname = "IDfromfname";
        public static string ChangePasswordV = "ChangePasswordVector";

    }
}
