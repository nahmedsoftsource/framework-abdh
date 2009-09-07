using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class PermissionType : Common.DomainTypeCode
  {
    public String ActionName { get; set; }

    public int? PermissionTypeGroupID { get; set; }
    public PermissionTypeGroup PermissionTypeGroup { get; set; }

    public int? OrderStatusID { get; set; }
    public OrderStatus OrderStatus { get; set; }

    public int? OrderTypeID { get; set; }
    public OrderType OrderType { get; set; }

    /// <summary>
    /// permission for party. For ex: SP, OP, Billing Company
    /// </summary>
    public int? PartyType { get; set; }

    public struct PARTY_TYPES
    {
      public const int ServiceProvider = 1;
      public const int Insurance = 2;
      public const int BillingCompany = 3;
      public const int OrderingParty = 4;
      public const int Employee = 5;
      public const int Partner = 6;
      public const int Supplier = 7;
    }

    /// <summary>
    /// permission of section
    /// </summary>
    public int? SectionPermission { get; set; }


    private static IDictionary<int, PermissionType> _permissionTypes;
    public static IDictionary<int, PermissionType> PermissionTypes
    {
      get
      {
        if (_permissionTypes == null)
        {
          _permissionTypes = new Dictionary<int, PermissionType>();
        }
        return PermissionType._permissionTypes;
      }

      set
      {
        PermissionType._permissionTypes = value;
      }
    }

    public static IDictionary<int, PermissionType> BuiltinPermissionTypes = new Dictionary<int, PermissionType> { 
      {Codes.Order_View_OrderingParty, new PermissionType{ID = Codes.Order_View_OrderingParty, Name = "Order_View_OrderingParty"}},
      {Codes.Order_View_ServiceProvider, new PermissionType{ID = Codes.Order_View_ServiceProvider, Name = "Order_View_ServiceProvider"}},
      {Codes.Order_Edit_OrderingParty, new PermissionType{ID = Codes.Order_Edit_OrderingParty, Name = "Order_Edit_OrderingParty"}},
    };


    public static PermissionType GetByID(int PermissionTypeID)
    {
      if (PermissionTypes.ContainsKey(PermissionTypeID))
      {
        return PermissionTypes[PermissionTypeID];
      }

      // check for built in permission
      if (BuiltinPermissionTypes.ContainsKey(PermissionTypeID))
      {
        return BuiltinPermissionTypes[PermissionTypeID];
      }

      throw new Exception("Not found ID " + PermissionTypeID);
    }

    #region Order Detail
    public const int PersonProfile_Edit = 1000;

    public const int OrderStatus_Create = 0;
    public const int OrderStatus_View = 1;

    public const int OrderInformation_Update = 2;
    public const int OrderInformation_View = 3;

    public const int RelatedOrder_Create = 4;
    public const int RelatedOrder_View = 5;

    public const int OrderingParty_Update = 6;
    public const int OrderingParty_View = 7;

    public const int OrderingPartyMailingInstruction_Update = 8;
    public const int OrderingPartyMailingInstruction_View = 9;

    public const int AgentAgencyInformation_Update = 10;
    public const int AgentAgencyInformation_View = 11;

    public const int PartnerInformation_Update = 12;
    public const int PartnerInformation_View = 13;

    public const int InsuranceInformation_Update = 14;
    public const int InsuranceInformation_View = 15;

    public const int SMMMailing_Update = 16;
    public const int SMMMailing_View = 17;

    public const int OrderLab_Update = 18;
    public const int OrderLab_View = 19;

    public const int ApplicantProfile_Update = 20;
    public const int ApplicantProfile_View = 21;

    public const int ApplicantContactInformation_Update = 22;
    public const int ApplicantContactInformation_View = 23;

    public const int ApplicantSchedule_Update = 24;
    public const int ApplicantSchedule_View = 25;

    public const int OrderAssignmentStatus_Update = 26;
    public const int OrderAssignmentStatus_View = 27;

    public const int OrderAssignmentFee_Update = 28;
    public const int OrderAssignmentFee_View = 29;

    public const int OrderAssignmentKit_Update = 30;
    public const int OrderAssignmenKit_View = 31;

    public const int OrderDocument_Update = 32;
    public const int OrderDocument_View = 33;

    public const int OrderRating_Update = 34;
    public const int OrderRating_View = 35;

    public const int EvenLog_Update = 36;
    public const int EvenLog_View = 37;

    public const int OrderRequirement_Update = 38;
    public const int OrderRequirement_View = 39;

    public const int OrderBilling_Update = 40;
    public const int OrderBilling_View = 41;

    public const int OrderFinance_Update = 42;
    public const int OrderFinance_View = 43;

    public const int OrderOfficeNote_Create = 44;
    public const int OrderOfficeNote_View = 45;

    public const int OrderQuestionAndAnswer_Create = 46;
    public const int OrderQuestionAndAnswer_View = 47;

    public const int OrderAssignmentInstruction_Update = 48;
    public const int OrderAssignmentInstruction_View = 49;

    public const int OrderAssignmentPaperworkInformation_Update = 50;
    public const int OrderAssignmentPaperworkInformation_View = 51;

    public const int OrderAssignmentPaperwork_Create = 52;
    public const int OrderAssignmentPaperwork_View = 53;

    public const int OrderAssignmentPaperworkStatus_Create = 54;
    public const int OrderAssignmentPaperworkStatus_View = 55;

    public const int Order_View = 56;

    public const int OrderAssignment_Assign = 57;
    #endregion

    #region Service Provider Party Profile
    public const int ServiceProvider_PartyProfile_Create = 58;
    public const int ServiceProvider_PartyProfile_Update = 59;
    public const int ServiceProvider_PartyProfile_View = 60;
    #endregion

    #region Service Provider Profile
    public const int ServiceProvider_Profile_Update = 61;
    public const int ServiceProvider_Profile_View = 62;
    #endregion

    #region Service Provider Fee Profile
    public const int ServiceProvider_FeeProfile_Create = 63;
    public const int ServiceProvider_FeeProfile_Update = 64;
    public const int ServiceProvider_FeeProfile_View = 65;
    #endregion

    #region Service Provider Schedule Profile
    public const int ServiceProvider_ScheduleProfile_Create = 66;
    public const int ServiceProvider_ScheduleProfile_Update = 67;
    public const int ServiceProvider_ScheduleProfile_View = 68;
    #endregion

    #region Service Provider Area Profile
    public const int ServiceProvider_AreaProfile_Create = 69;
    public const int ServiceProvider_AreaProfile_Update = 70;
    public const int ServiceProvider_AreaProfile_View = 71;
    #endregion

    #region Service Provider Billing Approval Profile
    //public const int ServiceProvider_BillingApprovalProfile_Create = 72;
    public const int ServiceProvider_BillingApprovalProfile_Update = 73;
    public const int ServiceProvider_BillingApprovalProfile_View = 74;
    #endregion

    #region Service Provider Black List Profile
    public const int ServiceProvider_BlackListProfile_Create = 75;
    public const int ServiceProvider_BlackListProfile_Update = 76;
    public const int ServiceProvider_BlackListProfile_View = 77;
    #endregion

    #region Service Provider User Profile
    public const int ServiceProvider_UserProfile_Create = 78;
    public const int ServiceProvider_UserProfile_Update = 79;
    public const int ServiceProvider_UserProfile_View = 80;
    #endregion

    #region Service Provider Credentialing Profile
    public const int ServiceProvider_CredentialingProfile_Create = 81;
    public const int ServiceProvider_CredentialingProfile_Update = 82;
    public const int ServiceProvider_CredentialingProfile_View = 83;
    #endregion

    #region Service Provider Post Office Note Profile
    public const int ServiceProvider_PostOfficeNoteProfile_Create = 86;
    public const int ServiceProvider_PostOfficeNoteProfile_Update = 87;
    public const int ServiceProvider_PostOfficeNoteProfile_View = 88;
    #endregion

    #region Service Provider Party Contact Profile
    public const int ServiceProvider_PartyContactProfile_Create = 89;
    public const int ServiceProvider_PartyContactProfile_Update = 90;
    public const int ServiceProvider_PartyContactProfile_View = 91;
    #endregion

    //Insurance and Billing Company
    #region Insurance and Billing Company

    #region  Party Profile
    public const int Insurance_PartyProfile_Create = 300;
    public const int Insurance_PartyProfile_Update = 301;
    public const int Insurance_PartyProfile_View = 302;
    #endregion

    #region  Contact Info Email Address
    public const int Insurance_PartyContactEmailAddressProfile_Create = 303;
    public const int Insurance_PartyContactEmailAddressProfile_Update = 304;
    public const int Insurance_PartyContactEmailAddressProfile_View = 305;
    #endregion

    #region  Profile
    public const int Insurance_Profile_Create = 306;
    public const int Insurance_Profile_Update = 307;
    public const int Insurance_Profile_View = 308;
    #endregion

    #region  Labs
    public const int Insurance_LabsProfile_Create = 309;
    public const int Insurance_LabsProfile_Update = 310;
    public const int Insurance_LabsProfile_View = 311;
    #endregion

    #region  Forms
    public const int Insurance_FormsProfile_Create = 312;
    public const int Insurance_FormsProfile_Update = 313;
    public const int Insurance_FormsProfile_View = 314;
    #endregion

    #region  Requirement
    public const int Insurance_RequirementProfile_Create = 315;
    public const int Insurance_RequirementProfile_Update = 316;
    public const int Insurance_RequirementProfile_View = 317;
    #endregion

    #region  Billing
    public const int Insurance_BillingProfile_Create = 318;
    public const int Insurance_BillingProfile_Update = 319;
    public const int Insurance_BillingProfile_View = 320;
    #endregion

    #region  Product Type
    public const int Insurance_ProductTypeProfile_Create = 321;
    public const int Insurance_ProductTypeProfile_Update = 322;
    public const int Insurance_ProductTypeProfile_View = 323;
    #endregion

    #region  Mailing
    public const int Insurance_MailingProfile_Create = 324;
    public const int Insurance_MailingProfile_Update = 325;
    public const int Insurance_MailingProfile_View = 326;
    #endregion

    #region  Locations
    public const int Insurance_LocationsProfile_Create = 327;
    public const int Insurance_LocationsProfile_Update = 328;
    public const int Insurance_LocationsProfile_View = 329;
    #endregion

    #region Post Office Note
    public const int Insurance_PostOfficeNoteProfile_Create = 330;
    public const int Insurance_PostOfficeNoteProfile_Update = 331;
    public const int Insurance_PostOfficeNoteProfile_View = 332;
    #endregion

    #region Requirement Condition and Chart Generator    
    public const int Insurance_RequirementCondionChart_Update = 334;
    public const int Insurance_RequirementCondionChart_View = 335;
    #endregion

    #region Requirement Code
    public const int Insurance_RequirementCodeProfile_Create = 336;
    public const int Insurance_RequirementCodeProfile_Update = 337;
    public const int Insurance_RequirementCodeProfile_View = 338;
    #endregion

    //Billing      

    #region  Profile
    public const int BillingCompany_Profile_Update = 340;
    public const int BillingCompany_Profile_View = 341;
    #endregion
   
    #region  Pricing Surcharges
    public const int Insurance_PricingSurchargesProfile_Create = 342;
    public const int Insurance_PricingSurchargesProfile_Update = 343;
    public const int Insurance_PricingSurchargesProfile_View = 344;
    #endregion

    #region  Contact Info Email Address
    public const int BillingCompany_PartyContactEmailAddressProfile_Create = 345;
    public const int BillingCompany_PartyContactEmailAddressProfile_Update = 346;
    public const int BillingCompany_PartyContactEmailAddressProfile_View = 347;
    #endregion

    #region  Post office note
    public const int BillingCompany_PostOfficeNote_Create = 348;
    public const int BillingCompany_PostOfficeNote_Update = 349;
    public const int BillingCompany_PostOfficeNote_View = 350;
    #endregion

    #endregion
    //end

    //begin Accountant
    #region Accountant

    #region Invoice
    public const int Accountant_Invoice_Create = 700;
    public const int Accountant_Invoice_Update = 701;
    public const int Accountant_Invoice_View = 702;
    #endregion

    #region Receivable
    //public const int Accountant_Receivable_Create = 703;
    //public const int Accountant_Receivable_Update = 704;
    //public const int Accountant_Receivable_View = 705;
    #endregion

    #region Data Transfer
    public const int Accountant_DataTransfer_Create = 706;
    public const int Accountant_DataTransfer_Update = 707;
    public const int Accountant_DataTransfer_View = 708;
    #endregion

    #region Payable
    public const int Accountant_Payable_Create = 709;
    public const int Accountant_Payable_Update = 710;
    public const int Accountant_Payable_View = 711;
    #endregion

    #region Payment
    public const int Accountant_Payment_Create = 712;
    public const int Accountant_Payment_Update = 713;
    public const int Accountant_Payment_View = 714;
    #endregion

    #region Statement
    public const int Accountant_Statement_Create = 715;
    public const int Accountant_Statement_Update = 716;
    public const int Accountant_Statement_View = 717;
    #endregion

    #region Re all
    public const int Accountant_ReALL_Create = 718;
    public const int Accountant_ReALL_Update = 719;
    public const int Accountant_ReALL_View = 720;
    #endregion

    #region Approval Wrire off, Adjustment
    //public const int Accountant_ApprovalWriteAdjustment_Create = 721;
    //public const int Accountant_ApprovalWriteAdjustment_Update = 722;
    //public const int Accountant_ApprovalWriteAdjustment_View = 723;
    #endregion

    #region Adjustment
    public const int Accountant_Adjustment_Create = 724;
    public const int Accountant_Adjustment_Update = 725;
    public const int Accountant_Adjustment_View = 726;
    #endregion

    #endregion
    //end

    #region Ordering Party / Party Profile
    public const int OrderingParty_PartyProfile_Create = 400;
    public const int OrderingParty_PartyProfile_Update = 401;
    public const int OrderingParty_PartyProfile_View = 402;
    #endregion

    #region Ordering Party / Party Contact Information
    public const int OrderingParty_PartyContactInformation_Create = 403;
    public const int OrderingParty_PartyContactInformation_Update = 404;
    public const int OrderingParty_PartyContactInformation_View = 405;
    #endregion

    #region Ordering Party / Agent Contact
    public const int OrderingParty_AgentContact_Create = 406;
    public const int OrderingParty_AgentContact_Update = 407;
    public const int OrderingParty_AgentContact_View = 408;
    #endregion

    #region Ordering Party / Agency Management
    public const int OrderingParty_AgencyManagement_Create = 409;
    public const int OrderingParty_AgencyManagement_Update = 410;
    public const int OrderingParty_AgencyManagement_View = 411;
    #endregion

    #region Ordering Party / Mailing List
    public const int OrderingParty_MailingList_Create = 412;
    public const int OrderingParty_MailingList_Update = 413;
    public const int OrderingParty_MailingList_View = 414;
    #endregion

    #region Ordering Party / Insurance List
    public const int OrderingParty_InsuranceList_Create = 415;
    public const int OrderingParty_InsuranceList_Update = 416;
    public const int OrderingParty_InsuranceList_View = 417;
    #endregion

    #region Ordering Party / Order Management
    public const int OrderingParty_OrderManagement_Create = 418;
    public const int OrderingParty_OrderManagement_Update = 419;
    public const int OrderingParty_OrderManagement_View = 420;
    #endregion

    #region Ordering Party / Question Answer
    public const int OrderingParty_QuestionAnswer_Create = 421;
    public const int OrderingParty_QuestionAnswer_Update = 422;
    public const int OrderingParty_QuestionAnswer_View = 423;
    #endregion

    /*#region Ordering Party / OP Member
    public const int OrderingParty_OPMember_Create = 424;
    public const int OrderingParty_OPMember_Update = 425;
    public const int OrderingParty_OPMember_View = 426;
    #endregion*/

    /*#region Ordering Party / User Account
    public const int OrderingParty_UserAccount_Create = 427;
    public const int OrderingParty_UserAccount_Update = 428;
    public const int OrderingParty_UserAccount_View = 429;
    #endregion*/

    #region Ordering Party / Office Note
    public const int OrderingParty_OfficeNote_Create = 430;
    public const int OrderingParty_OfficeNote_Update = 431;
    public const int OrderingParty_OfficeNote_View = 432;
    #endregion

    #region Ordering Party / General info
    public const int OrderingParty_GeneralInfo_Update = 433;
    public const int OrderingParty_GeneralInfo_View = 434;
    #endregion

    #region Employee Management / Management
    public const int EmployeeManagement_Management_Create = 500;
    public const int EmployeeManagement_Management_Update = 501;
    public const int EmployeeManagement_Management_View = 502;
    #endregion

    #region Employee Management / Permission
    public const int EmployeeManagement_Permission_Create = 503;
    public const int EmployeeManagement_Permission_Update = 504;
    public const int EmployeeManagement_Permission_View = 505;
    #endregion

    #region Employee Management / User Role
    public const int EmployeeManagement_UserRole_Create = 506;
    public const int EmployeeManagement_UserRole_Update = 507;
    public const int EmployeeManagement_UserRole_View = 508;
    #endregion

    #region Employee Management / Office Note
    public const int EmployeeManagement_OfficeNote_Create = 509;
    public const int EmployeeManagement_OfficeNote_Update = 510;
    public const int EmployeeManagement_OfficeNote_View = 511;
    #endregion

    #region Inventory / Item
    public const int Inventory_Item_Create = 600;
    public const int Inventory_Item_Update = 601;
    public const int Inventory_Item_View = 602;
    #endregion

    #region Inventory / Supply Order
    public const int Inventory_SupplyOrder_Create = 603;
    public const int Inventory_SupplyOrder_Update = 604;
    public const int Inventory_SupplyOrder_View = 605;
    #endregion

    #region Inventory / Sales Order
    public const int Inventory_SalesOrder_Create = 606;
    public const int Inventory_SalesOrder_Update = 607;
    public const int Inventory_SalesOrder_View = 608;
    #endregion

    #region Inventory / Purchase Order
    public const int Inventory_PurchaseOrder_Create = 609;
    public const int Inventory_PurchaseOrder_Update = 610;
    public const int Inventory_PurchaseOrder_View = 611;
    #endregion

    #region Inventory / Packing List
    public const int Inventory_PackingList_Create = 612;
    public const int Inventory_PackingList_Update = 613;
    public const int Inventory_PackingList_View = 614;
    #endregion

    #region Inventory / Receive
    public const int Inventory_Receive_Create = 615;
    public const int Inventory_Receive_Update = 616;
    public const int Inventory_Receive_View = 617;
    #endregion

    #region Inventory / Shipping
    public const int Inventory_Shipping_Create = 618;
    public const int Inventory_Shipping_Update = 619;
    public const int Inventory_Shipping_View = 620;
    #endregion

    #region Inventory / Supplier
    public const int Inventory_Supplier_Create = 621;
    public const int Inventory_Supplier_Update = 622;
    public const int Inventory_Supplier_View = 623;
    #endregion

    #region Inventory / Supplier
    public const int Inventory_PartyProfileSupplier_Create = 624;
    public const int Inventory_PartyProfileSupplier_Update = 625;
    public const int Inventory_PartyProfileSupplier_View = 626;
    #endregion

    #region Inventory / Supplier
    public const int Inventory_PartyContactEmailAddressSupplier_Create = 627;
    public const int Inventory_PartyContactEmailAddressSupplier_Update = 628;
    public const int Inventory_PartyContactEmailAddressSupplier_View = 629;
    #endregion

    #region Inventory / Supplier
    public const int Inventory_PostOfficeNoteSupplier_Create = 630;
    public const int Inventory_PostOfficeNoteSupplier_Update = 631;
    public const int Inventory_PostOfficeNoteSupplier_View = 632;

    #region Office Note
    public const int OfficeNote_Create = 1000;
    public const int OfficeNote_Update = 1001;
    public const int OfficeNote_View = 1002;
    #endregion

    #region Party Profile
    public const int PartyProfile_Create = 1003;
    public const int PartyProfile_Update = 1004;
    public const int PartyProfile_View = 1005;
    #endregion

    #region Party Contact Info
    public const int PartyContactInfo_Create = 1006;
    public const int PartyContactInfo_Update = 1007;
    public const int PartyContactInfo_View = 1008;
    #endregion

    #region Partner

    #region Party Profile
    public const int Partner_PartyProfile_Create = 800;
    public const int Partner_PartyProfile_Update = 801;
    public const int Partner_PartyProfile_View = 802;
    #endregion

    #region Contact Information
    public const int Partner_ContactInfoProfile_Create = 803;
    public const int Partner_ContactInfoProfile_Update = 804;
    public const int Partner_ContactInfoProfile_View = 805;
    #endregion

    #region Post Office Note
    public const int Partner_PostOfficeNote_Create = 806;
    public const int Partner_PostOfficeNote_Update = 807;
    public const int Partner_PostOfficeNote_View = 808;
    #endregion

    #region Applicant SNN/DOB
    public const int Aplicant_SNNDOB_Update = 900;
    public const int Aplicant_SNNDOB_View = 94;
    #endregion

    #region Place Order
    public const int PlaceOrder = 902;
    public const int SearchOrder = 903;
    #endregion
    #endregion

    public struct Codes
    {
      //public const int None = 0;
      public const int PlaceOrder = 1;
      //public const int UpdateOrder = 2;
      //public const int ViewOfficeNotes = 4;

      #region Order Status
      public const int OrderStatus_Create_IfNew = 5;
      public const int OrderStatus_Create_IfProcessing = 6;
      public const int OrderStatus_Create_IfCompleted = 7;
      public const int OrderStatus_Create_IfVerified = 8;
      public const int OrderStatus_Create_IfClosed = 9;
      public const int OrderStatus_Create_IfOnHold = 10;
      public const int OrderStatus_Create_IfCanceled = 11;

      public const int OrderStatus_View = 12;
      #endregion

      #region Order Information
      public const int OrderInformation_Update_IfNew = 19;
      public const int OrderInformation_Update_IfProcessing = 20;
      public const int OrderInformation_Update_IfCompleted_Paramed = 21;
      public const int OrderInformation_Update_IfCompleted_Direct = 22;
      public const int OrderInformation_Update_IfVerified = 23;
      public const int OrderInformation_Update_IfClosed = 24;
      public const int OrderInformation_Update_IfOnHold = 25;
      public const int OrderInformation_Update_IfCanceled = 26;

      public const int OrderInformation_View = 27;
      #endregion

      #region Related Order
      public const int RelatedOrder_Create_IfNew = 28;
      public const int RelatedOrder_Create_IfProcessing = 29;
      public const int RelatedOrder_Create_IfCompleted = 30;
      public const int RelatedOrder_Create_IfVerified = 31;
      public const int RelatedOrder_Create_IfClosed = 32;
      public const int RelatedOrder_Create_IfOnHold = 33;
      public const int RelatedOrder_Create_IfCanceled = 34;

      public const int RelatedOrder_View = 35;
      #endregion

      #region Ordering Party
      public const int OrderingParty_Update_IfNew = 36;
      public const int OrderingParty_Update_IfProcessing = 37;
      public const int OrderingParty_Update_IfCompleted = 38;
      public const int OrderingParty_Update_IfVerified = 39;
      public const int OrderingParty_Update_IfClosed = 40;
      public const int OrderingParty_Update_IfOnHold = 41;
      public const int OrderingParty_Update_IfCanceled = 42;

      public const int OrderingParty_View = 43;
      #endregion

      #region Ordering Party Mailing Instruction
      public const int OrderingPartyMailingInstruction_Update_IfNew = 44;
      public const int OrderingPartyMailingInstruction_Update_IfProcessing = 45;
      public const int OrderingPartyMailingInstruction_Update_IfCompleted = 46;
      public const int OrderingPartyMailingInstruction_Update_IfVerified = 47;
      public const int OrderingPartyMailingInstruction_Update_IfClosed = 48;
      public const int OrderingPartyMailingInstruction_Update_IfOnHold = 49;
      public const int OrderingPartyMailingInstruction_Update_IfCanceled = 50;

      public const int OrderingPartyMailingInstruction_View = 51;
      #endregion

      #region Agent / Agentcy Information
      public const int AgentAgencyInformation_Update_IfNew = 52;
      public const int AgentAgencyInformation_Update_IfProcessing = 53;
      public const int AgentAgencyInformation_Update_IfCompleted = 54;
      public const int AgentAgencyInformation_Update_IfVerified = 55;
      public const int AgentAgencyInformation_Update_IfClosed = 56;
      public const int AgentAgencyInformation_Update_IfOnHold = 57;
      public const int AgentAgencyInformation_Update_IfCanceled = 58;

      public const int AgentAgencyInformation_View = 59;
      #endregion

      #region Partner Information
      public const int PartnerInformation_View = 60;
      #endregion

      #region Insurance Information
      public const int InsuranceInformation_Update_IfNew = 61;
      public const int InsuranceInformation_Update_IfProcessing = 62;
      public const int InsuranceInformation_Update_IfCompleted = 63;
      public const int InsuranceInformation_Update_IfVerified = 64;
      public const int InsuranceInformation_Update_IfClosed = 65;
      public const int InsuranceInformation_Update_IfOnHold = 66;
      public const int InsuranceInformation_Update_IfCanceled = 67;

      public const int InsuranceInformation_View = 68;
      #endregion

      #region SMM Mailing
      public const int SMMMailing_Update_IfNew = 69;
      public const int SMMMailing_Update_IfProcessing = 70;
      public const int SMMMailing_Update_IfCompleted = 71;
      public const int SMMMailing_Update_IfVerified = 72;
      public const int SMMMailing_Update_IfClosed = 73;
      public const int SMMMailing_Update_IfOnHold = 74;
      public const int SMMMailing_Update_IfCanceled = 75;

      public const int SMMMailing_View = 76;
      #endregion

      #region Ordering Lab
      public const int OrderLab_Update_IfNew = 77;
      public const int OrderLab_Update_IfProcessing = 78;
      public const int OrderLab_Update_IfCompleted = 79;
      public const int OrderLab_Update_IfVerified = 80;
      public const int OrderLab_Update_IfClosed = 81;
      public const int OrderLab_Update_IfOnHold = 82;
      public const int OrderLab_Update_IfCanceled = 83;

      public const int OrderLab_View = 84;
      #endregion

      #region Reminder - TBD

      #endregion

      #region Applicant Profile
      public const int ApplicantProfile_Update_IfNew = 85;
      public const int ApplicantProfile_Update_IfProcessing = 86;
      public const int ApplicantProfile_Update_IfCompleted = 87;
      public const int ApplicantProfile_Update_IfVerified = 88;
      public const int ApplicantProfile_Update_IfClosed = 89;
      public const int ApplicantProfile_Update_IfOnHold = 90;
      public const int ApplicantProfile_Update_IfCanceled = 91;
      public const int ApplicantProfile_Update_SSNAndDOB = 92;

      public const int ApplicantProfile_View = 93;
      #endregion

      #region Applicant Contact Information
      public const int ApplicantContactInformation_Update_IfNew = 95;
      public const int ApplicantContactInformation_Update_IfProcessing = 96;
      public const int ApplicantContactInformation_Update_IfCompleted = 97;
      public const int ApplicantContactInformation_Update_IfVerified = 98;
      public const int ApplicantContactInformation_Update_IfClosed = 99;
      public const int ApplicantContactInformation_Update_IfOnHold = 100;
      public const int ApplicantContactInformation_Update_IfCanceled = 101;

      public const int ApplicantContactInformation_View = 102;
      #endregion

      #region Applicant Schedule
      public const int ApplicantSchedule_Update_IfNew = 103;
      public const int ApplicantSchedule_Update_IfProcessing = 104;
      public const int ApplicantSchedule_Update_IfCompleted = 105;
      public const int ApplicantSchedule_Update_IfVerified = 106;
      public const int ApplicantSchedule_Update_IfClosed = 107;
      public const int ApplicantSchedule_Update_IfOnHold = 108;
      public const int ApplicantSchedule_Update_IfCanceled = 109;

      public const int ApplicantSchedule_View = 110;
      #endregion

      #region Order Assignment Status
      public const int OrderAssignmentStatus_Update_IfNew = 111;
      public const int OrderAssignmentStatus_Update_IfProcessing = 112;
      public const int OrderAssignmentStatus_Update_IfCompleted = 113;
      public const int OrderAssignmentStatus_Update_IfVerified = 114;
      public const int OrderAssignmentStatus_Update_IfClosed = 115;
      public const int OrderAssignmentStatus_Update_IfOnHold = 116;
      public const int OrderAssignmentStatus_Update_IfCanceled = 117;

      public const int OrderAssignmentStatus_View = 118;
      #endregion

      #region Order Assignment Fee
      public const int OrderAssignmentFee_Update_IfNew = 119;
      public const int OrderAssignmentFee_Update_IfProcessing = 120;
      public const int OrderAssignmentFee_Update_IfCompleted = 121;
      public const int OrderAssignmentFee_Update_IfVerified = 122;
      public const int OrderAssignmentFee_Update_IfClosed = 123;
      public const int OrderAssignmentFee_Update_IfOnHold = 124;
      public const int OrderAssignmentFee_Update_IfCanceled = 125;

      public const int OrderAssignmentFee_View = 126;
      #endregion

      #region Order Assignment Kit
      public const int OrderAssignmentKit_Update_IfNew = 127;
      public const int OrderAssignmentKit_Update_IfProcessing = 128;
      public const int OrderAssignmentKit_Update_IfCompleted = 129;
      public const int OrderAssignmentKit_Update_IfVerified = 130;
      public const int OrderAssignmentKit_Update_IfClosed = 131;
      public const int OrderAssignmentKit_Update_IfOnHold = 132;
      public const int OrderAssignmentKit_Update_IfCanceled = 133;

      public const int OrderAssignmentKit_View = 134;
      #endregion

      #region Order Document
      public const int OrderDocument_Create_IfNew = 135;
      public const int OrderDocument_Create_IfProcessing = 136;
      public const int OrderDocument_Create_IfCompleted = 137;
      public const int OrderDocument_Create_IfVerified = 138;
      public const int OrderDocument_Create_IfClosed = 139;
      public const int OrderDocument_Create_IfOnHold = 140;
      public const int OrderDocument_Create_IfCanceled = 141;

      public const int OrderDocument_View = 142;
      #endregion

      #region Order Rating
      public const int OrderRating_Update_IfNew = 143;
      public const int OrderRating_Update_IfProcessing = 144;
      public const int OrderRating_Update_IfCompleted = 145;
      public const int OrderRating_Update_IfVerified = 146;
      public const int OrderRating_Update_IfClosed = 147;
      public const int OrderRating_Update_IfOnHold = 148;
      public const int OrderRating_Update_IfCanceled = 149;

      public const int OrderRating_View = 150;
      #endregion

      #region Even Log
      public const int EvenLog_View = 151;
      #endregion

      #region Order Requirement
      public const int OrderRequirement_Update_IfNew = 152;
      public const int OrderRequirement_Update_IfProcessing = 153;
      public const int OrderRequirement_Update_IfCompleted = 154;
      public const int OrderRequirement_Update_IfVerified = 155;
      public const int OrderRequirement_Update_IfClosed = 156;
      public const int OrderRequirement_Update_IfOnHold = 157;
      public const int OrderRequirement_Update_IfCanceled = 158;

      public const int OrderRequirement_View = 159;
      #endregion

      #region Order Billing
      public const int OrderBilling_Update_IfNew = 160;
      public const int OrderBilling_Update_IfProcessing = 161;
      public const int OrderBilling_Update_IfCompleted = 162;
      public const int OrderBilling_Update_IfVerified = 163;
      public const int OrderBilling_Update_IfClosed = 164;
      public const int OrderBilling_Update_IfOnHold = 165;
      public const int OrderBilling_Update_IfCanceled = 166;

      public const int OrderBilling_View = 167;
      #endregion

      #region Order Finance
      public const int OrderFinance_View = 168;
      #endregion

      #region Order Office Note
      public const int OrderOfficeNote_Create_IfNew = 169;
      public const int OrderOfficeNote_Create_IfProcessing = 170;
      public const int OrderOfficeNote_Create_IfCompleted = 171;
      public const int OrderOfficeNote_Create_IfVerified = 172;
      public const int OrderOfficeNote_Create_IfClosed = 173;
      public const int OrderOfficeNote_Create_IfOnHold = 174;
      public const int OrderOfficeNote_Create_IfCanceled = 175;

      public const int OrderOfficeNote_View = 176;
      #endregion

      #region Order Question and Answer
      public const int OrderQuestionAndAnswer_Create_IfNew = 177;
      public const int OrderQuestionAndAnswer_Create_IfProcessing = 178;
      public const int OrderQuestionAndAnswer_Create_IfCompleted = 179;
      public const int OrderQuestionAndAnswer_Create_IfVerified = 180;
      public const int OrderQuestionAndAnswer_Create_IfClosed = 181;
      public const int OrderQuestionAndAnswer_Create_IfOnHold = 182;
      public const int OrderQuestionAndAnswer_Create_IfCanceled = 183;

      public const int OrderQuestionAndAnswer_View = 184;
      #endregion

      #region Order Assignment Instruction
      public const int OrderAssignmentInstruction_View = 185;
      #endregion

      #region Ordering Assignment Paperwork Information
      public const int OrderAssignmentPaperworkInformation_Update_IfNew = 186;
      public const int OrderAssignmentPaperworkInformation_Update_IfProcessing = 187;
      public const int OrderAssignmentPaperworkInformation_Update_IfCompleted = 188;
      public const int OrderAssignmentPaperworkInformation_Update_IfVerified = 189;
      public const int OrderAssignmentPaperworkInformation_Update_IfClosed = 190;
      public const int OrderAssignmentPaperworkInformation_Update_IfOnHold = 191;
      public const int OrderAssignmentPaperworkInformation_Update_IfCanceled = 192;

      public const int OrderAssignmentPaperworkInformation_View = 193;
      #endregion

      #region Ordering Assignment Paperwork
      public const int OrderAssignmentPaperwork_Create_IfNew = 194;
      public const int OrderAssignmentPaperwork_Create_IfProcessing = 195;
      public const int OrderAssignmentPaperwork_Create_IfCompleted = 196;
      public const int OrderAssignmentPaperwork_Create_IfVerified = 197;
      public const int OrderAssignmentPaperwork_Create_IfClosed = 198;
      public const int OrderAssignmentPaperwork_Create_IfOnHold = 199;
      public const int OrderAssignmentPaperwork_Create_IfCanceled = 200;

      public const int OrderAssignmentPaperwork_View = 201;
      #endregion

      #region Ordering Assignment Paperwork Status
      public const int OrderAssignmentPaperworkStatus_Create_IfNew = 202;
      public const int OrderAssignmentPaperworkStatus_Create_IfProcessing = 203;
      public const int OrderAssignmentPaperworkStatus_Create_IfCompleted = 204;
      public const int OrderAssignmentPaperworkStatus_Create_IfVerified = 205;
      public const int OrderAssignmentPaperworkStatus_Create_IfClosed = 206;
      public const int OrderAssignmentPaperworkStatus_Create_IfOnHold = 207;
      public const int OrderAssignmentPaperworkStatus_Create_IfCanceled = 208;

      public const int OrderAssignmentPaperworkStatus_View = 209;
      #endregion

      #region Order Detail View
      // special permission. When user has this permission, permission checker will be check 
      // whether user is OP and user.OPID = order.OPID, ... (for OPU, master OP, group, ...)
      public const int Order_View_OrderingParty = 210;

      // check if current user is SP and this order is placed by this user
      public const int Order_View_ServiceProvider = 211;

      // can view order. Any user has this permission can view order
      public const int Order_View = 212;
      #endregion

      #region Order Detail Edit
      // special permission (built in). If current user is OP, he only edit order if OPU ID of order is OPU
      // of current user or current user is master and OP ID of current user is OP ID of order.
      // If current user is not OP but has this permission, an exception will be throwed
      public const int Order_Edit_OrderingParty = 213;
      #endregion

      #region Ordering Assignment
      public const int OrderAssignment_Assign_IfNew = 214;
      public const int OrderAssignment_Assign_IfProcessing = 215;
      public const int OrderAssignment_Assign_IfCompleted = 216;
      public const int OrderAssignment_Assign_IfVerified = 217;
      public const int OrderAssignment_Assign_IfClosed = 218;
      public const int OrderAssignment_Assign_IfOnHold = 219;
      public const int OrderAssignment_Assign_IfCanceled = 220;
      #endregion

      #region SP

      #region Serivce Provider Party
      public const int ServiceProvider_PartyProfile_Create = 221;
      public const int ServiceProvider_PartyProfile_Update = 222;
      public const int ServiceProvider_PartyProfile_View = 223;
      #endregion

      #region Serivce Provider
      public const int ServiceProvider_Profile_Update = 224;
      public const int ServiceProvider_Profile_View = 225;
      #endregion

      #region Serivce Provider Fee
      public const int ServiceProvider_FeeProfile_Create = 226;
      public const int ServiceProvider_FeeProfile_Update = 227;
      public const int ServiceProvider_FeeProfile_View = 228;
      #endregion

      #region Serivce Provider Schedule
      public const int ServiceProvider_ScheduleProfile_Create = 229;
      public const int ServiceProvider_ScheduleProfile_Update = 230;
      public const int ServiceProvider_ScheduleProfile_View = 231;
      #endregion

      #region Serivce Provider Area
      public const int ServiceProvider_AreaProfile_Create = 232;
      public const int ServiceProvider_AreaProfile_Update = 233;
      public const int ServiceProvider_AreaProfile_View = 234;
      #endregion

      #region Serivce Provider Billing Approval
      //public const int ServiceProvider_BillingApprovalProfile_Create = 235;
      public const int ServiceProvider_BillingApprovalProfile_Update = 236;
      public const int ServiceProvider_BillingApprovalProfile_View = 237;
      #endregion

      #region Serivce Provider Black List
      public const int ServiceProvider_BlackListProfile_Create = 238;
      public const int ServiceProvider_BlackListProfile_Update = 239;
      public const int ServiceProvider_BlackListProfile_View = 240;
      #endregion

      #region Serivce Provider User
      public const int ServiceProvider_UserProfile_Create = 241;
      public const int ServiceProvider_UserProfile_Update = 242;
      public const int ServiceProvider_UserProfile_View = 243;
      #endregion

      #region Serivce Provider Credetialing
      public const int ServiceProvider_CredentialingProfile_Create = 244;
      public const int ServiceProvider_CredentialingProfile_Update = 245;
      public const int ServiceProvider_CredentialingProfile_View = 246;
      #endregion

      #region Serivce Provider Post Office Note
      public const int ServiceProvider_PostOfficeNoteProfile_Create = 249;
      public const int ServiceProvider_PostOfficeNoteProfile_Update = 250;
      public const int ServiceProvider_PostOfficeNoteProfile_View = 251;
      #endregion

      #region Service Provider Party Contact Profile
      public const int ServiceProvider_PartyContactProfile_Create = 252;
      public const int ServiceProvider_PartyContactProfile_Update = 253;
      public const int ServiceProvider_PartyContactProfile_View = 254;
      #endregion

      #endregion

      //Insurance and Billing Company
      #region Insurance and Billing Company

      #region  Party Profile
      public const int Insurance_PartyProfile_Create = 300;
      public const int Insurance_PartyProfile_Update = 301;
      public const int Insurance_PartyProfile_View = 302;
      #endregion

      #region  Contact Info Email Address
      public const int Insurance_PartyContactEmailAddressProfile_Create = 303;
      public const int Insurance_PartyContactEmailAddressProfile_Update = 304;
      public const int Insurance_PartyContactEmailAddressProfile_View = 305;
      #endregion

      #region  Profile
      public const int Insurance_Profile_Create = 306;
      public const int Insurance_Profile_Update = 307;
      public const int Insurance_Profile_View = 308;
      #endregion

      #region  Labs
      public const int Insurance_LabsProfile_Create = 309;
      public const int Insurance_LabsProfile_Update = 310;
      public const int Insurance_LabsProfile_View = 311;
      #endregion

      #region  Forms
      public const int Insurance_FormsProfile_Create = 312;
      public const int Insurance_FormsProfile_Update = 313;
      public const int Insurance_FormsProfile_View = 314;
      #endregion

      #region  Requirement
      public const int Insurance_RequirementProfile_Create = 315;
      public const int Insurance_RequirementProfile_Update = 316;
      public const int Insurance_RequirementProfile_View = 317;
      #endregion

      #region  Billing
      public const int Insurance_BillingProfile_Create = 318;
      public const int Insurance_BillingProfile_Update = 319;
      public const int Insurance_BillingProfile_View = 320;
      #endregion

      #region  Product Type
      public const int Insurance_ProductTypeProfile_Create = 321;
      public const int Insurance_ProductTypeProfile_Update = 322;
      public const int Insurance_ProductTypeProfile_View = 323;
      #endregion

      #region  Mailing
      public const int Insurance_MailingProfile_Create = 324;
      public const int Insurance_MailingProfile_Update = 325;
      public const int Insurance_MailingProfile_View = 326;
      #endregion

      #region  Locations
      public const int Insurance_LocationsProfile_Create = 327;
      public const int Insurance_LocationsProfile_Update = 328;
      public const int Insurance_LocationsProfile_View = 329;
      #endregion

      #region Post Office Note
      public const int Insurance_PostOfficeNoteProfile_Create = 330;
      public const int Insurance_PostOfficeNoteProfile_Update = 331;
      public const int Insurance_PostOfficeNoteProfile_View = 332;
      #endregion

      #region Requirement Condition and Chart Generator      
      public const int Insurance_RequirementCondionChart_Update = 334;
      public const int Insurance_RequirementCondionChart_View = 335;
      #endregion

      #region Requirement Code
      public const int Insurance_RequirementCodeProfile_Create = 336;
      public const int Insurance_RequirementCodeProfile_Update = 337;
      public const int Insurance_RequirementCodeProfile_View = 338;
      #endregion

      //Billing      

      #region  Profile      
      public const int BillingCompany_Profile_Update = 340;
      public const int BillingCompany_Profile_View = 341;
      #endregion

      #region  Pricing Surcharges
      public const int Insurance_PricingSurchargesProfile_Create = 342;
      public const int Insurance_PricingSurchargesProfile_Update = 343;
      public const int Insurance_PricingSurchargesProfile_View = 344;
      #endregion

      #region  Contact Info Email Address
      public const int BillingCompany_PartyContactEmailAddressProfile_Create = 345;
      public const int BillingCompany_PartyContactEmailAddressProfile_Update = 346;
      public const int BillingCompany_PartyContactEmailAddressProfile_View = 347;
      #endregion

      #region  Post office note
      public const int BillingCompany_PostOfficeNote_Create = 348;
      public const int BillingCompany_PostOfficeNote_Update = 349;
      public const int BillingCompany_PostOfficeNote_View = 350;
      #endregion

      #endregion
      //end

      //begin Accountant
      #region Accountant

      #region Invoice
      public const int Accountant_Invoice_Create = 700;
      public const int Accountant_Invoice_Update = 701;
      public const int Accountant_Invoice_View = 702;
      #endregion

      #region Receivable
      /*public const int Accountant_Receivable_Create = 703;
      public const int Accountant_Receivable_Update = 704;
      public const int Accountant_Receivable_View = 705;*/
      #endregion

      #region Data Transfer
      public const int Accountant_DataTransfer_Create = 706;
      public const int Accountant_DataTransfer_Update = 707;
      public const int Accountant_DataTransfer_View = 708;
      #endregion

      #region Payable
      public const int Accountant_Payable_Create = 709;
      public const int Accountant_Payable_Update = 710;
      public const int Accountant_Payable_View = 711;
      #endregion

      #region Payment
      public const int Accountant_Payment_Create = 712;
      public const int Accountant_Payment_Update = 713;
      public const int Accountant_Payment_View = 714;
      #endregion

      #region Statement
      /*public const int Accountant_Statement_Create = 715;
      public const int Accountant_Statement_Update = 716;
      public const int Accountant_Statement_View = 717;*/
      #endregion

      #region Re all
      /*public const int Accountant_ReALL_Create = 718;
      public const int Accountant_ReALL_Update = 719;
      public const int Accountant_ReALL_View = 720;*/
      #endregion

      #region Approval Wrire off, Adjustment
      //public const int Accountant_ApprovalWriteAdjustment_Create = 721;
      //public const int Accountant_ApprovalWriteAdjustment_Update = 722;
      //public const int Accountant_ApprovalWriteAdjustment_View = 723;
      #endregion

      #region Adjustment
      public const int Accountant_Adjustment_Create = 724;
      public const int Accountant_Adjustment_Update = 725;
      public const int Accountant_Adjustment_View = 726;
      #endregion

      #endregion
      //end Accoutant
      #region Ordering Party / Party Profile
      public const int OrderingParty_PartyProfile_Create = 400;
      public const int OrderingParty_PartyProfile_Update = 401;
      public const int OrderingParty_PartyProfile_View = 402;
      #endregion

      #region Ordering Party / Party Contact Information
      public const int OrderingParty_PartyContactInformation_Create = 403;
      public const int OrderingParty_PartyContactInformation_Update = 404;
      public const int OrderingParty_PartyContactInformation_View = 405;
      #endregion

      #region Ordering Party / Agent Contact
      public const int OrderingParty_AgentContact_Create = 406;
      public const int OrderingParty_AgentContact_Update = 407;
      public const int OrderingParty_AgentContact_View = 408;
      #endregion

      #region Ordering Party / Agency Management
      public const int OrderingParty_AgencyManagement_Create = 409;
      public const int OrderingParty_AgencyManagement_Update = 410;
      public const int OrderingParty_AgencyManagement_View = 411;
      #endregion

      #region Ordering Party / Mailing List
      //public const int OrderingParty_MailingList_Create = 412;
      public const int OrderingParty_MailingList_Update = 413;
      public const int OrderingParty_MailingList_View = 414;
      #endregion

      #region Ordering Party / Insurance List
      public const int OrderingParty_InsuranceList_Create = 415;
      public const int OrderingParty_InsuranceList_Update = 416;
      public const int OrderingParty_InsuranceList_View = 417;
      #endregion

      #region Ordering Party / Order Management
      public const int OrderingParty_OrderManagement_Create = 418;
      public const int OrderingParty_OrderManagement_Update = 419;
      public const int OrderingParty_OrderManagement_View = 420;
      #endregion

      #region Ordering Party / Question Answer
      public const int OrderingParty_QuestionAnswer_Create = 421;
      public const int OrderingParty_QuestionAnswer_Update = 422;
      public const int OrderingParty_QuestionAnswer_View = 423;
      #endregion

      /*#region Ordering Party / OP Member
      public const int OrderingParty_OPMember_Create = 424;
      public const int OrderingParty_OPMember_Update = 425;
      public const int OrderingParty_OPMember_View = 426;
      #endregion

      #region Ordering Party / User Account
      public const int OrderingParty_UserAccount_Create = 427;
      public const int OrderingParty_UserAccount_Update = 428;
      public const int OrderingParty_UserAccount_View = 429;
      #endregion*/

      #region Ordering Party / Office Note
      public const int OrderingParty_OfficeNote_Create = 430;
      public const int OrderingParty_OfficeNote_Update = 431;
      public const int OrderingParty_OfficeNote_View = 432;
      #endregion

      #region Ordering Party / General info
      public const int OrderingParty_GeneralInfo_Update = 433;
      public const int OrderingParty_GeneralInfo_View = 434;
      #endregion

      #region Employee Management / Management
      public const int EmployeeManagement_Management_Create = 500;
      public const int EmployeeManagement_Management_Update = 501;
      public const int EmployeeManagement_Management_View = 502;
      #endregion

      #region Employee Management / Permission
      public const int EmployeeManagement_Permission_Create = 503;
      public const int EmployeeManagement_Permission_Update = 504;
      public const int EmployeeManagement_Permission_View = 505;
      #endregion

      #region Employee Management / User Role
      public const int EmployeeManagement_UserRole_Create = 506;
      public const int EmployeeManagement_UserRole_Update = 507;
      public const int EmployeeManagement_UserRole_View = 508;
      #endregion

      #region Employee Management / Office Note
      public const int EmployeeManagement_OfficeNote_Create = 509;
      public const int EmployeeManagement_OfficeNote_Update = 510;
      public const int EmployeeManagement_OfficeNote_View = 511;
      #endregion

      #region Inventory / Item
      public const int Inventory_Item_Create = 600;
      public const int Inventory_Item_Update = 601;
      public const int Inventory_Item_View = 602;
      #endregion

      #region Inventory / Supply Order
      public const int Inventory_SupplyOrder_Create = 603;
      public const int Inventory_SupplyOrder_Update = 604;
      public const int Inventory_SupplyOrder_View = 605;
      #endregion

      #region Inventory / Sales Order
      public const int Inventory_SalesOrder_Create = 606;
      public const int Inventory_SalesOrder_Update = 607;
      public const int Inventory_SalesOrder_View = 608;
      #endregion

      #region Inventory / Purchase Order
      public const int Inventory_PurchaseOrder_Create = 609;
      public const int Inventory_PurchaseOrder_Update = 610;
      public const int Inventory_PurchaseOrder_View = 611;
      #endregion

      #region Inventory / Packing List
      public const int Inventory_PackingList_Create = 612;
      public const int Inventory_PackingList_Update = 613;
      public const int Inventory_PackingList_View = 614;
      #endregion

      #region Inventory / Receive
      public const int Inventory_Receive_Create = 615;
      public const int Inventory_Receive_Update = 616;
      public const int Inventory_Receive_View = 617;
      #endregion

      #region Inventory / Shipping
      public const int Inventory_Shipping_Create = 618;
      public const int Inventory_Shipping_Update = 619;
      public const int Inventory_Shipping_View = 620;
      #endregion

      #region Inventory / Medical Item
      public const int Inventory_Supplier_Create = 621;
      public const int Inventory_Supplier_Update = 622;
      public const int Inventory_Supplier_View = 623;
      #endregion

      #region Inventory / Party Profile Supplier
      public const int Inventory_PartyProfileSupplier_Create = 624;
      public const int Inventory_PartyProfileSupplier_Update = 625;
      public const int Inventory_PartyProfileSupplier_View = 626;
      #endregion

      #region Inventory / Party Contact Email Address Supplier
      public const int Inventory_PartyContactEmailAddressSupplier_Create = 627;
      public const int Inventory_PartyContactEmailAddressSupplier_Update = 628;
      public const int Inventory_PartyContactEmailAddressSupplier_View = 629;
      #endregion

      #region Inventory / Post Office Note Supplier
      public const int Inventory_PostOfficeNoteSupplier_Create = 630;
      public const int Inventory_PostOfficeNoteSupplier_Update = 631;
      public const int Inventory_PostOfficeNoteSupplier_View = 632;
      #endregion

      #endregion

      #region Partner

      #region Party Profile
      public const int Partner_PartyProfile_Create = 800;
      public const int Partner_PartyProfile_Update = 801;
      public const int Partner_PartyProfile_View = 802;
      #endregion

      #region Contact Information
      public const int Partner_ContactInfoProfile_Create = 803;
      public const int Partner_ContactInfoProfile_Update = 804;
      public const int Partner_ContactInfoProfile_View = 805;
      #endregion

      #region Post Office Note
      public const int Partner_PostOfficeNote_Create = 806;
      public const int Partner_PostOfficeNote_Update = 807;
      public const int Partner_PostOfficeNote_View = 808;
      #endregion

      #endregion

      #region General
      public const int SearchOrder = 905;
      #endregion
    }
  }
}
