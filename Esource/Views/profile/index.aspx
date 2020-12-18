<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Esource.Views.profile.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="profile">
        <asp:ScriptManager runat="server" ID="servscript">
        </asp:ScriptManager>
        <asp:Label runat="server" ID="LblUid" Visible="false"></asp:Label>
        <div class="card testimonial-card z-depth-2">
            <!-- =============================== Banner Image =============================== -->
            <div class="card-up indigo lighten-1 rounded-0 jarallax">
                <img loading="lazy" class="img-fluid jarallax-img " onerror='this.src="/img/profile/banner.png"'
                    src="/uploads/profile/{{user.id}}/banner.png" alt="">
                <div class="mask flex-center waves-effect waves-light">
                    <div class="h-100 w-100 col-12 align-items-end row justify-content-end p-0">
                        <div id="socialmedias" class="d-flex justify-content-center p-1 mr-2">
                            <a href="{{social_medias.[0]}}" class="col text-center "><i
                                class="fab fa-twitter fa-2x text-white text-center"></i></a>
                            <a href="{{social_medias.[1]}}" class="col text-center "><i
                                class="fab fa-instagram fa-2x text-white text-center"></i></a>
                            <a href="{{social_medias.[2]}}" class="col text-center "><i
                                class="fab fa-facebook fa-2x text-white text-center"></i></a>
                            <a href="{{social_medias.[3]}}" class="col text-center "><i
                                class="fab fa-youtube fa-2x text-white text-center"></i></a>
                            <a href="{{social_medias.[4]}}" class="col text-center "><i
                                class="fab fa-deviantart fa-2x text-white text-center"></i></a>
                        </div>
                    </div>
                </div>
            </div>

            <!-- =============================== Content =============================== -->
            <div class="card-body p-0">
                <div class="row justify-content-around">

                    <!-- =============================== User Information =============================== -->
                    <div class="col-lg-3 col-sm-12">
                        <div class="profile-margin">
                            <div class="card testimonial-card ">
                                <a href="<%=Page.ResolveUrl("~/Views/profile/edit.aspx") %>" class="m-2 ml-auto text-secondary">
                                    <i class="fas fa-edit fa-lg"></i>
                                </a>

                                <!-- Profile Image -->
                                <div class="avatar mx-auto white mt-4">
                                    <img loading="lazy" onerror='this.src = "/img/profile/default.png"'
                                        src="/uploads/profile/{{user.id}}/profilePic.png"
                                        class="rounded-circle  border" alt="">
                                </div>

                                <!-- User Details -->
                                <div class="card-body">
                                    <h3 class="card-title" runat="server" id="currUsername"></h3>

                                    <h5 runat="server" id="usertype" class="card-title text-muted">Service Provider
                                    </h5>

                                    <br>
                                    <p class="text-left">
                                        Followers: <a href="#" runat="server" id="followers" class="font-weight-bold" data-toggle="modal"
                                            data-target="#followersModal"></a>
                                    </p>

                                    <p class="text-left" runat="server">
                                        Following: <a href="#" runat="server" id="following" class="font-weight-bold" data-toggle="modal"
                                            data-target="#followingModal"></a>
                                    </p>
                                    <hr class="hr-primary">

                                    <p class="text-left">
                                        <b>Website:</b>
                                        <span runat="server" id="website" class="text-muted"></span>
                                    </p>

                                    <p class="text-left">
                                        <b>Birthday:</b>
                                        <span runat="server" id="dob" class="text-muted"></span>
                                    </p>

                                    <p class="text-left">
                                        <b>Gender:</b>
                                        <span runat="server" id="gender" class="text-muted"></span>
                                    </p>

                                    <p class="text-left">
                                        <b>Location:</b>
                                        <span runat="server" id="location" class="text-muted"></span>
                                    </p>

                                    <p class="text-left">
                                        <b>Occupation:</b>
                                        <span runat="server" id="occupation" class="text-muted"></span>
                                    </p>

                                    <p class="text-left"><b>Email:</b> <span runat="server" id="email"></span></p>

                                    <hr class="hr-primary">
                                </div>
                            </div>
                        </div>

                        <div class="card testimonial-card my-3">
                            <div class="card-body">
                                <h4 class="card-title text-left">Bio</h4>
                                <p runat="server" id="bio" class="text-left text-muted">
                                </p>
                                <hr class="hr-primary">
                                <h4 class="card-title text-left">Skills</h4>
                                <div class="row justify-content-start pl-2">
                                    <button type="button" class="btn btn-outline-secondary btn-rounded waves-effect skill-button">EDIT</button>
                                    <p class="text-left text-muted">
                                        Not Set
                                    </p>
                                </div>

                                <hr class="hr-primary">
                            </div>
                        </div>
                    </div>
                    <!-- =============================== User Content =============================== -->
                    <div class="classic-tabs col-lg-8 col-sm-12">
                        <ul class="nav tabs-white rounded-0" id="myClassicTabShadow" role="tablist">
                            <li class="nav-item m-0">
                                <a class="nav-link waves-light active show" id="portfolio-tab-classic-shadow"
                                    data-toggle="tab" href="#portfolio-classic-shadow" role="tab"
                                    aria-controls="portfolio-classic-shadow" aria-selected="true">Portfolio</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link waves-light" id="services-tab-classic-shadow" data-toggle="tab"
                                    href="#services-classic-shadow" role="tab" aria-controls="services-classic-shadow"
                                    aria-selected="false">Services </a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link waves-light" id="status-tab-classic-shadow" data-toggle="tab"
                                    href="#status-classic-shadow" role="tab" aria-controls="status-classic-shadow"
                                    aria-selected="false">Status </a>
                            </li>

                            <li class="nav-item">
                                <a class="nav-link waves-light" id="favs-tab-classic-shadow" data-toggle="tab"
                                    href="#favs-classic-shadow" role="tab" aria-controls="favs-classic-shadow"
                                    aria-selected="false">Favourites </a>
                            </li>

                            <li class="nav-item">
                                <a class="nav-link waves-light" id="likes-tab-classic-shadow" data-toggle="tab"
                                    href="#likes-classic-shadow" role="tab" aria-controls="likes-classic-shadow"
                                    aria-selected="false">Likes </a>
                            </li>
                        </ul>
                        <div class="tab-content min-vh-80 p-0" id="myClassicTabContentShadow">
                            <div class="tab-pane fade active show profile-content" id="portfolio-classic-shadow"
                                role="tabpanel" aria-labelledby="portfolio-tab-classic-shadow">
                                <div class="accordion md-accordion" id="accordionEx4" role="tablist" aria-multiselectable="true">
                                    <div class="card">
                                        <!-- Card body -->
                                        <div id="collapsePortfolio4" class="collapse show" role="tabpanel" aria-labelledby="headingPortfolio4"
                                            data-parent="#accordionEx4">
                                            <div class="card-body">
                                                <div class="row justify-content-start">
                                                    <div class="col-sm-5 col-lg-4 py-0 px-1">
                                                        <div class="portoflio-img-sm view overlay mb-1 rounded border border-depth-2 p-0">
                                                            <div class="h-100 row mx-auto">
                                                                <div class="col align-self-center text-center">
                                                                    <i class="fa fa-plus fa-7x" aria-hidden="true"></i>
                                                                </div>
                                                            </div>
                                                            <a href="/profile/submit">
                                                                <div class="mask flex-center waves-effect waves-light rgba-black-light">
                                                                    <h2 class="text-white">Add Project</h2>
                                                                </div>
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <asp:Repeater runat="server" ID="projects">
                                                        <ItemTemplate>
                                                            <div class="col-sm-5 col-lg-4 py-0 px-1">
                                                                <div class="portoflio-img-sm view overlay mb-1 rounded border p-0" data-toggle="modal"
                                                                    data-target="#project{{id}}">
                                                                    <img loading="lazy" src="/uploads/profile/{{uid}}/projects/{{id}}.png"
                                                                        class="h-100 mx-auto d-block" alt="">

                                                                    <div id="viewproject{{id}}" onclick="viewProject({{id}})"
                                                                        class="mask flex-center waves-effect waves-light rgba-black-strong">
                                                                        <div
                                                                            class="row col-12 align-items-end justify-content-end justify-content-around p-0 h-100">

                                                                            <div class="row col-12 justify-content-between p-0">
                                                                                <h5 class="col-12 text-white text-left font-weight-bold">{{title}}
                                                                                </h5>
                                                                                <h6 style="font-size: 2vh;" class="col-6 white-text text-left font-weight-bold">{{#if ../viewuser.id}}
                                            {{../viewuser.username}}
                                            {{else}}
                                            {{../user.username}}
                                            {{/if}}
                                                                                </h6>
                                                                                <h6 class="white-text text-right col-6">
                                                                                    <i class="far fa-heart"></i>
                                                                                    {{#if likes}}
                                            {{getNum likes}}
                                            {{else}}
                                            0
                                            {{/if}}&nbsp;
                                            <i class="fas fa-comment"></i>
                                                                                    {{#if comments}}
                                            {{comments.length}}
                                            {{else}}
                                            0
                                            {{/if}}
                                                                                </h6>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <div class="row justify-content-center">
                                                    <h1 class="my-5 py-5">This user has no Projects</h1>
                                                    <h1></h1>
                                                </div>
                                                <%--                                                    <div class="row justify-content-start">
                                                        <div class="col-sm-5 col-lg-4 py-0 px-1">
                                                            <div class="portoflio-img-sm view overlay mb-1 rounded border border-depth-2 p-0">
                                                                <div class="h-100 row mx-auto">
                                                                    <div class="col align-self-center">
                                                                        <i class="fa fa-plus fa-7x" aria-hidden="true"></i>

                                                                    </div>
                                                                </div>
                                                                <a href="/profile/submit">
                                                                    <div class="mask flex-center waves-effect waves-light rgba-black-light">
                                                                        <h2 class="text-white">Add Project</h2>

                                                                    </div>
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade profile-content" id="services-classic-shadow" role="tabpanel"
                            aria-labelledby="services-tab-classic-shadow">
                            <asp:UpdatePanel runat="server" ID="servpanel" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row" id="servcon">
                                        <asp:Repeater runat="server" ID="servList" OnItemCommand="servList_ItemCommand" OnItemDataBound="servList_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="servicecards col-12 col-md-4 col-lg-4 d-flex align-items-stretch mt-4 <%#Eval("categories") %>" data-id="<%#Eval("Id") %>" data-views="<%#Eval("views") %>" data-favs="<%#Eval("favs") %>">
                                                    <div class="card w-100">
                                                        <div class="view overlay border-bottom border-primary rounded-top">
                                                            <asp:HiddenField runat="server" ID="img_path" Value='<%#Eval("img_path") %>' />
                                                            <asp:Image runat="server" ID="poster" CssClass="card-img-top" />
                                                            <a>
                                                                <div class="mask rgba-black-light"></div>
                                                            </a>
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
                                                                    <asp:LinkButton runat="server" CssClass="align-middle ml-1" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'><%#Eval("username") %></asp:LinkButton>
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
                                                            <h5 class="m-0">$<%#Eval("price") %></h5>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="tab-pane fade profile-content" id="status-classic-shadow" role="tabpanel"
                            aria-labelledby="status-tab-classic-shadow">
                        </div>
                        <div class="tab-pane fade profile-content" id="favs-classic-shadow" role="tabpanel"
                            aria-labelledby="favs-tab-classic-shadow">
                            <asp:UpdatePanel runat="server" ID="favPanel" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row" id="servcon">
                                        <asp:Repeater runat="server" ID="favList" OnItemCommand="favList_ItemCommand" OnItemDataBound="servList_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="servicecards col-12 col-md-4 col-lg-4 d-flex align-items-stretch mt-4 <%#Eval("categories") %>" data-id="<%#Eval("Id") %>" data-views="<%#Eval("views") %>" data-favs="<%#Eval("favs") %>">
                                                    <div class="card w-100">
                                                        <div class="view overlay border-bottom border-primary rounded-top">
                                                            <asp:HiddenField runat="server" ID="img_path" Value='<%#Eval("img_path") %>' />
                                                            <asp:Image runat="server" ID="poster" CssClass="card-img-top" />
                                                            <a>
                                                                <div class="mask rgba-black-light"></div>
                                                            </a>
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
                                                                    <asp:LinkButton runat="server" CssClass="align-middle ml-1" CommandName="viewprofile" CommandArgument='<%#Eval("uid") %>'><%#Eval("username") %></asp:LinkButton>
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
                                                            <h5 class="m-0">$<%#Eval("price") %></h5>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="tab-pane fade profile-content" id="likes-classic-shadow" role="tabpanel"
                            aria-labelledby="likes-tab-classic-shadow">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
    </section>
</asp:Content>
