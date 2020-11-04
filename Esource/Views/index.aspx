<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Esource.Views.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                <i class="fas fa-eye"></i> View Marketplace
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
                                <i class="fas fa-user-plus"></i> Register
                            </a>
                        </div>
                    </div>
                </div>
            </div>            
        </div>
    </section>
</asp:Content>
