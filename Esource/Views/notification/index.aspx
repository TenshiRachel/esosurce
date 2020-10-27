<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Esource.Views.notification.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="notifications">
        <h1 class="col-12 text-center">Notifications</h1>
        <div class="col-lg-10 col-sm-12 mx-auto">
            <ul class="nav nav-tabs rounded-0" role="tablist">
                <li class="nav-item ml-0">
                    <a class="nav-link active show waves-light" data-toggle="tab" role="tab" href="#favnotifs"
                        aria-selected="false" aria-controls="favnotifs">
                        Likes
                        <span runat="server" id="favalert" visible="false" class="font-weight-bold text-danger">!</span>
                    </a>
                </li>
                <li class="nav-item ml-0">
                    <a class="nav-link waves-light" data-toggle="tab" role="tab" href="#jnotifs" 
                        aria-selected="false" aria-controls="jnotifs">
                        Jobs
                        <span runat="server" id="jobalert" visible="false" class="font-weight-bold text-danger">!</span>
                    </a>
                </li>
                <li class="nav-item ml-0">
                    <a class="nav-link waves-light" data-toggle="tab" role="tab" href="#fnotifs"
                        aria-selected="false" aria-controls="fnotifs">
                        Files
                        <span id="falert" runat="server" visible="false" class="font-weight-bold text-danger">!</span>
                    </a>
                </li>
                <li class="nav-item ml-0">
                    <a class="nav-link waves-light" data-toggle="tab" role="tab" href="#rnotifs"
                        aria-selected="false" aria-controls="rnotifs">
                        Requests
                        <span id="ralert" runat="server" visible="false" class="font-weight-bold text-danger">!</span>
                    </a>
                </li>
            </ul>
            <div class="tab-content p-0">
                <div class="tab-pane fade active show" id="favnotifs" role="tabpanel" aria-labelledby="favnotifs">
                    <div class="row justify-content-center mx-auto p-2 col-12">
                        <div runat="server" id="favclear" class="col-12 row justify-content-end mx-auto" visible="false">
                            <asp:LinkButton runat="server" CssClass="ml-auto btn btn-secondary" CommandArgument="fav" OnCommand="clearAll">
                                Clear All
                            </asp:LinkButton>
                        </div>
                        <asp:Repeater runat="server" ID="favs" OnItemCommand="favs_ItemCommand" OnItemDataBound="favs_ItemDataBound">
                            <ItemTemplate>
                                <div id="notif<%#Eval("Id") %>" class="col-12 row justify-content-between z-depth-1 my-2">
                                    <div class="col-8 row mx-auto my-3">
                                        <div class="pl-2 align-self-center pt-1">
                                            <h5>
                                                <asp:LinkButton runat="server" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'><%#Eval("username") %></asp:LinkButton> favourited
                                                <asp:LinkButton runat="server" CommandName="viewservice" CommandArgument='<%#Eval("pid") %>'><%#Eval("title") %></asp:LinkButton>
                                            </h5>
                                        </div>
                                    </div>
                                    <div class="col-2 align-self-center pt-2 row justify-content-end mx-auto">
                                        <h6 class="text-muted text-right">
                                            <%#Eval("date_created") %>
                                        </h6>
                                    </div>
                                    <asp:LinkButton runat="server" CssClass="close mx-auto align-self-center" CommandName="clear" CommandArgument='<%#Eval("Id") %>'>
                                        <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="text-center mt-2">
                                    <h4>
                                        <asp:Label runat="server" ID="LbErr" Text="No Notifications" Visible="false"></asp:Label>
                                    </h4>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="tab-pane fade" id="jnotifs" role="tabpanel" aria-labelledby="jnotifs">
                    <div class="row justify-content-center mx-auto p-2 col-12">
                        <div runat="server" id="jobclear" class="col-12 row justify-content-end mx-auto" visible="false">
                            <asp:LinkButton runat="server" CssClass="ml-auto btn btn-secondary" CommandArgument="job" OnCommand="clearAll">
                                Clear All
                            </asp:LinkButton>
                        </div>
                        <asp:Repeater runat="server" ID="jobs" OnItemCommand="jobs_ItemCommand" OnItemDataBound="jobs_ItemDataBound">
                            <ItemTemplate>
                                <div id="notif<%#Eval("Id") %>" class="col-12 row justify-content-between z-depth-1 my-2">
                                    <div class="col-8 row mx-auto my-3">
                                        <div class="pl-2 align-self-center pt-1">
                                            <h5>
                                                <asp:LinkButton runat="server" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'><%#Eval("username") %></asp:LinkButton> requested your service
                                                <asp:LinkButton runat="server" CommandName="viewservice" CommandArgument='<%#Eval("pid") %>'><%#Eval("title") %></asp:LinkButton>
                                                <br />
                                                <asp:LinkButton CssClass="small" runat="server" CommandName="viewjob">Please check job dashboard</asp:LinkButton>
                                            </h5>
                                        </div>
                                    </div>
                                    <div class="col-2 align-self-center pt-2 row justify-content-end mx-auto">
                                        <h6 class="text-muted text-right">
                                            <%#Eval("date_created") %>
                                        </h6>
                                    </div>
                                    <asp:LinkButton runat="server" CssClass="close mx-auto align-self-center" CommandName="clear" CommandArgument='<%#Eval("Id") %>'>
                                        <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="text-center mt-2">
                                    <h4>
                                        <asp:Label runat="server" ID="LbErr" Text="No Notifications" Visible="false"></asp:Label>
                                    </h4>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="tab-pane fade" id="fnotifs" role="tabpanel" aria-labelledby="fnotifs">
                    <div class="row justify-content-center mx-auto p-2 col-12">
                        <div runat="server" id="fileclear" class="col-12 row justify-content-end mx-auto" visible="true">
                            <asp:LinkButton runat="server" CssClass="ml-auto btn btn-secondary" CommandArgument="file" OnCommand="clearAll">
                                Clear All
                            </asp:LinkButton>
                        </div>
                        <asp:Repeater runat="server" ID="files" OnItemCommand="files_ItemCommand" OnItemDataBound="files_ItemDataBound">
                            <ItemTemplate>
                                <div id="notif<%#Eval("Id") %>" class="col-12 row justify-content-between z-depth-1 my-2">
                                    <div class="col-8 row mx-auto my-3">
                                        <div class="pl-2 align-self-center pt-1">
                                            <h5>
                                                <asp:LinkButton runat="server" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'><%#Eval("username") %></asp:LinkButton> shared 
                                                <asp:LinkButton runat="server" CommandName="viewfile" CommandArgument='<%#Eval("pid") %>'><%#Eval("title") %></asp:LinkButton>
                                            </h5>
                                        </div>
                                    </div>
                                    <div class="col-2 align-self-center pt-2 row justify-content-end mx-auto">
                                        <h6 class="text-muted text-right">
                                            <%#Eval("date_created") %>
                                        </h6>
                                    </div>
                                    <asp:LinkButton runat="server" CssClass="close mx-auto align-self-center" CommandName="clear" CommandArgument='<%#Eval("Id") %>'>
                                        <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="text-center mt-2">
                                    <h4>
                                        <asp:Label runat="server" ID="LbErr" Text="No Notifications" Visible="false"></asp:Label>
                                    </h4>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="tab-pane fade" id="rnotifs" role="tabpanel" aria-labelledby="rnotifs">
                    <div class="row justify-content-center mx-auto p-2 col-12">
                        <div runat="server" id="reqclear" class="col-12 row justify-content-end mx-auto" visible="false">
                            <asp:LinkButton runat="server" CssClass="ml-auto btn btn-secondary" CommandArgument="request" OnCommand="clearAll">
                                Clear All
                            </asp:LinkButton>
                        </div>
                        <asp:Repeater runat="server" ID="requests" OnItemCommand="requests_ItemCommand" OnItemDataBound="requests_ItemDataBound">
                            <ItemTemplate>
                                <div id="notif<%#Eval("Id") %>" class="col-12 row justify-content-between z-depth-1 my-2">
                                    <div class="col-8 row mx-auto my-3">
                                        <div class="pl-2 align-self-center pt-1">
                                            <h5>
                                                <asp:LinkButton runat="server" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'><%#Eval("username") %></asp:LinkButton> completed your request of 
                                                <asp:LinkButton runat="server" CommandName="viewservice" CommandArgument='<%#Eval("pid") %>'><%#Eval("title") %></asp:LinkButton>
                                            </h5>
                                        </div>
                                    </div>
                                    <div class="col-2 align-self-center pt-2 row justify-content-end mx-auto">
                                        <h6 class="text-muted text-right">
                                            <%#Eval("date_created") %>
                                        </h6>
                                    </div>
                                    <asp:LinkButton runat="server" CssClass="close mx-auto align-self-center" CommandName="clear" CommandArgument='<%#Eval("Id") %>'>
                                        <span aria-hidden="true">&times;</span>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div class="text-center mt-2">
                                    <h4>
                                        <asp:Label runat="server" ID="LbErr" Text="No Notifications" Visible="false"></asp:Label>
                                    </h4>
                                </div>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
