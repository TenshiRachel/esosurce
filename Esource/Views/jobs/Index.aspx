<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Esource.Views.jobs.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="jobs">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:Label runat="server" ID="LblUid" Visible="false"></asp:Label>
        <div class="row">
            <div class="col-12 col-md-9 order-1 order-md-0">
                <div class="card">
                    <div
                        class="view view-cascade primary-light-gradient py-2 mx-4 mb-3 d-flex justify-content-center align-items-center text-center">
                        <h3 class=" mx-3">Jobs</h3>
                    </div>

                    <div class="card-body">
                        <div class="table-responsive table-hover w-100" style="padding: 0 15px;">
                            <table id="jobs-table" class="table table-striped text-center">
                                <thead class="deep-purple accent-3 white-text">
                                    <tr>
                                        <th id="client" class="th-sm rounded-top-left">Client</th>
                                        <th id="date" class="th-sm">Date Requested</th>
                                        <th id="service" class="th-sm">Service Name</th>
                                        <th id="payment" class="th-sm">Payment Amount</th>
                                        <th id="remarks" class="th-sm">Remarks</th>
                                        <th id="action" class="th-sm rounded-top-right">Action</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <asp:UpdatePanel runat="server" ID="jobPanel" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Repeater runat="server" ID="joblist" OnItemCommand="joblist_ItemCommand" OnItemDataBound="joblist_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr class="animated faster data-rows">
                                                        <td headers="client" class="align-middle">
                                                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("cid") %>' CommandName="viewprofile"><%#Eval("cName") %></asp:LinkButton>
                                                        </td>
                                                        <td headers="date" class="align-middle"><%#Eval("date_created") %></td>
                                                        <td headers="service" data-name='<%#Eval("sName") %>' class="align-middle name"><%#Eval("sName") %></td>
                                                        <td headers="payment" class="align-middle">$<%#Eval("price") %></td>
                                                        <td headers="remarks" class="align-middle"><%#Eval("remarks") %></td>
                                                        <td headers="action" class="align-middle">
                                                            <asp:HiddenField runat="server" ID="status" Value='<%#Eval("status") %>' />
                                                            <asp:LinkButton runat="server" ID="btnAccept" CommandArgument='<%#Eval("Id") + "," + Eval("sid") + "," + Eval("cid")%>' CommandName="accept" CssClass="btn btn-sm btn-success material-tooltip-md"
                                                                data-tooltip="tooltip" data-placement="top" title="Accept Job" Visible="false">
                                            Accept Job<i class="fas fa-check ml-2"></i></asp:LinkButton>
                                                            <asp:LinkButton runat="server" ID="btnReject" CommandArgument='<%#Eval("Id") + "," + Eval("sid") + "," + Eval("cid") %>' CommandName="reject" CssClass="btn btn-sm btn-danger material-tooltip-md"
                                                                data-tooltip="tooltip" data-placement="top" title="Reject Job" Visible="false">
                                            Reject Job<i class="fas fa-times ml-2"></i>
                                                            </asp:LinkButton>
                                                            <p runat="server" id="await" class="text-center grey-text small font-weight-bold mb-0" visible="false">Awaiting payment</p>
                                                            <asp:LinkButton runat="server" ID="btnSubmit" CommandArgument='<%#Eval("Id") + "," + Eval("sid") + "," + Eval("cid")Eval %>' CommandName="submit" CssClass="btn btn-sm btn-success material-tooltip-md"
                                                                data-tooltip="tooltip" data-placement="top" title="Submit Job" Visible="false">
                                            Job completed<i class="fas fa-check ml-2"></i></asp:LinkButton>
                                                            <p runat="server" id="completed" visible="false" class="text-center grey-text small font-weight-bold mb-0">Completed</p>
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
                    <div
                        class="view view-cascade primary-light-gradient narrower py-2 mx-4 mb-3 d-flex justify-content-center align-items-center text-center">
                        <h3 class=" mx-3">Action</h3>
                    </div>

                    <div class="card-body">
                        <div class="md-form md-outline my-0">
                            <input id="action-search-input" class="form-control" type="text" name="search">
                            <label for="action-search-input">Search Jobs</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
