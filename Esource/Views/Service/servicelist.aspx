<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="servicelist.aspx.cs" Inherits="Esource.Views.Service.servicelist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="services">
        <asp:ScriptManager runat="server" ID="servscript">
        </asp:ScriptManager>
        <asp:HiddenField runat="server" ID="LblUid" />
        <div class="row">
            <div class="col-12 col-md-4 order-2 order-md-1 mt-2 mt-md-0">
                <div id="filter">
                    <select class="md-form md-outline category-select custom-select">
                        <option selected>Show All</option>
                        <option>Graphics &amp; Design</option>
                        <option>Writing &amp; Translation</option>
                        <option>Video &amp; Animation</option>
                        <option>Music &amp; Audio</option>
                        <option>Programming &amp; Tech</option>
                    </select>
                </div>
            </div>
            <div class="col-12 col-md-4 order-3 order-md-2">
                <div id="sort">
                    <select class="md-form md-outline sort-select custom-select">
                        <option selected disabled>None</option>
                        <option>Oldest first</option>
                        <option>Newest first</option>
                        <option>Most Viewed</option>
                        <option>Most Popular</option>
                    </select>
                </div>
            </div>
            <div class="col-12 col-md-4 order-1 order-md-3 mt-2 mt-md-0">
                <div class="input-group md-form md-outline">
                    <input id="search" class="form-control" type="text" name="search" placeholder="Search by title">
                    <div class="input-group-append">
                        <button class="btn btn-md btn-info m-0 px-3 py-2 waves-effect" type="button" id="searchbut">
                            <i class="fas fa-search"></i>
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <asp:UpdatePanel runat="server" ID="servpanel" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="row" id="servcon">
                    <asp:Repeater runat="server" ID="servList" OnItemCommand="servList_ItemCommand" OnItemDataBound="servList_ItemDataBound">
                        <ItemTemplate>
                            <div class="servicecards col-12 col-md-4 col-lg-3 d-flex align-items-stretch mt-4 <%#Eval("categories") %>" data-id="<%#Eval("Id") %>" data-views="<%#Eval("views") %>" data-favs="<%#Eval("favs") %>">
                                <div class="card w-100">
                                    <div class="view overlay border-bottom border-primary rounded-top">
                                        <asp:HiddenField runat="server" ID="img_path" Value='<%#Eval("img_path") %>' />
                                        <asp:Image runat="server" ID="poster" CssClass="card-img-top"/>
                                        <a><div class="mask rgba-black-light"></div></a>
                                    </div>
                                    <div class="ml-auto mr-3 mt-2">
                                        <asp:LinkButton runat="server" CssClass="btn-primary btn-sm m-0" data-tooltip="tooltip"
                                            data-placement="top" title="View More Details" CommandName="view" CommandArgument='<%#Eval("Id") %>'>
                                            <i class="fas fa-eye"></i>
                                        </asp:LinkButton>
                                    </div>
                                    <div class="card-body d-flex flex-column">

                                        <div class="d-flex mt-2">
                                            <div class="flex-fill">
                                                <img src="<%#Eval("profile_src") %>" onerror="this.src='<%= Page.ResolveUrl("~/Content/img/placeholder.jpg") %>'" class="rounded-circle img-fluid z-depth-1 avatar" style="max-width: 2rem;" />
                                                <asp:LinkButton runat="server" CssClass="align-middle ml-1" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'>Username</asp:LinkButton>
                                            </div>
                                            <div class="d-flex align-items-center">
                                                <span class="text-muted small">
                                                    <i class="fas fa-clock mr-2"></i><%#Eval("date_created") %>
                                                </span>
                                            </div>
                                        </div>

                                        <div class="d-flex mt-4">
                                            <div class="flex-fill">
                                                <h4 class="name card-title mb-0" data-name="<%#Eval("name") %>"><%#Eval("name") %></h4>
                                            </div>

                                            <div class="d-flex align-items-center font-weight-bold ml-3">
                                                <%#Eval("views") %><i class="far fa-eye ml-2"></i>
                                            </div>
                                        </div>

                                        <hr class="w-100" />
                                        <div class="flex-fill">
                                            <p class="card-text">
                                                <%#Eval("desc") %>
                                            </p>
                                        </div>
                                
                                        <div class="d-flex">
                                            <div class="flex-fill text-right">
                                                <asp:LinkButton runat="server" CssClass="btn btn-sm btn-red mr-0" CommandName="favourite" CommandArgument='<%#Eval("Id") %>'
                                                    data-tooltip="tooltip" title="Like service">
                                                    <span class="font-weight-bold">
                                                        <%#Eval("favs") %>
                                                        <i class="fas fa-heart ml-2"></i>
                                                    </span> 
                                                </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="card-footer accent-2 white-text deep-purple text-center">
                                        <h5 class="m-0">
                                            $<%#Eval("price") %></h5>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="mt-4">
            <h3 runat="server" id="LbErr" visible="false" class="font-weight-bold text-center">No services at the moment</h3>
        </div>
    </section>
    <script src="<%=Page.ResolveUrl("~/Scripts/servicescript.js") %>" type="text/javascript"></script>
</asp:Content>
