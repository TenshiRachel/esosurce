<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="Esource.Views.service.payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="payment-service">
        <asp:Label runat="server" ID="LblUid" Visible="false"></asp:Label>
        <div class="card z-depth-2">
            <div class="vh-100 row justify-content-around p-5">
                <div class="col-12 row justify-content-around">
                    <h1 class="text-center col-12">Send Payment</h1>
                </div>
                <div class="col-5">
                    <h1 class="text-center">From</h1>
                    <!-- Card -->
                    <div class="vh-60 card">

                        <!-- Background color -->
                        <div class="indigo lighten-1">
                            <img class="card-img-top img-fluid"
                                onerror='this.src="<%=Page.ResolveUrl("~/Content/img/placeholder.jpg") %>"' src="">
                        </div>

                        <!-- Avatar -->
                        <div class="avatar mx-auto white">
                            <img onerror='this.src = "<%=Page.ResolveUrl("~/Content/img/placeholder.jpg") %>"'
                                src="" class="rounded-circle"
                                alt="woman avatar">
                        </div>

                        <!-- Content -->
                        <div class="card-body">
                            <!-- Name -->
                            <h4 class="card-title">client username</h4>
                            <hr>
                            <!-- Quotation -->
                            <div class="row justify-content-between">
                                {{!--
                                <h6 class="text-left col-5"><b>Paypal Email:</b></h6>
                                <h6 class="text-right col-7">client paypal</h6>
                                --}}
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
                    <i class=" far fa-arrow-right fa-4x my-auto"></i>
                </div>

                <div class="col-5">
                    <h1 class="text-center">To</h1>
                    <div class="vh-60 card">

                        <!-- Background color -->
                        <div class="indigo lighten-1">
                            <img style="" class="card-img-top img-fluid"
                                onerror='this.src="<%=Page.ResolveUrl("~/Content/img/placeholder.jpg") %>"' src="">
                        </div>

                        <!-- Avatar -->
                        <div class="avatar mx-auto white">
                            <img onerror='this.src = "<%=Page.ResolveUrl("~/Content/img/placeholder.jpg") %>"'
                                src="" class="rounded-circle " alt="">
                        </div>

                        <!-- Content -->
                        <div class="card-body">
                            <!-- Name -->
                            <h4 class="card-title">freelancer username</h4>
                            <hr>
                            <!-- Quotation -->
                            <div class="row justify-content-between">
                                <h6 class="text-left col-5"><b>Paypal Email:</b></h6>
                                <h6 class="text-right col-7">freelancer paypal</h6>

                            </div>
                        </div>
                        <div class="text-center">
                            <asp:Button runat="server" ID="btnPay" CssClass="btn btn-md btn-purple" OnClick="btnPay_Click" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>

</asp:Content>
