<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Esource.Views.auth.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="register container mt-4">
        <ul class="nav nav-tabs md-tabs primary-gradient z-depth-3 mx-auto" role="tablist">
            <li class="nav-item nav-item flex-fill text-center">
                <a class="nav-link active" data-toggle="tab" href="#cTab" role="tab">Client Account
                </a>
            </li>
            <li class="nav-item nav-item flex-fill text-center">
                <a class="nav-link" data-toggle="tab" href="#spTab" role="tab">Service Provider Account
                </a>
            </li>
        </ul>

        <div class="tab-content card z-depth-3 px-0 pb-0">
            <div class="tab-pane fade show active" id="cTab" role="tabpanel">
                <div class="card-body px-5">
                    <h5 class="card-title text-center mb-4">Join As Client</h5>
                    <div class="md-form md-outline input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text primary-light-gradient white-text">
                                <i class="far fa-user"></i>
                            </span>
                        </div>
                        <input type="text" id="name" class="form-control" runat="server" placeholder="Username" required />
                    </div>

                    <div class="input-group mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text primary-light-gradient white-text">
                                <i class="far fa-envelope"></i>
                            </span>
                        </div>
                        <input type="email" id="email" class="form-control" runat="server" placeholder="Email" required />
                    </div>

                    <div class="input-group mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text primary-light-gradient white-text">
                                <i class="fas fa-lock"></i>
                            </span>
                        </div>
                        <input type="password" id="password" class="form-control" runat="server" placeholder="Password" required />
                    </div>

                    <div class="input-group mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text primary-light-gradient white-text">
                                <i class="fas fa-lock"></i>
                            </span>
                        </div>
                        <input type="password" id="confirm_password" class="form-control" runat="server" placeholder="Confirm Password" required />
                    </div>

                    <asp:Label runat="server" Visible="false" ID="clientType" Text="client"></asp:Label>

                    <asp:LinkButton runat="server" ID="btnClientRegister" CssClass="btn btn-md btn-outline-primary btn-block" OnClick="btnRegister_Click">
                        <i class="fas fa-user-plus mr-2"></i>Join
                    </asp:LinkButton>
                </div>

                <div class="card-footer">
                    <p class="text-center small m-0">
                        Already a member? <a href="<%=Page.ResolveUrl("~/Views/auth/login.aspx") %>">Sign In</a>
                    </p>
                </div>
            </div>

            <div class="tab-pane fade" id="spTab" role="tabpanel">
                <div class="card-body px-5">
                    <h5 class="card-title text-center mb-4">Join As Service Provider</h5>
                    <div class="md-form md-outline input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text primary-light-gradient white-text">
                                <i class="far fa-user"></i>
                            </span>
                        </div>
                        <input type="text" id="svc_name" class="form-control" runat="server" placeholder="Username" required />
                    </div>

                    <div class="input-group mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text primary-light-gradient white-text">
                                <i class="far fa-envelope"></i>
                            </span>
                        </div>
                        <input type="email" id="svc_email" class="form-control" runat="server" placeholder="Email" required />
                    </div>

                    <div class="input-group mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text primary-light-gradient white-text">
                                <i class="fas fa-lock"></i>
                            </span>
                        </div>
                        <input type="password" id="svc_password" class="form-control" runat="server" placeholder="Password" required />
                    </div>

                    <div class="input-group mb-4">
                        <div class="input-group-prepend">
                            <span class="input-group-text primary-light-gradient white-text">
                                <i class="fas fa-lock"></i>
                            </span>
                        </div>
                        <input type="password" id="svc_confirm_password" class="form-control" runat="server" placeholder="Confirm Password" required />
                    </div>

                    <asp:Label runat="server" Visible="false" ID="serviceType" Text="service"></asp:Label>

                    <asp:LinkButton runat="server" ID="btnServiceRegister" CssClass="btn btn-md btn-outline-primary btn-block" OnClick="btnRegister_Click">
                        <i class="fas fa-user-plus mr-2"></i>Join
                    </asp:LinkButton>

                </div>

                <div class="card-footer">
                    <p class="text-center small m-0">
                        Already a member? <a href="<%=Page.ResolveUrl("~/Views/auth/login.aspx") %>">Sign In</a>
                    </p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
