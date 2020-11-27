<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="request.aspx.cs" Inherits="Esource.Views.service.request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="requests">
        <asp:HiddenField runat="server" ID="LblUid" />
        <asp:ScriptManager runat="server" ID="reqpanel_script"></asp:ScriptManager>
        <div class="row">
            <div class="col-12 col-md-9 order-1 order-md-0">
                <div class="card">
                    <div
                        class="view primary-light-gradient py-2 mx-4 mb-3 d-flex justify-content-center align-items-center text-center">
                        <span class="mx-3 font-weight-bold">Requests</span>
                    </div>

                    <div class="card-body">
                        <div class="table-responsive table-hover w-100" style="padding: 0 15px;">
                            <table id="requests-table" class="table table-striped text-center">
                                <thead class="deep-purple accent-3 white-text">
                                    <tr>
                                        <th id="provider" class="th-sm rounded-top-left">Service provider</th>
                                        <th id="date" class="th-sm">Date Requested</th>
                                        <th id="service" class="th-sm">Service Name</th>
                                        <th id="payment" class="th-sm">Payment Amount</th>
                                        <th id="remarks" class="th-sm">Remarks</th>
                                        <th id="action" class="th-sm rounded-top-right">Action</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="reqpanel">
                                        <ContentTemplate>
                                            <asp:Repeater runat="server" ID="reqlist" OnItemCommand="reqlist_ItemCommand" OnItemDataBound="reqlist_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr class="animated faster">
                                                        <td headers="provider" class="align-middle">
                                                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("uid") %>' CommandName="viewprofile"><%#Eval("username") %></asp:LinkButton>
                                                        </td>
                                                        <td headers="date" class="align-middle"><%#Eval("date_created") %></td>
                                                        <td headers="service" class="align-middle"><%#Eval("sName") %></td>
                                                        <td headers="payment" class="align-middle">$<%#Eval("price") %></td>
                                                        <td headers="remarks" class="align-middle"><%#Eval("remarks") %></td>
                                                        <td headers="action" class="align-middle">
                                                            <asp:HiddenField runat="server" ID="status" Value='<%#Eval("status") %>' />
                                                            <asp:LinkButton runat="server" ID="btnPay" CommandArgument='<%#Eval("sid") + "," + Eval("Id") %>' CommandName="pay" Visible="false" CssClass="btn btn-sm btn-success material-tooltip-md">
                                            Send payment<i class="fas fas-dollar-sign ml-2"></i></asp:LinkButton>

                                                            <asp:LinkButton runat="server" ID="btnCancel" CommandArgument='<%#Eval("Id") + "," + Eval("uid") + "," + Eval("sid") %>' CommandName="cancel" Visible="false" CssClass="btn btn-sm btn-danger">Cancel request<i class="fas fa-times ml-2"></i>
                                                            </asp:LinkButton>

                                                            <p runat="server" id="await" visible="false">Awaiting completion of request</p>

                                                            <p runat="server" id="completed" visible="false">Request completed</p>

                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </tbody>
                            </table>
                        </div>
                        <p runat="server" id="end" visible="false" class="text-center grey-text small font-weight-bold mb-0">End of contents</p>
                    </div>
                </div>
            </div>

            <div class="col-12 col-md-3 my-4 my-md-0 order-0 order-md-1">
                <div class="card">
                    <div class="view primary-light-gradient py-2 mx-4 mb-3 d-flex justify-content-center align-items-center text-center">
                        <span class="mx-3 font-weight-bold">Action</span>
                    </div>

                    <div class="card-body">
                        <div class="md-form md-outline my-0">
                            <input id="action-search-input" class="form-control" type="text" name="search">
                            <label for="action-search-input">Search Request</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
