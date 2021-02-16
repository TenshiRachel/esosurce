<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="paymentList.aspx.cs" Inherits="Esource.Views.service.paymentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="LblUid" Visible="false"></asp:Label>
    <section class="payment-list">
        <div class="row col-12 mb-2">
            <a href="<%=Page.ResolveUrl("~/Views/profile/index.aspx") %>" class="text-secondary">
                <h4><i class="fas fa-chevron-left mr-1"></i>Profile</h4>
            </a>
        </div>
    <div class="row">
        <div class="col-12 col-md-9 order-1 order-md-0">
            <div class="card">
                <div
                    class="view view-cascade primary-light-gradient py-2 mx-4 mb-3 d-flex justify-content-center align-items-center text-center">
                    <h4 class="mx-3">Transactions
                    </h4>
                </div>

                <div class="card-body">
                    <div class="table-responsive table-hover w-100" style="padding: 0 15px;">
                        <table id="transaction-table" class="table table-striped text-center">
                            <thead class="deep-purple accent-3 white-text">
                                <tr>
                                    <th runat="server" id="provider">Service Provider </th>
                                    <th id="name" class="th-sm">Service Name</th>
                                    <th id="price" class="th-sm">Price</th>
                                    <th id="date" class="th-sm rounded-top-right">Date</th>
                                    <th id="action" class="th-sm"></th>
                                </tr>
                            </thead>

                            <tbody>
                                <asp:Repeater runat="server" ID="translist" OnItemCommand="translist_ItemCommand" OnItemDataBound="translist_ItemDataBound">
                                    <ItemTemplate>
                                        <tr class="animated faster">
                                            <td headers="provider" class="align-middle"><%#Eval("serviceProvider") %></td>
                                            <td headers="name" class="align-middle"><%#Eval("service") %></td>
                                            <td headers="price" class="align-middle">$<%#Eval("price") %>
                                        <%#Eval("currency") %></td>
                                            <td headers="date" class="align-middle"><%#Eval("date") %></td>
                                            <th class="align-middle" headers="action">
                                                <asp:LinkButton CssClass="btn btn-success btn-sm" CommandName="details" CommandArgument='<%#Eval("Id") %>' runat="server">View Details
                                                </asp:LinkButton>
                                            </th>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <p runat="server" id="end" visible="false" class="text-center grey-text small font-weight-bold mb-0">End of contents</p>
                </div>
            </div>
        </div>

        <div class="col-12 col-md-3 my-4 my-md-0 order-0 order-md-1">
            <div class="card">
                <div
                    class="view view-cascade primary-light-gradient py-2 mx-4 mb-3 d-flex justify-content-center align-items-center text-center">
                    <h4 class="mx-3">Action</h4>
                </div>

                <div class="card-body">
                    <div class="md-form md-outline my-0">
                        <input id="action-search-input" class="form-control" type="text" name="search">
                        <label for="action-search-input">Search Payments</label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="<%=Page.ResolveUrl("~/Scripts/transactions.js") %>" type="text/javascript"></script>
    </section>
</asp:Content>
