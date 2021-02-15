<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Esource.Views.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <section class="home-hero">
        <div class="carousel slide carousel-fade z-depth-3" data-ride="carousel">
            <div class="carousel-inner" role="listbox">
                <div class="carousel-item active">
                    <div class="view">
                        <video class="video-fluid" autoplay loop muted>
                            <source src="<%=Page.ResolveUrl("~/Content/vid/home/forest.mp4") %>" type="video/mp4" />
                        </video>
                    </div>

                    <div class="carousel-caption d-flex align-items-center">
                        <div class="animated fadeInDown mask rgba-black-light rounded z-depth-1 p-4 w-100">
                            <h1 class="h1-responsive mb-0 mb-md-2">Welcome to OutSource</h1>
                            <p class="d-none d-md-block">
                                A platform for freelancers to offer services to clients worldwide.
                            </p>
                        </div>
                    </div>
                </div>

                <div class="carousel-item">
                    <div class="view">
                        <video class="video-fluid" autoplay loop muted>
                            <source src="<%=Page.ResolveUrl("~/Content/vid/home/photography.mp4") %>" type="video/mp4" />
                        </video>
                        <div class="mask rgba-deep-purple-light"></div>
                    </div>

                    <div class="carousel-caption d-flex align-items-center">
                        <div class="animated fadeInDown mask rgba-black-light rounded z-depth-1 p-4  w-100">
                            <h1 class="h1-responsive">Looking for Services?</h1>
                            <p class="d-none d-md-block">
                                Are you looking to hire someone for their services, look no further.<br />
                                OutSource provides you a platform where freelancers offer a wide range of services.
                            </p>

                            <a class="btn btn-md btn-primary" href="<%=Page.ResolveUrl("~/Views/service/servicelist.aspx") %>">
                                <i class="fas fa-eye"></i>View Marketplace
                            </a>
                        </div>
                    </div>
                </div>

                <div class="carousel-item">
                    <div class="view">
                        <video class="video-fluid" autoplay loop muted>
                            <source src="<%=Page.ResolveUrl("~/Content/vid/home/typing.mp4") %>" type="video/mp4" />
                        </video>
                        <div class="mask rgba-deep-purple-light"></div>
                    </div>

                    <div class="carousel-caption d-flex align-items-center">
                        <div class="animated fadeInDown mask rgba-black-light rounded z-depth-1 p-4  w-100">
                            <h1 class="h1-responsive">Register on OutSource</h1>
                            <p class="d-none d-md-block">
                                Register an account with us today as a service provider or as a client.<br />
                            </p>

                            <a class="btn btn-md btn-light-green" href="<%=Page.ResolveUrl("~/Views/auth/register.aspx") %>">
                                <i class="fas fa-user-plus"></i>Register
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="home">
        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <section class="service-favs deep-purple lighten-5 mx-n3 my-4 px-3 py-5 z-depth-1">
                    <h3 class="h3-responsive font-weight-bold text-center text-primary mb-4">Top Favourite Services
                    </h3>
                    <div class="row">
                        <asp:Repeater runat="server" ID="topServiceFavs" OnItemCommand="topServiceFavs_ItemCommand" OnItemDataBound="topServiceFavs_ItemDataBound">
                            <ItemTemplate>
                                <div class="col-12 col-md-3 d-flex align-items-stretch mt-4 mt-md-0">
                                    <div class="card-wrapper">
                                        <div id="" class="card card-rotating w-100">
                                            <div class="face front d-flex flex-column rounded">
                                                <div class="view overlay border-bottom border-primary rounded-top">
                                                    <asp:HiddenField runat="server" ID="serviceId" Value='<%#Eval("Id") %>' />
                                                    <asp:Image runat="server" ID="poster" CssClass="card-img-top" ImageUrl="~/Content/img/placeholder.jpg" />
                                                    <a>
                                                        <div class="mask rgba-black-light"></div>
                                                    </a>
                                                </div>

                                                <div class="btn-action text-right ml-auto mr-3">
                                                    <a class="rotate-btn btn-sm btn-primary m-0 mr-2 material-tooltip-sm" data-card="" data-tooltip="tooltip" data-placement="top" title="View User Info">
                                                        <i class="fas fa-id-card"></i>
                                                    </a>
                                                    <asp:LinkButton runat="server" CssClass="btn-primary btn-sm m-0 material-tooltip-sm" data-tooltip="tooltip" data-placement="top" title="View Service Details" CommandName="view" CommandArgument='<%#Eval("Id") %>'>
                                                <i class="fas fa-eye"></i>
                                                    </asp:LinkButton>
                                                </div>

                                                <div class="card-body d-flex flex-column">
                                                    <div class="d-flex mt-2">
                                                        <div class="flex-fill">
                                                            <asp:HiddenField runat="server" ID="provider_ID" Value='<%#Eval("uid") %>' />
                                                            <asp:Image runat="server" ID="userImg" CssClass="d-inline rounded-circle img-fluid z-depth-1" Style="max-width: 2rem;" />

                                                            <asp:LinkButton runat="server" CssClass="align-middle ml-1" CommandArgument='<%#Eval("uid") %>' CommandName="viewprofile"><%#Eval("username") %></asp:LinkButton>
                                                        </div>

                                                        <div class="d-flex align-items-center">
                                                            <span class="text-muted small">
                                                                <i class="fas fa-clock mr-2"></i><%#Eval("date_created") %>
                                                            </span>
                                                        </div>
                                                    </div>

                                                    <div class="d-flex mt-4">
                                                        <div class="flex-fill">
                                                            <h4 class="card-title mb-0"><%#Eval("name") %></h4>
                                                        </div>

                                                        <div class="d-flex align-items-center font-weight-bold ml-3">
                                                            <%#Eval("views") %><i class="fas fa-eye ml-2"></i>
                                                        </div>
                                                    </div>

                                                    <hr class="w-100">

                                                    <div class="flex-fill">
                                                        <p class="card-text">
                                                            <%#Eval("desc") %>
                                                        </p>
                                                    </div>

                                                    <div class="d-flex">
                                                        <asp:LinkButton runat="server" CommandName="fav" CommandArgument='<%#Eval("Id") %>' CssClass="btn btn-sm btn-red mr-0 material-tooltip-sm">
                                                        <span class="font-weight-bold"><%#Eval("favs") %><i class="fas fa-heart ml-2"></i>
                                                        </span>
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>

                                                <div class="card-footer deep-purple accent-3 white-text text-center">
                                                    $<%#Eval("price") %>
                                                </div>
                                            </div>

                                            <div class="face back d-flex flex-column rounded">
                                                <div class="view overlay border-bottom border-primary rounded-top">
                                                    <asp:Image runat="server" ImageUrl="~/Content/img/placeholder.jpg" CssClass="card-img-top" ID="userBanner" />
                                                    <a>
                                                        <div class="mask rgba-black-light"></div>
                                                    </a>
                                                </div>

                                                <div class="btn-action text-right ml-auto mr-3">
                                                    <a class="rotate-btn btn-sm btn-primary m-0 mr-2 material-tooltip-sm" data-card="" data-tooltip="tooltip" data-placement="top" title="View User Info">
                                                        <i class="fas fa-id-card"></i>
                                                    </a>
                                                    <asp:LinkButton runat="server" CssClass="btn-primary btn-sm m-0 material-tooltip-sm" data-tooltip="tooltip" data-placement="top" title="View User Profile" CommandArgument='<%#Eval("uid") %>' CommandName="viewprofile">
                                                <i class="fas fa-user-tie"></i>
                                                    </asp:LinkButton>
                                                </div>

                                                <div class="card-body d-flex flex-column">
                                                    <div class="d-flex mt-3">
                                                        <div class="flex-fill">
                                                            <h6 class="card-title mb-0">
                                                                <asp:Image runat="server" ID="profileImg" CssClass="d-inline img-fluid rounded-circle z-depth-1" Style="max-width: 2rem;" />

                                                                <asp:LinkButton runat="server" CssClass="align-middle ml-1" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'><%#Eval("username") %></asp:LinkButton>
                                                            </h6>
                                                        </div>

                                                        <div class="d-flex align-items-center">
                                                            <i class="fas fa-venus-mars fa-2x text-muted"></i>
                                                        </div>
                                                    </div>

                                                    <div class="d-flex mt-3">
                                                        <div class="flex-fill text-muted">
                                                            <asp:Label runat="server" ID="occupation" CssClass="card-title mb-0">
                                                                Freelancer
                                                            </asp:Label>
                                                        </div>

                                                        <div class="d-flex align-items-center text-muted ml-3">
                                                            <asp:Label runat="server" ID="country" CssClass="card-title mb-0">
                                                            </asp:Label>
                                                        </div>
                                                    </div>

                                                    <hr class="w-100">

                                                    <div class="flex-fill flex-center">
                                                        <asp:Label runat="server" ID="bio" CssClass="card-text">
                                                        </asp:Label>
                                                    </div>

                                                    <%--                                            {{#if this.user.skills}}
                                            <div class="d-flex text-center">
                                                <div class="flex-fill">
                                                    <h5 class="text-primary mb-0">Skills</h5>
                                                </div>
                                            </div>

                                            <hr class="w-100">

                                            <div class="d-flex text-center">
                                                <div class="flex-fill">
                                                    {{#each this.user.skills}}
                                                        <div class="chip chip-sm deep-purple accent-3 white-text">
                                                            {{this}}
                                                        </div>
                                                    {{/each}}
                                                </div>
                                            </div>
                                            {{/if}}--%>
                                                </div>

                                                <div class="card-footer d-flex deep-purple accent-3 white-text">
                                                    <div class="flex-fill">
                                                        <i class="fas fa-globe-asia"></i>
                                                        <i class="fas fa-envelope"></i>
                                                    </div>

                                                    <div class="flex-fill text-right">
                                                        <a runat="server" id="website" class="white-text" href="#"></a>
                                                        <a runat="server" id="useremail" class="white-text" href="#"></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="col-12" runat="server" id="servFavErr" visible="false">
                            <h1 class="h1-responsive font-weight-bold text-center text-danger my-4">
                                <i class="fas fa-exclamation-triangle fa-3x"></i>
                            </h1>
                            <h1 class="h1-responsive font-weight-bold text-center text-muted">No Services To Display
                            </h1>
                        </div>
                    </div>
                </section>
                <section runat="server" id="servViewsSection" class="mask rgba-deep-purple-light service-views view z-depth-2 mx-n3 my-4 px-3 pb-5 pt-9 z-depth-1" data-jarallax-video="mp4:/vid/home_parallax/1.mp4">
                    <h3 class="h3-responsive font-weight-bold text-center text-white mb-4 p-3">Top Viewed Services
                    </h3>
                    <div runat="server" id="servViewsDiv" class="row">
                        <asp:Repeater runat="server" ID="topViewServ" OnItemCommand="topViewServ_ItemCommand" OnItemDataBound="topViewServ_ItemDataBound">
                            <ItemTemplate>
                                <div class="col-12 col-md-3 d-flex align-items-stretch mt-4 mt-md-0">
                                    <div class="card-wrapper">
                                        <div id="" class="card card-rotating z-depth-3 w-100">
                                            <div class="face front d-flex flex-column rounded">
                                                <div class="view overlay border-bottom border-primary rounded-top">
                                                    <asp:HiddenField runat="server" ID="serviceId" Value='<%#Eval("Id") %>' />
                                                    <asp:Image runat="server" ID="poster" CssClass="card-img-top" ImageUrl="~/Content/img/placeholder.jpg" />
                                                    <a>
                                                        <div class="mask rgba-black-light"></div>
                                                    </a>
                                                </div>

                                                <div class="btn-action text-right ml-auto mr-3">
                                                    <a class="rotate-btn btn-sm btn-primary m-0 mr-2 material-tooltip-sm" data-card="" data-tooltip="tooltip" data-placement="top" title="View User Info">
                                                        <i class="fas fa-id-card"></i>
                                                    </a>
                                                    <asp:LinkButton runat="server" CssClass="btn-sm btn-primary m-0 material-tooltip-sm" data-tooltip="tooltip" data-placement="top" title="View Service Details" CommandName="view" CommandArgument='<%#Eval("Id") %>'>
                                                <i class="fas fa-eye"></i>
                                                    </asp:LinkButton>
                                                </div>

                                                <div class="card-body d-flex flex-column">
                                                    <div class="d-flex mt-2">
                                                        <div class="flex-fill">
                                                            <asp:HiddenField runat="server" ID="provider_ID" Value='<%#Eval("uid") %>' />
                                                            <asp:Image runat="server" ID="userImg" CssClass="d-inline rounded-circle img-fluid z-depth-1" Style="max-width: 2rem;" />

                                                            <asp:LinkButton runat="server" CssClass="align-middle ml-1" CommandArgument='<%#Eval("uid") %>' CommandName="viewprofile"><%#Eval("username") %></asp:LinkButton>
                                                        </div>

                                                        <div class="d-flex align-items-center">
                                                            <span class="text-muted small">
                                                                <i class="fas fa-clock mr-2"></i><%#Eval("date_created") %>
                                                            </span>
                                                        </div>
                                                    </div>

                                                    <div class="d-flex mt-4">
                                                        <div class="flex-fill">
                                                            <h4 class="card-title mb-0"><%#Eval("name") %></h4>
                                                        </div>

                                                        <div class="d-flex align-items-center font-weight-bold ml-3">
                                                            <%#Eval("views") %><i class="fas fa-eye ml-2"></i>
                                                        </div>
                                                    </div>

                                                    <hr class="w-100">

                                                    <div class="flex-fill">
                                                        <p class="card-text">
                                                            <%#Eval("desc") %>
                                                        </p>
                                                    </div>

                                                    <div class="d-flex">
                                                        <asp:LinkButton runat="server" CssClass="btn btn-sm btn-red mr-0 material-tooltip-sm" CommandArgument='<%#Eval("Id") %>' CommandName="fav" data-tooltip="tooltip" data-placement="top" title="Favourite/Unfavourite">
                                                        <span class="font-weight-bold"><%#Eval("favs") %><i class="fas fa-heart ml-2"></i>
                                                        </span>
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>

                                                <div class="card-footer deep-purple accent-3 white-text text-center">
                                                    $<%#Eval("price") %>
                                                </div>
                                            </div>

                                            <div class="face back d-flex flex-column rounded">
                                                <div class="view overlay border-bottom border-primary rounded-top">
                                                    <asp:Image runat="server" ImageUrl="~/Content/img/placeholder.jpg" CssClass="card-img-top" ID="userBanner" />

                                                    <a>
                                                        <div class="mask rgba-black-light"></div>
                                                    </a>
                                                </div>

                                                <div class="btn-action text-right ml-auto mr-3">
                                                    <a class="rotate-btn btn-sm btn-primary m-0 mr-2 material-tooltip-sm" data-card="" data-tooltip="tooltip" data-placement="top" title="View User Info">
                                                        <i class="fas fa-id-card"></i>
                                                    </a>
                                                    <asp:LinkButton runat="server" CssClass="btn-primary btn-sm m-0 material-tooltip-sm" data-tooltip="tooltip" data-placement="top" title="View User Profile" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'>
                                                        <i class="fas fa-user-tie"></i>
                                                    </asp:LinkButton>
                                                </div>

                                                <div class="card-body d-flex flex-column">
                                                    <div class="d-flex mt-3">
                                                        <div class="flex-fill">
                                                            <asp:Image runat="server" ID="profileImg" CssClass="d-inline img-fluid rounded-circle z-depth-1" Style="max-width: 2rem;" />

                                                            <asp:LinkButton runat="server" CssClass="align-middle ml-1" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'><%#Eval("username") %></asp:LinkButton>
                                                            </h6>
                                                        </div>

                                                        <div class="d-flex align-items-center">
                                                            <i class="fas fa-venus-mars fa-2x text-muted"></i>
                                                        </div>
                                                    </div>

                                                    <div class="d-flex mt-3">
                                                        <div class="flex-fill text-muted">
                                                            <asp:Label runat="server" ID="occupation" CssClass="card-title mb-0">
                                                                Freelancer
                                                            </asp:Label>
                                                        </div>

                                                        <div class="d-flex align-items-center text-muted ml-3">
                                                            <asp:Label runat="server" ID="country" CssClass="card-title mb-0">
                                                            </asp:Label>
                                                        </div>
                                                    </div>

                                                    <hr class="w-100">

                                                    <div class="flex-fill flex-center">
                                                        <asp:Label runat="server" ID="bio" CssClass="card-text">
                                                        </asp:Label>
                                                    </div>

                                                    <%--{{#if this.user.skills}}
                                            <div class="d-flex text-center">
                                                <div class="flex-fill">
                                                    <h5 class="text-primary mb-0">Skills</h5>
                                                </div>
                                            </div>

                                            <hr class="w-100">

                                            <div class="d-flex text-center">
                                                <div class="flex-fill">
                                                    {{#each this.user.skills}}
                                                        <div class="chip chip-sm deep-purple accent-3 white-text">
                                                            {{this}}
                                                        </div>
                                                    {{/each}}
                                                </div>
                                            </div>
                                            {{/if}}--%>
                                                </div>

                                                <div class="card-footer d-flex deep-purple accent-3 white-text">
                                                    <div class="flex-fill">
                                                        <i class="fas fa-globe-asia"></i>
                                                        <i class="fas fa-envelope"></i>
                                                    </div>

                                                    <div class="flex-fill text-right">
                                                        <a runat="server" id="website" class="white-text" href="#"></a>
                                                        <a runat="server" id="useremail" class="white-text" href="#"></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="col-12" id="servViewErr" runat="server" visible="false">
                            <h1 class="h1-responsive font-weight-bold text-center text-danger my-4">
                                <i class="fas fa-exclamation-triangle fa-3x"></i>
                            </h1>
                            <h1 class="h1-responsive font-weight-bold text-center text-white">No Services To Display
                            </h1>
                        </div>
                    </div>
                </section>
            </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>
