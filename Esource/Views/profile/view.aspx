<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="Esource.Views.profile.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="profile">
        <asp:ScriptManager runat="server" ID="servscript">
        </asp:ScriptManager>
        <!-- Card -->
        <div class="card testimonial-card z-depth-2 rounded-0">
        <!-- Background color -->
        <div class="vh-40 card-up indigo lighten-1 rounded-0 jarallax">
            <img loading="lazy" class="img-fluid jarallax-img " onerror='this.src="/img/profile/banner.png"'
                src="/uploads/profile/{{viewuser.id}}/banner.png" alt="">
        </div>


        <!-- =============================== Content =============================== -->
        <div style="" class="card-body p-0 rounded-0">

            <div class="row justify-content-around">
                <div class="col-lg-3 col-sm-12">
                    <div class="profile-margin">
                        <!-- Card -->
                        <div class="card testimonial-card ">

                            <!-- Background color -->
                            <div style="height:auto;" class="card-up indigo lighten-1 rounded-0">
                            </div>

                            <div class="avatar mx-auto white mt-4">

                                <img loading="lazy" onerror='this.src = "/img/profile/default.png"'
                                    src="/uploads/profile/{{viewuser.id}}/profilePic.png"
                                    class="rounded-circle  border" alt="">
                            </div>

                            <!-- Content -->
                            <div class="card-body">
                                <!-- Name -->
                                <h3 runat="server" id="viewUsername" class="card-title"></h3>

                                <h5 runat="server" id="viewUsertype" class="card-title text-muted">
                                    Service Provider
                                </h5>

                                <div class="">
                                    <asp:LinkButton runat="server" visible="false" id="unfollowButton" OnClick="unfollowButton_Click"
                                        class="btn btn-secondary active">
                                        Followed </asp:LinkButton>
                                    <asp:LinkButton runat="server" id="followButton" OnClick="followButton_Click"
                                        class="btn btn-secondary">
                                        Follow </asp:LinkButton>
                                </div>

                                <br>
                                <p class="text-left"> <a href="#" class="font-weight-bold" data-toggle="modal"
                                        data-target="#followersModal">Followers:</a> 0 </p>
                                <p class="text-left"> <a href="#" class="font-weight-bold" data-toggle="modal"
                                        data-target="#followingModal">Following:</a> 0</p>
                                <hr class="hr-primary">


                                <p class="text-left"><b>Website:</b>
                                    <span runat="server" id="website" class="text-muted"></span>
                                </p>
                                <p class="text-left"><b>Birthday:</b>
                                    <span runat="server" id="dob" class="text-muted"></span>
                                </p>
                                <p class="text-left"><b>Gender:</b>
                                    <span runat="server" id="gender" class="text-muted"></span>
                                </p>
                                <p class="text-left"><b>Location:</b>
                                    <span runat="server" id="location" class="text-muted"></span>
                                </p>
                                <p class="text-left"><b>Occupation:</b>
                                    <span runat="server" id="occupation" class="text-muted"></span>
                                </p>
                                <p class="text-left"><b>Email:</b> <span runat="server" id="email"></span></p>
                                <hr class="hr-primary">
                            </div>
                        </div>
                    </div>

                    <div class="mt-3">
                        <!-- Card -->
                        <div class="card testimonial-card ">


                            <!-- Content -->
                            <div class="card-body">
                                <!-- Name -->
                                <h4 class="card-title text-left">Bio</h4>
                                <p runat="server" id="bio" class="text-left text-muted">
                                    Not set
                                </p>
                                <hr class="hr-primary">
                                <h4 class="card-title text-left">Skills</h4>
                                <p class="text-left text-muted">
                                    Not set
                                </p>
                                <div class="row justify-content-start pl-2">
                                    <button type="button"
                                        class="btn btn-outline-secondary btn-rounded waves-effect skill-button">Edit</button>
                                </div>

                                <hr class="hr-primary">


                            </div>
                        </div>
                    </div>

                    <br>
                    <br>
                </div>

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
                                aria-selected="false"> Services </a>
                        </li>


                        <li class="nav-item">
                            <a class="nav-link waves-light" id="status-tab-classic-shadow" data-toggle="tab"
                                href="#status-classic-shadow" role="tab" aria-controls="status-classic-shadow"
                                aria-selected="false"> Status </a>
                        </li> 

                        <li class="nav-item">
                            <a class="nav-link waves-light" id="favorites-tab-classic-shadow" data-toggle="tab"
                                href="#favs-classic-shadow" role="tab" aria-controls="favs-classic-shadow"
                                aria-selected="false"> Favourites </a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link waves-light" id="likes-tab-classic-shadow" data-toggle="tab"
                                href="#likes-classic-shadow" role="tab" aria-controls="likes-classic-shadow"
                                aria-selected="false"> Likes </a>
                        </li>

                    </ul>

                    <div class="tab-content min-vh-80 p-0" id="myClassicTabContentShadow">
                        <div class="tab-pane fade active show profile-content" id="portfolio-classic-shadow"
                            role="tabpanel" aria-labelledby="portfolio-tab-classic-shadow">
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
                        <div class="tab-pane fade profile-content" id="favs-classic-shadow" role="tabpanel"
                            aria-labelledby="favs-tab-classic-shadow">
                        </div>
                        <div class="tab-pane fade profile-content" id="likes-classic-shadow" role="tabpanel"
                            aria-labelledby="likes-tab-classic-shadow">
                        </div>
                    </div>

                </div>

            </div>

        </div>

</section>
</asp:Content>
