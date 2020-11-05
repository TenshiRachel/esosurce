<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Esource.Views.profile.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="profile">

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
                            <a href="/profile/edit" class="m-2 ml-auto text-secondary">
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
                                <h3 class="card-title">Cozen</h3>

                                <h5 class="card-title text-muted">
                                    Service Provider
                                </h5>

                                <br>
                                <p class="text-left">
                                    <a href="#" class="font-weight-bold" data-toggle="modal"
                                        data-target="#followersModal">Followers:
                                    </a>
                                    0
                                </p>

                                <p class="text-left">
                                    <a href="#" class="font-weight-bold" data-toggle="modal"
                                        data-target="#followingModal">Following:
                                    </a>
                                    0
                                </p>
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

                                <p class="text-left"><b>Email:</b> joshdebean@gmail.com</p>

                                <hr class="hr-primary">


                            </div>
                        </div>
                    </div>

                    <div class="card testimonial-card my-3">
                        <div class="card-body">
                            <h4 class="card-title text-left">Bio</h4>
                            <p class="text-left text-muted">
                                    Not set
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
                                aria-selected="false"> Services </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link waves-light" id="status-tab-classic-shadow" data-toggle="tab"
                                href="#status-classic-shadow" role="tab" aria-controls="status-classic-shadow"
                                aria-selected="false"> Status </a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link waves-light" id="favs-tab-classic-shadow" data-toggle="tab"
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
                        <div class="tab-pane fade profile-content" id="status-classic-shadow" role="tabpanel"
                            aria-labelledby="status-tab-classic-shadow">
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
