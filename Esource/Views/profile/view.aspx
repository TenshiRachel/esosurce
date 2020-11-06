<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="Esource.Views.profile.view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="profile">

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
                                <h3 class="card-title">Username</h3>

                                <h5 class="card-title text-muted">
                                    Client
                                </h5>

                                <div class="">
                                    <p onclick="followUser({{viewuser.id}})" id="followButton"
                                        class="btn btn-secondary btn-rounded">
                                        Follow </p>
                                </div>

                                <br>
                                <p class="text-left"> <a href="#" class="font-weight-bold" data-toggle="modal"
                                        data-target="#followersModal">Followers:</a> 0 </p>
                                <p class="text-left"> <a href="#" class="font-weight-bold" data-toggle="modal"
                                        data-target="#followingModal">Following:</a> 0</p>
                                <hr class="hr-primary">


                                <p class="text-left"><b>Website:</b>
                                    <span class="text-muted">None</span>
                                </p>
                                <p class="text-left"><b>Birthday:</b>
                                    <span class="text-muted">Not Set</span>
                                </p>
                                <p class="text-left"><b>Gender:</b>
                                    <span class="text-muted">Not Set</span>
                                </p>
                                <p class="text-left"><b>Location:</b>
                                    <span class="text-muted">Not Set</span>
                                </p>
                                <p class="text-left"><b>Occupation:</b>
                                    <span class="text-muted">Not Set</span>
                                </p>
                                <p class="text-left"><b>Email:</b> Email</p>
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
                                <p class="text-left text-muted">
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
