<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Esource.Views.auth.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="login mt-4">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card z-depth-3">
                    <h3 class="text-center mt-2">Login</h3>
                    <div class="card-body text-center">
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
                        <asp:LinkButton ID="btnLogin" CssClass="btn btn-md btn-outline-primary" runat="server" OnClick="btnLogin_Click">
                            <i class="fas fa-sign-in-alt mr-2"></i>Login
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
