<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Esource.Views.auth.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="login mt-4">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card z-depth-3">
                    <h3 class="text-center">Login</h3>
                    <div class="card-body text-center">
                        <div class="md-form md-outline">
                            <input id="email" type="email" name="email" class="form-control" required>
                            <label for="email">Email</label>
                        </div>
                        <div class="md-form md-outline">
                            <input id="password" type="password" name="password" class="form-control" required>
                            <label for="password">Password</label>
                        </div>

                        <button class="btn btn-md btn-outline-primary btn-rounded" type="submit">
                            <i class="fas fa-sign-in-alt mr-2"></i>Login
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
