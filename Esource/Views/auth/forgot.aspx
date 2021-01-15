<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/index.Master" AutoEventWireup="true" CodeBehind="forgot.aspx.cs" Inherits="Esource.Views.auth.forgot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="forgot-password">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card z-depth-3">
                    <div class="card-body text-center">
                        <h3 class="text-center">Forgot Password</h3>

                        <div class="md-form md-outline">
                            <input id="email" type="email" name="email" class="form-control" runat="server">
                            <label for="email">Email</label>
                        </div>

                        <asp:LinkButton ID="btnForgot" class="btn btn-md btn-outline-primary btn-rounded" type="submit" runat="server" OnClick="btnForgot_Click">
                            <i class="fas fa-unlock-alt mr-2"></i>Reset Password
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
