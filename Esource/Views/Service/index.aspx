<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Esource.Views.service.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="viewserv container mx-auto">
        <asp:HiddenField runat="server" ID="LblUid" />
        <div class="col-10 mx-auto row justify-content-around">
                    <asp:Repeater runat="server" ID="serviceview" OnItemCommand="serviceview_ItemCommand" OnItemDataBound="serviceview_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-lg-6">
                                <div>
                                    <div class="card w-100">

                                        <div class="view overlay border-bottom border-primary rounded-top">
                                            <asp:HiddenField runat="server" ID="img_path" Value='<%#Eval("img_path") %>'></asp:HiddenField>
                                            <asp:Image runat="server" ID="poster" CssClass="card-img-top" alt='<%#Eval("name") %>' />
                                            <a>
                                                <div class="mask rgba-black-light"></div>
                                            </a>
                                        </div>

                                        <div class="card-body d-flex flex-column">

                                            <div class="d-flex mt-2">
                                                <div class="d-flex align-items-center">
                                                    <span class="text-muted small">
                                                        <i class="far fa-clock mr-2"></i><%#Eval("date_created") %>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="d-flex mt-4">
                                                <div class="flex-fill">
                                                    <h4 class="card-title mb-0"><%#Eval("name") %></h4>
                                                </div>

                                                <div class="d-flex align-items-center font-weight-bold ml-3">
                                                    <%#Eval("views") %><i class="far fa-eye ml-2"></i>
                                                </div>
                                            </div>

                                            <hr class="w-100">

                                            <div class="flex-fill">
                                                <p class="card-text">
                                                    <%#Eval("desc") %>
                                                </p>
                                            </div>

                                            <div class="remarks">
                                                <div class="md-form md-outline">
                                                    <asp:Label runat="server" AssociatedControlID="tbRemarks" Text="Remarks" CssClass="font-italic card-text"></asp:Label>
                                                    <asp:TextBox runat="server" ID="tbRemarks" CssClass="form-control" TextMode="MultiLine" Rows="7"></asp:TextBox>
                                                </div>
                                                <div class="text-right">
                                                    <asp:LinkButton runat="server" CssClass="btn btn-success" CommandName="request" CommandArgument='<%#Eval("uid") %>'>Request Service</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="card-footer deep-purple accent-2 white-text text-center">
                                            <h5 class="m-0">
                                                $<%#Eval("price") %>
                                            </h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <div class="user-overview">
                                    <asp:HiddenField runat="server" ID="LblFid" Value='<%#Eval("uid") %>' />
                                    <div class="card">
                                        <div style="height:auto;" class="indigo view lighten-1 rounded-0">
                                            <img class="img-fluid" src="#" onerror="this.src='<%=Page.ResolveUrl("~/Content/img/placeholder.jpg") %>'" />
                                            <div class="mask flex-center waves-effect waves-light"></div>
                                        </div>

                                        <div class="avatar mx-auto white mt-4">
                                            <img onerror="this.src='<%= Page.ResolveUrl("~/Content/img/placeholder.jpg") %>'"
                                                src="<%#Eval("profile_src") %>" class="rounded-circle avatar" alt="" style="max-width: 2rem;">
                                        </div>

                                        <div class="card-body">
                                            <asp:LinkButton runat="server" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'>
                                                <h3 class="card-title"><%#Eval("username") %></h3>
                                            </asp:LinkButton>
                                            <h5 class="card-title text-muted">
                                                Service Provider
                                            </h5>
                                            <br>
                                            <p class="text-left"> <b>Followers:</b> 0</p>
                                            <p class="text-left"> <b>Following:</b> 0</p>
                                            <hr class="hr-primary">

                                            <p class="text-left"><b>Email:</b> <asp:Label runat="server" ID="email"></asp:Label></p>

                                            <hr class="hr-primary">

                                            <br />
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
        </section>
</asp:Content>
