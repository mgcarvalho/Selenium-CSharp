//using Ebankit.FunctionalTests.EMS;
//using ebankIT.Tools.TestingLIB.Constants;
//using Ebankit.NetCore.Common.Tests;
//using Ebankit.Tests.Functional.EMS.Campaigns.Campaigns.Utils;
//using Ebankit.Tools.TestingLIB;
//using Ebankit.Tools.TestingLIB.Core;
//using Ebankit.Tools.TestingLIB.Order;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using Xunit;

//namespace Ebankit.Tests.Functional.EMS.Campaigns.Campaigns
//{

//    [TestCaseOrderer(AssemblyConfiguration.Namespace, AssemblyConfiguration.AssemblyName)]
//    [Collection("Sequence1")]
//    public class CreateAndEditOutboundCampaignPushNotification : BaseFunctionalTest
//    {
//        #region Variables

//        private string TitleCampaignId = "TitleCampaignId";
//        private string TitleCampaignsPageText = "Campaigns";
//        private string BtnCreateNewCampaignsCssClass = "btn_add";
//        private string BtnCreateNewCampaignsText = "Create new campaign";
//        private string TitleCreateNewCampaignId = "CreateNewCampaignTitleId";
//        private string TitleCreateCampaignText = "Create new campaign";
//        private string Step1ActiveNameFieldId = "CampaignNameId";
//        private string Step1ActiveNameFieldText = "Name";
//        private string TitleStep2Id = "CampaignChannelTitleId";
//        private string TitleStep2Text = "Channels";
//        private string SubTitleDispatchCalendarPushID = "subTitleDispatchCalendar_2";
//        private string SubtitleDispatchCalendarText = "Dispatch calendar";
//        private string TitlePopupDispatchId = "CampaignDispatchTitleId";
//        private string TitlePopupDispatchText = "Campaign dispatch";
//        private string TitleStep3Id = "CampaignContentTitleId";
//        private string TitleStep3Text = "Contents";
//        private string TitleStep4Id = "CampaignAddicionalInfoId";
//        private string TitleStep4Text = "Additional Information";
//        private string TitleStep5Id = "CampaignSummaryTitleId";
//        private string TitleStep5Text = "Summary";
//        private string TitleCampaignsGridText = "Campaigns";
//        private string SuccessApprovalCampaignXPath = "//*[@id=\"MainView\"]/section/div/div[2]/div/p";
//        private string SuccessApprovalCampaignText = "The campaign was sent to validation.";
//        private string BtnSeeDetailsApprovalCssClass = "btn_primary";
//        private string BtnSeeDetailsApprovalText = "See details";
//        private string BtnBackToListApprovalCssClass = "//*[@id=\"MainView\"]/section/div/div[3]/div[2]/a/span";
//        private string BtnBackToListApprovalText = "Back to list";
//        private string SuccessLaunchCampaignXPath = "//*[@id=\"MainView\"]/section/div/div[2]/div/p";
//        private string SuccessLaunchCampaignText = "The campaign was launched.";
//        private string BtnSeeDetailsCssClass = "btn_primary";
//        private string BtnSeeDetailsText = "See details";
//        private string BtnBackToListCssClass = "//*[@id=\"MainView\"]/section/div/div[3]/div[2]/a/span";
//        private string BtnBackToListText = "Back to list";
//        private string NameCampaignGridXPath = "//*[@id=\"campaignsGrid\"]/table/tbody/tr/td[3]";
//        private string StatusCampaignGridXPath = "//*[@id=\"campaignsGrid\"]/table/tbody/tr/td[4]";
//        private string StatusCampaignGridText = "Canceled";
//        private string TitleCampaignDetailsId = "CampaignDetailsTitleId";
//        private string TitleDetailsCampaignText = "Campaign details";
//        private string SubtitleSummaryXPath = "//*[@id=\"MainView\"]/section/div/section/h4";
//        private string SubtitleSummaryText = "Summary";
//        private string CampaignTabId = "CampaignTabId";
//        private string ChannelsTabId = "ChannelsTabId";
//        private string ContentTabId = "ContentTabId";
//        private string ResponsesTabId = "ResponseTabId";
//        private string AdditionalInfoTabId = "AdditionalInfoTabId";
//        private string CampaignTabText = "Campaign";
//        private string ChannelsTabText = "Channels";
//        private string ContentsTabText = "Contents";
//        private string ResponsesTabText = "Responses";
//        private string AdditionalInformationTabText = "Additional Information";
//        private string DescContentPushId = "ContentDescriptionushId";
//        private string DescContentPushText = "Define the content for the Push Notification.";
//        private static string EnablePushId = "CampaignChannels_2__Active";
//        private static string CHANNEL_PUSH = "3003";

//        #endregion


//        #region Step1Campaign

//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(1)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "Campaigns_CampaignType1", "F-TEST - CAMPAIGN OUTBOUND DESCRIPTION PUSH", "English", "F-TEST - LISTNAME_OUTBOUND_AT01")]
//        public void Step1CampaignPUSH_Success(string name, string type, string description, string language, string marketinglist)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();
//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                var titleCampaigns = Driver.GetElementByID(TitleCampaignId).Text;
//                Assert.Equal(TitleCampaignsPageText, titleCampaigns);

//                var btnNewCampaign = Driver.GetElementByCssClass(BtnCreateNewCampaignsCssClass).Text;
//                Assert.Equal(BtnCreateNewCampaignsText, btnNewCampaign);

//                Driver.GoToCreateCampaign();

//                Thread.Sleep(6000);

//                var titleCreateCampaign = Driver.GetElementByID(TitleCreateNewCampaignId).Text;
//                Assert.Equal(TitleCreateCampaignText, titleCreateCampaign);

//                var step1Active = Driver.GetElementByID(Step1ActiveNameFieldId).Text;
//                Assert.Equal(Step1ActiveNameFieldText, step1Active);

//                CreateCampaignUtils.InsertDetailsToCreate(Driver, quickTimeout, name, type, description, language);

//                CreateCampaignUtils.InsertStrategyAudienceToCreate(Driver, quickTimeout, marketinglist);

//                CreateCampaignUtils.Step1ContinueClick(Driver, quickTimeout);

//                Thread.Sleep(20000);

//                var titleStep2 = Driver.GetElementByID(TitleStep2Id).Text;
//                Assert.Equal(TitleStep2Text, titleStep2);

//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }

//        #endregion

//        #region Step2Campaign

//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(2)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "All", "Single dispatch", "02:00")]
//        public void Step2CampaignPUSH_Success(string name, string statusCampaign, string frequencyDispatch, string hourSending)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();
//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                var titleCampaigns = Driver.GetElementByID(TitleCampaignId).Text;
//                Assert.Equal(TitleCampaignsPageText, titleCampaigns);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.InsertNameToSearch(Driver, quickTimeout, name, statusCampaign);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                CreateCampaignUtils.EditCampaign(Driver, quickTimeout);

//                Thread.Sleep(12000);

//                var titleStep2 = Driver.GetElementByID(TitleStep2Id).Text;
//                Assert.Equal(TitleStep2Text, titleStep2);

//                CreateCampaignUtils.EnableChannel(Driver, quickTimeout, EnablePushId);

//                Thread.Sleep(3000);

//                Driver.ScrollToElement("subTitleDispatchCalendar_1");

//                Thread.Sleep(4000);

//                var subtitleDispatchCalendar = Driver.GetElementByID(SubTitleDispatchCalendarPushID).Text;
//                Assert.Equal(SubtitleDispatchCalendarText, subtitleDispatchCalendar);

//                CreateCampaignUtils.ClickAddDispatch(Driver, quickTimeout, CHANNEL_PUSH);

//                Thread.Sleep(6000);

//                var titlePopupDispatch = Driver.GetElementByID(TitlePopupDispatchId).Text;
//                Assert.Equal(TitlePopupDispatchText, titlePopupDispatch);

//                CreateCampaignUtils.InsertDetailsToDispatch(Driver, quickTimeout, frequencyDispatch, hourSending);

//                CreateCampaignUtils.SaveDispatch(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(4000);

//                CreateCampaignUtils.Step2ContinueClick(Driver, quickTimeout);

//                Thread.Sleep(20000);

//                var titleStep3 = Driver.GetElementByID(TitleStep3Id).Text;
//                Assert.Equal(TitleStep3Text, titleStep3);

//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }

//        #endregion

//        #region Step3Campaign

//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(3)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "F-TEST - PUSH NOTIFICATION TITLE", "F-TEST - BODY MESSAGE PUSH NOTIFICATION", "All", "www.ebankit.com")]
//        public void Step3CampaignPUSH_Success(string name, string contentTitle, string contentBody, string statusCampaign, string contentURL)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();
//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                var titleCampaigns = Driver.GetElementByID(TitleCampaignId).Text;
//                Assert.Equal(TitleCampaignsPageText, titleCampaigns);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.InsertNameToSearch(Driver, quickTimeout, name, statusCampaign);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                CreateCampaignUtils.EditCampaign(Driver, quickTimeout);

//                Thread.Sleep(12000);

//                var titleStep3 = Driver.GetElementByID(TitleStep3Id).Text;
//                Assert.Equal(TitleStep3Text, titleStep3);

//                CreateCampaignUtils.ExpandContent(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                var descContentPUSH = Driver.GetElementByID(DescContentPushId).Text;
//                Assert.Equal(DescContentPushText, descContentPUSH);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.InsertDetailsPushContent(Driver, quickTimeout, contentTitle, contentBody, contentURL);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(2000);

//                CreateCampaignUtils.Step3ContinueClick(Driver, quickTimeout);

//                Thread.Sleep(20000);

//                var titleStep4 = Driver.GetElementByID(TitleStep4Id).Text;
//                Assert.Equal(TitleStep4Text, titleStep4);

//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }

//        #endregion

//        #region Step4Campaign

//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(4)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "All")]
//        public void Step4CampaignPUSH_Success(string name, string statusCampaign)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();
//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                var titleCampaigns = Driver.GetElementByID(TitleCampaignId).Text;
//                Assert.Equal(TitleCampaignsPageText, titleCampaigns);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.InsertNameToSearch(Driver, quickTimeout, name, statusCampaign);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                CreateCampaignUtils.EditCampaign(Driver, quickTimeout);

//                Thread.Sleep(12000);

//                var titleStep4 = Driver.GetElementByID(TitleStep4Id).Text;
//                Assert.Equal(TitleStep4Text, titleStep4);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(4000);
//                CreateCampaignUtils.Step4ContinueClick(Driver, quickTimeout);

//                Thread.Sleep(20000);

//                var titleStep5 = Driver.GetElementByID(TitleStep5Id).Text;
//                Assert.Equal(TitleStep5Text, titleStep5);

//                CreateCampaignUtils.SaveForLater(Driver, quickTimeout);

//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }

//        #endregion

//        #region Step5ValidationCampaign

//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(5)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "All")]
//        public void Step5ValidationCampaignPUSH_Success(string name, string statusCampaign)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();
//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                var titleCampaigns = Driver.GetElementByID(TitleCampaignId).Text;
//                Assert.Equal(TitleCampaignsPageText, titleCampaigns);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.InsertNameToSearch(Driver, quickTimeout, name, statusCampaign);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                CreateCampaignUtils.EditCampaign(Driver, quickTimeout);

//                Thread.Sleep(12000);

//                var titleStep5 = Driver.GetElementByID(TitleStep5Id).Text;
//                Assert.Equal(TitleStep5Text, titleStep5);

//                CreateCampaignUtils.SaveForLater(Driver, quickTimeout);

//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }

//        #endregion

//        #region ProposedCampaign
//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(6)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "All")]
//        public void ProposedCampaignPUSH_Success(string name, string statusCampaign)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();
//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                var titleCampaigns = Driver.GetElementByID(TitleCampaignId).Text;
//                Assert.Equal(TitleCampaignsPageText, titleCampaigns);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.InsertNameToSearch(Driver, quickTimeout, name, statusCampaign);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                CreateCampaignUtils.EditCampaign(Driver, quickTimeout);

//                Thread.Sleep(12000);

//                var titleStep5 = Driver.GetElementByID(TitleStep5Id).Text;
//                Assert.Equal(TitleStep5Text, titleStep5);

//                CreateCampaignUtils.SaveForLater(Driver, quickTimeout);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(1000);

//                CreateCampaignUtils.ClickCancel(Driver, quickTimeout);

//                Thread.Sleep(20000);

//                var titleCampaignsGrid = Driver.GetElementByID(TitleCampaignId).Text;
//                Assert.Equal(TitleCampaignsGridText, titleCampaignsGrid);

//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }
//        #endregion

//        #region ReadyToLauchCampaign
//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(7)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "All")]
//        public void ReadyToLaunchCampaignPUSH_Success(string name, string statusCampaign)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();
//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                var titleCampaigns = Driver.GetElementByID(TitleCampaignId).Text;
//                Assert.Equal(TitleCampaignsPageText, titleCampaigns);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.InsertNameToSearch(Driver, quickTimeout, name, statusCampaign);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                CreateCampaignUtils.EditCampaign(Driver, quickTimeout);

//                Thread.Sleep(12000);

//                var titleStep5 = Driver.GetElementByID(TitleStep5Id).Text;
//                Assert.Equal(TitleStep5Text, titleStep5);

//                Thread.Sleep(4000);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.SendToApproval(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.PopupSendToApproval(Driver, quickTimeout);

//                Thread.Sleep(9000);

//                var messageSendApprovalCampaign = Driver.GetElementByXPath(SuccessApprovalCampaignXPath).Text;
//                Assert.Equal(SuccessApprovalCampaignText, messageSendApprovalCampaign);

//                var btnSeeDetail = Driver.GetElementByCssClass(BtnSeeDetailsApprovalCssClass).Text;
//                Assert.Equal(BtnSeeDetailsApprovalText, btnSeeDetail);

//                var btnBackList = Driver.GetElementByXPath(BtnBackToListApprovalCssClass).Text;
//                Assert.Equal(BtnBackToListApprovalText, btnBackList);


//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }
//        #endregion

//        #region LauchCampaign
//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(8)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "All")]
//        public void LaunchCampaignPUSH_Success(string name, string statusCampaign)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();
//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                var titleCampaigns = Driver.GetElementByID(TitleCampaignId).Text;
//                Assert.Equal(TitleCampaignsPageText, titleCampaigns);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.InsertNameToSearch(Driver, quickTimeout, name, statusCampaign);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                CreateCampaignUtils.EditCampaign(Driver, quickTimeout);

//                Thread.Sleep(12000);

//                var titleStep5 = Driver.GetElementByID(TitleStep5Id).Text;
//                Assert.Equal(TitleStep5Text, titleStep5);

//                Thread.Sleep(4000);

//                CreateCampaignUtils.SrollBottom(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.LaunchCampaign(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.PopupLaunchCampaign(Driver, quickTimeout);

//                Thread.Sleep(9000);

//                var messageLaunchedCampaign = Driver.GetElementByXPath(SuccessLaunchCampaignXPath).Text;
//                Assert.Equal(SuccessLaunchCampaignText, messageLaunchedCampaign);

//                var btnSeeDetails = Driver.GetElementByCssClass(BtnSeeDetailsCssClass).Text;
//                Assert.Equal(BtnSeeDetailsText, btnSeeDetails);

//                var btnBackToList = Driver.GetElementByXPath(BtnBackToListCssClass).Text;
//                Assert.Equal(BtnBackToListText, btnBackToList);


//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }
//        #endregion

//        #region CampaignDetailsSummary
//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(9)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "All")]
//        public void DetailsSummaryCampaignPUSH_Success(string name, string statusCampaign)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();

//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.InsertNameToSearch(Driver, quickTimeout, name, statusCampaign);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.DetailsCampaign(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                var titleDetails = Driver.GetElementByID(TitleCampaignDetailsId).Text;
//                Assert.Equal(TitleDetailsCampaignText, titleDetails);

//                var subtitleSummary = Driver.GetElementByXPath(SubtitleSummaryXPath).Text;
//                Assert.Equal(SubtitleSummaryText, subtitleSummary);

//                Thread.Sleep(3000);

//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }

//        #endregion

//        #region CampaignDetailsTabs
//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(10)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "All")]
//        public void DetailsTabsCampaignPUSH_Success(string name, string statusCampaign)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();

//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.InsertNameToSearch(Driver, quickTimeout, name, statusCampaign);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(3000);

//                CreateCampaignUtils.DetailsCampaign(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                var titleDetails = Driver.GetElementByID(TitleCampaignDetailsId).Text;
//                Assert.Equal(TitleDetailsCampaignText, titleDetails);

//                var campaignTab = Driver.GetElementByID(CampaignTabId).Text;
//                Assert.Equal(CampaignTabText, campaignTab);

//                var channelsTab = Driver.GetElementByID(ChannelsTabId).Text;
//                Assert.Equal(ChannelsTabText, channelsTab);

//                var contentsTab = Driver.GetElementByID(ContentTabId).Text;
//                Assert.Equal(ContentsTabText, contentsTab);

//                var responsesTab = Driver.GetElementByID(ResponsesTabId).Text;
//                Assert.Equal(ResponsesTabText, responsesTab);

//                var additionalInformationTab = Driver.GetElementByID(AdditionalInfoTabId).Text;
//                Assert.Equal(AdditionalInformationTabText, additionalInformationTab);

//                Thread.Sleep(3000);

//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }

//        #endregion

//        #region CancelCampaign

//        [Trait("TestCategory", "Sanity")]
//        [Trait("Application", TestModules.EMS_Campaigns)]
//        [Trait("Priority", TestPriorities.HIGH)]
//        [Theory, TestOrderPriority(11)]
//        [InlineData("F-TEST - CAMPAIGN OUTBOUND PUSH", "All")]
//        public void CancelCampaignPUSH_Success(string name, string statusCampaign)
//        {
//            try
//            {
//                var quickTimeout = Driver.TimeoutWindow(120);
//                Driver.ResizeTestWindow();

//                //Login and enter EMS
//                Driver.LoginAsTechAdmin();

//                //Go to Applications page
//                Driver.GoToCampaigns();

//                Thread.Sleep(10000);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.InsertNameToSearch(Driver, quickTimeout, name, statusCampaign);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                CreateCampaignUtils.CancelCampaign(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                CreateCampaignUtils.PopupCancelCampaign(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                CreateCampaignUtils.OpenSearchTab(Driver, quickTimeout);

//                CreateCampaignUtils.SearchClick(Driver, quickTimeout);

//                Thread.Sleep(6000);

//                var NameCampaign = Driver.GetElementByXPath(NameCampaignGridXPath).Text;
//                Assert.Equal(name, NameCampaign);

//                var StatusCampaign = Driver.GetElementByXPath(StatusCampaignGridXPath).Text;
//                Assert.Equal(StatusCampaignGridText, StatusCampaign);

//            }
//            catch (Exception e)
//            {
//                TakeScreenshot(e);
//            }
//        }
//        #endregion

//    }
//}
