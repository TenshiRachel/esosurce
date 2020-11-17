<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="Esource.Views.service.payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="payment-service">
        <asp:Label runat="server" ID="LblUid" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="LblJid" Visible="false"></asp:Label>
        <div class="card z-depth-2">
            <div class="row justify-content-around p-5">
                <div class="col-12 row justify-content-around">
                    <h1 class="text-center col-12">Send Payment</h1>
                </div>
                <div class="col-5">
                    <h1 class="text-center">From</h1>
                    <!-- Card -->
                    <div class="card">

                        <!-- Background color -->
                        <div class="indigo lighten-1">
                            <img class="card-img-top img-fluid"
                                onerror='this.src="<%=Page.ResolveUrl("~/Content/img/placeholder.jpg") %>"' src="#">
                        </div>

                        <!-- Avatar -->
                        <div class="avatar mx-auto white mt-4">
                            <img runat="server" id="client_avatar" src="#" class="rounded-circle" alt="avatar">
                        </div>

                        <!-- Content -->
                        <div class="card-body">
                            <!-- Name -->
                            <h4 runat="server" id="client_name" class="card-title"></h4>
                            <hr>
                            <!-- Quotation -->
                            <div class="row justify-content-between">
                                <h6 class="text-left col-5"><b>Paypal Email:</b></h6>
                                <h6 runat="server" id="client_email" class="text-right col-7"></h6>
                                <h6 class="text-left col-5"><b>Payment Amount:</b></h6>
                                <h6 runat="server" id="servprice" class="text-right col-7"></h6>
                            </div>
                        </div>
                        <div class="text-center">
                            <a href="<%=Page.ResolveUrl("~/Views/service/index.aspx") %>" class="btn btn-purple">Back
                            </a>
                        </div>

                    </div>
                    <!-- Card -->
                </div>
                <div class="col-2 row justify-content-center align-items-center">
                    <i class=" fas fa-arrow-right fa-4x my-auto"></i>
                </div>

                <div class="col-5">
                    <h1 class="text-center">To</h1>
                    <div class="card">

                        <!-- Background color -->
                        <div class="indigo lighten-1">
                            <img style="" class="card-img-top img-fluid"
                                onerror='this.src="<%=Page.ResolveUrl("~/Content/img/placeholder.jpg") %>"' src="#">
                        </div>

                        <!-- Avatar -->
                        <div class="avatar mx-auto white mt-4">
                            <img runat="server" id="freelance_avatar" src="#" class="rounded-circle " alt="">
                        </div>

                        <!-- Content -->
                        <div class="card-body">
                            <!-- Name -->
                            <h4 runat="server" id="freelance_name" class="card-title"></h4>
                            <hr>
                            <!-- Quotation -->
                            <div class="row justify-content-between">
                                <h6 class="text-left col-5"><b>Paypal Email:</b></h6>
                                <h6 runat="server" id="freelance_email" class="text-right col-7"></h6>

                            </div>
                        </div>
                        <div class="text-center">
                            <asp:LinkButton runat="server" ID="btnPay" CssClass="btn btn-purple" OnClick="btnPay_Click">Send</asp:LinkButton>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>
    <script src="https://js.stripe.com/v3/"></script>
</asp:Content>
