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
                <asp:Image runat="server" ID="userBanner" loading="lazy" CssClass="img-fluid jarallax-img " ImageUrl="~/Content/img/placeholder.jpg" />
                <div class="mask flex-center waves-effect waves-light">
                    <div class="h-100 w-100 col-12 align-items-end row justify-content-end p-0">
                        <div id="socialmedias" class="d-flex justify-content-center p-1">
                            <a href="#" runat="server" id="twitter" class="col text-center "><i
                                class="fab fa-twitter fa-2x text-white text-center"></i></a>
                            <a href="#" runat="server" id="insta" class="col text-center "><i
                                class="fab fa-instagram fa-2x text-white text-center"></i></a>
                            <a href="#" runat="server" id="facebook" class="col text-center "><i
                                class="fab fa-facebook fa-2x text-white text-center"></i></a>
                            <a href="#" runat="server" id="youtube" class="col text-center "><i
                                class="fab fa-youtube fa-2x text-white text-center"></i></a>
                            <a href="#" runat="server" id="deviant" class="col text-center "><i
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
                                    <asp:Image loading="lazy" runat="server" ID="userProfilePic" CssClass="rounded-circle  border" ImageUrl="~/Content/img/placeholder.jpg" />
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
                                    <asp:Repeater runat="server" ID="skillsRepeater">
                                        <ItemTemplate>
                                            <button type="button" class="btn btn-outline-secondary btn-rounded waves-effect skill-button"><%# Container.DataItem.ToString() %></button>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <p runat="server" id="noskill" visible="false" class="text-left text-muted">
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
                            <%if (getCurrUser().type == "freelancer")
                                { %>
                            <li class="nav-item">
                                <a class="nav-link waves-light" id="services-tab-classic-shadow" data-toggle="tab"
                                    href="#services-classic-shadow" role="tab" aria-controls="services-classic-shadow"
                                    aria-selected="false">Services </a>
                            </li>
                            <%} %>

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
                                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
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
                                                                    <a href="<%=Page.ResolveUrl("~/Views/profile/addProject.aspx") %>">
                                                                        <div class="mask flex-center waves-effect waves-light rgba-black-light">
                                                                            <h2 class="text-white">Add Project</h2>
                                                                        </div>
                                                                    </a>
                                                                </div>
                                                            </div>
                                                            <asp:Repeater runat="server" ID="projects" OnItemDataBound="projects_ItemDataBound" OnItemCommand="projects_ItemCommand">
                                                                <ItemTemplate>
                                                                    <div class="col-sm-5 col-lg-4 py-0 px-1">
                                                                        <asp:HiddenField runat="server" ID="projectId" Value='<%#Eval("Id") %>' />
                                                                        <div class="portoflio-img-sm view overlay mb-1 rounded border p-0" data-toggle="modal"
                                                                            data-target="#project<%#Eval("Id") %>">
                                                                            <asp:Image runat="server" ID="projCover" ImageUrl="~/Content/img/placeholder.jpg" CssClass="h-100 mx-auto d-block" />

                                                                            <div id="viewproject<%#Eval("Id") %>"
                                                                                class="mask flex-center waves-effect waves-light rgba-black-strong">
                                                                                <div class="row col-12 align-items-end justify-content-end justify-content-around p-0 h-100">

                                                                                    <div class="row col-12 justify-content-between p-0">
                                                                                        <h5 class="col-12 text-white text-left font-weight-bold"><%#Eval("title") %>
                                                                                        </h5>
                                                                                        <h6 runat="server" id="username" style="font-size: 2vh;" class="col-6 white-text text-left font-weight-bold"></h6>
                                                                                        <h6 class="white-text text-right col-6">
                                                                                            <i class="fas fa-heart"></i>
                                                                                            <%#Eval("likes") %>&nbsp;
                                            <i class="fas fa-comment"></i>
                                                                                            <%#Eval("comments") %>
                                                                                        </h6>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <section class="profile-modal">
                                                                                <div class="modal fade project" id="project<%#Eval("Id") %>" tabindex="-1" role="dialog" aria-labelledby="project<%#Eval("Id") %>Label"
                                                                                    aria-hidden="true" data-backdrop="false">

                                                                                    <div class="modal-dialog-project modal-dialog" role="document">
                                                                                        <div class="modal-content mt-5 p-0">

                                                                                            <div class="modal-header">
                                                                                                <div class="col-12 row justify-content-between">
                                                                                                    <div class="col-lg-3 col-sm-12 row justify-content-start pl-4">

                                                                                                        <div class="col-2 align-self-center p-0 h-100">
                                                                                                            <asp:Image runat="server" ID="projModalCover" ImageUrl="~/Content/img/placeholder.jpg" CssClass="white img-fluid rounded-circle  " />
                                                                                                        </div>

                                                                                                        <div class="col-8 align-self-center pl-3 h-100">
                                                                                                            <div class="row m-auto h-100 p-0">
                                                                                                                <h5 class="col-12 p-0 align-self-start text-left font-weight-bold"><%#Eval("title") %></h5>
                                                                                                                <a href="<%=Page.ResolveUrl("~/Views/profile/index.aspx") %>">
                                                                                                                    <h6 class="col-12 p-0 align-self-end text-left">
                                                                                                                        <asp:Label runat="server" ID="modal_username"></asp:Label>
                                                                                                                    </h6>
                                                                                                                </a>
                                                                                                            </div>

                                                                                                        </div>

                                                                                                    </div>

                                                                                                    <div class="col-lg-3 col-sm-12 row justify-content-end px-0">
                                                                                                        <div id="deleteButton" class="row justify-content-between">
                                                                                                            <asp:LinkButton CommandName="edit" CommandArgument='<%#Eval("Id") %>' runat="server" CssClass="btn btn-success justify-content-center">
                                                                                            <i class="fas fa-edit fa-lg"></i>&nbsp; Edit
                                                                                                            </asp:LinkButton>
                                                                                                            <a data-toggle="modal" data-target="#confirmDelete<%#Eval("Id") %>">
                                                                                                                <button type="button" class="btn btn-danger justify-content-center">
                                                                                                                    <i class="fas fa-trash-alt fa-lg"></i>&nbsp; Delete
                                                                                                                </button>
                                                                                                            </a>
                                                                                                        </div>
                                                                                                        <button type="button" class="close m-2" data-dismiss="modal" style="padding: 0 0 0 1rem !important;" aria-label="Close">
                                                                                                            <span aria-hidden="true">&times;</span>
                                                                                                        </button>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>

                                                                                            <div class="modal-body black p-0">
                                                                                                <div id="contentTest" class="col-12 overflow-auto white p-4 min-vh-80">
                                                                                                    <%#Eval("content") %>
                                                                                                </div>

                                                                                                <div class="container black w-100 row justify-content-center mx-0 py-5">

                                                                                                    <div class="row justify-content-center">
                                                                                                        <asp:Image runat="server" ID="profilePic" ImageUrl="~/Content/img/placeholder.jpg" CssClass="white img-fluid rounded-circle w-20" />
                                                                                                        <h3 class="col-12 text-center white-text font-weight-bold my-3">Services by
                                <asp:Label runat="server" ID="modal_username2"></asp:Label>
                                                                                                        </h3>
                                                                                                    </div>
                                                                                                    <div class="row col-12 justify-content-around">
                                                                                                        <asp:Repeater runat="server" ID="userServices" OnItemDataBound="userServices_ItemDataBound">
                                                                                                            <ItemTemplate>

                                                                                                                <div class="card-body border-purple white col-lg-3 col-sm-12 rounded mx-2">
                                                                                                                    <div class="row justify-content-around">

                                                                                                                        <div class="card">
                                                                                                                            <div class="view overlay">
                                                                                                                                <asp:HiddenField runat="server" ID="serviceId" Value='<%#Eval("Id") %>' />
                                                                                                                                <asp:Image runat="server" ID="poster" loading="lazy" ImageUrl="~/Content/img/placeholder.jpg" CssClass="card-img-top service-img w-100" />
                                                                                                                            </div>

                                                                                                                            <asp:LinkButton runat="server" class="btn-primary btn btn-sm ml-auto mr-4 material-tooltip-sm"
                                                                                                                                data-tooltip="tooltip" data-placement="top" title="View More Details"
                                                                                                                                CommandName="view" CommandArgument='<%#Eval("Id") %>'>
                                            <i class="fas fa-eye"></i>
                                                                                                                            </asp:LinkButton>

                                                                                                                            <div class="card-body">
                                                                                                                                <h4 class="card-title name" data-names="Service Title"><%#Eval("name") %></h4>

                                                                                                                                <hr>

                                                                                                                                <p class="card-text">
                                                                                                                                    <%#Eval("desc") %>
                                                                                                                                </p>
                                                                                                                            </div>

                                                                                                                            <div class="card-footer deep-purple accent-2 white-text text-center mt-4">
                                                                                                                                <h5 class="m-0">$<%#Eval("price") %>
                                                                                                                                </h5>
                                                                                                                            </div>
                                                                                                                        </div>
                                                                                                                    </div>
                                                                                                                </div>

                                                                                                            </ItemTemplate>
                                                                                                        </asp:Repeater>
                                                                                                    </div>
                                                                                                    <div runat="server" id="noService" visible="false" class="row col-12 justify-content-around">
                                                                                                        <h4 class="text-white my-5">This user has no services </h4>
                                                                                                    </div>
                                                                                                </div>


                                                                                            </div>

                                                                                            <div class="modal-footer blue-grey lighten-5">
                                                                                                <div class="row mx-auto justify-content-around col-12">

                                                                                                    <div id="commentSection" class="col-lg-8 col-sm-12 border p-4 white">
                                                                                                        <h4 class="text-center">Comments </h4>
                                                                                                        <hr class="hr-primary">
                                                                                                        <ul class="list-unstyled chat">

                                                                                                            <li class="row mb-4">

                                                                                                                <div class="col-1 pr-2">
                                                                                                                    <asp:Image runat="server" loading="lazy" ImageUrl="~/Content/img/placeholder.jpg"
                                                                                                                        CssClass="avatar white img-fluid rounded-circle accent-3 z-depth-1"
                                                                                                                        ID="modal_profilePic" />
                                                                                                                </div>

                                                                                                                <div class="col-11 pl-2">
                                                                                                                    <div class="chat-body rounded white p-3 z-depth-1">
                                                                                                                        <div class="header d-flex">
                                                                                                                            <div class="flex-fill text-left">
                                                                                                                                <asp:Label runat="server" CssClass="primary-font font-weight-bold"
                                                                                                                                    ID="formUsername"></asp:Label>
                                                                                                                            </div>
                                                                                                                        </div>

                                                                                                                        <hr class="w-100">


                                                                                                                        <asp:TextBox runat="server" CssClass="form-control" name="commentContent"
                                                                                                                            ID="tbComment" MaxLength="300"></asp:TextBox>


                                                                                                                    </div>
                                                                                                                    <div class="row justify-content-end mx-auto">
                                                                                                                        <asp:LinkButton runat="server" CommandName="comment" class="btn btn-secondary" CommandArgument='<%#Eval("Id") %>'>
                                                    Submit
                                                    Comment
                                                                                                                        </asp:LinkButton>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                            </li>

                                                                                                        </ul>

                                                                                                        <hr class="hr-primary">
                                                                                                        <div class="chat-message flex-fill">
                                                                                                            <ul class="list-unstyled chat" id="hrAfter<%#Eval("Id") %>">
                                                                                                                <asp:Repeater runat="server" ID="comments" OnItemDataBound="comments_ItemDataBound">
                                                                                                                    <ItemTemplate>
                                                                                                                        <li class="row mb-4">

                                                                                                                            <div class="col-1 pr-2">
                                                                                                                                <asp:HiddenField runat="server" ID="idField" Value='<%#Eval("uid") %>' />
                                                                                                                                <asp:Image runat="server" loading="lazy" ID="profpic" ImageUrl="~/Content/img/placeholder.jpg"
                                                                                                                                    CssClass="avatar white img-fluid rounded-circle accent-3 z-depth-1" />
                                                                                                                            </div>

                                                                                                                            <div class="col-11 pl-2">
                                                                                                                                <div class="chat-body rounded white p-3 z-depth-1">
                                                                                                                                    <div class="header d-flex">
                                                                                                                                        <div class="flex-fill text-left">
                                                                                                                                            <asp:LinkButton runat="server" CommandName="viewProfile" CommandArgument='<%#Eval("uid") %>'>
                                                                    <strong class="primary-font"><%#Eval("username") %></strong>
                                                                                                                                            </asp:LinkButton>
                                                                                                                                        </div>
                                                                                                                                        <div class="flex-fill text-right">
                                                                                                                                            <small class="pull-right text-muted">
                                                                                                                                                <i class="far fa-clock mr-1"></i><%#Eval("date") %>
                                                                                                                                            </small>
                                                                                                                                        </div>
                                                                                                                                    </div>

                                                                                                                                    <hr class="w-100">

                                                                                                                                    <p class="text-left mb-0">
                                                                                                                                        <%#Eval("content") %>
                                                                                                                                    </p>
                                                                                                                                </div>
                                                                                                                            </div>
                                                                                                                        </li>

                                                                                                                    </ItemTemplate>
                                                                                                                </asp:Repeater>
                                                                                                            </ul>
                                                                                                        </div>
                                                                                                        <div runat="server" visible="false" id="noComments">
                                                                                                            <h5 class="text-center mb-3 text-muted">
                                                                                                                <i class="fas fa-comment-times fa-3x"></i>
                                                                                                            </h5>
                                                                                                            <h5 class="text-center text-muted">No Comments
                                                                                                            </h5>
                                                                                                        </div>

                                                                                                    </div>

                                                                                                    <div class="col-lg-3 col-sm-12 p-0">
                                                                                                        <div class="border p-4 white">
                                                                                                            <h4 class="text-center">Details </h4>
                                                                                                            <hr class="hr-primary w-100">

                                                                                                            <div class="row justify-content-between">
                                                                                                                <div class="col-6">
                                                                                                                    <p class="text-right font-weight-bold">Posted:</p>
                                                                                                                    <p class="text-right font-weight-bold">Likes: </p>
                                                                                                                    <p class="text-right font-weight-bold">Comments: </p>
                                                                                                                </div>
                                                                                                                <div class="col-6">
                                                                                                                    <p class="text-left"><%#Eval("datePosted") %></p>
                                                                                                                    <p class="text-left">
                                                                                                                        <%#Eval("likes") %>
                                                                                                                    </p>
                                                                                                                    <p class="text-left">
                                                                                                                        <%#Eval("comments") %>
                                                                                                                    </p>
                                                                                                                </div>
                                                                                                            </div>

                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>

                                                                                        </div>
                                                                                    </div>

                                                                                </div>
                                                                                <div class="modal fade" id="confirmDelete<%#Eval("Id") %>" tabindex="-1" role="dialog"
                                                                                    aria-labelledby="confirmDelete<%#Eval("Id") %>Label" aria-hidden="true" data-backdrop="false">
                                                                                    <div class="modal-dialog modal-sm modal-dialog-centered" role="document">
                                                                                        <div class="modal-content">

                                                                                            <div class="modal-header">
                                                                                                <h5 class="modal-title text-center col-12">Confirmation</h5>
                                                                                            </div>
                                                                                            <div class="modal-body">
                                                                                                <p class="my-3 text-center">
                                                                                                    Are you sure you want to delete
                                                                                                    <br>
                                                                                                    <%#Eval("title") %>?
                                                                                                </p>
                                                                                            </div>
                                                                                            <div class="modal-footer py-1">
                                                                                                <div class="row justify-content-between mx-auto w-100">
                                                                                                    <asp:LinkButton CssClass="btn btn-danger" runat="server" CommandName="delete" CommandArgument='<%#Eval("Id") %>'>
                                                                                                        Yes
                                                                                                    </asp:LinkButton>
                                                                                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>

                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </section>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>

                                                        <div runat="server" visible="false" id="noProj" class="row justify-content-center">
                                                            <h1 class="my-5 py-5">Currently no Projects</h1>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
                                                                <asp:HiddenField runat="server" ID="serviceId" Value='<%#Eval("Id") %>' />
                                                                <asp:Image runat="server" ID="poster" CssClass="card-img-top" ImageUrl="~/Content/img/placeholder.jpg" />
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
                                                                        <asp:Image runat="server" ID="providerPic" ImageUrl="~/Content/img/placeholder.jpg" CssClass="rounded-circle img-fluid z-depth-1 avatar" Style="max-width: 2rem;" />
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
                                                                <asp:HiddenField runat="server" ID="serviceId" Value='<%#Eval("Id") %>' />
                                                                <asp:Image runat="server" ID="poster" CssClass="card-img-top" ImageUrl="~/Content/img/placeholder.jpg" />
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
                                                                        <asp:Image runat="server" ID="providerPic" ImageUrl="~/Content/img/placeholder.jpg" CssClass="rounded-circle img-fluid z-depth-1 avatar" Style="max-width: 2rem;" />
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
        <!-- =============================== Followers Modal =============================== -->
        <div class="modal fade" id="followersModal" tabindex="-1" role="dialog" aria-labelledby="modelTitleId"
            aria-hidden="true" data-backdrop="false">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 runat="server" class="modal-title" id="followerTitle"></h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body vh-30 overflow-auto">
                        <p runat="server" visible="false" class="text-center" id="noFollower">You have no followers ;-;</p>
                        <asp:Repeater runat="server" ID="followerRepeater" OnItemCommand="followerRepeater_ItemCommand" OnItemDataBound="bindImage">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>'>
                                    <div class="row justify-content-start">
                                        <div class="col-2">
                                            <asp:HiddenField runat="server" ID="followId" Value='<%#Eval("Id") %>' />
                                            <asp:Image runat="server" ID="profilePic" ImageUrl="~/Content/img/placeholder.jpg" CssClass="rounded-circle border w-100" />
                                        </div>
                                        <div class="col-5">
                                            <%#Eval("username") %>

                                            <br>
                                            <p>
                                                <%#Eval("type") %>
                                            </p>
                                        </div>

                                    </div>
                                </asp:LinkButton>
                                <hr class="hr-primary p-0 mt-0">
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- =============================== Following Modal =============================== -->
        <div class="modal fade" id="followingModal" tabindex="-1" role="dialog" aria-labelledby="modelTitleId"
            aria-hidden="true" data-backdrop="false">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 runat="server" class="modal-title" id="followingTitle"></h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body vh-30 overflow-auto">
                        <p runat="server" visible="false" class="text-center" id="noFollowing">Wow very empty. Much following.</p>
                        <asp:Repeater runat="server" ID="followingRepeater" OnItemCommand="followerRepeater_ItemCommand" OnItemDataBound="bindImage">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" CommandArgument='<%#Eval("Id") %>'>
                                    <div class="row justify-content-start">
                                        <div class="col-2">
                                            <asp:HiddenField runat="server" ID="followId" Value='<%#Eval("Id") %>' />
                                            <asp:Image runat="server" ID="profilePic" ImageUrl="~/Content/img/placeholder.jpg" CssClass="rounded-circle border w-100" />
                                        </div>
                                        <div class="col-5">

                                            <b><%#Eval("username") %></b>

                                            <br>
                                            <p>
                                                <%#Eval("type") %>
                                            </p>
                                        </div>

                                    </div>
                                </asp:LinkButton>
                                <hr class="hr-primary p-0 mt-0">
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
