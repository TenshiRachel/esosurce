<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="paymentDetails.aspx.cs" Inherits="Esource.Views.service.paymentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="payment-details">
        <asp:Label runat="server" ID="LblUid" Visible="false"></asp:Label>
        <div class="row col-12 mb-2">
            <a href="<%=Page.ResolveUrl("~/Views/service/paymentList.aspx") %>" class="text-secondary">
                <h4><i class="fas fa-chevron-left mr-1"></i>Transactions</h4>
            </a>
        </div>
        <div class="row col-10 justify-content-center z-depth-2 p-3 rounded mx-auto">
            <h1 class="text-center col-12 mb-3 deep-purple-text">Receipt </h1>
            <div class="col-6 mb-3">
                <h3 class="text-start purple-text">Service Provider Details </h3>
                <p runat="server" id="provider"></p>
            </div>

            <div class="col-6">
                <h3 class="text-start purple-text">Transaction Info</h3>
            </div>

            <hr class="col-12 hr-primary mb-4">

            <div class="row col-12 secondary-color-dark rounded-top p-0">
                <div class="col-2 border border-top-0 border-bottom-0 border-white py-2">
                    <h5 class="text-white">Service Name</h5>
                </div>

                <div class="col-2 border border-top-0 border-bottom-0 border-white py-2">
                    <h5 class="text-white">Price</h5>
                </div>
                <div class="col-2 border border-top-0 border-bottom-0 border-white py-2">
                    <h5 class="text-white">Date</h5>
                </div>
            </div>
            <div class="row col-12 py-2 p-0 border-bottom">
                <div class="col-2">
                    <p runat="server" id="service"></p>
                </div>
                <div class="col-2" runat="server" id="price">
                    <p>
                    </p>
                </div>
                <div class="col-2" runat="server" id="date">
                </div>
            </div>

        </div>

    </section>
</asp:Content>
